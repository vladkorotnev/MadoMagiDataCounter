using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCounterCommon.Elements
{
    public class Extractor : Source<bool>, ISink<int>
    {
        public int BitNumber { get; set; }
        public bool ActiveHigh { get; set; }

        public Extractor() { }
        public Extractor(int bitNo) : this()
        {
            BitNumber = bitNo;
        }

        private bool haveOldBitState = false;
        private bool oldBitState = false;

        public void Signal(int data)
        {
            if (!haveOldBitState)
            {
                oldBitState = !ActiveHigh;
                haveOldBitState = true;
            }

            bool newBitState = (data & (1 << BitNumber)) != 0;
            if (newBitState != oldBitState)
            {
                NotifySinks(ActiveHigh ? newBitState : !newBitState);
            }
            oldBitState = newBitState;
        }
    }

    public class Trigger : SignalSource, ISink<int>
    {
        public int BitNumber { get; set; }
        public bool ActiveHigh { get; set; }

        public Trigger() { }
        public Trigger(int bitNo) : this()
        {
            BitNumber = bitNo;
        }

        private bool haveOldBitState = false;
        private bool oldBitState = false;

        public void Signal(int data)
        {
            if(!haveOldBitState)
            {
                oldBitState = !ActiveHigh;
                haveOldBitState = true;
            }

            bool newBitState = (data & (1 << BitNumber)) != 0;
            if (newBitState == !ActiveHigh && newBitState != oldBitState)
            {
                NotifySinks();
            }
            oldBitState = newBitState;
        }
    }
}
