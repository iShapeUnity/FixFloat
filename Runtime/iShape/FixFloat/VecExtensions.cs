using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace iShape.FixFloat {

    public static class VecExtensions {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixVec ToFixVec(this float2 vec)
        {
            return new FixVec(vec.x.ToFix(), vec.y.ToFix());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SqrLength(this float2 vec)
        {
            return math.lengthsq(vec);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Length(this float2 vec)
        {
            return math.length(vec);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 Normalize(this float2 vec)
        {
            return math.normalize(vec);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float DotProduct(this float2 vec, float2 other)
        {
            return math.dot(vec, other);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CrossProduct(this float2 vec, float2 other)
        {
            return vec.x * other.y - vec.y * other.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsClockwise(this float2 vec, float2 other)
        {
            return vec.x * other.y < vec.y * other.x;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 Ortho(this float2 vec, bool clockwise)
        {
            return clockwise ? new float2(vec.y, -vec.x).Normalize() : new float2(-vec.y, vec.x).Normalize();
        }
    }

}