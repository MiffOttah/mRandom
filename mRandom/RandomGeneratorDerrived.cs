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
        /// Returns a non-negative random integer less than limit.
        /// </summary>
        public int RandomLessThan(int limit)
        {
            return Convert.ToInt32(Math.Truncate(RandomDouble() * limit));
        }

        /// <summary>
        /// Returns a non-negative random integer less than limit.
        /// </summary>
        public long RandomLessThan(long limit)
        {
            return Convert.ToInt64(Math.Truncate(RandomDouble() * limit));
        }

        /// <summary>
        /// Returns a random integer greater than or equal to minValue and less than or equal to maxValue.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random value.</param>
        /// <param name="maxValue">The inclusive upper bound of the random value.</param>
        public int RandomBetweenInclusive(int minValue, int maxValue)
        {
            if (minValue > maxValue) throw new ArgumentException("Minimum value must be less than or equal to the maximum value.");
            if (minValue == maxValue) return minValue;

            int diff = (maxValue - minValue) + 1;
            return minValue + RandomLessThan(diff);
        }
    }
}
