using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LANInterface
{
    public partial class UDPSettingsPanel : UserControl
    {
        public UDPSettingsPanel()
        {
            InitializeComponent();
        }

        private void SomethingChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
