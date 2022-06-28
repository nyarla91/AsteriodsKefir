using System.Numerics;

namespace Model.Bullets
{
    public class LaserBullet : Bullet
    {
        protected override float MovementSpeed => 6;
        protected override bool IsDestroyedOnHit => false;
        public override string SpritePath => "Sprites/LaserBullet";

        public LaserBullet(Vector2 position, float rotation) : base(position, rotation)
        {
            
        }
    }
}