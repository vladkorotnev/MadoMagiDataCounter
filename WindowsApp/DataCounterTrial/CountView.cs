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

namespace MadoMagiDataCounter
{
    public partial class CountView : UserControl, ISink<int>, ISink<bool>, ISink<TimeSpan>, ISink<double>
    {
        public CountView()
        {
            InitializeComponent();
        }

        private void CountView_Load(object sender, EventArgs e)
        {

        }

        public void Signal(int newValue)
        {
            Action x = delegate () { Value = newValue.ToString(); };
            if (InvokeRequired) Invoke(x);
            else x();
        }

        public void Signal(bool newValue)
        {
            Action x = delegate () { Value = newValue ? "YES" : "."; };
            if (InvokeRequired) Invoke(x);
            else x();
        }

        public void Signal(TimeSpan newValue)
        {
            Action x = delegate () { Value = String.Format("{0:h\\:mm\\:ss}", newValue); };
            if (InvokeRequired) Invoke(x);
            else x();
        }

        public void Signal(double newValue)
        {
            Action x = delegate () {
                var percentage = Math.Truncate(newValue * 100 * 100) / 100;
                Value = String.Format("{0:N2}", percentage); 
            };
            if (InvokeRequired) Invoke(x);
            else x();
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
