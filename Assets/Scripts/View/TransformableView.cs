using System;
using Extentions;
using Model;
using UnityEngine;

namespace View
{
    public abstract class TransformableView<TModel> : FixedUpdaterView where TModel : Transformable
    {
        private Transform _transform;
        public Transform Transform => _transform ??= transform;
        
        private TModel _model;

        protected TModel Model
        {
            get => _model;
            set
            {
                if (_model != null)
                    throw new Exception("Model can only be set once");
                
                _model = value;
                _model.OnTransformed += ApplyTransform;
            }
        }

        public void ApplyTransform(Transformable transformable)
        {
            Transform.localPosition = transformable.Position.ToUnityVector();
            Transform.rotation = Quaternion.Euler(0, 0, transformable.Rotation);
        }

        protected virtual void OnDestroy()
        {
            _model.OnTransformed -= ApplyTransform;
            _model = null;
        }
    }
}