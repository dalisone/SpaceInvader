using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Inimigo : Sprite
    {

        List<Inimigo> inimigos = new List<Inimigo>();

        public Inimigo(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY, Image[] Image)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.VelX = VelX;
            this.VelY = VelY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.Image = Image;
        }

        public Inimigo(List<Inimigo> inimigos)
        {
            this.inimigos = inimigos;
        }

        public void SetInimigos(List<Inimigo> inimigos)
        {
            this.inimigos = inimigos;
        }

        public void setSizeX(int sizeX)
        {
            this.SizeX = sizeX;
        }

        public void setSizeY(int sizeY)
        {
            this.SizeY = sizeY;
        }

        public void CreateEnemies()
        {

            float posx = 0;
            float posy = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Inimigo inimigue = new Inimigo(posx, posy, 0, 0, 150, 150, new Image[] { Properties.Resources.inimigo_1 });
                    inimigos.Add(inimigue);
                    posx += 80;
                }

                posx = 0;
                posy += 40;
            }
        }

        public void SetImage(Image[] imagem)
        {
            this.Image = imagem;
        }
    }
}
