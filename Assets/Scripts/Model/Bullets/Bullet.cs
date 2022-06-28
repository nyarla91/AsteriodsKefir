using System;
using System.Numerics;

namespace Model.Bullets
{
    public abstract class Bullet : Transformable, IFixedUpdatable
    {
        protected abstract float MovementSpeed { get; }
        protected virtual bool IsDestroyedOnHit => true;
        public abstract string SpritePath { get; }

        public event Action OnDestroy;
        
        protected Bullet(Vector2 position, float rotation) : base(position, rotation)
        {
            
        }
        
        public void FixedUpdate(float deltaTime)
        {
            Position += MovementSpeed * deltaTime * Facing;
        }

        public void OnHit()
        {
            if (IsDestroyedOnHit)
                OnDestroy?.Invoke();
        }
    }
}