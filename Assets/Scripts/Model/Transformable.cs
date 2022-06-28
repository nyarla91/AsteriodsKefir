using System;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

namespace Model
{
    public class Transformable
    {
        private float _rotation;
        private Vector2 _position;
        private Vector2 _scale;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                OnTransformed?.Invoke(this);
            }
        }

        public Vector2 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                OnTransformed?.Invoke(this);
            }
        }

        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value % 360;
                OnTransformed?.Invoke(this);
            }
        }

        public event Action<Transformable> OnTransformed;

        public Transformable(Vector2 position, Vector2 scale, float rotation)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;
        }
    }
}