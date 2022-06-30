using System.Numerics;
using Model.Obstacles;

namespace Model.Bullets
{
    public abstract class Bullet : Colliding, IFixedUpdatable
    {
        protected abstract float MovementSpeed { get; }
        protected virtual bool IsDestroyedOnHit => true;
        public abstract string SpritePath { get; }

        protected Bullet(Transformable origin) : base(origin.Position, origin.Rotation, Vector2.One)
        {
            
        }
        
        public void FixedUpdate(float deltaTime)
        {
            MoveForward(MovementSpeed * deltaTime);
        }

        public override void OnCollide(Colliding other)
        {
            base.OnCollide(other);
            if (other is Obstacle && IsDestroyedOnHit)
                OnDestroy?.Invoke();
        }
    }
}