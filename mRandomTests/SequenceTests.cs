using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom.Tests
{
    [TestClass]
    public class SequenceTests
    {
        const int ITERATIONS = 800;

        [TestMethod]
        public void PickTest()
        {
            var source = new string[] { "This", "Is", "Some", "String", "Data", "123", "456" };

            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                for (int i = 0; i < ITERATIONS; i++)
                {
                    CollectionAssert.Contains(source, r.Pick(source));
                }
            }
        }

        [TestMethod]
        public void ShuffleTest()
        {
            var source = new string[] { "This", "Is", "Some", "String", "Data", "123", "456" };

            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                for (int i = 0; i < ITERATIONS; i++)
                {
                    CollectionAssert.AreEquivalent(source, r.Shuffle(source));
                }
            }
        }

        [TestMethod]
        public void SampleTest()
        {
            var source = new string[] { "This", "Is", "Some", "String", "Data", "123", "456" };

            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                for (int i = 0; i < ITERATIONS; i++)
                {
                    var samples = r.SampleWithoutReplacement(source, 3);
                    CollectionAssert.AllItemsAreUnique(samples);
                    foreach (var sample in samples)
                    {
                        CollectionAssert.Contains(source, sample);
                    }
                }
            }
        }

        [TestMethod]
        public void BadPickTest()
        {
            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                Assert.ThrowsException<SampleFromEmptinessException>(() => r.Pick(Enumerable.Empty<object>()));

                var someData = new int[] { 1, 2 };
                Assert.ThrowsException<InsufficientDataToSampleFromException>(() => r.SampleWithoutReplacement(someData, 6));
            }
        }

        [TestMethod]
        public void WeightedSamplingTest()
        {
            using (var r = new RandomGenerator(new SystemRandomRandomnessSource()))
            {
                var samples = new WeightedSampling<string>
                {
                    { "Common", 0.8 },
                    { "Rare1", 0.1 },
                    { "Rare2", 0.1 }
                };
                var results = new List<string>(ITERATIONS);

                for (int i = 0; i < ITERATIONS; i++)
                {
                    results.Add(samples.Sample(r));
                }

                Assert.IsTrue(results.Count(res => res == "Common") >= (results.Count / 2));
            }
        }
    }
}
