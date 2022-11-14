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
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            serialPort.PortName = (string)cmbCom.SelectedItem;
            serialPort.Open();

            cmbCom.Visible = false;
            btnStart.Visible = false;
            btnStop.Visible = true;
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
            stsBigBonusTime.Value = timerOrEmpty(viewModel.Timer.SinceLastBigBonus);
            stsSmallBonusTime.Value = timerOrEmpty(viewModel.Timer.SinceLastSmallBonus);
        }

        private String timerOrEmpty(TimeSpan value)
        {
            if (value == TimeSpan.Zero) return "-:--:--";
            return String.Format("{0:h\\:mm\\:ss}", value);
        }

        private void btnRstAll_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Reset ALL counters?", "Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                viewModel.Reset();
                updateValues();
            }
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
