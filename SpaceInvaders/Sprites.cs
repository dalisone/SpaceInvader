using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Sprite
    {
        private float posX;
        private float posY;
        private float velX;
        private float velY;
        private int sizeX;
        private int sizeY;
        private Image[] image;
        int posImageAtual;

        public Sprite()
        {

        }

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }
        public float VelX { get => velX; set => velX = value; }
        public float VelY { get => velY; set => velY = value; }
        public Image[] Image { get => image; set => image = value; }
        public int PosImageAtual { get => posImageAtual; set => posImageAtual = value; }

        public void Move()
        {
            posX += velX;
            posY += velY;
        }

        public void Draw(PictureBox Jogo, Graphics g)
        {
            g.DrawImage(image[posImageAtual], this.PosX, this.PosY, this.SizeX, this.SizeY);
        }

        public void Colisao(PictureBox Jogo)
        {
            if(posX <= 0)
            {
                posX = 0;
            }
            if(posY <= 0)
            {
                posY = 0;
            }
            if(posX+sizeX >= Jogo.Width)
            {
                posX = Jogo.Width - sizeX;
            }
        }
    }
}
