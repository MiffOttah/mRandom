using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MiffTheFox.mRandom.Tests
{
    [TestClass]
    public class SamplingTests
    {
        const int ITERATIONS = 2000;

        [TestMethod]
        public void BinStringSamplingTest()
        {
            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                Assert.AreEqual(BinString.Empty, r.RandomBinString(0));

                for (int i = 1; i < 20; i++)
                {
                    Assert.AreEqual(i, r.RandomBinString(i).Length);
                }
            }
        }

        [TestMethod]
        public void IntegerSamplingTest()
        {
            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                for (int i = 0; i < ITERATIONS; i++)
                {
                    Assert.IsTrue(r.RandomInt32() >= 0);
                    Assert.IsTrue(r.RandomInt64() >= 0);
                }
            }
        }

        [TestMethod]
        public void FloatingPointSamplingTest()
        {
            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                float f;
                double d;
                for (int i = 0; i < ITERATIONS; i++)
                {
                    f = r.RandomSingle();
                    Assert.IsTrue(f >= 0.0);
                    Assert.IsTrue(f < 1.0);

                    d = r.RandomDouble();
                    Assert.IsTrue(d >= 0.0);
                    Assert.IsTrue(d < 1.0);
                }
            }
        }

        [TestMethod]
        public void IntegerRangeTest()
        {
            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                for (int i = 0; i < ITERATIONS; i++)
                {
                    int maxInt = (i + 2) * 5;
                    int randInt = r.RandomLessThan(maxInt);
                    Assert.IsTrue(randInt >= 0);
                    Assert.IsTrue(randInt < maxInt);

                    long maxLong = (i + 2) * 5 << 32;
                    long randLong = r.RandomLessThan(maxLong);
                    Assert.IsTrue(randLong >= 0);
                    Assert.IsTrue(randLong < maxLong);
                }

                for (int i = 0; i < ITERATIONS; i++)
                {
                    int minInt = i * -5;
                    int maxInt = i * 5;

                    int randInt = r.RandomBetweenInclusive(minInt, maxInt);
                    Assert.IsTrue(randInt <= maxInt);
                    Assert.IsTrue(randInt >= minInt);
                }
            }
        }
    }
}
