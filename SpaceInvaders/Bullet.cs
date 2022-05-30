using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Bullet : Sprite
    {
        public Bullet(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.VelX = VelX;
            this.VelY = VelY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.Image = new Image[] { Properties.Resources.tiro };
        }

        public void Shot()
        {
            VelY = -5;
        }
    }
}
