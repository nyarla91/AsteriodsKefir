using System;
using System.Numerics;
using Model.Bullets;

namespace Model.Obstacles
{
    public abstract class Obstacle : Colliding
    {
        public abstract string SpritePath { get; }
        public abstract int ScoreWorth { get; }

        public Obstacle(Vector2 position, float rotation, Vector2 scale) : base(position, rotation, scale)
        {
        }

        public override void OnCollide(Colliding other)
        {
            base.OnCollide(other);
            if (other is Bullet)
                ScoreCounter.Instance.AddScore(ScoreWorth);
        }
    }
}