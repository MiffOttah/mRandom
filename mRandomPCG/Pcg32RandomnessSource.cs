using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiffTheFox.mRandom.PcgRandom
{
    public class Pcg32RandomnessSource : IRandomnessSource
    {
        private bool _Disposed = false;
        private BinString _Buffer = BinString.Empty;
        private ulong _State;
        private ulong _Sequence;

        public Pcg32RandomnessSource()
        {
            _Seed((ulong)Environment.TickCount, (ulong)DateTime.Now.Ticks);
        }

        public Pcg32RandomnessSource(ulong initState, ulong initSequence)
        {
            _Seed(initState, initSequence);
        }

        private void _Seed(ulong initState, ulong initSequence)
        {
            _State = 0;
            _Sequence = (initSequence << 1) | 1;
            _Sample();
            _State += initState;
            _Sample();
        }

        private static ulong _ConvertTo32Bit(ulong value, int shift)
        {
            return ((value >> shift) & uint.MaxValue);
        }

        private uint _Sample()
        {
            const ulong MAGIC = 6364136223846793005;
            ulong oldstate = _State;
            _State = oldstate * MAGIC + _Sequence;
            ulong xorshifted = _ConvertTo32Bit((oldstate >> 18) ^ oldstate, 27);
            int rot = (int)_ConvertTo32Bit(oldstate, 59);
            int complement = -rot & 31;
            return (uint)((xorshifted << rot) | (xorshifted >> complement));
        }

        public BinString GetRandomBytes(int length)
        {
            if (_Disposed) throw new ObjectDisposedException(null);

            // if there isn't enough data in the buffer, generate some
            if (_Buffer.Length < length)
            {
                int iterations = length / 4 + 1;
                var builder = new BinStringBuilder(_Buffer.Length + iterations * 4);
                builder.Append(_Buffer);

                for (int i = 0; i < iterations; i++)
                {
                    builder.Append(BitConverter.GetBytes(_Sample()));
                }

                _Buffer = builder.ToBinString();
            }

            var r = _Buffer.Substring(0, length);
            _Buffer = _Buffer.Substring(length);
            return r;
        }

        public void Dispose()
        {
            if (!_Disposed)
            {
                _Buffer = null;
                _Disposed = true;
            }
        }
    }
}
