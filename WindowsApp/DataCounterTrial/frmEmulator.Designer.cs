﻿
namespace MadoMagiDataCounter
{
    partial class frmEmulator
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "0";
            this.button1.Text = "Alarm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Tag = "1";
            this.button2.Text = "BB";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Tag = "2";
            this.button3.Text = "?";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Tag = "3";
            this.button4.Text = "RB";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(12, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Tag = "4";
            this.button5.Text = "unused";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 58);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Tag = "5";
            this.button6.Text = "Out";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(12, 35);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 6;
            this.button7.Tag = "6";
            this.button7.Text = "?";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(12, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 7;
            this.button8.Tag = "7";
            this.button8.Text = "In";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.onButtonPress);
            this.button8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.onButtonRelease);
            // 
            // frmEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(99, 206);
            this.ControlBox = false;
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmulator";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TEST MODE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}