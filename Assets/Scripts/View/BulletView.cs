using Model.Bullets;
using UnityEngine;

namespace View
{
    public class BulletView : CollidingView
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Initialize(Bullet model)
        {
            Model = model;
            _spriteRenderer.sprite = Resources.Load<Sprite>(model.SpritePath);
        }
    }
}