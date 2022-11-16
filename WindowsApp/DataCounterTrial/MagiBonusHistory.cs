using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoMagiDataCounter
{
    enum MagiEventType
    {
        BigBonus,
        RegularBonus,
        GameStart,
        Payout
    }

    class MagiEventHistoryItem
    {
        public MagiEventType EventType { get; private set; }
        public int GamesNeeded { get; private set; }
        public int CoinDelta { get; private set; }

        internal MagiEventHistoryItem(MagiEventType type, int games, int credits, int payouts)
        {
            EventType = type;
            GamesNeeded = games;
            CoinDelta = payouts - credits;
        }
    }

    class MagiBonusHistoryController
    {
        private int lastCredits = 0;
        private int lastPayouts = 0;


        public int LastCredits { get { return lastCredits; } }
        public int LastPayouts { get { return lastPayouts; } }

        public event EventHandler<MagiEventHistoryItem> NewHistoryItem;


        public MagiBonusHistoryController()
        {
        }

        public void Reset()
        {
            lastCredits = 0;
            lastPayouts = 0;
        }

        public void Record(MagiEventType bonus, int currentGames, int currentCredits, int currentPayouts)
        {
            var historyItem = new MagiEventHistoryItem(bonus, currentGames, currentCredits, currentPayouts);
            lastCredits = currentCredits;
            lastPayouts = currentPayouts;
            NewHistoryItem.Invoke(this, historyItem);
        }
    }
}
