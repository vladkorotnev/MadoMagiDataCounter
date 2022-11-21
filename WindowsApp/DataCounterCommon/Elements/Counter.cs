using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCounterCommon.Elements
{
    public class Counter: Source<int>, ISignalSink, IResetable
    {
        private int _count = 0;
        public int Value
        {
            get { return _count; }
        }

        public void Signal()
        {
            _count++;
            NotifySinks(_count);
        }

        public void Reset()
        {
            _count = 0;
            NotifySinks(_count);
        }
    }
}
