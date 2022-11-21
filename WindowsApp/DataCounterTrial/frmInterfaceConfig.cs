using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadoMagiDataCounter
{
    public partial class frmInterfaceConfig : Form
    {
        public Control Configurator { get; set; }

        public frmInterfaceConfig()
        {
            InitializeComponent();
        }

        private void frmInterfaceConfig_Load(object sender, EventArgs e)
        {
            if (Configurator != null)
            {
                this.Width = Configurator.Width;
                this.Height = Configurator.Height + pnlFooter.Height * 2;

                pnlHolder.Controls.Add(Configurator);
                Configurator.Parent = pnlHolder;
                Configurator.Dock = DockStyle.Fill;
            }
        }
    }
}
