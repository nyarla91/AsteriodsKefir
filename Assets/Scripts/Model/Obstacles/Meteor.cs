using System;
using Model.Bullets;
using Vector2 = System.Numerics.Vector2;

namespace Model.Obstacles
{
    public class Meteor : Obstacle, IFixedUpdatable
    {
        private readonly ObstaclesSpawner _spawner;
        public override string SpritePath => "Sprites/Meteor";
        public override int ScoreWorth => 3;

        protected virtual float Speed => 1;
        protected virtual int PiecesOnBreak => 3;
        
        public Meteor(Vector2 position, float rotation, ObstaclesSpawner spawner)
            : base(position, rotation, Vector2.One )
        {
            _spawner = spawner;
        }

        public void FixedUpdate(float deltaTime)
        {
            Position += Speed * deltaTime * Facing;
        }

        public override void OnCollide(Colliding other)
        {
            base.OnCollide(other);
            if (other is not Bullet)
                return;
            
            for (int i = 0; i < PiecesOnBreak; i++)
            {
                Random random = new Random();
                float rotation = random.Next(0, 360);
                _spawner.SpawnObstacle(new PieceOfMeteor(Position, rotation, _spawner));
            }
            OnDestroy?.Invoke();
        }
    }
}