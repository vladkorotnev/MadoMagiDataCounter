using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataCounterCommon;
using DataCounterCommon.Elements;

namespace MadoMagiDataCounter
{
    class RatioCalculator
    {
        public Memory<int> inCredits { get; private set; }
        public Memory<int> inPayouts { get; private set; }

        public Relay<double> outRatio { get; private set; }
        public Relay<int> outBalance { get; private set; }

        public RatioCalculator()
        {
            inCredits = new Memory<int>();
            inPayouts = new Memory<int>();
            outRatio = new Relay<double>();
            outBalance = new Relay<int>();

            var x = new ActionReceiver<int>(new Action<int>(delegate (int _)
            {
                var credits = inCredits.LastValue;
                var payouts = inPayouts.LastValue;
                if (credits != 0)
                {
                    outRatio.Signal(((double)payouts) / ((double)credits));
                }
                outBalance.Signal(payouts - credits);
            }));

            inCredits.Connect(x);
            inPayouts.Connect(x);
        }
    }


    class DataCounterCircuit: CounterCircuit, IResetable
    {
        private Resetter _globalReset = new Resetter();
        private const int BET_OF_ONE_GAME = 3; // credits per normal game

        public Relay<int> Credits { get; private set; }
        public SignalRelay CreditPulse { get; private set; }
        public Relay<int> Payout { get; private set; }

        public SignalRelay BigBonusPulse { get; private set; }
        public Relay<int> BigBonus { get; private set; }
        public SignalRelay RegularBonusPulse { get; private set; }
        public Relay<int> RegularBonus { get; private set; }

        public Relay<int> Spins { get; private set; }
        public Relay<int> Games { get; private set; }
        public SignalRelay SpinPulse { get; private set; }
        public SignalRelay GamePulse { get; private set; }

        public Relay<bool> Alarm { get; private set; }

        public Relay<TimeSpan> WallTime { get; private set; }


        public DataCounterCircuit(): base() {
            // Create the primary signals that the slot machine provides us with
            var creditPulse = new Trigger(7);
            var payoutPulse = new Trigger(5);
            var regBonusPulse = new Trigger(3);
            var bigBonusPulse = new Trigger(1);
            var alarmSignal = new Extractor(0);
            InputNub.Connect(
                    creditPulse,
                    payoutPulse,
                    regBonusPulse,
                    bigBonusPulse,
                    alarmSignal
            );

            // Expose some signals directly
            RegularBonusPulse = new SignalRelay();
            regBonusPulse.Connect(RegularBonusPulse);
            BigBonusPulse = new SignalRelay();
            bigBonusPulse.Connect(BigBonusPulse);
            Alarm = new Relay<bool>();
            alarmSignal.Connect(Alarm);
            CreditPulse = new SignalRelay();
            creditPulse.Connect(CreditPulse);

            // Create the main counters
            var creditCounter = new Counter();
            creditPulse.Connect(creditCounter);
            var payoutCounter = new Counter();
            payoutPulse.Connect(payoutCounter);
            var bigBonusCounter = new Counter();
            bigBonusPulse.Connect(bigBonusCounter);
            var regBonusCounter = new Counter();
            regBonusPulse.Connect(regBonusCounter);

            // Wire up the reset signal
            _globalReset.Connect(
                creditCounter,
                payoutCounter,
                bigBonusCounter,
                regBonusCounter
            );

            // Expose the main counters
            Credits = new Relay<int>();
            Payout = new Relay<int>();
            BigBonus = new Relay<int>();
            RegularBonus = new Relay<int>();
            creditCounter.Connect(Credits);
            payoutCounter.Connect(Payout);
            bigBonusCounter.Connect(BigBonus);
            regBonusCounter.Connect(RegularBonus);

            // Infer a SPIN by delaying after a bunch of credit pulses
            var spinPulse = new Threshold();
            creditPulse.Connect(spinPulse);
            var spinCounter = new Counter();
            _globalReset.ConnectReceiver(spinCounter);
            spinPulse.Connect(spinCounter);
            // Expose the counter and pulse
            Spins = new Relay<int>();
            spinCounter.Connect(Spins);
            SpinPulse = new SignalRelay();
            spinPulse.Connect(SpinPulse);

            // Infer a GAME by checking that we spent exactly N credits
            var gamePulse = new Threshold(BET_OF_ONE_GAME);
            creditPulse.Connect(gamePulse);
            var gameCounter = new Counter();
            _globalReset.ConnectReceiver(gameCounter);
            gamePulse.Connect(gameCounter);
            // Expose the counter and pulse
            Games = new Relay<int>();
            gameCounter.Connect(Games);
            GamePulse = new SignalRelay();
            gamePulse.Connect(GamePulse);

            // Reset the game and spin counters some time after the bonus has hit
            var bonusResetDelay = new Threshold(1, true, 250);
            bigBonusPulse.Connect(bonusResetDelay);
            regBonusPulse.Connect(bonusResetDelay);
            var bonusResetSignal = new Resetter();
            bonusResetSignal.Connect(gameCounter, spinCounter);
            bonusResetDelay.Connect(bonusResetSignal);

            // Create a wall clock that starts with the first spin
            var clock = new TimeCounter();
            _globalReset.ConnectReceiver(clock);
            WallTime = new Relay<TimeSpan>();
            clock.Connect(WallTime);
            gamePulse.Connect(clock);
        }

        public void Reset()
        {
            _globalReset.Signal();
        }
    }
}
