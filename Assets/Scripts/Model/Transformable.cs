using System;
using System.Threading.Tasks;
using Vector2 = System.Numerics.Vector2;

namespace Model
{
    public class Transformable
    {
        private float _rotation;
        private Vector2 _position;
        private Vector2 _scale;
        
        public Action OnDestroy;
        
        protected virtual bool DestroyedOutOfMapBounds => true;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                OnTransformed?.Invoke(this);
                if (DestroyedOutOfMapBounds && _position.Length() > 15)
                    OnDestroy?.Invoke();
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

        public Vector2 Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                OnTransformed?.Invoke(this);
            }
        }

        protected Vector2 Facing => Rotation.DegreesToVector2();

        public event Action<Transformable> OnTransformed;

        protected Transformable(Vector2 position, float rotation, Vector2 scale)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;
            ApplyTransform();
        }

        protected void MoveForward(float distance)
        {
            Position += distance * Facing;
        }

        private async void ApplyTransform()
        {
            await Task.Delay(1);
            OnTransformed?.Invoke(this);
        }
    }
}