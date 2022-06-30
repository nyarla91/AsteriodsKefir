using System;
using Vector2 = System.Numerics.Vector2;
using Vector3 = System.Numerics.Vector3;

namespace Model
{
    public static class MathExtentions
    {
        public static Vector2 Normalized(this Vector2 vector) => vector / vector.Length();

        public static Vector3 WithZ(this Vector3 vector, float z) => new Vector3(vector.X, vector.Y, z);

        public static Vector2 DegreesToVector2(this float degrees) =>
            new Vector2((float) Math.Cos(degrees * DegreesToRadians()), (float) Math.Sin(degrees * DegreesToRadians()));

        public static float ToDegrees(this Vector2 vector) => (float) (Math.Atan2(vector.Y, vector.X) * RadiansToDegrees());
        
        public static double DegreesToRadians() => Math.PI / 180;
        public static double RadiansToDegrees() => 180 / Math.PI;
    }
}