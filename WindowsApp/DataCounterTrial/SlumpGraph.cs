using DataCounterCommon;
using DataCounterCommon.Elements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadoMagiDataCounter
{
    public partial class SlumpGraph : UserControl, IResetable
    {
        public Memory<int> inSpins { get; private set; }
        public Memory<int> inGames { get; private set; }
        public Memory<int> inBalance { get; private set; }
        public SignalRelay inBigBonus { get; private set; }
        public SignalRelay inRegBonus { get; private set;  }
        public SignalRelay inNextPoint { get; private set; }

        public SlumpGraph()
        {
            InitializeComponent();

            inNextPoint = new SignalRelay();
            inBalance = new Memory<int>();
            inBigBonus = new SignalRelay();
            inRegBonus = new SignalRelay();
            inSpins = new Memory<int>();
            inGames = new Memory<int>();

            var createNextDot = new ActionReceiver(new Action(delegate ()
            {
                var x = new Action(() =>
                {
                    chartMoney.Series[0].Points.AddXY(chartMoney.Series[0].Points.Count, inBalance.LastValue);
                });
                if (InvokeRequired) Invoke(x);
                else x();
            }));
            inNextPoint.ConnectReceiver(createNextDot);

            var updateCurrentDotPosition = new ActionReceiver<int>(new Action<int>(delegate (int balance)
            {
                var x = new Action(() =>
                {
                    var index = chartMoney.Series[0].Points.Count - 1;
                    if (index < 0) return;
                    chartMoney.Series[0].Points[index].SetValueY(balance);
                    chartMoney.ChartAreas[0].RecalculateAxesScale();
                });
                if (InvokeRequired) Invoke(x);
                else x();
            }));
            inBalance.ConnectReceiver(updateCurrentDotPosition);

            var placeRegBonusDot = new ActionReceiver(new Action(delegate ()
            {
                var x = new Action(() =>
                {
                    PlaceBonusDot(Color.Red, "RB");
                });
                if (InvokeRequired) Invoke(x);
                else x();
            }));
            inRegBonus.ConnectReceiver(placeRegBonusDot);

            var placeBigBonusDot = new ActionReceiver(new Action(delegate ()
            {
                var x = new Action(() =>
                {
                    PlaceBonusDot(Color.Gold, "BB");
                });
                if (InvokeRequired) Invoke(x);
                else x();
            }));
            inBigBonus.ConnectReceiver(placeBigBonusDot);
        }

        private void PlaceBonusDot(Color color, string label)
        {
            int moneyIdx = chartMoney.Series[0].Points.Count - 1 - inSpins.LastValue + inGames.LastValue;
            int newIdx = chartMoney.Series[1].Points.AddXY(moneyIdx, chartMoney.Series[0].Points[moneyIdx].YValues[0]);
            chartMoney.Series[1].Points[newIdx].Color = color;
            chartMoney.Series[1].Points[newIdx].Label = label;
        }

        public void Reset()
        {
            chartMoney.Series[0].Points.Clear();
            chartMoney.Series[0].Points.AddXY(0,0);
            chartMoney.Series[1].Points.Clear();
        }
    }
}
