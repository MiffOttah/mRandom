using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    /// <summary>
    /// A list of items where each item has an associated weight that can be used to take a weighted random sample.
    /// </summary>
    /// <typeparam name="T">The type of items for sampling from.</typeparam>
    public class WeightedSampling<T> : ICollection<WeightedSamplingItem<T>>
    {
        private readonly List<WeightedSamplingItem<T>> _Items = new List<WeightedSamplingItem<T>>();
        public int Count => _Items.Count;
        public bool IsReadOnly => false;

        public void Add(WeightedSamplingItem<T> item)
        {
            _Items.Add(item);
        }

        /// <summary>
        /// Adds the item to the sampling with the specified weight.
        /// </summary>
        public void Add(T item, double weight = 1.0)
        {
            Add(new WeightedSamplingItem<T>(item, weight));
        }

        /// <summary>
        /// Removes all items from the sampling.
        /// </summary>
        public void Clear()
        {
            _Items.Clear();
        }

        public bool Contains(WeightedSamplingItem<T> item)
        {
            return _Items.Contains(item);
        }

        public bool Contains(T item)
        {
            return _Items.Any(i => i.ValueEquals(item));
        }

        public void CopyTo(WeightedSamplingItem<T>[] array, int arrayIndex)
        {
            _Items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<WeightedSamplingItem<T>> GetEnumerator()
        {
            return ((ICollection<WeightedSamplingItem<T>>)_Items).GetEnumerator();
        }

        public bool Remove(WeightedSamplingItem<T> item)
        {
            return _Items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<WeightedSamplingItem<T>>)_Items).GetEnumerator();
        }

        /// <summary>
        /// Randomly selects an item from the sampling. 
        /// </summary>
        /// <param name="rng">The RandomGenerator that makes the selection.</param>
        public T Sample(RandomGenerator rng)
        {
            if (_Items.Count == 1) return _Items[0].Value;
            if (_Items.Count < 1) throw new SampleFromEmptinessException();

            var total = _Items.Sum(i => i.Weight);
            var adjusted = _Items.Select(i => i.Weight / total).ToArray();
            var selection = rng.RandomDouble();
            var accumulated = 0.0;

            for (int i = 0; i < _Items.Count; i++)
            {
                accumulated += adjusted[i];
                if (accumulated >= selection)
                {
                    return _Items[i].Value;
                }
            }

            return _Items[_Items.Count - 1].Value;
        }
    }

    public class WeightedSamplingItem<T>
    {
        public T Value { get; set; }
        public double Weight { get; set; }

        public WeightedSamplingItem(T value, double weight = 1.0)
        {
            Value = value;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Value} (weight {Weight})";
        }

        public override int GetHashCode()
        {
            if (object.ReferenceEquals(Value, null)) return 0;
            return Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is WeightedSamplingItem<T> that)
            {
                if (object.ReferenceEquals(this.Value, null))
                {
                    return object.ReferenceEquals(that.Value, null);
                }
                else
                {
                    return this.Value.Equals(that.Value);
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValueEquals(object obj)
        {
            if (object.ReferenceEquals(Value, null))
            {
                return object.ReferenceEquals(obj, null);
            }
            else
            {
                return Value.Equals(obj);
            }
        }
    }
}
