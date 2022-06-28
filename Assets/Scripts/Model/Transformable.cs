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

        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value % 360;
                OnTransformed?.Invoke(this);
            }
        }
        
        protected Vector2 Facing
        {
            get
            {
                const double DegreesToRadians = Math.PI / 180;
                return new Vector2((float) Math.Cos(Rotation * DegreesToRadians), (float) Math.Sin(Rotation * DegreesToRadians));
            }
        }

        public event Action<Transformable> OnTransformed;

        public Transformable(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }
    }
}