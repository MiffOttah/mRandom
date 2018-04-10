using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    partial class RandomGenerator
    {
        /// <summary>
        /// Returns a random binary string of the specified length.
        /// </summary>
        /// <param name="length">The length of string to get.</param>
        public BinString RandomBinString(int length)
        {
            return Source.GetRandomBytes(length);
        }

        /// <summary>
        /// Returns a random 32-bit integer between 0 and Int32.MaxValue.
        /// </summary>
        public int RandomInt32()
        {
            return Source.GetRandomBytes(4).ToInt32(null) & int.MaxValue;
        }

        /// <summary>
        /// Returns a random unsigned 32-bit integer.
        /// </summary>
        public uint RandomUInt32()
        {
            return Source.GetRandomBytes(4).ToUInt32(null);
        }

        /// <summary>
        /// Returns a random 64-bit integer between 0 and Int64.MaxValue.
        /// </summary>
        public long RandomInt64()
        {
            return Source.GetRandomBytes(8).ToInt64(null) & long.MaxValue;
        }


        /// <summary>
        /// Returns a random unsigned 64-bit integer.
        /// </summary>
        public ulong RandomUInt64()
        {
            return Source.GetRandomBytes(8).ToUInt64(null);
        }

        /// <summary>
        /// Returns a random decimal number between 0.0 and 1.0.
        /// </summary>
        public float RandomSingle()
        {
            return Convert.ToSingle(RandomDouble());
        }

        /// <summary>
        /// Returns a random decimal number between 0.0 and 1.0.
        /// </summary>
        public double RandomDouble()
        {
            return RandomInt64() * FACTOR;
        }
    }
}
