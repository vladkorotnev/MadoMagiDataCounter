using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataCounterCommon.Elements
{
    public class Cooldown: SignalSource, ISignalSink, IResetable
    {
        public double Delay { get; set; }
        private DateTime _lastEvent = DateTime.MinValue;

        public Cooldown(double delayMs = 500)
        {
            Delay = delayMs;
        }

        public void Signal()
        {
            if((DateTime.Now - _lastEvent).TotalMilliseconds >= Delay)
            {
                NotifySinks();
                _lastEvent = DateTime.Now;
            }
        }

        public void Reset()
        {
            _lastEvent = DateTime.MinValue;
        }
    }
    public class Threshold: SignalSource, ISignalSink, IResetable
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
                    NotifySinks();
                }
            } 
            else
            {
                while (count >= Divisor)
                {
                    NotifySinks();
                    count -= Divisor;
                }
            }
            count = 0;
            timer.Stop();
        }

        public void Signal()
        {
            count += 1;
            timer.Stop();
            timer.Start();
        }

        public void Reset()
        {
            timer.Stop();
            count = 0;
        }
    }
}
