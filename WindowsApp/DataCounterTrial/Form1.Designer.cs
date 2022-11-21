
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint11 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 100D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint12 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 50D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint13 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 254D);
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint14 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint15 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint16 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint17 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint18 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 1D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint19 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint20 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 0D);
            this.cmbCom = new System.Windows.Forms.ComboBox();
            this.btnRstAll = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.chartBonuses = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMoney = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnConfig = new System.Windows.Forms.Button();
            this.stsGameCount = new MadoMagiDataCounter.CountView();
            this.stsSpinCount = new MadoMagiDataCounter.CountView();
            this.stsTime = new MadoMagiDataCounter.CountView();
            this.stsReturn = new MadoMagiDataCounter.CountView();
            this.stsCredits = new MadoMagiDataCounter.CountView();
            this.stsUnknown = new MadoMagiDataCounter.CountView();
            this.stsPayout = new MadoMagiDataCounter.CountView();
            this.stsSmallBonus = new MadoMagiDataCounter.CountView();
            this.stsUnknown2 = new MadoMagiDataCounter.CountView();
            this.stsBigBonus = new MadoMagiDataCounter.CountView();
            this.stsAlert = new MadoMagiDataCounter.CountView();
            ((System.ComponentModel.ISupportInitialize)(this.chartBonuses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMoney)).BeginInit();
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
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            // chartBonuses
            // 
            this.chartBonuses.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.LabelStyle.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisX.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.IsLabelAutoFit = false;
            chartArea3.AxisY.LabelStyle.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea3.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            chartArea3.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea3.AxisY2.IsLabelAutoFit = false;
            chartArea3.AxisY2.LabelStyle.Enabled = false;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.AxisY2.Maximum = 10D;
            chartArea3.AxisY2.Minimum = 0D;
            chartArea3.BackColor = System.Drawing.Color.Transparent;
            chartArea3.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea3.BorderColor = System.Drawing.Color.White;
            chartArea3.Name = "ChartArea1";
            this.chartBonuses.ChartAreas.Add(chartArea3);
            this.chartBonuses.Location = new System.Drawing.Point(12, 260);
            this.chartBonuses.Margin = new System.Windows.Forms.Padding(0);
            this.chartBonuses.Name = "chartBonuses";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series6.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series6.Label = "#VAL{N0}G";
            series6.LabelForeColor = System.Drawing.Color.White;
            series6.Name = "srsSpins";
            series6.Points.Add(dataPoint11);
            series6.Points.Add(dataPoint12);
            series6.Points.Add(dataPoint13);
            series6.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series6.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.DarkGray;
            series6.SmartLabelStyle.MaxMovingDistance = 100D;
            series7.ChartArea = "ChartArea1";
            series7.CustomProperties = "DrawSideBySide=True, DrawingStyle=Emboss, EmptyPointValue=Zero, PointWidth=1";
            series7.Name = "srsBonusKindBig";
            series7.Points.Add(dataPoint14);
            series7.Points.Add(dataPoint15);
            series7.Points.Add(dataPoint16);
            series7.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series8.ChartArea = "ChartArea1";
            series8.CustomProperties = "DrawSideBySide=False, DrawingStyle=Emboss, PointWidth=1";
            series8.Name = "srsBonusKindSmall";
            series8.Points.Add(dataPoint17);
            series8.Points.Add(dataPoint18);
            series8.Points.Add(dataPoint19);
            series8.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.chartBonuses.Series.Add(series6);
            this.chartBonuses.Series.Add(series7);
            this.chartBonuses.Series.Add(series8);
            this.chartBonuses.Size = new System.Drawing.Size(228, 149);
            this.chartBonuses.TabIndex = 17;
            this.chartBonuses.Text = "chart1";
            // 
            // chartMoney
            // 
            this.chartMoney.BackColor = System.Drawing.Color.Transparent;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea4.AxisX.Minimum = 0D;
            chartArea4.AxisX.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.IsStartedFromZero = false;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.DimGray;
            chartArea4.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea4.AxisY2.IsLabelAutoFit = false;
            chartArea4.AxisY2.LabelStyle.Enabled = false;
            chartArea4.AxisY2.MajorGrid.Enabled = false;
            chartArea4.AxisY2.Maximum = 10D;
            chartArea4.AxisY2.Minimum = 0D;
            chartArea4.BackColor = System.Drawing.Color.Transparent;
            chartArea4.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea4.BorderColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.chartMoney.ChartAreas.Add(chartArea4);
            this.chartMoney.Location = new System.Drawing.Point(243, 260);
            this.chartMoney.Name = "chartMoney";
            series9.BorderWidth = 3;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series9.Color = System.Drawing.Color.White;
            series9.Font = new System.Drawing.Font("MS Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series9.LabelForeColor = System.Drawing.Color.White;
            series9.Name = "srsMoney";
            series9.SmartLabelStyle.AllowOutsidePlotArea = System.Windows.Forms.DataVisualization.Charting.LabelOutsidePlotAreaStyle.Yes;
            series9.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.DarkGray;
            series9.SmartLabelStyle.MaxMovingDistance = 100D;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series10.LabelBackColor = System.Drawing.Color.DarkGray;
            series10.LabelBorderColor = System.Drawing.Color.Gray;
            series10.MarkerSize = 8;
            series10.Name = "srsBbPoints";
            dataPoint20.Color = System.Drawing.Color.Red;
            dataPoint20.Label = "BB";
            series10.Points.Add(dataPoint20);
            series10.SmartLabelStyle.CalloutBackColor = System.Drawing.Color.DarkGray;
            series10.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.DarkGray;
            this.chartMoney.Series.Add(series9);
            this.chartMoney.Series.Add(series10);
            this.chartMoney.Size = new System.Drawing.Size(465, 149);
            this.chartMoney.TabIndex = 18;
            this.chartMoney.Text = "chart1";
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
            // stsUnknown2
            // 
            this.stsUnknown2.BackColor = System.Drawing.Color.Transparent;
            this.stsUnknown2.DataBindings.Add(new System.Windows.Forms.Binding("Title", global::MadoMagiDataCounter.Properties.Settings.Default, "Unk1Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.stsUnknown2.Location = new System.Drawing.Point(549, 68);
            this.stsUnknown2.Name = "stsUnknown2";
            this.stsUnknown2.Size = new System.Drawing.Size(159, 47);
            this.stsUnknown2.TabIndex = 2;
            this.stsUnknown2.TextWidth = 53;
            this.stsUnknown2.Title = global::MadoMagiDataCounter.Properties.Settings.Default.Unk1Title;
            this.stsUnknown2.Value = ".";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(734, 452);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.stsGameCount);
            this.Controls.Add(this.chartMoney);
            this.Controls.Add(this.chartBonuses);
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
            ((System.ComponentModel.ISupportInitialize)(this.chartBonuses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMoney)).EndInit();
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
        private System.Windows.Forms.ComboBox cmbCom;
        private CountView stsCredits;
        private System.Windows.Forms.Button btnRstAll;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private CountView stsReturn;
        private CountView stsTime;
        private System.Windows.Forms.Timer timer;
        private CountView stsSpinCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBonuses;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMoney;
        private CountView stsGameCount;
        private System.Windows.Forms.Button btnConfig;
    }
}

