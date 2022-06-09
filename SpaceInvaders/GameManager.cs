using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace SpaceInvaders
{
    public class GameManager
    {

        private static GameManager crr = new GameManager();
        public static GameManager Current => crr;

        SoundPlayer enemyShot = new SoundPlayer(Properties.Resources.tiro_bicho);

        SoundPlayer naveShot = new SoundPlayer(Properties.Resources.tiro1);



        int x = 0;
        private GameManager()
        {


        }

        public static void Reestart()
        {
            crr = new GameManager();
        }

        public void Frames(PictureBox pbNave, Graphics g, int Width, int Height, Nave navinha, EnemyCollection coll)
        {


            navinha.Colisao(pbNave);
            coll.Colisao(pbNave);


            navinha.Draw(pbNave, g);
            coll.Draw(pbNave, g);

            foreach (Sprite sprite in Sprites)
            {
                sprite.Move();
            }

            g.Clear(Color.Black);

            navinha.Draw(pbNave, g);
            coll.Draw(pbNave, g);
            foreach (Sprite sprite in Sprites)
            {
                sprite.Draw(pbNave, g);
            }

            navinha.Move();
            //navinha.HitBox.Draw(g);
            DrawLives(g, navinha.Lives, (int)(Height * 0.03), (int)(Width * 0.02));

            for (int i = 0; i < Sprites.Count; i++) 
            { 
                if(Sprites[i] is Bullet bullet && bullet.ShotHit)
                {
                    Sprites.Remove(Sprites[i]);
                    i--;
                }
            }

            for (int i = 0; i < Sprites.Count; i++)
            {
                if (Sprites[i] is BulletEnemy bulletEnemy && bulletEnemy.EnemyShotHit)
                {
                    Sprites.Remove(Sprites[i]);
                    i--;
                }
            }

            for (int i = 0; i < coll.Count; i++)
            {
                if (coll[i].Hit)
                {
                    coll.Remove(coll[i]);
                    i--;
                }
            }

            for (int i = 0; i < coll.Count; i++)
            {
                for(int j = 0; j < Sprites.Count; j++)
                {
                    coll[i].CheckCollision(Sprites[j]);
                }
            }

            for (int i = 0; i < Sprites.Count; i++)
            {
                for (int j = 0; j < coll.Count; j++)
                {
                    Sprites[i].CheckCollision(coll[j]);
                }
            }

            for (int i = 0; i < Sprites.Count; i++)
            {
                for (int j = 0; j < coll.Count; j++)
                {
                    if (Sprites[i] is BulletEnemy)
                    {
                        Sprites[i].CheckCollision(navinha);
                    }
                    navinha.CheckCollision(coll[j]);
                }
            }

            for (int i = 0; i < Sprites.Count; i++)
            {
               navinha.CheckCollision(Sprites[i]);
            }

            if (x == 0)
            {
                coll.Right();
                coll.Move();


                foreach (var inimiguin in coll)
                {
                    if (inimiguin.PosX == Width - inimiguin.SizeX || inimiguin.PosX == Width - inimiguin.SizeX - 1 || inimiguin.PosX == Width - inimiguin.SizeX - 2 || inimiguin.PosX == Width - inimiguin.SizeX - 3 || inimiguin.PosX == Width - inimiguin.SizeX - 4 || inimiguin.PosX == Width - inimiguin.SizeX - 5)
                    {
                        x = 1;
                        break;
                    }
                }
            }

            if (x == 1)
            {
                coll.Left();
                coll.Move();

                foreach (var inimiguin in coll)
                {
                    if (inimiguin.PosX == 40 || inimiguin.PosX == 35 || inimiguin.PosX == 36 || inimiguin.PosX == 37 || inimiguin.PosX == 38 || inimiguin.PosX == 39 || inimiguin.PosX == 41 || inimiguin.PosX == 42 || inimiguin.PosX == 43 || inimiguin.PosX == 44 || inimiguin.PosX == 45)
                    {
                        x = 0;
                        break;
                    }
                }
                if (x == 0)
                {
                    foreach (var inimiguin in coll)
                    {
                        inimiguin.PosY += Height / 25;
                    }
                }
            }

            if (navinha.Lives == 0)
            {
                navinha.Death();
            }

            if (navinha.Lives == 0)
            {
                g.DrawImage(Properties.Resources.jeff, Width-Width, Height-Height, Width, Height);
                MessageBox.Show("HACKEDDD!%#@$TR@#@LEDSAMD");
                Application.Exit();
            }

            if(coll.Count == 0)
            {   
                Application.Exit();
            }

            pbNave.Refresh();
        }

        

        public EnemyCollection LoadClassic(int width, int height, int qtdCol, int qtdLine)
        {
            EnemyCollection coll = new EnemyCollection();

            int sizeHor = width / 12;
            int sizeVert = height / 7;

            var img = Properties.Resources.inimigo_1;

            int incrementVert = 0;

            int posHor = 40;
            int posVer = 0;

            for (int i = 0; i < qtdLine; i++)
            {
                int incrementHor = 0;

                if (i == 1)
                {
                    img = Properties.Resources.inimigo_2;
                }
                if (i == 2)
                {
                    img = Properties.Resources.inimigo_3;
                }

                if (i == 3)
                {
                    img = Properties.Resources.inimigo_4;
                }

                for (int j = 0; j < qtdCol; j++)
                {
                    coll.Add(posHor + incrementHor, posVer + incrementVert, 0, 0, sizeHor, sizeVert, img);
                    incrementHor += width / 18;
                }
                incrementVert += height / 15;
            }

            return coll;
        }

        public void Shooting(Nave navinha)
        {
             float VelY = -10;
             Bullet shot = new Bullet(navinha.PosX + navinha.SizeX / 2, navinha.PosY + navinha.SizeY / 2, 0, VelY, 7, 7);
             Sprites.Add(shot);
             naveShot.Play();
        }

        public void EnemyShot(EnemyCollection enemy, int pos)
        {
            float VelYEnemy = 10;
            BulletEnemy shot2 = new BulletEnemy(enemy[pos].PosX + enemy[pos].SizeX / 2, enemy[pos].PosY + enemy[pos].SizeY / 2, 0, VelYEnemy, 7, 7);
            Sprites.Add(shot2);
            enemyShot.Play();
        }


        private void DrawLives(Graphics g, int lives, int height, int width)
        {
            for (int i = 0; i < lives; i++)
            {
                g.FillEllipse(Brushes.LightGreen, width, height, 15, 15);
                width += 30;
            }
        }


        public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

    }
}
