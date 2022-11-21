using DataCounterCommon;
using DataCounterCommon.Elements;
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
        private List<ICounterInput> inputPorts = new List<ICounterInput>();
        private ICounterInput activePort = null;
        private DataCounterCircuit circuit = new DataCounterCircuit();
        private RatioCalculator calculator = new RatioCalculator();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inputPorts = PluginLoader.GetInterfacePlugins(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "interfaces"));

            cmbCom.Items.Clear();
            foreach(var i in inputPorts)
            {
                cmbCom.Items.Add(i.Name);
            }
            cmbCom.SelectedIndex = cmbCom.Items.IndexOf(Properties.Settings.Default.LastInterfaceName);

            circuit.Credits.ConnectReceiver(stsCredits);
            circuit.Credits.ConnectReceiver(calculator.inCredits);

            circuit.Payout.ConnectReceiver(stsPayout);
            circuit.Payout.ConnectReceiver(calculator.inPayouts);

            circuit.BigBonus.ConnectReceiver(stsBigBonus);
            circuit.BigBonusPulse.ConnectReceiver(slumpGraph.inBigBonus);
            circuit.BigBonusPulse.ConnectReceiver(barGraph.inBigBonus);

            circuit.RegularBonus.ConnectReceiver(stsSmallBonus);
            circuit.RegularBonusPulse.ConnectReceiver(slumpGraph.inRegBonus);
            circuit.RegularBonusPulse.ConnectReceiver(barGraph.inRegBonus);

            circuit.Spins.ConnectReceiver(stsSpinCount);
            circuit.Spins.ConnectReceiver(slumpGraph.inSpins);

            circuit.Games.ConnectReceiver(stsGameCount);
            circuit.Games.ConnectReceiver(slumpGraph.inGames);
            circuit.Games.ConnectReceiver(barGraph.inGames);

            circuit.Alarm.ConnectReceiver(stsAlert);
            circuit.WallTime.ConnectReceiver(stsTime);

            calculator.outRatio.ConnectReceiver(stsReturn);
            calculator.outBalance.ConnectReceiver(slumpGraph.inBalance);

            var nextPointPulse = new Cooldown();
            circuit.CreditPulse.ConnectReceiver(nextPointPulse);
            nextPointPulse.ConnectReceiver(slumpGraph.inNextPoint);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            if (activePort == null) return;

            try
            {
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

            cmbCom.Visible = false;
            btnConfig.Visible = false;
            btnStart.Visible = false;

            // Set up a counter graph
            circuit.InputNub = activePort;
            circuit.Reset();
            slumpGraph.Reset();
            barGraph.Reset();
        }

        private void btnRstAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Reset ALL counters?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                circuit.Reset();
                slumpGraph.Reset();
                barGraph.Reset();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Visible = false;
            btnStart.Visible = true;
            cmbCom.Visible = true;
            btnConfig.Visible = true;

            if (activePort == null) return;
            activePort.Stop();
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
