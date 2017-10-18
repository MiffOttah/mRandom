using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom
{
    public class SampleFromEmptinessException : InsufficientDataToSampleFromException
    {
        public SampleFromEmptinessException() : base("Cannot sample from an empty source.")
        {
        }
    }

    public class InsufficientDataToSampleFromException : InvalidOperationException
    {
        public InsufficientDataToSampleFromException() : base("There is not sufficent data in the source to take the requested amount of samples.")
        {
        }

        protected InsufficientDataToSampleFromException(string message) : base(message)
        {
        }
    }
}
