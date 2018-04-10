using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    /// <summary>
    /// Repersents a provider of random or pseudo-random bytes that can be used by a RandomGenerator.
    /// </summary>
    public interface IRandomnessSource : IDisposable
    {
        BinString GetRandomBytes(int length);
    }
}
