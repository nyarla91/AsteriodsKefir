using System.Numerics;

namespace Model.Bullets
{
    public class CannonBullet : Bullet
    {
        protected override float MovementSpeed => 9;
        public override string SpritePath => "Sprites/CannonBullet";

        public CannonBullet(Vector2 position, float rotation, Vector2 scale) : base(position, rotation, scale)
        {
        }
    }
}