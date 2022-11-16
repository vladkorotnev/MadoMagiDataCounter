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

        private Timer gameCountTimer = new Timer();
        private Timer payoutTimer = new Timer();
        private int gameCountBetDelta = 0;
        private const int BET_OF_ONE_GAME = 3;

        public MagiCounter()
        {
            State = new MagiCounterValues();
            Timer = new MagiCounterTimes();
            History = new MagiBonusHistoryController();
            
            gameCountTimer.Enabled = false;
            gameCountTimer.Interval = 300;
            gameCountTimer.AutoReset = false;
            gameCountTimer.Elapsed += SpinCountTimer_Elapsed;

            payoutTimer.Enabled = false;
            payoutTimer.Interval = 300;
            payoutTimer.AutoReset = false;
            payoutTimer.Elapsed += PayoutTimer_Elapsed;
        }

        private void PayoutTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            History.Record(MagiEventType.Payout, State.GameCount, State.Credits, State.Payouts);
            payoutTimer.Stop();
        }

        private void SpinCountTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Only count a spin with a bet of 3 as one game
            // Reason: within bonus mode the bet is 2 or 1
            if(gameCountBetDelta == BET_OF_ONE_GAME)
            {
                State.GameCount++;
            }

            State.SpinCount++;
            History.Record(MagiEventType.GameStart, State.GameCount, State.Credits, State.Payouts);
            gameCountTimer.Stop();
            gameCountBetDelta = 0;
        }

        public void Reset()
        {
            State.ResetAll();
            Timer.ResetAll();
            History.Reset();
            gameCountTimer.Stop();
            payoutTimer.Stop();
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
                                History.Record(MagiEventType.BigBonus, State.GameCount, State.Credits, State.Payouts);
                                State.BigBonus++;
                                State.GameCount = 0;
                                State.SpinCount = 0;
                                break;

                            case 2:
                                State.UnknownBonus++;
                                break;

                            case 3:
                                History.Record(MagiEventType.RegularBonus, State.GameCount, State.Credits, State.Payouts);
                                State.SmallBonus++;
                                State.GameCount = 0;
                                State.SpinCount = 0;
                                break;

                            case 4:
                                // unused;
                                break;

                            case 5:
                                State.Payouts++;
                                payoutTimer.Stop();
                                payoutTimer.Start();
                                break;

                            case 6:
                                State.UnknownCounter++;
                                break;

                            case 7:
                                State.Credits++;
                                gameCountBetDelta++;
                                Timer.StartCountingIfNeeded();
                                gameCountTimer.Stop();
                                gameCountTimer.Start();
                                break;
                        }
                    }
                }

                lastData = data;
            }
        }
    }
}
