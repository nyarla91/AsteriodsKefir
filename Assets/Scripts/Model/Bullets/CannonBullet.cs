using System.Numerics;

namespace Model.Bullets
{
    public class CannonBullet : Bullet
    {
        protected override float MovementSpeed => 3;
        public override string SpritePath => "Sprites/CannonBullet";

        public CannonBullet(Vector2 position, float rotation) : base(position, rotation)
        {
        }
    }
}