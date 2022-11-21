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

namespace SerialInterface
{
    public partial class ConfigWindow : UserControl, ISettingsPanel
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        public void Apply()
        {
            Properties.Settings.Default.Save();
        }

        private void SomethingChanged(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
