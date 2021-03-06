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

        public bool ShotHit { get; set; } = false;
        public Bullet(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.VelX = VelX;
            this.VelY = VelY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.HitBox = HitBox.FromSprite(this);
        }

        public override void Draw(PictureBox Jogo, Graphics g)
        {
            g.FillEllipse(Brushes.White, this.PosX, this.PosY, 10, 10);
        }

        public override void CheckCollision(Sprite entity)
        {
            float dx = entity.PosX - this.PosX;
            float dy = entity.PosY - this.PosY;
            if (dx * dx + dy * dy > 100 * 100)
                return;
            var info = entity.HitBox.IsColliding(HitBox);
            if (info.IsColliding)
            {
                ShotHit = true;
            }
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            
        }
    }
}
