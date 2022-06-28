using System;
using Vector2 = System.Numerics.Vector2;

namespace Model
{
    public class PlayerMovement : Transformable, IFixedUpdatable
    {
        private const float Acceleration = 0.1f;
        private const float Deacceleration = 0.03f;
        private const float MovementSpeed = 4; // units/second
        private const float RotationSpeed = 120; // degrees/second
        
        private readonly Vector2 _cameraMaxBounds;
        private readonly Vector2 _cameraMinBounds;
        
        private bool _isAccelerating;
        private Vector2 _velocity;

        public PlayerMovement(Vector2 position, float rotation, Vector2 cameraMaxBounds, Vector2 cameraMinBounds) : base(position, rotation)
        {
            _cameraMaxBounds = cameraMaxBounds;
            _cameraMinBounds = cameraMinBounds;
        }

        public void StartAcceleration() => _isAccelerating = true;
        public void EndAcceleration() => _isAccelerating = false;

        public void Rotate(float deltaTime, float axis) => Rotation += axis * RotationSpeed * deltaTime;

        public void FixedUpdate(float deltaTime)
        {
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            float t = _isAccelerating ? Acceleration : Deacceleration;
            Vector2 targetVelocity = _isAccelerating ? (MovementSpeed * deltaTime * Facing) : Vector2.Zero;
            _velocity = Vector2.Lerp(_velocity, targetVelocity, t);

            Position += _velocity;

            Teleport();
        }

        private void Teleport()
        {
            float x = LoopCoordinate(Position.X, _cameraMinBounds.X, _cameraMaxBounds.X);
            float y = LoopCoordinate(Position.Y, _cameraMinBounds.Y, _cameraMaxBounds.Y);
            Position = new Vector2(x, y);
        }

        private float LoopCoordinate(float coordinate, float min, float max)
        {
            if (max < min)
                throw new ArgumentException("Min cannot be more than Max");

            float step = max - min;
            while (coordinate < min)
                coordinate += step;
            while (coordinate > max)
                coordinate -= step;

            return coordinate;
        }
    }
}