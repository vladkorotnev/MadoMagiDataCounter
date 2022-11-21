using DataCounterCommon;
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
    public partial class BarGraph : UserControl, IResetable
    {
        public Memory<int> inGames { get; private set; }
        public SignalRelay inBigBonus { get; private set; }
        public SignalRelay inRegBonus { get; private set; }

        public BarGraph()
        {
            inGames = new Memory<int>();
            inBigBonus = new SignalRelay();
            inRegBonus = new SignalRelay();

            var markBigBonus = new ActionReceiver(new Action(delegate ()
            {
                var x = new Action(() => MarkBonus(true));
                if (InvokeRequired) Invoke(x);
                else x();
            }));
            inBigBonus.ConnectReceiver(markBigBonus);

            var markRegBonus = new ActionReceiver(new Action(delegate ()
            {
                var x = new Action(() => MarkBonus(false));
                if (InvokeRequired) Invoke(x);
                else x();
            }));
            inRegBonus.ConnectReceiver(markRegBonus);


            var updateGameCount = new ActionReceiver<int>(new Action<int>(delegate (int gameCount)
            {
                var x = new Action(() =>
                {
                    chartBonuses.Series[0].Points.RemoveAt(0);
                    chartBonuses.Series[0].Points.InsertY(0, gameCount);
                    chartBonuses.ChartAreas[0].RecalculateAxesScale();
                    chartBonuses.Update();
                });
                if (InvokeRequired) Invoke(x);
                else x();
            }));
            inGames.ConnectReceiver(updateGameCount);

            InitializeComponent();
        }

        private void MarkBonus(bool isBig)
        {
            chartBonuses.Series[0].Points.RemoveAt(0);
            chartBonuses.Series[0].Points.InsertY(0, 0);
            chartBonuses.Series[0].Points.InsertY(1, inGames.LastValue);
            chartBonuses.Series[1].Points.InsertY(1, isBig ? 1 : 0);
            chartBonuses.Series[2].Points.InsertY(1, isBig ? 0 : 1);
            chartBonuses.ChartAreas[0].RecalculateAxesScale();
            chartBonuses.Update();
        }

        public void Reset()
        {
            chartBonuses.Series[0].Points.Clear();
            chartBonuses.Series[0].Points.AddY(0);
            chartBonuses.Series[1].Points.Clear();
            chartBonuses.Series[1].Points.AddY(0);
            chartBonuses.Series[2].Points.Clear();
            chartBonuses.Series[2].Points.AddY(0);
        }
    }
}
