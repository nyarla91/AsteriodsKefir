using System;
using Random = System.Random;
using Vector2 = System.Numerics.Vector2;

namespace Model.Obstacles
{
    public class ObstaclesSpawner : IFixedUpdatable
    {
        private readonly Player _player;
        private readonly ScoreCounter _scoreCounter;
        private readonly Timer _spawnTimer = new Timer(0.2f);
        private float _ufoSpawnChance = 0.5f;
        
        private static Vector2 RandomPointInCircle
        {
            get
            {
                Random random = new Random();
                float angle = (float) random.Next(0, 360);
                double distance = random.NextDouble();
                
                return angle.DegreesToVector2() * (float) distance;
            }
        }

        public event Action<Obstacle> OnObstacleSpawned;

        public ObstaclesSpawner(Player player, ScoreCounter scoreCounter)
        {
            _player = player;
            _scoreCounter = scoreCounter;
            _spawnTimer.OnExpired += SpawnRandomObstacle;
        }

        public void UpdateStats(float ufoSpawnChance, float spawnPeriod)
        {
            _ufoSpawnChance = ufoSpawnChance;
            _spawnTimer.Duration = spawnPeriod;
        }

        public void FixedUpdate(float deltaTime)
        {
            _spawnTimer.Update(deltaTime);
        }

        private void SpawnRandomObstacle()
        {
            Random random = new Random();
            
            Vector2 position = RandomPointInCircle.Normalized() * 12;
            Vector2 lookDirection = (RandomPointInCircle * 9 - position).Normalized();
            float rotation = lookDirection.ToDegrees();
            
            Obstacle obstacle = random.NextDouble() > _ufoSpawnChance 
                ? new Meteor(position, rotation, _scoreCounter, this)
                : new UFO(position, rotation, _player, _scoreCounter);
            SpawnObstacle(obstacle);
        }

        public void SpawnObstacle(Obstacle obstacle)
        {
            OnObstacleSpawned?.Invoke(obstacle);
        }
    }
}