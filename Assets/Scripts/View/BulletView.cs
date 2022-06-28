using Model.Bullets;
using UnityEngine;

namespace View
{
    public class BulletView : TransformableView<Bullet>
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        public void Initialize(Bullet model)
        {
            Model = model;
            fixedUpdatables.Add(Model);
            _spriteRenderer.sprite = Resources.Load<Sprite>(model.SpritePath);
        }
    }
}