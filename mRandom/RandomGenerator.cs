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
