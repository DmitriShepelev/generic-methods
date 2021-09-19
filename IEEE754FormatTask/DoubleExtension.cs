using System;
using System.Runtime.InteropServices;

namespace IEEE754FormatTask
{
    public static class DoubleExtension
    {
        /// <summary>
        /// Returns a string representation of a double type number
        /// in the IEEE754 (see https://en.wikipedia.org/wiki/IEEE_754) format.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>A string representation of a double type number in the IEEE754 format.</returns>
        public static string GetIEEE754Format(this double number)
        {
            UnionStruct x = new UnionStruct
            {
                D = number,
            };
            return x.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct UnionStruct
        {
            [FieldOffset(0)]
            public double D;

            [FieldOffset(0)]
            private long l;

            public override string ToString()
            {
                long mask = 0x01;
                var result = new char[64];
                for (int i = 0; i < 64; i++)
                {
                    if ((this.l & mask) == 0)
                    {
                        result[i] = '0';
                    }
                    else
                    {
                        result[i] = '1';
                    }

                    mask <<= 1;
                }

                Array.Reverse(result);
                return new string(result);
            }
        }
    }
}
