
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
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.btnRstAll = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnUndockSlump = new System.Windows.Forms.Button();
            this.barGraph = new MadoMagiDataCounter.BarGraph();
            this.slumpGraph = new MadoMagiDataCounter.SlumpGraph();
            this.stsGameCount = new MadoMagiDataCounter.CountView();
            this.stsSpinCount = new MadoMagiDataCounter.CountView();
            this.stsTime = new MadoMagiDataCounter.CountView();
            this.stsReturn = new MadoMagiDataCounter.CountView();
            this.stsCredits = new MadoMagiDataCounter.CountView();
            this.stsUnknown = new MadoMagiDataCounter.CountView();
            this.stsPayout = new MadoMagiDataCounter.CountView();
            this.stsSmallBonus = new MadoMagiDataCounter.CountView();
            this.stsBalance = new MadoMagiDataCounter.CountView();
            this.stsBigBonus = new MadoMagiDataCounter.CountView();
            this.stsAlert = new MadoMagiDataCounter.CountView();
            this.btnUndockBar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbCom
            // 
            this.cmbCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCom.FormattingEnabled = true;
            this.cmbCom.Location = new System.Drawing.Point(174, 416);
            this.cmbCom.Name = "cmbCom";
            this.cmbCom.Size = new System.Drawing.Size(121, 21);
            this.cmbCom.TabIndex = 7;
            this.cmbCom.SelectedIndexChanged += new System.EventHandler(this.cmbCom_SelectedIndexChanged);
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
            this.btnStart.Location = new System.Drawing.Point(93, 416);
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
            this.btnStop.Location = new System.Drawing.Point(93, 416);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 21);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(560, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "by Akasaka/Genjitsu Labs, 2022";
            // 
            // btnConfig
            // 
            this.btnConfig.Enabled = false;
            this.btnConfig.ForeColor = System.Drawing.Color.Black;
            this.btnConfig.Location = new System.Drawing.Point(301, 416);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 21);
            this.btnConfig.TabIndex = 20;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnUndockSlump
            // 
            this.btnUndockSlump.ForeColor = System.Drawing.Color.Black;
            this.btnUndockSlump.Location = new System.Drawing.Point(698, 233);
            this.btnUndockSlump.Name = "btnUndockSlump";
            this.btnUndockSlump.Size = new System.Drawing.Size(24, 23);
            this.btnUndockSlump.TabIndex = 23;
            this.btnUndockSlump.Text = "∆";
            this.btnUndockSlump.UseVisualStyleBackColor = true;
            this.btnUndockSlump.Click += new System.EventHandler(this.btnUndockSlump_Click);
            // 
            // barGraph
            // 
            this.barGraph.BackColor = System.Drawing.Color.Transparent;
            this.barGraph.Location = new System.Drawing.Point(10, 233);
            this.barGraph.Name = "barGraph";
            this.barGraph.Size = new System.Drawing.Size(230, 165);
            this.barGraph.TabIndex = 22;
            // 
            // slumpGraph
            // 
            this.slumpGraph.BackColor = System.Drawing.Color.Transparent;
            this.slumpGraph.Location = new System.Drawing.Point(246, 233);
            this.slumpGraph.Name = "slumpGraph";
            this.slumpGraph.Size = new System.Drawing.Size(476, 165);
            this.slumpGraph.TabIndex = 21;
            // 
            // stsGameCount
            // 
            this.stsGameCount.BackColor = System.Drawing.Color.Transparent;
            this.stsGameCount.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "GameCountTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsGameCount.Location = new System.Drawing.Point(281, 68);
            this.stsGameCount.Name = "stsGameCount";
            this.stsGameCount.Size = new System.Drawing.Size(213, 47);
            this.stsGameCount.TabIndex = 19;
            this.stsGameCount.TextWidth = 80;
            this.stsGameCount.Title = global::MadoMagiDataCounter.Properties.Settings.Default.GameCountTitle;
            this.stsGameCount.Value = "---";
            // 
            // stsSpinCount
            // 
            this.stsSpinCount.BackColor = System.Drawing.Color.Transparent;
            this.stsSpinCount.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "SpinCountTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsSpinCount.Location = new System.Drawing.Point(281, 12);
            this.stsSpinCount.Name = "stsSpinCount";
            this.stsSpinCount.Size = new System.Drawing.Size(213, 47);
            this.stsSpinCount.TabIndex = 14;
            this.stsSpinCount.TextWidth = 80;
            this.stsSpinCount.Title = global::MadoMagiDataCounter.Properties.Settings.Default.SpinCountTitle;
            this.stsSpinCount.Value = "---";
            // 
            // stsTime
            // 
            this.stsTime.BackColor = System.Drawing.Color.Transparent;
            this.stsTime.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "TimerTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsTime.Location = new System.Drawing.Point(12, 177);
            this.stsTime.Name = "stsTime";
            this.stsTime.Size = new System.Drawing.Size(228, 47);
            this.stsTime.TabIndex = 13;
            this.stsTime.TextWidth = 66;
            this.stsTime.Title = global::MadoMagiDataCounter.Properties.Settings.Default.TimerTitle;
            this.stsTime.Value = "-:--:--";
            // 
            // stsReturn
            // 
            this.stsReturn.BackColor = System.Drawing.Color.Transparent;
            this.stsReturn.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "ReturnTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsReturn.Location = new System.Drawing.Point(12, 124);
            this.stsReturn.Name = "stsReturn";
            this.stsReturn.Size = new System.Drawing.Size(228, 47);
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
            this.stsCredits.Size = new System.Drawing.Size(228, 47);
            this.stsCredits.TabIndex = 9;
            this.stsCredits.TextWidth = 100;
            this.stsCredits.Title = global::MadoMagiDataCounter.Properties.Settings.Default.CreditsTitle;
            this.stsCredits.Value = "---";
            // 
            // stsUnknown
            // 
            this.stsUnknown.BackColor = System.Drawing.Color.Transparent;
            this.stsUnknown.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "Unk2Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsUnknown.Location = new System.Drawing.Point(549, 124);
            this.stsUnknown.Name = "stsUnknown";
            this.stsUnknown.Size = new System.Drawing.Size(159, 47);
            this.stsUnknown.TabIndex = 6;
            this.stsUnknown.TextWidth = 53;
            this.stsUnknown.Title = global::MadoMagiDataCounter.Properties.Settings.Default.Unk2Title;
            this.stsUnknown.Value = ".";
            // 
            // stsPayout
            // 
            this.stsPayout.BackColor = System.Drawing.Color.Transparent;
            this.stsPayout.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "PayoutsTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsPayout.Location = new System.Drawing.Point(12, 68);
            this.stsPayout.Name = "stsPayout";
            this.stsPayout.Size = new System.Drawing.Size(228, 47);
            this.stsPayout.TabIndex = 5;
            this.stsPayout.TextWidth = 100;
            this.stsPayout.Title = global::MadoMagiDataCounter.Properties.Settings.Default.PayoutsTitle;
            this.stsPayout.Value = "---";
            // 
            // stsSmallBonus
            // 
            this.stsSmallBonus.BackColor = System.Drawing.Color.Transparent;
            this.stsSmallBonus.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "SmallBonusTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsSmallBonus.Location = new System.Drawing.Point(281, 124);
            this.stsSmallBonus.Name = "stsSmallBonus";
            this.stsSmallBonus.Size = new System.Drawing.Size(213, 47);
            this.stsSmallBonus.TabIndex = 3;
            this.stsSmallBonus.TextWidth = 95;
            this.stsSmallBonus.Title = global::MadoMagiDataCounter.Properties.Settings.Default.SmallBonusTitle;
            this.stsSmallBonus.Value = "---";
            // 
            // stsBalance
            // 
            this.stsBalance.BackColor = System.Drawing.Color.Transparent;
            this.stsBalance.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "Unk1Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsBalance.Location = new System.Drawing.Point(549, 68);
            this.stsBalance.Name = "stsBalance";
            this.stsBalance.Size = new System.Drawing.Size(159, 47);
            this.stsBalance.TabIndex = 2;
            this.stsBalance.TextWidth = 53;
            this.stsBalance.Title = global::MadoMagiDataCounter.Properties.Settings.Default.Unk1Title;
            this.stsBalance.Value = ".";
            // 
            // stsBigBonus
            // 
            this.stsBigBonus.BackColor = System.Drawing.Color.Transparent;
            this.stsBigBonus.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "BigBonusTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsBigBonus.Location = new System.Drawing.Point(281, 180);
            this.stsBigBonus.Name = "stsBigBonus";
            this.stsBigBonus.Size = new System.Drawing.Size(213, 47);
            this.stsBigBonus.TabIndex = 1;
            this.stsBigBonus.TextWidth = 95;
            this.stsBigBonus.Title = global::MadoMagiDataCounter.Properties.Settings.Default.BigBonusTitle;
            this.stsBigBonus.Value = "---";
            // 
            // stsAlert
            // 
            this.stsAlert.BackColor = System.Drawing.Color.Transparent;
            this.stsAlert.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "AlertTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsAlert.Location = new System.Drawing.Point(549, 12);
            this.stsAlert.Name = "stsAlert";
            this.stsAlert.Size = new System.Drawing.Size(159, 47);
            this.stsAlert.TabIndex = 0;
            this.stsAlert.TextWidth = 53;
            this.stsAlert.Title = global::MadoMagiDataCounter.Properties.Settings.Default.AlertTitle;
            this.stsAlert.Value = ".";
            // 
            // btnUndockBar
            // 
            this.btnUndockBar.ForeColor = System.Drawing.Color.Black;
            this.btnUndockBar.Location = new System.Drawing.Point(216, 230);
            this.btnUndockBar.Name = "btnUndockBar";
            this.btnUndockBar.Size = new System.Drawing.Size(24, 23);
            this.btnUndockBar.TabIndex = 24;
            this.btnUndockBar.Text = "∆";
            this.btnUndockBar.UseVisualStyleBackColor = true;
            this.btnUndockBar.Click += new System.EventHandler(this.btnUndockBar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(734, 452);
            this.Controls.Add(this.btnUndockBar);
            this.Controls.Add(this.btnUndockSlump);
            this.Controls.Add(this.barGraph);
            this.Controls.Add(this.slumpGraph);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.stsGameCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stsSpinCount);
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
            this.Controls.Add(this.stsBalance);
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
        private CountView stsBalance;
        private CountView stsSmallBonus;
        private CountView stsPayout;
        private CountView stsUnknown;
        private System.Windows.Forms.ComboBox cmbCom;
        private CountView stsCredits;
        private System.Windows.Forms.Button btnRstAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private CountView stsReturn;
        private CountView stsTime;
        private CountView stsSpinCount;
        private System.Windows.Forms.Label label1;
        private CountView stsGameCount;
        private System.Windows.Forms.Button btnConfig;
        private SlumpGraph slumpGraph;
        private BarGraph barGraph;
        private System.Windows.Forms.Button btnUndockSlump;
        private System.Windows.Forms.Button btnUndockBar;
    }
}

