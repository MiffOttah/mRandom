using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiffTheFox.mRandom.Tests
{
    [TestClass]
    public class SourceTests
    {
        [TestMethod]
        public void SystemRandomSourceTest()
        {
            using (var sr = new SystemRandomRandomnessSource())
            {
                for (int i = 0; i < 32; i++)
                {
                    Assert.AreEqual(i, sr.GetRandomBytes(i).Length);
                }
            }

            using (var seeded = new SystemRandomRandomnessSource(new Random(42)))
            {
                Assert.AreEqual(BinString.FromBytes("3e17ba96ae04cd3b99869e56f0adbf3a"), seeded.GetRandomBytes(16));
            }
        }

        [TestMethod]
        public void CryptoSourceTest()
        {
            using (var sr = new CryptoRandomnessSource())
            {
                for (int i = 0; i < 32; i++)
                {
                    Assert.AreEqual(i, sr.GetRandomBytes(i).Length);
                }
            }
        }

        [TestMethod]
        public void DefaultRNGTest()
        {
            for (int i = 0; i < 32; i++)
            {
                Assert.AreEqual(i, RandomGenerator.Default.RandomBinString(i).Length);
            }
        }
    }
}
