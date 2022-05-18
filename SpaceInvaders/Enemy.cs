using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Enemy : Sprite
    {
        public Enemy(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY, params Image[] Image)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.VelX = VelX;
            this.VelY = VelY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.Image = Image;
        }

        public void setSizeX(int sizeX)
        {
            this.SizeX = sizeX;
        }

        public void setSizeY(int sizeY)
        {
            this.SizeY = sizeY;
        }

        public void SetImage(Image[] imagem)
        {
            this.Image = imagem;
        }

        public void Right()
        {
            VelX = 5;
        }

        public void Left()
        {
            VelX = -5;
        }
    }
}
