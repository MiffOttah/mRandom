using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    public partial class RandomGenerator : IDisposable
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
    }
}
