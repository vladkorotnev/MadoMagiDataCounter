using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialInterface
{
    public partial class ConfigWindow : UserControl
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void Apply()
        {
            Properties.Settings.Default.Save();
        }

        private void SomethingChanged(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
