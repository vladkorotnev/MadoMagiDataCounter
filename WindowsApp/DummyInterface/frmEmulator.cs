using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyInterface
{
    public partial class frmEmulator : Form
    {
        public frmEmulator()
        {
            InitializeComponent();
        }

        public event EventHandler<int> OnByteReceived;

        private int portState = 0xFF;

        private void onButtonPress(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            var bitNumber = Convert.ToInt32(btn.Tag);

            portState &= ~(1 << bitNumber);
            OnByteReceived.Invoke(this, portState);
        }

        private void onButtonRelease(object sender, MouseEventArgs e)
        {
            var btn = (Button)sender;
            var bitNumber = Convert.ToInt32(btn.Tag);

            portState |= (1 << bitNumber);
            OnByteReceived.Invoke(this, portState);
        }
    }
}
