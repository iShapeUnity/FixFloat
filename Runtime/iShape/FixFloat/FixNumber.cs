using System.Runtime.CompilerServices;

namespace iShape.FixFloat {
    
    /// <summary>
    /// Provides methods and constants for working with fixed-point arithmetic.
    /// It supports numbers in the range 2^21 - 1 to -2^21 + 1
    /// with a precision of 1/1024, with the ideal range being 10,000,000 to
    /// -10,000,000 with a precision of 0.01.
    /// </summary>
    public static class FixNumber
    {
        
        /// <summary>
        /// The number of bits representing the fractional part of the fixed-point number.
        /// 1 / 1024 ~ 0.001 = 1
        /// 256 = 0.25
        /// 1024 = 1
        /// (1024 + 512) = 1.5
        /// (2048 + 256) = 2.25  
        /// </summary>
        public const int FractionBits = 10;
        
        /// <summary>
        /// The maximum number of bits for the integer part of the fixed-point number. 31
        /// </summary>
        public const int MaxBits = (64 >> 1) - 1;
        
        /// <summary>
        /// The maximum value of the fixed-point number. 2^31 - 1
        /// </summary>
        public const long Max = (1L << MaxBits) - 1;
        
        /// <summary>
        /// The minimum value of the fixed-point number. -2^31 + 1
        /// </summary>
        public const long Min = -Max;

        /// <summary>
        /// The fixed-point representation of 1.0.
        /// </summary>
        public const long Unit = 1L << FractionBits;
        
        /// <summary>
        /// The fixed-point representation of 0.5.
        /// </summary>
        public const long Half = 1L << (FractionBits - 1);

        /// <summary>
        /// The fixed-point representation of PI.
        /// </summary>
        public const long PI = 3217;

        /// <summary>
        /// Divides a fixed-point number by another number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Div(this long number, long value)
        {
            return (number << FractionBits) / value;
        }

        /// <summary>
        /// Multiplies a fixed-point number by another number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Mul(this long number, long value)
        {
            return (number * value) >> FractionBits;
        }

        /// <summary>
        /// Calculates the square of a fixed-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sqr(this long number)
        {
            return (number * number) >> FractionBits;
        }

        /// <summary>
        /// Calculates the square root of a fixed-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sqrt(this long number)
        {
            return (number << FractionBits).FastSquareRoot();
        }

        /// <summary>
        /// Converts a fixed-point number to a double-precision floating-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ToDouble(this long number)
        {
            return (double)number / Unit;
        }

        /// <summary>
        /// Converts a fixed-point number to a single-precision floating-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToFloat(this long number)
        {
            return (float)number / Unit;
        }

        /// <summary>
        /// Converts a fixed-point number to an integer.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ToInt(this long number)
        {
            return (int)(number >> FractionBits);
        }

        /// <summary>
        /// Converts an integer to a fixed-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long FromInt(long value)
        {
            return value << FractionBits;
        }

        /// <summary>
        /// Converts a double-precision floating-point number to a fixed-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToFix(this double value)
        {
            return (long)(value * Unit);
        }

        /// <summary>
        /// Converts a floating-point number to a fixed-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToFix(this float value)
        {
            return (long)(value * Unit);
        }

        /// <summary>
        /// Converts a integer number to a fixed-point number.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long ToFix(this int value)
        {
            return (long)value << FractionBits;
        }
    }

    internal static class Int64FastRoot
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static long FastSquareRoot(this long number) {
            long a = (long)System.Math.Sqrt(number);
            long b = a + 1;

            return b * b > number ? a : b;
        }
    }
}