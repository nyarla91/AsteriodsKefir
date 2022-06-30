namespace Model.Bullets
{
    public class CannonBullet : Bullet
    {
        protected override float MovementSpeed => 9;
        public override string SpritePath => "Sprites/CannonBullet";

        public CannonBullet(Transformable origin) : base(origin)
        {
        }
    }
}