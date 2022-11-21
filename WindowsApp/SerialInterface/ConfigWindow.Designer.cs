
namespace SerialInterface
{
    partial class ConfigWindow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // cmbPort
            // 
            this.cmbPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SerialInterface.Properties.Settings.Default, "LastCOM", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(7, 24);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(140, 21);
            this.cmbPort.TabIndex = 1;
            this.cmbPort.Text = global::SerialInterface.Properties.Settings.Default.LastCOM;
            this.cmbPort.SelectedValueChanged += new System.EventHandler(this.SomethingChanged);
            this.cmbPort.TabStopChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // cmbBaud
            // 
            this.cmbBaud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBaud.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::SerialInterface.Properties.Settings.Default, "LastBaud", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(6, 68);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(140, 21);
            this.cmbBaud.TabIndex = 3;
            this.cmbBaud.Text = global::SerialInterface.Properties.Settings.Default.LastBaud;
            this.cmbBaud.SelectedValueChanged += new System.EventHandler(this.SomethingChanged);
            this.cmbBaud.TextChanged += new System.EventHandler(this.SomethingChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate:";
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbBaud);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.label1);
            this.Name = "ConfigWindow";
            this.Size = new System.Drawing.Size(150, 101);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.Label label2;
    }
}
