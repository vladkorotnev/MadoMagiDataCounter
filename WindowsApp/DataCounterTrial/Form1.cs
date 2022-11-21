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

            circuit.Credits.Connect(stsCredits);
            circuit.Credits.Connect(calculator.inCredits);

            circuit.Payout.Connect(stsPayout);
            circuit.Payout.Connect(calculator.inPayouts);

            circuit.BigBonus.Connect(stsBigBonus);
            circuit.BigBonusPulse.Connect(slumpGraph.inBigBonus);
            circuit.BigBonusPulse.Connect(barGraph.inBigBonus);

            circuit.RegularBonus.Connect(stsSmallBonus);
            circuit.RegularBonusPulse.Connect(slumpGraph.inRegBonus);
            circuit.RegularBonusPulse.Connect(barGraph.inRegBonus);

            circuit.Spins.Connect(stsSpinCount);
            circuit.Spins.Connect(slumpGraph.inSpins);

            circuit.Games.Connect(stsGameCount);
            circuit.Games.Connect(slumpGraph.inGames);
            circuit.Games.Connect(barGraph.inGames);

            circuit.Alarm.Connect(stsAlert);
            circuit.WallTime.Connect(stsTime);

            calculator.outRatio.Connect(stsReturn);
            calculator.outBalance.Connect(slumpGraph.inBalance);
            calculator.outBalance.Connect(stsBalance);

            var nextPointPulse = new Cooldown();
            circuit.CreditPulse.Connect(nextPointPulse);
            nextPointPulse.Connect(slumpGraph.inNextPoint);
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

            circuit.InputNub = activePort;
            circuit.Reset();
            slumpGraph.Reset();
            barGraph.Reset();

            Text = String.Format("DataCounter: connected on {0}", activePort.Name);
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
            Text = "DataCounter";

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
            if(settingsView is ISettingsPanel)
            {
                ((ISettingsPanel)settingsView).Apply();
            }
        }

        Form slumpGraphPopOut = null;
        Form barGraphPopOut = null;

        private void PopOutGraph(string title, Control graph, ref Form form)
        {
            if(graph.Parent == this)
            {
                form = new Form();
                form.BackColor = Color.Black;
                form.FormBorderStyle = FormBorderStyle.Sizable;
                form.Text = title;
                form.Controls.Add(graph);
                graph.Parent = form;
                graph.Dock = DockStyle.Fill;
                form.Show();
                form.FormClosing += PopOutPutBack;
            } 
            else if(graph.Parent == form)
            {
                form.Close();
                form = null;
            }
        }

        private void PopOutPutBack(object sender, FormClosingEventArgs e)
        {
            var chart = ((Form)sender).Controls[0];
            this.Controls.Add(chart);
            chart.Parent = this;
            chart.Dock = DockStyle.None;
        }

        private void btnUndockSlump_Click(object sender, EventArgs e)
        {
            PopOutGraph("Slump Graph", slumpGraph, ref slumpGraphPopOut);
        }

        private void btnUndockBar_Click(object sender, EventArgs e)
        {
            PopOutGraph("Bar Graph", barGraph, ref barGraphPopOut);
        }
    }
}
