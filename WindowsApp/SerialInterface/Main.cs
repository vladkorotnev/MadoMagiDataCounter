using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataCounterCommon;

namespace SerialInterface
{
    public partial class SerialInterface : ICounterInput
    {
        private SerialPort activePort = null;
        private ConfigWindow settingPanel = new ConfigWindow();

        public CounterInputState State
        {
            get
            {
                if (activePort == null || !activePort.IsOpen) return CounterInputState.Ready;
                return CounterInputState.Running;
            }
        }

        public string Name => "Serial";

        public ISink<int> Receiver { get; set; }

        public Control GetSettingsPanel()
        {
            return settingPanel;
        }

        public void Start()
        {
            if (State == CounterInputState.Running) return;

            var portName = Properties.Settings.Default.LastCOM;
            var baudRate = Convert.ToInt32(Properties.Settings.Default.LastBaud);

            if(baudRate == 0)
            {
                throw new ArgumentOutOfRangeException("BaudRate", "Baud rate should be set correctly");
            }

            activePort = new SerialPort(portName, baudRate);
            activePort.DataReceived += ActivePort_DataReceived;
            activePort.Open();
        }

        private void ActivePort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (activePort.BytesToRead > 0)
            {
                int data = activePort.ReadByte();
                if(Receiver != null)
                    Receiver.Signal(data);
            }
        }

        public void Stop()
        {
            if (State != CounterInputState.Running) return;

            activePort.Close();
            activePort = null;
        }
    }
}
