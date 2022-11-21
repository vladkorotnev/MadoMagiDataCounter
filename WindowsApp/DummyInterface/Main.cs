using DataCounterCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyInterface
{
    public class PortEmulator : DataCounterCommon.ICounterInput
    {
        private CounterInputState _state = CounterInputState.Ready;
        private frmEmulator simulator = new frmEmulator();

        public PortEmulator()
        {
            simulator.OnByteReceived += OnSimulatedByte;
        }

        private void OnSimulatedByte(object sender, int e)
        {
            if(Receiver != null)
            {
                Receiver.Signal(e);
            }
        }

        public CounterInputState State
        {
            get { return _state;  }
        }

        public string Name => "Dummy";

        public ISink<int> Receiver { get; set; }

        public Control GetSettingsPanel()
        {
            return new ctlDummyConfigurator();
        }

        public void Start()
        {
            simulator.Show();
            _state = CounterInputState.Running;
        }

        public void Stop()
        {
            simulator.Close();
            _state = CounterInputState.Ready;
        }
    }
}
