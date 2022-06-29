using Vector2 = System.Numerics.Vector2;

namespace Model
{
    public class Colliding : Transformable
    {
        protected Colliding(Vector2 position, float rotation, Vector2 scale) : base(position, rotation, scale)
        {
            
        }

        public virtual void OnCollide(Colliding other)
        {
            
        }
    }
}