using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
    public class FixedUpdaterView : MonoBehaviour
    {
        private List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();

        protected void AddUpdatable(IFixedUpdatable updatableToAdd)
        {
            if (!_fixedUpdatables.Contains(updatableToAdd))
                _fixedUpdatables.Add(updatableToAdd);
        }
        
        protected virtual void FixedUpdate()
        {
            foreach (IFixedUpdatable fixedUpdatable in _fixedUpdatables)
            {
                fixedUpdatable?.FixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}