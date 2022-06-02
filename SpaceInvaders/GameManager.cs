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

        public List<Sprite> Sprites { get; private set; } = new List<Sprite>();

        //public void Shooting(Spaceship spaceship)
        //{
        //    float VelX = (float)(2f * Math.Sin(Math.PI * spaceship.RotationAngle / 180));
        //    float VelY = (float)(-2f * Math.Cos(Math.PI * spaceship.RotationAngle / 180));
        //    Shots shot = new Shots(spaceship.PosX + spaceship.SizeX / 2, spaceship.PosY + spaceship.SizeY / 2, VelX * 15, VelY * 15, 7, 7);
        //    Sprites.Add(shot);
        //}
    }
}
