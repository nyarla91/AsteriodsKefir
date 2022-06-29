using Model.Obstacles;
using UnityEngine;

namespace View
{
    public class ObstacleView : CollidingView
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Initialize(Obstacle model)
        {
            Model = model;
            _spriteRenderer.sprite = Resources.Load<Sprite>(model.SpritePath);
        }
    }
}