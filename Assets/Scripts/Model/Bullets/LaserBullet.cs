using System.Numerics;

namespace Model.Bullets
{
    public class LaserBullet : Bullet
    {
        protected override float MovementSpeed => 15;
        protected override bool IsDestroyedOnHit => false;
        public override string SpritePath => "Sprites/LaserBullet";

        public LaserBullet(Transformable origin) : base(origin)
        {
            
        }
    }
}