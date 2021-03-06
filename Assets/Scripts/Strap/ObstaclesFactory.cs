using Model.Obstacles;
using UnityEngine;
using View;
using View.Player;
using View.UI;

namespace Strap
{
    public class ObstaclesFactory : MonoBehaviour
    {
        [SerializeField] private ScoreCounterView _scoreCounter;
        [SerializeField] private FixedUpdaterView _updater;
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private GameObject _obstaclePrefab;
        [Tooltip("0 - Only Meteors\n1 - Only UFOs")] [Range(0, 1)]
        [SerializeField] private float _ufoSpawnChance; 
        [SerializeField] private float _spawnPeriod;

        private ObstaclesSpawner _model;
        
        private void Start()
        {
            _model = new ObstaclesSpawner(_playerView.Model, _scoreCounter.Model);
            _updater.AddUpdatable(_model);
            _model.OnObstacleSpawned += SpawnObstacle;
            OnValidate();
        }

        private void SpawnObstacle(Obstacle obstacle)
        {
            _updater.AddUpdatable(obstacle);
            ObstacleView view = Instantiate(_obstaclePrefab, obstacle.Position. ToUnityVector(), Quaternion.Euler(0, 0, obstacle.Rotation))
                    .GetComponent<ObstacleView>();
            
            view.Initialize(obstacle);
        }

        private void OnValidate()
        {
            _model?.UpdateStats(_ufoSpawnChance, _spawnPeriod);
        }

        private void OnDestroy()
        {
            _model = null;
        }
    }
}