using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataCounterCommon;

namespace LANInterface
{
    public partial class UDPSettingsPanel : UserControl, ISettingsPanel
    {
        public UDPSettingsPanel()
        {
            InitializeComponent();
        }

        private void SomethingChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        public void Apply()
        {
            Properties.Settings.Default.Save();
        }
    }
}
