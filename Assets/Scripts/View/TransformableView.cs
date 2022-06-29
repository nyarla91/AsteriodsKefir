using System;
using Model;
using UnityEngine;

namespace View
{
    public abstract class TransformableView<TModel> : FixedUpdaterView where TModel : Transformable
    {
        private Transform _transform;
        public Transform Transform => _transform ??= transform;
        
        private TModel _model;

        public TModel Model
        {
            get => _model;
            protected set
            {
                if (_model != null)
                    throw new Exception("Model can only be set once");
                
                _model = value;
                if (_model is IFixedUpdatable)
                    AddUpdatable((IFixedUpdatable) _model);
                    
                _model.OnTransformed += ApplyTransform;
                Model.OnDestroy += () => Destroy(gameObject);
            }
        }

        public void ApplyTransform(Transformable transformable)
        {
            Transform.localPosition = transformable.Position.ToUnityVector();
            Transform.rotation = Quaternion.Euler(0, 0, transformable.Rotation);
            Transform.localScale =  transformable.Scale.To3().WithZ(1).ToUnityVector();
        }

        protected virtual void OnDestroy()
        {
            _model.OnTransformed -= ApplyTransform;
            _model = null;
        }
    }
}