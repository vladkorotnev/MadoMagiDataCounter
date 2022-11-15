using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MadoMagiDataCounter
{
    class MagiCounter
    {
        private int lastData = 0xFF;
        public MagiCounterValues State { get; private set; }
        public MagiCounterTimes Timer { get; private set; }
        public MagiBonusHistoryController History { get; private set; }
        private Timer spinCountTimer = new Timer();

        public MagiCounter()
        {
            State = new MagiCounterValues();
            Timer = new MagiCounterTimes();
            History = new MagiBonusHistoryController();
            
            spinCountTimer.Enabled = false;
            spinCountTimer.Interval = 300;
            spinCountTimer.AutoReset = false;
            spinCountTimer.Elapsed += SpinCountTimer_Elapsed;
        }

        private void SpinCountTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            State.SpinCount++;
            spinCountTimer.Stop();
        }

        public void Reset()
        {
            State.ResetAll();
            Timer.ResetAll();
            History.Reset();
            spinCountTimer.Stop();
        }

        public void ReceiveDataByte(int data)
        {
            if (data != lastData)
            {
                State.Alert = (data & (1 << 0)) == 0;

                int nowMask = 0;
                for (int i = 1; i < 8; i++)
                {
                    nowMask = 1 << i;
                    bool inLastFrame = (lastData & nowMask) > 0;
                    bool inNewFrame = (data & nowMask) > 0;
                    // Sense rising edge
                    if (!inLastFrame && inNewFrame)
                    {
                        switch(i)
                        {
                            case 1:
                                History.Record(MagiBonusType.Big, State.SpinCount, State.Credits, State.Payouts);
                                State.BigBonus++;
                                State.SpinCount = 0;
                                break;

                            case 2:
                                State.UnknownBonus++;
                                break;

                            case 3:
                                History.Record(MagiBonusType.Regular, State.SpinCount, State.Credits, State.Payouts);
                                State.SmallBonus++;
                                State.SpinCount = 0;
                                break;

                            case 4:
                                // unused;
                                break;

                            case 5:
                                State.Payouts++;
                                break;

                            case 6:
                                State.UnknownCounter++;
                                break;

                            case 7:
                                State.Credits++;
                                Timer.StartCountingIfNeeded();
                                spinCountTimer.Stop();
                                spinCountTimer.Start();
                                break;
                        }
                    }
                }

                lastData = data;
            }
        }
    }
}
