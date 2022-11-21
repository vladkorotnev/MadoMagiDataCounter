using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DataCounterCommon.Elements
{
    public class TimeCounter: Source<TimeSpan>, IResetable, ISignalSink
    {
        private bool _running = false;
        private Timer _timer = new Timer();
        private DateTime _startTime = DateTime.MaxValue;

        public TimeCounter(double interval = 500)
        {
            _timer.Interval = interval;
            _timer.AutoReset = true;
            _timer.Stop();
            _timer.Elapsed += OnTick;
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            NotifySinks(DateTime.Now - _startTime);
        }

        public void Signal()
        {
            if (_running) return;
            _running = true;
            _startTime = DateTime.Now;
            _timer.Start();
        }

        public void Reset()
        {
            _running = false;
            _timer.Stop();
            NotifySinks(TimeSpan.Zero);
        }
    }
}
