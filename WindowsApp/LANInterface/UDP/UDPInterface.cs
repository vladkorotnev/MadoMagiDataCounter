using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataCounterCommon;

namespace LANInterface
{
    public class UDPInterface : ICounterInput
    {
        private UdpClient client = null;
        private UDPSettingsPanel settingsPanel = new UDPSettingsPanel();

        public CounterInputState State
        {
            get
            {
                if (client == null) return CounterInputState.Ready;

                return CounterInputState.Running;
            }
        }

        public string Name => "UDP";

        public ISink<int> Receiver { get; set; }

        public Control GetSettingsPanel()
        {
            return settingsPanel;
        }

        public void Start()
        {
            if (State != CounterInputState.Ready) return;

            var prefs = Properties.Settings.Default;
            client = new UdpClient(new IPEndPoint(IPAddress.Parse(prefs.UDPBind), Convert.ToInt32(prefs.UDPPort)));
            client.BeginReceive(new AsyncCallback(onReceive), null);
        }

        private void onReceive(IAsyncResult res)
        {
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 8000);
            byte[] received = client.EndReceive(res, ref RemoteIpEndPoint);
            client.BeginReceive(new AsyncCallback(onReceive), null);

            if(received.Length == 1)
            {
                if(Receiver != null)
                {
                    Receiver.Signal(received[0]);
                }
            }
            else
            {
#if DEBUG
                Debug.Fail("Expected 1 byte, received " + received.Length.ToString());
#endif
            }
        }

        public void Stop()
        {
            client.Close();
            client.Dispose();
            client = null;
        }
    }
}
