using System.Numerics;
using Model.Bullets;

namespace Model.Obstacles
{
    public class UFO : Obstacle, IFixedUpdatable
    {
        private readonly Transformable _target;
        public override string SpritePath => "Sprites/UFO";
        public override int ScoreWorth => 5;

        private float _speed = 1.2f;
        
        public UFO(Vector2 position, float rotation, Transformable target) : base(position, rotation, Vector2.One * 0.5f)
        {
            _target = target;
        }

        public void FixedUpdate(float deltaTime)
        {
            if (_target == null)
                return;
            Vector2 moveDirection = (_target.Position - Position).Normalized();
            Position += _speed * deltaTime * moveDirection;
        }

        public override void OnCollide(Colliding other)
        {
            base.OnCollide(other);
            if (other is not Bullet)
                return;
            
            OnDestroy?.Invoke();
        }
    }
}