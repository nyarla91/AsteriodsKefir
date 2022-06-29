using Model;
using UnityEngine;

namespace View
{
    public class CollidingView : TransformableView<Colliding>
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out CollidingView colliding))
            {
                Model.OnCollide(colliding.Model);
            }
        }
    }
}