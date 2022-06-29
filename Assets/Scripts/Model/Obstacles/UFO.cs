using System.Numerics;
using Model.Bullets;
using static Model.ScoreCounterFacade;

namespace Model.Obstacles
{
    public class UFO : Obstacle, IFixedUpdatable
    {
        private readonly Transformable _player;
        public override string SpritePath => "Sprites/UFO";
        public override int ScoreWorth => 5;

        private float _speed = 1.2f;
        
        public UFO(Vector2 position, float rotation, Transformable player) : base(position, rotation, Vector2.One * 0.5f)
        {
            _player = player;
        }

        public void FixedUpdate(float deltaTime)
        {
            Vector2 moveDirection = (_player.Position - Position).Normalized();
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