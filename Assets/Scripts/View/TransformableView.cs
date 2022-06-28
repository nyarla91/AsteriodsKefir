using System;
using Extentions;
using Model;
using UnityEngine;

namespace View
{
    public abstract class TransformableView<TModel> : MonoBehaviour where TModel : Transformable
    {
        private Transform _transform;
        public Transform Transform => _transform ??= transform;
        
        private TModel _model;

        protected TModel Model
        {
            get => _model;
            set
            {
                _model = value;
                _model.OnTransformed += ApplyTransform;
            }
        }

        public void ApplyTransform(Transformable transformable)
        {
            Transform.localPosition = transformable.Position.ToUnityVector();
            Transform.localScale = transformable.Scale.ToUnityVector();
            Transform.rotation = Quaternion.Euler(0, 0, transformable.Rotation);
        }

        private void OnDestroy()
        {
            _model.OnTransformed -= ApplyTransform;
        }
    }
}