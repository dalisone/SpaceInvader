using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class GameManager
    {

        private static GameManager crr = new GameManager();
        public static GameManager Current => crr;

        int x = 0;

        Timer tmShot = new Timer();
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

            navinha.HitBox.Draw(g);


            if (x == 0)
            {
                coll.Right();
                coll.Move();


                foreach (var inimiguin in coll)
                {
                    if (inimiguin.PosX == Width - coll[0].SizeX - 2)
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
                    if (inimiguin.PosX == 40)
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
            Bullet shot = new Bullet(navinha.PosX + navinha.SizeX/2, navinha.PosY+navinha.SizeY/2, 0, VelY, 7, 7);
            Sprites.Add(shot);
        }

        public void EnemyShot(EnemyCollection enemy, int pos)
        {
            float VelYEnemy = 10;
            Bullet shot2 = new Bullet(enemy[pos].PosX + enemy[pos].SizeX/2, enemy[pos].PosY + enemy[pos].SizeY / 2, 0, VelYEnemy, 7, 7);
            Sprites.Add(shot2);
        }

        public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

    }
}
