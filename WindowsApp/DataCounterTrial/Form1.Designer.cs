
namespace MadoMagiDataCounter
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.btnRstAll = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.stsReturn = new MadoMagiDataCounter.CountView();
            this.stsCredits = new MadoMagiDataCounter.CountView();
            this.stsUnknown = new MadoMagiDataCounter.CountView();
            this.stsPayout = new MadoMagiDataCounter.CountView();
            this.stsSmallBonus = new MadoMagiDataCounter.CountView();
            this.stsUnknown2 = new MadoMagiDataCounter.CountView();
            this.stsBigBonus = new MadoMagiDataCounter.CountView();
            this.stsAlert = new MadoMagiDataCounter.CountView();
            this.stsTime = new MadoMagiDataCounter.CountView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.stsBigBonusTime = new MadoMagiDataCounter.CountView();
            this.stsSmallBonusTime = new MadoMagiDataCounter.CountView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 38400;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Location = new System.Drawing.Point(93, 416);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(121, 21);
            this.cmbCom.TabIndex = 7;
            // 
            // btnRstAll
            // 
            this.btnRstAll.ForeColor = System.Drawing.Color.Black;
            this.btnRstAll.Location = new System.Drawing.Point(12, 416);
            this.btnRstAll.Name = "btnRstAll";
            this.btnRstAll.Size = new System.Drawing.Size(75, 21);
            this.btnRstAll.TabIndex = 10;
            this.btnRstAll.Text = "Reset ALL";
            this.btnRstAll.UseVisualStyleBackColor = true;
            this.btnRstAll.Click += new System.EventHandler(this.btnRstAll_Click);
            // 
            // btnStart
            // 
            this.btnStart.ForeColor = System.Drawing.Color.Black;
            this.btnStart.Location = new System.Drawing.Point(220, 415);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 21);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.ForeColor = System.Drawing.Color.Black;
            this.btnStop.Location = new System.Drawing.Point(220, 415);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 21);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // stsReturn
            // 
            this.stsReturn.BackColor = System.Drawing.Color.Transparent;
            this.stsReturn.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "ReturnTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsReturn.Location = new System.Drawing.Point(12, 180);
            this.stsReturn.Name = "stsReturn";
            this.stsReturn.Size = new System.Drawing.Size(228, 78);
            this.stsReturn.TabIndex = 12;
            this.stsReturn.TextWidth = 100;
            this.stsReturn.Title = global::MadoMagiDataCounter.Properties.Settings.Default.ReturnTitle;
            this.stsReturn.Value = "---.-";
            // 
            // stsCredits
            // 
            this.stsCredits.BackColor = System.Drawing.Color.Transparent;
            this.stsCredits.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "CreditsTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsCredits.Location = new System.Drawing.Point(12, 12);
            this.stsCredits.Name = "stsCredits";
            this.stsCredits.Size = new System.Drawing.Size(228, 78);
            this.stsCredits.TabIndex = 9;
            this.stsCredits.TextWidth = 76;
            this.stsCredits.Title = global::MadoMagiDataCounter.Properties.Settings.Default.CreditsTitle;
            this.stsCredits.Value = "---";
            // 
            // stsUnknown
            // 
            this.stsUnknown.BackColor = System.Drawing.Color.Transparent;
            this.stsUnknown.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "Unk2Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsUnknown.Location = new System.Drawing.Point(480, 180);
            this.stsUnknown.Name = "stsUnknown";
            this.stsUnknown.Size = new System.Drawing.Size(228, 78);
            this.stsUnknown.TabIndex = 6;
            this.stsUnknown.TextWidth = 76;
            this.stsUnknown.Title = global::MadoMagiDataCounter.Properties.Settings.Default.Unk2Title;
            this.stsUnknown.Value = ".";
            // 
            // stsPayout
            // 
            this.stsPayout.BackColor = System.Drawing.Color.Transparent;
            this.stsPayout.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "PayoutsTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsPayout.Location = new System.Drawing.Point(12, 96);
            this.stsPayout.Name = "stsPayout";
            this.stsPayout.Size = new System.Drawing.Size(228, 78);
            this.stsPayout.TabIndex = 5;
            this.stsPayout.TextWidth = 76;
            this.stsPayout.Title = global::MadoMagiDataCounter.Properties.Settings.Default.PayoutsTitle;
            this.stsPayout.Value = "---";
            // 
            // stsSmallBonus
            // 
            this.stsSmallBonus.BackColor = System.Drawing.Color.Transparent;
            this.stsSmallBonus.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "SmallBonusTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsSmallBonus.Location = new System.Drawing.Point(246, 12);
            this.stsSmallBonus.Name = "stsSmallBonus";
            this.stsSmallBonus.Size = new System.Drawing.Size(228, 78);
            this.stsSmallBonus.TabIndex = 3;
            this.stsSmallBonus.TextWidth = 100;
            this.stsSmallBonus.Title = global::MadoMagiDataCounter.Properties.Settings.Default.SmallBonusTitle;
            this.stsSmallBonus.Value = "---";
            // 
            // stsUnknown2
            // 
            this.stsUnknown2.BackColor = System.Drawing.Color.Transparent;
            this.stsUnknown2.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "Unk1Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsUnknown2.Location = new System.Drawing.Point(480, 96);
            this.stsUnknown2.Name = "stsUnknown2";
            this.stsUnknown2.Size = new System.Drawing.Size(228, 78);
            this.stsUnknown2.TabIndex = 2;
            this.stsUnknown2.TextWidth = 76;
            this.stsUnknown2.Title = global::MadoMagiDataCounter.Properties.Settings.Default.Unk1Title;
            this.stsUnknown2.Value = ".";
            // 
            // stsBigBonus
            // 
            this.stsBigBonus.BackColor = System.Drawing.Color.Transparent;
            this.stsBigBonus.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "BigBonusTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsBigBonus.Location = new System.Drawing.Point(246, 180);
            this.stsBigBonus.Name = "stsBigBonus";
            this.stsBigBonus.Size = new System.Drawing.Size(228, 78);
            this.stsBigBonus.TabIndex = 1;
            this.stsBigBonus.TextWidth = 100;
            this.stsBigBonus.Title = global::MadoMagiDataCounter.Properties.Settings.Default.BigBonusTitle;
            this.stsBigBonus.Value = "---";
            // 
            // stsAlert
            // 
            this.stsAlert.BackColor = System.Drawing.Color.Transparent;
            this.stsAlert.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "AlertTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsAlert.Location = new System.Drawing.Point(480, 12);
            this.stsAlert.Name = "stsAlert";
            this.stsAlert.Size = new System.Drawing.Size(228, 78);
            this.stsAlert.TabIndex = 0;
            this.stsAlert.TextWidth = 76;
            this.stsAlert.Title = global::MadoMagiDataCounter.Properties.Settings.Default.AlertTitle;
            this.stsAlert.Value = ".";
            // 
            // stsTime
            // 
            this.stsTime.BackColor = System.Drawing.Color.Transparent;
            this.stsTime.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "TimerTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsTime.Location = new System.Drawing.Point(12, 264);
            this.stsTime.Name = "stsTime";
            this.stsTime.Size = new System.Drawing.Size(228, 78);
            this.stsTime.TabIndex = 13;
            this.stsTime.TextWidth = 66;
            this.stsTime.Title = global::MadoMagiDataCounter.Properties.Settings.Default.TimerTitle;
            this.stsTime.Value = "-:--:--";
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // stsBigBonusTime
            // 
            this.stsBigBonusTime.BackColor = System.Drawing.Color.Transparent;
            this.stsBigBonusTime.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "BigTimeTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsBigBonusTime.Location = new System.Drawing.Point(246, 264);
            this.stsBigBonusTime.Name = "stsBigBonusTime";
            this.stsBigBonusTime.Size = new System.Drawing.Size(228, 78);
            this.stsBigBonusTime.TabIndex = 14;
            this.stsBigBonusTime.TextWidth = 64;
            this.stsBigBonusTime.Title = global::MadoMagiDataCounter.Properties.Settings.Default.BigTimeTitle;
            this.stsBigBonusTime.Value = "-:--:--";
            // 
            // stsSmallBonusTime
            // 
            this.stsSmallBonusTime.BackColor = System.Drawing.Color.Transparent;
            this.stsSmallBonusTime.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "SmallTimeTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsSmallBonusTime.Location = new System.Drawing.Point(246, 96);
            this.stsSmallBonusTime.Name = "stsSmallBonusTime";
            this.stsSmallBonusTime.Size = new System.Drawing.Size(228, 78);
            this.stsSmallBonusTime.TabIndex = 15;
            this.stsSmallBonusTime.TextWidth = 64;
            this.stsSmallBonusTime.Title = global::MadoMagiDataCounter.Properties.Settings.Default.SmallTimeTitle;
            this.stsSmallBonusTime.Value = "-:--:--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "by Akasaka/Genjitsu Labs, 2022";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(734, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stsSmallBonusTime);
            this.Controls.Add(this.stsBigBonusTime);
            this.Controls.Add(this.stsTime);
            this.Controls.Add(this.stsReturn);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnRstAll);
            this.Controls.Add(this.stsCredits);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbCom);
            this.Controls.Add(this.stsUnknown);
            this.Controls.Add(this.stsPayout);
            this.Controls.Add(this.stsSmallBonus);
            this.Controls.Add(this.stsUnknown2);
            this.Controls.Add(this.stsBigBonus);
            this.Controls.Add(this.stsAlert);
            this.ForeColor = System.Drawing.Color.White;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "DataCounter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CountView stsAlert;
        private CountView stsBigBonus;
        private CountView stsUnknown2;
        private CountView stsSmallBonus;
        private CountView stsPayout;
        private CountView stsUnknown;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox cmbCom;
        private CountView stsCredits;
        private System.Windows.Forms.Button btnRstAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private CountView stsReturn;
        private CountView stsTime;
        private System.Windows.Forms.Timer timer;
        private CountView stsBigBonusTime;
        private CountView stsSmallBonusTime;
        private System.Windows.Forms.Label label1;
    }
}

