using System.Windows.Forms;

namespace TetrisBot
{
    partial class TetrisBot
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.BoardPic = new System.Windows.Forms.PictureBox();
            this.NextPic = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PlayBut = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.CalibrationInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextPic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(6, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Run Calibration";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BoardPic
            // 
            this.BoardPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.BoardPic.Location = new System.Drawing.Point(6, 21);
            this.BoardPic.Name = "BoardPic";
            this.BoardPic.Size = new System.Drawing.Size(97, 127);
            this.BoardPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BoardPic.TabIndex = 2;
            this.BoardPic.TabStop = false;
            this.BoardPic.Click += new System.EventHandler(this.button2_Click);
            // 
            // NextPic
            // 
            this.NextPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NextPic.Location = new System.Drawing.Point(109, 21);
            this.NextPic.Name = "NextPic";
            this.NextPic.Size = new System.Drawing.Size(97, 127);
            this.NextPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.NextPic.TabIndex = 5;
            this.NextPic.TabStop = false;
            this.NextPic.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(225, 415);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PlayBut);
            this.tabPage1.Controls.Add(this.log);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(217, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TetrisBot";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PlayBut
            // 
            this.PlayBut.Location = new System.Drawing.Point(3, 356);
            this.PlayBut.Name = "PlayBut";
            this.PlayBut.Size = new System.Drawing.Size(205, 23);
            this.PlayBut.TabIndex = 10;
            this.PlayBut.Text = "Play";
            this.PlayBut.UseVisualStyleBackColor = true;
            this.PlayBut.Click += new System.EventHandler(this.PlayBut_Click);
            // 
            // log
            // 
            this.log.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.log.Location = new System.Drawing.Point(6, 6);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(202, 344);
            this.log.TabIndex = 9;
            this.log.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.trackBar1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.CalibrationInfo);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.BoardPic);
            this.tabPage2.Controls.Add(this.NextPic);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(217, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Calibration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 10;
            this.trackBar1.Location = new System.Drawing.Point(6, 169);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(200, 45);
            this.trackBar1.TabIndex = 14;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Pause between pressing keys";
            // 
            // CalibrationInfo
            // 
            this.CalibrationInfo.Location = new System.Drawing.Point(6, 220);
            this.CalibrationInfo.Multiline = true;
            this.CalibrationInfo.Name = "CalibrationInfo";
            this.CalibrationInfo.ReadOnly = true;
            this.CalibrationInfo.Size = new System.Drawing.Size(199, 130);
            this.CalibrationInfo.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "NextFigure";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Board";
            // 
            // TetrisBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 422);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(255, 461);
            this.MinimumSize = new System.Drawing.Size(255, 461);
            this.Name = "TetrisBot";
            this.Text = "TetrisBot";
            ((System.ComponentModel.ISupportInitialize)(this.BoardPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NextPic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private PictureBox BoardPic;
        private PictureBox NextPic;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button PlayBut;
        private TextBox log;
        private TabPage tabPage2;
        private Label label2;
        private Label label1;
        private TextBox CalibrationInfo;
        private TrackBar trackBar1;
        private Label label3;
    }
}