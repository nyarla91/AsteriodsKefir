using System;
using System.Numerics;

namespace Model
{
    public class PlayerMovement : Transformable, IFixedUpdatable
    {
        private const float Acceleration = 0.1f;
        private const float Deacceleration = 0.03f;
        private const float MovementSpeed = 4;
        private const float RotationSpeed = 120;
        
        private bool _accelerating;
        private Vector2 _velocity;
        private Vector2 Facing
        {
            get
            {
                const double DegreesToRadians = Math.PI / 180;
                return new Vector2((float) Math.Cos(Rotation * DegreesToRadians), (float) Math.Sin(Rotation * DegreesToRadians));
            }
        }

        public PlayerMovement(Vector2 position, Vector2 scale, float rotation) : base(position, scale, rotation)
        {
            
        }

        public void StartAcceleration() => _accelerating = true;
        public void EndAcceleration() => _accelerating = false;

        public void Rotate(float deltaTime, float axis) => Rotation += axis * RotationSpeed * deltaTime;

        public void FixedUpdate(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            float t = _accelerating ? Acceleration : Deacceleration;
            Vector2 targetVelocity = _accelerating ? (MovementSpeed * deltaTime * Facing) : Vector2.Zero;
            _velocity = Vector2.Lerp(_velocity, targetVelocity, t);

            Position += _velocity;
        }
    }
}