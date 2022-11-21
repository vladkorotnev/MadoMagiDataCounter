using DataCounterCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadoMagiDataCounter
{
    public partial class Form1 : Form
    {
        private MagiCounter viewModel = new MagiCounter();
        private List<ICounterInput> inputPorts = new List<ICounterInput>();
        private ICounterInput activePort = null;

        public Form1()
        {
            InitializeComponent();
            inputPorts = PluginLoader.GetInterfacePlugins(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "interfaces"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var prefs = Properties.Settings.Default;

            cmbCom.Items.Clear();
            foreach(var i in inputPorts)
            {
                cmbCom.Items.Add(i.Name);
            }
            cmbCom.SelectedIndex = cmbCom.Items.IndexOf(Properties.Settings.Default.LastInterfaceName);

            viewModel.History.NewHistoryItem += OnNewGraphItem;
            viewModel.OnUpdate += OnUpdate;
        }

        private void OnUpdate(object sender, MagiCounterValues e)
        {
            updateValues();
        }

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

                    int moneyIdx = chartMoney.Series[0].Points.Count - 1 - viewModel.State.SpinCount + viewModel.State.GameCount;
                    int newIdx = chartMoney.Series[1].Points.AddXY(moneyIdx, chartMoney.Series[0].Points[moneyIdx].YValues[0]);
                    chartMoney.Series[1].Points[newIdx].Color = e.EventType == MagiEventType.BigBonus ? Color.Gold : Color.Red;
                    chartMoney.Series[1].Points[newIdx].Label = e.EventType == MagiEventType.BigBonus ? "BB" : "RB";
                }
                else
                {
                    int moneyCount = chartMoney.Series[0].Points.Count;
                    if (e.EventType == MagiEventType.Payout)
                    {
                        int moneyIdx = moneyCount - 1;
                        chartMoney.Series[0].Points.RemoveAt(moneyIdx);
                        moneyCount -= 1;
                    }
                    chartMoney.Series[0].Points.AddXY(moneyCount, e.CoinDelta);
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

            if (activePort == null) return;

            try
            {
                activePort.Receivers.Clear();
                activePort.Receivers.Add(viewModel);
                activePort.Start();
            }
            catch(Exception error)
            {
                MessageBox.Show(
                        String.Format("An error occurred when connecting via {0}:\n{1}", activePort.Name, error.Message),
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                );
                return;
            }
            btnStop.Visible = true;

            ResetAll();

            cmbCom.Visible = false;
            btnConfig.Visible = false;
            btnStart.Visible = false;
            timer.Enabled = true;
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
            chartMoney.Series[1].Points.Clear();
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
            btnStop.Visible = false;
            btnStart.Visible = true;
            cmbCom.Visible = true;
            timer.Enabled = false;
            btnConfig.Visible = true;

            if (activePort == null) return;
            activePort.Stop();
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

            if (activePort == null) return;
            activePort.Stop();
        }

        private void cmbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            activePort = inputPorts[cmbCom.SelectedIndex];
            var settingsView = activePort.GetSettingsPanel();
            btnConfig.Enabled = (settingsView != null);
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (activePort == null) return;
            var settingsView = activePort.GetSettingsPanel();
            if (settingsView == null) return;

            var configDialog = new frmInterfaceConfig();
            configDialog.Configurator = settingsView;
            configDialog.Text += ": " + activePort.Name;
            configDialog.ShowDialog();
        }
    }
}
