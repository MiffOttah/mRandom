using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    partial class RandomGenerator
    {

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
    }
}
