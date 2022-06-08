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

        public bool Hit { get; set; } = false;

        public Enemy(float PosX, float PosY, float VelX, float VelY, int SizeX, int SizeY, params Image[] Image)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.VelX = VelX;
            this.VelY = VelY;
            this.SizeX = SizeX;
            this.SizeY = SizeY;
            this.Image = Image;
            this.HitBox = HitBox.FromEnemy(this);
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
                    info.Type = EntityType.Navinha;
                }
                else if (entity is Bullet)
                { 
                    info.Type = EntityType.Shot;
                }
                OnCollision(info, entity);
            }
        }

        public override void OnCollision(CollisionInfo info, Sprite sprite)
        {
            if (info.Type == EntityType.Shot)
            {
                Hit = true;
            }
        }
    }
}
