
namespace HourCounter
{
    partial class HourCounter
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.procInfo = new System.Windows.Forms.Label();
            this.chooseProc = new System.Windows.Forms.Button();
            this.trackList = new System.Windows.Forms.ListBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.deleteProc = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.gitHub = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(40, 302);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // procInfo
            // 
            this.procInfo.AutoSize = true;
            this.procInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.procInfo.Font = new System.Drawing.Font("Rubik Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.procInfo.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.procInfo.Location = new System.Drawing.Point(123, 302);
            this.procInfo.Name = "procInfo";
            this.procInfo.Size = new System.Drawing.Size(203, 16);
            this.procInfo.TabIndex = 4;
            this.procInfo.Text = "(Choose tracker to show stats)";
            // 
            // chooseProc
            // 
            this.chooseProc.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.chooseProc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chooseProc.FlatAppearance.BorderSize = 0;
            this.chooseProc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseProc.Font = new System.Drawing.Font("Rubik Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseProc.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.chooseProc.Location = new System.Drawing.Point(518, 43);
            this.chooseProc.Name = "chooseProc";
            this.chooseProc.Size = new System.Drawing.Size(107, 36);
            this.chooseProc.TabIndex = 5;
            this.chooseProc.Text = "Track";
            this.chooseProc.UseVisualStyleBackColor = false;
            this.chooseProc.Click += new System.EventHandler(this.chooseProc_Click);
            // 
            // trackList
            // 
            this.trackList.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.trackList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trackList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.trackList.FormattingEnabled = true;
            this.trackList.ItemHeight = 36;
            this.trackList.Location = new System.Drawing.Point(12, 12);
            this.trackList.Name = "trackList";
            this.trackList.Size = new System.Drawing.Size(472, 180);
            this.trackList.TabIndex = 6;
            this.trackList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.trackList_DrawItem);
            this.trackList.SelectedIndexChanged += new System.EventHandler(this.trackList_SelectedIndexChanged);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Tip";
            this.notifyIcon.Text = "HourCounter";
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // deleteProc
            // 
            this.deleteProc.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.deleteProc.FlatAppearance.BorderSize = 0;
            this.deleteProc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteProc.Font = new System.Drawing.Font("Rubik Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteProc.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.deleteProc.Location = new System.Drawing.Point(518, 113);
            this.deleteProc.Name = "deleteProc";
            this.deleteProc.Size = new System.Drawing.Size(107, 44);
            this.deleteProc.TabIndex = 5;
            this.deleteProc.Text = "Remove Tracker";
            this.deleteProc.UseVisualStyleBackColor = false;
            this.deleteProc.Click += new System.EventHandler(this.deleteProc_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // gitHub
            // 
            this.gitHub.ActiveLinkColor = System.Drawing.Color.MediumSlateBlue;
            this.gitHub.AutoSize = true;
            this.gitHub.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gitHub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gitHub.Font = new System.Drawing.Font("Rubik Medium", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gitHub.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.gitHub.LinkColor = System.Drawing.Color.MediumSlateBlue;
            this.gitHub.Location = new System.Drawing.Point(40, 226);
            this.gitHub.Name = "gitHub";
            this.gitHub.Size = new System.Drawing.Size(76, 26);
            this.gitHub.TabIndex = 7;
            this.gitHub.TabStop = true;
            this.gitHub.Text = "GitHub";
            this.gitHub.VisitedLinkColor = System.Drawing.Color.MediumSlateBlue;
            this.gitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitHub_LinkClicked);
            // 
            // HourCounter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(655, 409);
            this.Controls.Add(this.gitHub);
            this.Controls.Add(this.trackList);
            this.Controls.Add(this.deleteProc);
            this.Controls.Add(this.chooseProc);
            this.Controls.Add(this.procInfo);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximumSize = new System.Drawing.Size(671, 448);
            this.MinimumSize = new System.Drawing.Size(671, 448);
            this.Name = "HourCounter";
            this.Opacity = 0D;
            this.Text = "HourCounter by PenazzZ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HourCounter_FormClosing);
            this.Load += new System.EventHandler(this.HourCounter_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.HourCounter_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label procInfo;
        private System.Windows.Forms.Button chooseProc;
        private System.Windows.Forms.ListBox trackList;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button deleteProc;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.LinkLabel gitHub;
    }
}

