using Model;
using UnityEngine;

namespace View
{
    public class FixedUpdaterView : MonoBehaviour
    {
        protected IFixedUpdatable fixedUpdatable;

        protected virtual void FixedUpdate()
        {
            fixedUpdatable?.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}