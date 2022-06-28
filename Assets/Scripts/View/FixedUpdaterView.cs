using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
    public class FixedUpdaterView : MonoBehaviour
    {
        protected List<IFixedUpdatable> fixedUpdatables = new List<IFixedUpdatable>();

        protected virtual void FixedUpdate()
        {
            foreach (IFixedUpdatable fixedUpdatable in fixedUpdatables)
            {
                fixedUpdatable?.FixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}