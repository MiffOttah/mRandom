using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    public class RandomGenerator : IDisposable
    {
        private readonly IRandomnessSource _Source;
        public IRandomnessSource Source => _Source;

        const double FACTOR = 1.0 / long.MaxValue;

        public RandomGenerator(IRandomnessSource source)
        {
            _Source = source;
        }

        public void Dispose()
        {
            _Source.Dispose();
        }

        #region Direct sampling of the RNG

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

        #endregion

        #region Derived methods

        public int RandomLessThan(int limit)
        {
            return Convert.ToInt32(Math.Truncate(RandomDouble() * limit));
        }

        public long RandomLessThan(long limit)
        {
            return Convert.ToInt64(Math.Truncate(RandomDouble() * limit));
        }

        public int RandomBetweenInclusive(int minValue, int maxValue)
        {
            if (minValue > maxValue) throw new ArgumentException("Minimum value must be less than or equal to the maximum value.");
            if (minValue == maxValue) return minValue;

            int diff = (maxValue - minValue) + 1;
            return minValue + RandomLessThan(diff);
        }

        #endregion
    }
}
