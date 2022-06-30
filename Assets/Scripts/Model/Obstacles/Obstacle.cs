using System.Numerics;
using Model.Bullets;

namespace Model.Obstacles
{
    public abstract class Obstacle : Colliding, IFixedUpdatable
    {
        protected ScoreCounter ScoreCounter { get; }
        public abstract string SpritePath { get; }
        protected abstract int ScoreWorth { get; }

        protected Obstacle(Vector2 position, float rotation, Vector2 scale, ScoreCounter scoreCounter) : base(position, rotation, scale)
        {
            ScoreCounter = scoreCounter;
        }

        public override void OnCollide(Colliding other)
        {
            base.OnCollide(other);
            if (other is Bullet)
                ScoreCounter.AddScore(ScoreWorth);
        }

        public virtual void FixedUpdate(float deltaTime)
        {
            
        }
    }
}