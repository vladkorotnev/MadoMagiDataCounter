using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoMagiDataCounter
{
    class MagiCounter
    {
        private int lastData = 0xFF;
        public MagiCounterValues State { get; private set; }
        public MagiCounterTimes Timer { get; private set; }

        public MagiCounter()
        {
            State = new MagiCounterValues();
            Timer = new MagiCounterTimes();
        }

        public void Reset()
        {
            State.ResetAll();
            Timer.ResetAll();
        }

        public void ReceiveDataByte(int data)
        {
            if (data != lastData)
            {
                State.Alert = (data & (1 << 0)) > 0;

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
                                State.BigBonus++;
                                Timer.BonusHappened(true);
                                break;

                            case 2:
                                State.UnknownBonus++;
                                break;

                            case 3:
                                State.SmallBonus++;
                                Timer.BonusHappened(false);
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
                                break;
                        }
                    }
                }

                lastData = data;
            }
        }
    }
}
