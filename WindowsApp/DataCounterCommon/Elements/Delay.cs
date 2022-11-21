using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataCounterCommon.Elements
{
    public class Extractor: Source<Signal>, ISink<int>
    {
        public int BitNumber { get; set; }
        public bool ActiveHigh { get; set; }

        public Extractor() { }
        public Extractor(int bitNo): this()
        {
            BitNumber = bitNo;
        }


        public void Signal(int data)
        {
            bool newBitState = (data & (1 << BitNumber)) != 0;
            if(newBitState == !ActiveHigh)
            {
                NotifySinks(DataCounterCommon.Signal.v);
            }
        }
    }

    public class Threshold: Source<Signal>, ISink<Signal>
    {
        public double Delay { 
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }
        public int Divisor { get; set; }
        public bool OneShot { get; set; }

        private Timer timer = new Timer();
        private int count = 0;

        public Threshold(int divisor = 1, bool oneShot = true, double delay = 250)
        {
            Divisor = divisor;
            Delay = delay;
            OneShot = oneShot;
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = false;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(OneShot)
            {
                if(count >= Divisor)
                {
                    NotifySinks(DataCounterCommon.Signal.v);
                }
            } 
            else
            {
                while (count >= Divisor)
                {
                    NotifySinks(DataCounterCommon.Signal.v);
                    count -= Divisor;
                }
            }
            count = 0;
            timer.Stop();
        }

        public void Signal(Signal _)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
