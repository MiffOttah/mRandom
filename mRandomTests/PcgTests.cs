using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MiffTheFox.mRandom.Tests
{
    [TestClass]
    public class PcgTests
    {
        [TestMethod]
        public void BasicTest()
        {
            using (var r = new RandomGenerator(new PcgRandom.Pcg32RandomnessSource()))
            {
                Assert.AreEqual(BinString.Empty, r.RandomBinString(0));

                for (int i = 1; i < 20; i++)
                {
                    Assert.AreEqual(i, r.RandomBinString(i).Length);
                }
            }
        }
    }
}
