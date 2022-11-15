using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoMagiDataCounter
{
    enum MagiBonusType
    {
        Big,
        Regular
    }

    class MagiBonusHistoryEntry
    {
        public MagiBonusType BonusType { get; private set; }
        public int GamesNeeded { get; private set; }
        public int CoinDelta { get; private set; }

        internal MagiBonusHistoryEntry(MagiBonusType type, int games, int credits, int payouts)
        {
            BonusType = type;
            GamesNeeded = games;
            CoinDelta = payouts - credits;
        }
    }

    class MagiBonusHistoryController
    {
        private int lastCredits = 0;
        private int lastPayouts = 0;


        public List<MagiBonusHistoryEntry> BonusHistory { get; private set; }
        public int LastCredits { get { return lastCredits; } }
        public int LastPayouts { get { return lastPayouts; } }

        public event EventHandler<MagiBonusHistoryEntry> NewHistoryItem;


        public MagiBonusHistoryController()
        {
            BonusHistory = new List<MagiBonusHistoryEntry>();
        }

        public void Reset()
        {
            lastCredits = 0;
            lastPayouts = 0;
            BonusHistory.Clear();
        }

        public void Record(MagiBonusType bonus, int currentSpins, int currentCredits, int currentPayouts)
        {
            var historyItem = new MagiBonusHistoryEntry(bonus, currentSpins, currentCredits - lastCredits, currentPayouts - lastPayouts);
            lastCredits = currentCredits;
            lastPayouts = currentPayouts;
            BonusHistory.Add(historyItem);
            NewHistoryItem.Invoke(this, historyItem);
        }
    }
}
