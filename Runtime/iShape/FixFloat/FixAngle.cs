using System.Runtime.CompilerServices;

namespace iShape.FixFloat {

    public static class FixAngle {

        private const long IndexMask = 256 - 1;
        private const long FullRoundMask = 1024 - 1;

        /// <summary>
        /// Returns the sine value for the specified angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Sin(this long angle)
        {
            int quarter = (int)(angle & FullRoundMask) >> 8;
            int index = (int)(angle & IndexMask);

            switch (quarter)
            {
                case 0:
                    return Value(index);
                case 1:
                    return Value(256 - index);
                case 2:
                    return -Value(index);
                default:
                    return -Value(256 - index);
            }
        }
        
        /// <summary>
        /// Returns the cosine value for the specified angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long Cos(this long angle)
        {
            int quarter = (int)(angle & FullRoundMask) >> 8;
            int index = (int)(angle & IndexMask);

            switch (quarter)
            {
                case 0:
                    return Value(256 - index);
                case 1:
                    return -Value(index);
                case 2:
                    return -Value(256 - index);
                default:
                    return Value(index);
            }
        }
        
        /// <summary>
        /// Returns a rotation matrix for the specified angle.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static FixVec Rotator(this long angle)
        {
            int quarter = (int)(angle & FullRoundMask) >> 8;
            int index = (int)(angle & IndexMask);

            long sn;
            long cs;

            switch (quarter)
            {
                case 0:
                    sn = Value(index);
                    cs = Value(256 - index);
                    break;
                case 1:
                    sn = Value(256 - index);
                    cs = -Value(index);
                    break;
                case 2:
                    sn = -Value(index);
                    cs = -Value(256 - index);
                    break;
                default:
                    sn = -Value(256 - index);
                    cs = Value(index);
                    break;
            }

            return new FixVec(cs, sn);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static long Value(int index)
        {
            int i = index >> 1;
            if ((index & 1) == 1)
            {
                return (FixSin.Map[i] + FixSin.Map[i + 1]) >> 1;
            }
            else
            {
                return FixSin.Map[i];
            }
        }
        
        /// <summary>
        /// Converts a fixed-point radian value to a fixed-point angle value.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long RadToFixAngle(this long value) {
            return (value << 9) / FixNumber.PI;
        }
    }

}