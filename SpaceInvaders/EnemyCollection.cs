using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class EnemyCollection : List<Enemy>
    {
        public void Add(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY, params Image[] Image)
        {
            this.Add(new Enemy(PosX, PosY, VelX, VelY, SizeX, SizeY, Image));
        }

        public void setSizeX(int size)
        {
            foreach (var enemy in this)
                enemy.setSizeX(size);
        }

        public void setSizeY(int size)
        {
            foreach (var enemy in this)
                enemy.setSizeY(size);
        }

        public void Colisao(PictureBox pb)
        {
            foreach (var enemy in this)
                enemy.Colisao(pb);
        }

        public void Draw(PictureBox pb, Graphics g)
        {
            foreach (var enemy in this)
                enemy.Draw(pb, g);
        }

        public void Right()
        {
            foreach (var enemy in this)
                enemy.VelX = 5;
        }

        public void Left()
        {
            foreach (var enemy in this)
                enemy.VelX = -5;
        }

        public void Move()
        {
            foreach (var enemy in this)
            {
                enemy.PosX += enemy.VelX;
                enemy.PosY += enemy.VelY;
            }
        }

        public static EnemyCollection LoadClassic(int width, int height, int qtdCol, int qtdLine)
        {
            EnemyCollection coll = new EnemyCollection();

            int sizeHor = width / 12;
            int sizeVert = height / 7;

            var img = Properties.Resources.inimigo_1;

            int incrementHor =0;
            int incrementVert = 0;

            int posHor = 40;
            int posVer = 0;

            for(int i = 0; i < qtdLine; i++)
            {
                incrementHor = 0;

                if(i == 1)
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
                incrementVert += 80;
            }

            return coll;
        }
    }
}
