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
    public partial class CountView : UserControl
    {
        public CountView()
        {
            InitializeComponent();
        }

        private void CountView_Load(object sender, EventArgs e)
        {

        }

        public string Value
        {
            get { return lblCount.Text; }
            set
            {
                lblCount.Text = value;
            }
        }

        public string Title
        {
            get { return tbName.Text; }
            set
            {
                tbName.Text = value;
            }
        }

        public int TextWidth
        {
            get { return splitContainer1.SplitterDistance; }
            set { splitContainer1.SplitterDistance = value;  }
        }

        public override string Text
        {
            get { return Title; }
            set { Title = value; }
        }
    }
}
