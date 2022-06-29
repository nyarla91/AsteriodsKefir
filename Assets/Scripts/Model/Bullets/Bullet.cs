using System.Numerics;
using Model.Obstacles;

namespace Model.Bullets
{
    public abstract class Bullet : Colliding, IFixedUpdatable
    {
        protected abstract float MovementSpeed { get; }
        protected virtual bool IsDestroyedOnHit => true;
        public abstract string SpritePath { get; }

        protected Bullet(Vector2 position, float rotation, Vector2 scale) : base(position, rotation, scale)
        {
            
        }
        
        public void FixedUpdate(float deltaTime)
        {
            Position += MovementSpeed * deltaTime * Facing;
        }

        public override void OnCollide(Colliding other)
        {
            base.OnCollide(other);
            if (other is Obstacle && IsDestroyedOnHit)
                OnDestroy?.Invoke();
        }
    }
}