using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders
{
    public class EnemyHitBox : HitBox
    {
        public Enemy enemy { get; set; }
        public override PointF[] Points => new PointF[]
        {
            
            new PointF(enemy.PosX+80  , enemy.PosY +100  ),
            new PointF(enemy.PosX+80 + enemy.SizeX /3, enemy.PosY +100  ),
            new PointF(enemy.PosX+80 + enemy.SizeX/3, enemy.PosY  ),
            new PointF(enemy.PosX+80, enemy.PosY  +100 ),
            new PointF(enemy.PosX+80, enemy.PosY+100   ),
        };
    }
}
