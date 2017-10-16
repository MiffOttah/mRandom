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
            return _Source.GetRandomBytes(length);
        }

        public int RandomInt32()
        {
            return _Source.GetRandomBytes(4).ToInt32(null) & int.MaxValue;
        }

        public uint RandomUInt32()
        {
            return _Source.GetRandomBytes(4).ToUInt32(null);
        }

        public long RandomInt64()
        {
            return _Source.GetRandomBytes(8).ToInt64(null) & long.MaxValue;
        }

        public ulong RandomUInt64()
        {
            return _Source.GetRandomBytes(8).ToUInt64(null);
        }

        public float RandomSingle()
        {
            return Convert.ToSingle(RandomDouble());
        }

        public double RandomDouble()
        {
            return RandomInt64() * FACTOR;
        }
    }
}
