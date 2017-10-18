using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    partial class RandomGenerator
    {
        private static IList<T> _CollapseToList<T>(IEnumerable<T> source)
        {
            // If source isn't an IList<T>, enumerate it and make it an array
            if (source is IList<T> sourceList) return sourceList;
            return source.ToArray();
        }

        public T Pick<T>(IEnumerable<T> source)
        {
            var sourceList = _CollapseToList(source);
            if (sourceList.Count == 0) throw new SampleFromEmptinessException();
            if (sourceList.Count == 1) return sourceList[0];

            int choice = RandomLessThan(sourceList.Count);
            return sourceList[choice];
        }

        public T[] Shuffle<T>(IEnumerable<T> source)
        {
            var sourceList = _CollapseToList(source);
            int[] selections = Enumerable.Range(0, sourceList.Count).ToArray();
            int j, temp;

            for (int i = selections.Length - 1; i >= 0; i--)
            {
                j = RandomBetweenInclusive(0, i);
                if (j != i)
                {
                    temp = selections[j];
                    selections[j] = selections[i];
                    selections[i] = temp;
                }
            }

            var result = new T[selections.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = sourceList[selections[i]];
            }
            return result;
        }

        public T[] SampleWithoutReplacement<T>(IEnumerable<T> source, int samples)
        {
            if (samples <= 0) throw new ArgumentException("Must take 1 or more samples.");
                    
            var shuffled = Shuffle(source);
            if (samples > shuffled.Length) throw new InsufficientDataToSampleFromException();
            if (samples == shuffled.Length) return shuffled;

            var result = new T[samples];
            Array.Copy(shuffled, result, samples);
            return result;
        }
    }
}
