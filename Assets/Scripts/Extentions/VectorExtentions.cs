using UnityEngine;
using SN = System.Numerics;

namespace Extentions
{
    public static class VectorExtentions
    {
        public static Vector2 ToUnityVector(this System.Numerics.Vector2 original) => new Vector2(original.X, original.Y);
        public static SN.Vector2 ToSystemVector(this Vector2 original) => new SN.Vector2(original.x, original.y);
        
        
        public static Vector3 ToUnityVector(this System.Numerics.Vector3 original) => new Vector3(original.X, original.Y, original.Z);
        public static SN.Vector3 ToSystemVector(this Vector3 original) => new SN.Vector3(original.x, original.y, original.z);
        
        
        public static SN.Vector3 To3(this SN.Vector2 original) => new SN.Vector3(original.X, original.Y, 0);
        public static SN.Vector2 To2(this SN.Vector3 original) => new SN.Vector2(original.X, original.Y);
    }
}