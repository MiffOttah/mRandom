using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MiffTheFox.mRandom
{
    /// <summary>
    /// A randomess source that draws from System.Random.
    /// </summary>
    public class SystemRandomRandomnessSource : IRandomnessSource
    {
        private Random _RNG;

        public SystemRandomRandomnessSource()
        {
            _RNG = new Random();
        }

        public SystemRandomRandomnessSource(Random rng)
        {
            _RNG = rng;
        }

        public void Dispose()
        {
        }

        public BinString GetRandomBytes(int length)
        {
            byte[] b = new byte[length];
            _RNG.NextBytes(b);
            return new BinString(b);
        }
    }

    /// <summary>
    /// A randomness source that draws from System.Security.Cryptography.RandomNumberGenerator.
    /// </summary>
    public class CryptoRandomnessSource : IRandomnessSource
    {
        private RandomNumberGenerator _RNG;

        public CryptoRandomnessSource()
        {
            _RNG = RandomNumberGenerator.Create();
        }

        public CryptoRandomnessSource(RandomNumberGenerator rng)
        {
            _RNG = rng;
        }

        public void Dispose()
        {
            ((IDisposable)_RNG).Dispose();
        }

        public BinString GetRandomBytes(int length)
        {
            byte[] b = new byte[length];
            _RNG.GetBytes(b);
            return new BinString(b);
        }
    }
}
