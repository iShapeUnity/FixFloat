using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace iShape.FixFloat {

    /// <summary>
    /// Represents a fixed-point 2D vector using long integer coordinates.
    /// </summary>
    public readonly struct FixVec {

        /// <summary>
        /// The X coordinate of the vector.
        /// </summary>
        public readonly long x;
        
        /// <summary>
        /// The Y coordinate of the vector.
        /// </summary>
        public readonly long y;

        /// <summary>
        /// Constructs a new fixed-point vector with the specified X and Y coordinates.
        /// </summary>
        /// <param name="x">The X coordinate of the vector.</param>
        /// <param name="y">The Y coordinate of the vector.</param>
        public FixVec(long x, long y) {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns a zero vector (0, 0).
        /// </summary>
        public static FixVec Zero => new FixVec(0, 0);

        /// <summary>
        /// Packs the X and Y coordinates into a single long value.
        /// </summary>
        public long BitPack => (x << (FixNumber.MaxBits + 1)) + y;

        /// <summary>
        /// Converts the fixed-point vector to a float2 representation.
        /// </summary>
        /// <returns>A float2 representation of the vector.</returns>
        public float2 ToFloat2() {
            return new float2(x.ToFloat(), y.ToFloat());
        }

        /// <summary>
        /// Calculates the squared length of the vector.
        /// </summary>
        public long SqrLength => (x * x + y * y).FastNormalize();

        /// <summary>
        /// Calculates the length of the vector.
        /// </summary>
        public long Length => (x * x + y * y).FastSquareRoot();

        /// <summary>
        /// Returns a normalized version of the vector.
        /// </summary>
        public FixVec Normalize {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get {
                long s = (1L << 30) / Length;
                long xx = (s * x).SQRNormalize();
                long yy = (s * y).SQRNormalize();
                
                return new FixVec(xx, yy);
            }
        }

        /// <summary>
        /// Returns a vector with half the length of the original vector.
        /// </summary>
        public FixVec Half => new FixVec(x / 2, y / 2);

        /// <summary>
        /// Returns an orthogonal vector, normalized and rotated 90 degrees clockwise or counterclockwise.
        /// </summary>
        /// <param name="clockwise">If true, returns a clockwise rotated vector. Otherwise, returns a counterclockwise rotated vector.</param>
        /// <returns>A normalized orthogonal vector.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FixVec Ortho(bool clockwise) {
            return clockwise
                ? new FixVec(y, -x).Normalize
                : new FixVec(-y, x).Normalize;
        }

        /// <summary>
        /// Adds two fixed-point vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixVec operator +(FixVec left, FixVec right) {
            return new FixVec(left.x + right.x, left.y + right.y);
        }

        /// <summary>
        /// Subtracts two fixed-point vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixVec operator -(FixVec left, FixVec right) {
            return new FixVec(left.x - right.x, left.y - right.y);
        }

        /// <summary>
        /// Multiplies a fixed-point vector by a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixVec operator *(FixVec left, long right) {
            long x = left.x.Mul(right);
            long y = left.y.Mul(right);
            return new FixVec(x, y);
        }
        
        /// <summary>
        /// Multiplies a scalar by a fixed-point vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixVec operator *(long left, FixVec right) {
            long x = right.x.Mul(left);
            long y = right.y.Mul(left);
            return new FixVec(x, y);
        }
        
        /// <summary>
        /// Calculates the dot product of two fixed-point vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long DotProduct(FixVec v)
        {
            long xx = x.Mul(v.x);
            long yy = y.Mul(v.y);
            return xx + yy;
        }

        /// <summary>
        /// Calculates the cross product of two fixed-point vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long CrossProduct(FixVec v)
        {
            long a = x.Mul(v.y);
            long b = y.Mul(v.x);

            return a - b;
        }
        
        /// <summary>
        /// Calculates the cross product of a fixed-point vector and a scalar.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FixVec CrossProduct(long a) {
            long x0 = a.Mul(y);
            long y0 = a.Mul(x);

            return new FixVec(-x0, y0);
        }

        /// <summary>
        /// Calculates the squared distance between two fixed-point vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long SqrDistance(FixVec v)
        {
            return (this - v).SqrLength;
        }

        /// <summary>
        /// Calculates the middle point between two fixed-point vectors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public FixVec Middle(FixVec v)
        {
            FixVec sum = this + v;
            return new FixVec(sum.x / 2, sum.y / 2);
        }
        
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

}