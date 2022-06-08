using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public class Nave : Sprite
    {

        int vidas = 3;
        public Nave(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.VelX = VelX;
            this.VelY = VelY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.Image = new Image[] {Properties.Resources.nave };
            this.HitBox = HitBox.FromSprite(this);
        }
        
        
        public void setSizeX(int sizeX)
        {
            this.SizeX = sizeX;
        }

        public void setSizeY(int sizeY)
        {
            this.SizeY = sizeY;
        }

        public void Left()
        {
            VelX = -15;
        }

        public void Right()
        {
            VelX = 15;
        }

        public override void CheckCollision(Sprite entity)
        {
            float dx = entity.PosX - this.PosX;
            float dy = entity.PosY - this.PosY;
            if (dx * dx + dy * dy > 100 * 100)
                return;
            var info = HitBox.IsColliding(entity.HitBox);
            if (info.IsColliding)
            {
                if (entity is Enemy)
                {
                    info.Type = EntityType.Inimigo;
                }
                else if (entity is BulletEnemy)
                {
                    info.Type = EntityType.Shot;
                }
                OnCollision(info, entity);
            }
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            if (info.Type == EntityType.Shot || info.Type == EntityType.Inimigo)
            {
                this.LoseLife();
            }
        }

        public void LoseLife()
        {
            if (vidas == 0)
            {
                Application.Exit();
            }

            vidas--;
            return;
        }

    }
}
