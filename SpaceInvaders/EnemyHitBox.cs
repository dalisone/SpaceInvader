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
            
            new PointF(enemy.PosX+55  , enemy.PosY+110  ),
            new PointF(enemy.PosX+55 + enemy.SizeX /3, enemy.PosY +110  ),
            new PointF(enemy.PosX+55 + enemy.SizeX/3, enemy.PosY+60  ),
            new PointF(enemy.PosX+55, enemy.PosY  +60 ),
            new PointF(enemy.PosX+55, enemy.PosY +60  ),
        };
    }
}
