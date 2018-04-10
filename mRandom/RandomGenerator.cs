using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    public partial class RandomGenerator : IDisposable
    {
        public IRandomnessSource Source { get; }

        const double FACTOR = 1.0 / long.MaxValue;

        public RandomGenerator(IRandomnessSource source)
        {
            Source = source;
        }

        public void Dispose()
        {
            Source.Dispose();
        }

        private static RandomGenerator _SystemRandomGenerator = null;

        /// <summary>
        /// Returns a RandomGenerator using the default System.Random as a randomness source.
        /// </summary>
        public static RandomGenerator Default
        {
            get
            {
                if (_SystemRandomGenerator == null) _SystemRandomGenerator = new RandomGenerator(new SystemRandomRandomnessSource());
                return _SystemRandomGenerator;
            }
        }
    }
}
