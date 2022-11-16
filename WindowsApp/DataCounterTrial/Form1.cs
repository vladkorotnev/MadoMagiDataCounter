using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadoMagiDataCounter
{
    public partial class Form1 : Form
    {
        private MagiCounter viewModel = new MagiCounter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var prefs = Properties.Settings.Default;

            cmbCom.Items.Clear();
            foreach(var i in System.IO.Ports.SerialPort.GetPortNames())
            {
                cmbCom.Items.Add(i);
            }

            if(prefs.LastCOM != null)
            {
                if(!cmbCom.Items.Contains(prefs.LastCOM))
                {
                    cmbCom.Items.Add(prefs.LastCOM);
                }

                cmbCom.SelectedIndex = cmbCom.Items.IndexOf(prefs.LastCOM);
            }

#if DEBUG
            cmbCom.Items.Add("dummy");
#endif

            viewModel.History.NewHistoryItem += OnNewGraphItem;
        }

#if DEBUG
        private void OnDummyByte(object sender, int e)
        {
            viewModel.ReceiveDataByte(e);
            updateValues();
        }
#endif

        private void OnNewGraphItem(object sender, MagiEventHistoryItem e)
        {
            Action x = delegate ()
            {
                if(e.EventType == MagiEventType.BigBonus || e.EventType == MagiEventType.RegularBonus)
                {
                    chartBonuses.Series[0].Points.InsertY(1, e.GamesNeeded);
                    chartBonuses.Series[1].Points.InsertY(1, e.EventType == MagiEventType.BigBonus ? 1 : 0);
                    chartBonuses.Series[2].Points.InsertY(1, e.EventType == MagiEventType.RegularBonus ? 1 : 0);
                    chartBonuses.ChartAreas[0].RecalculateAxesScale();
                    chartBonuses.Update();
                } 
                else
                {
                    if (e.EventType == MagiEventType.Payout)
                    {
                        int moneyIdx = chartMoney.Series[0].Points.Count - 1;
                        chartMoney.Series[0].Points.RemoveAt(moneyIdx);
                    }
                    chartMoney.Series[0].Points.AddY(e.CoinDelta);
                    chartMoney.ChartAreas[0].RecalculateAxesScale();
                    chartMoney.Update();
                }
            };

            if (InvokeRequired)
                Invoke(x);
            else
                x();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
#if DEBUG
            if(cmbCom.SelectedItem.ToString() == "dummy")
            {
                frmEmulator testMode = new frmEmulator();
                testMode.Show();
                testMode.Left = this.Left + this.Width + 5;
                testMode.Top = this.Top;
                testMode.OnByteReceived += OnDummyByte;
            }
            else
#endif
            {
                serialPort.PortName = (string)cmbCom.SelectedItem;
                serialPort.Open();
                btnStop.Visible = true;
            }

            ResetAll();

            cmbCom.Visible = false;
            btnStart.Visible = false;
            timer.Enabled = true;
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            while(serialPort.BytesToRead > 0)
            {
                int data = serialPort.ReadByte();
                viewModel.ReceiveDataByte(data);
            }
            this.updateValues();
        }

        private void updateValues()
        {
            if(InvokeRequired)
            {
                Action x = delegate ()
                {
                    this.updateValues();
                };
                Invoke(x);
                return;
            }

            stsAlert.Value = viewModel.State.Alert ? "YES" : ".";
            stsBigBonus.Value = viewModel.State.BigBonus.ToString();
            stsUnknown2.Value = viewModel.State.UnknownBonus.ToString();
            stsSmallBonus.Value = viewModel.State.SmallBonus.ToString();
            stsPayout.Value = viewModel.State.Payouts.ToString();
            stsUnknown.Value = viewModel.State.UnknownCounter.ToString();
            stsCredits.Value = viewModel.State.Credits.ToString();

            stsTime.Value = String.Format("{0:h\\:mm\\:ss}", viewModel.Timer.TotalElapsed);
            stsSpinCount.Value = viewModel.State.SpinCount.ToString();
            stsGameCount.Value = viewModel.State.GameCount.ToString();

            double retRatio = Math.Truncate(viewModel.State.ReturnRatio * 100 * 100) / 100;
            stsReturn.Value = String.Format("{0:N2}", retRatio);

            chartBonuses.Series[0].Points.RemoveAt(0);
            chartBonuses.Series[0].Points.InsertY(0, viewModel.State.GameCount);
            chartBonuses.ChartAreas[0].RecalculateAxesScale();
            chartBonuses.Update();

        }

        private void btnRstAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Reset ALL counters?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                ResetAll();
            }
        }

        private void ResetAll()
        {
            viewModel.Reset();
            updateValues();

            chartMoney.Series[0].Points.Clear();
            chartMoney.Series[0].Points.AddY(0);


            chartBonuses.Series[0].Points.Clear();
            chartBonuses.Series[0].Points.AddY(0);
            chartBonuses.Series[1].Points.Clear();
            chartBonuses.Series[1].Points.AddY(0);
            chartBonuses.Series[2].Points.Clear();
            chartBonuses.Series[2].Points.AddY(0);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            serialPort.Close();
            btnStop.Visible = false;
            btnStart.Visible = true;
            cmbCom.Visible = true;
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            updateValues();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
