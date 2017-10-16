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
    }
}
