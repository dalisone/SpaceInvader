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

        public Inimigo(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.VelX = VelX;
            this.VelY = VelY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.Image = new Image[] { Properties.Resources.inimigo_1 };
        }

        public Inimigo(List<Inimigo> inimigos)
        {
            this.inimigos = inimigos;
        }

        public void SetInimigos(List<Inimigo> inimigos)
        {
            this.inimigos = inimigos;
        }
    }
}
