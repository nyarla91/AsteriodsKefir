using System.Collections.Generic;
using Model;
using UnityEngine;

namespace View
{
    public sealed class FixedUpdaterView : MonoBehaviour
    {
        private readonly List<IFixedUpdatable> _fixedUpdatables = new List<IFixedUpdatable>();

        public void AddUpdatable(params IFixedUpdatable[] updatablesToAdd)
        {
            foreach (IFixedUpdatable fixedUpdatable in updatablesToAdd)
            {
                if (!_fixedUpdatables.Contains(fixedUpdatable))
                    _fixedUpdatables.Add(fixedUpdatable);
            }
        }
        
        private void FixedUpdate()
        {
            for (int i = _fixedUpdatables.Count - 1; i >= 0; i--)
            {
                if (_fixedUpdatables[i] == null)
                {
                    _fixedUpdatables.RemoveAt(i);
                    continue;
                }
                _fixedUpdatables[i].FixedUpdate(Time.fixedDeltaTime);
            }
        }
    }
}