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
        public DateTime LastBigBonus { get; private set; }
        public DateTime LastSmallBonus { get; private set; }

        private TimeSpan ElapsedFrom(DateTime time)
        {
            var now = DateTime.Now;
            if (time == DateTime.MaxValue || time > now) return TimeSpan.Zero;
            return now.Subtract(time);
        }

        public TimeSpan TotalElapsed {  get { return ElapsedFrom(GameStartDate); } }
        public TimeSpan SinceLastBigBonus {  get { return ElapsedFrom(LastBigBonus); } }
        public TimeSpan SinceLastSmallBonus {  get { return ElapsedFrom(LastSmallBonus); } }
        public TimeSpan SinceAnyBonus { get { return ElapsedFrom(LastBigBonus > LastSmallBonus ? LastBigBonus : LastSmallBonus); } }

        public MagiCounterTimes()
        {
            ResetAll();
        }

        public void ResetAll()
        {
            GameStartDate = DateTime.MaxValue;
            LastBigBonus = DateTime.MaxValue;
            LastSmallBonus = DateTime.MaxValue;
        }

        public void StartCountingIfNeeded()
        {
            if (GameStartDate < DateTime.Now) return;
            GameStartDate = DateTime.Now;
        }

        public void BonusHappened(bool isBig)
        {
            if (isBig) LastBigBonus = DateTime.Now;
            else LastSmallBonus = DateTime.Now;
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

        public double ReturnRatio
        {
            get
            {
                return ((double)Payouts / (double)Credits);
            }
        }

        public void ResetAll()
        {
            Credits = 0;
            Payouts = 0;
            SmallBonus = 0;
            BigBonus = 0;
            Alert = false;
        }
    }
}
