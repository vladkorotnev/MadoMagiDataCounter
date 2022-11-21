using DataCounterCommon;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyInterface
{
    public class Demo : Source<int>, ICounterInput
    {
        private enum DemoState
        {
            Playing,
            BigBonus,
            RegularBonus
        }

        [Flags]
        private enum DemoPinAssign
        {
            Alarm = 1 << 0,
            BigBonus = 1 << 1,
            RegularBonus = 1 << 3,
            Payout = 1 << 5,
            Credit = 1 << 7
        }

        public Demo()
        {
            State = CounterInputState.Ready;
        }

        private Thread _demoThread = null;

        public CounterInputState State { get; private set; }

        public string Name => "Demo";

        public Control GetSettingsPanel() => null;

        public void Start()
        {
            State = CounterInputState.Running;
            _demoThread = new Thread(new ThreadStart(DemoLoop));
            _demoThread.Start();
        }

        public void Stop()
        {
            State = CounterInputState.Ready;
        }

        private void DemoLoop()
        {
            var r = new Random();
            var demoState = DemoState.Playing;
            var gamesCount = 0;
            var bonusDoseAmt = 14;
            var bonusAmt = 0;

            while (State == CounterInputState.Running)
            {
                switch(demoState)
                {
                    case DemoState.Playing:
                        BlinkBit(DemoPinAssign.Credit, 3);
                        gamesCount++;
                        Thread.Sleep(300);

                        var rand = r.Next(0, Convert.ToInt32(1000.0d * Math.Min(1.0d, (double)gamesCount / 20.0d)));
                        var isWin = rand >= 600;
                        var isRB = rand >= 760;
                        var isBB = rand >= 870;
                        Debug.Print("CHOICE={0} GC={1}", rand, gamesCount);

                        if (isWin)
                        {
                            var winAmount = r.Next(3, 6);
                            Debug.Print("WIN={0}", winAmount);
                            BlinkBit(DemoPinAssign.Payout, winAmount);
                        }

                        if(isBB)
                        {
                            demoState = DemoState.BigBonus;
                            bonusAmt = r.Next(299, 499);
                        } 
                        else if (isRB)
                        {
                            demoState = DemoState.RegularBonus;
                            bonusAmt = r.Next(50, 150);
                        }
                        break;

                    case DemoState.RegularBonus:
                        BlinkBit(DemoPinAssign.Credit);
                        goto case DemoState.BigBonus;

                    case DemoState.BigBonus:
                        BlinkBit(DemoPinAssign.Credit);
                        Thread.Sleep(500);
                        var winAmt = Math.Min(bonusAmt, bonusDoseAmt);
                        bonusAmt -= winAmt;
                        BlinkBit(DemoPinAssign.Payout, winAmt);
                        if(bonusAmt <= 0)
                        {
                            BlinkBit(demoState == DemoState.BigBonus ? DemoPinAssign.BigBonus : DemoPinAssign.RegularBonus);
                            demoState = DemoState.Playing;
                            gamesCount = 0;
                        }
                        break;
                }
                Thread.Sleep(300);
            }
        }

        private void BlinkBit(DemoPinAssign bit, int times = 1)
        {
            int _demoOutputState = 0xFF;
            for (int i = 0; i < times; i++)
            {
                _demoOutputState &= ~(int)bit;
                NotifySinks(_demoOutputState);
                Thread.Sleep(50);
                _demoOutputState |= (int)bit;
                NotifySinks(_demoOutputState);
            }
        }
    }
}
