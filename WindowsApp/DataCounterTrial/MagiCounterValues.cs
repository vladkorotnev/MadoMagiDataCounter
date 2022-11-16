using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoMagiDataCounter
{
    class MagiCounterTimes
    {
        public DateTime GameStartDate { get; private set; }

        private TimeSpan ElapsedFrom(DateTime time)
        {
            var now = DateTime.Now;
            if (time == DateTime.MaxValue || time > now) return TimeSpan.Zero;
            return now.Subtract(time);
        }

        public TimeSpan TotalElapsed {  get { return ElapsedFrom(GameStartDate); } }

        public MagiCounterTimes()
        {
            ResetAll();
        }

        public void ResetAll()
        {
            GameStartDate = DateTime.MaxValue;
        }

        public void StartCountingIfNeeded()
        {
            if (GameStartDate < DateTime.Now) return;
            GameStartDate = DateTime.Now;
        }
    }


    class MagiCounterValues
    {
        public int Credits { get; set; }
        public int Payouts { get; set; }
        public int SmallBonus { get; set; }
        public int BigBonus { get; set; }
        public int UnknownBonus { get; set; }
        public int UnknownCounter { get; set; }
        public bool Alert { get; set; }
        public int GameCount { get; set; }
        public int SpinCount { get; set; }
        public double ReturnRatio
        {
            get
            {
                if (Credits == 0) return 1.0;
                return ((double)Payouts / (double)Credits);
            }
        }

        public void ResetAll()
        {
            Credits = 0;
            Payouts = 0;
            SmallBonus = 0;
            BigBonus = 0;
            GameCount = 0;
            SpinCount = 0;
            Alert = false;
        }
    }
}
