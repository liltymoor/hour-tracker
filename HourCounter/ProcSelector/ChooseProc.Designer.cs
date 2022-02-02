
namespace HourCounter
{
    partial class ChooseProc
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
            this.ProcessList = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.procInfo = new System.Windows.Forms.Label();
            this.SelectProc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessList
            // 
            this.ProcessList.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ProcessList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProcessList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ProcessList.FormattingEnabled = true;
            this.ProcessList.ItemHeight = 18;
            this.ProcessList.Location = new System.Drawing.Point(1, 1);
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(405, 252);
            this.ProcessList.TabIndex = 1;
            this.ProcessList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ProcessList_DrawItem);
            this.ProcessList.SelectedIndexChanged += new System.EventHandler(this.ProcessList_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(30, 282);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // procInfo
            // 
            this.procInfo.AutoSize = true;
            this.procInfo.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.procInfo.Location = new System.Drawing.Point(87, 282);
            this.procInfo.MaximumSize = new System.Drawing.Size(145, 13);
            this.procInfo.MinimumSize = new System.Drawing.Size(145, 13);
            this.procInfo.Name = "procInfo";
            this.procInfo.Size = new System.Drawing.Size(145, 13);
            this.procInfo.TabIndex = 3;
            this.procInfo.Text = "(Select your process to track)";
            // 
            // SelectProc
            // 
            this.SelectProc.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SelectProc.FlatAppearance.BorderSize = 0;
            this.SelectProc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectProc.Font = new System.Drawing.Font("Rubik", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectProc.ForeColor = System.Drawing.Color.MediumSlateBlue;
            this.SelectProc.Location = new System.Drawing.Point(21, 342);
            this.SelectProc.Name = "SelectProc";
            this.SelectProc.Size = new System.Drawing.Size(107, 29);
            this.SelectProc.TabIndex = 4;
            this.SelectProc.Text = "Select";
            this.SelectProc.UseVisualStyleBackColor = false;
            this.SelectProc.Click += new System.EventHandler(this.SelectProc_Click);
            // 
            // ChooseProc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(407, 383);
            this.Controls.Add(this.SelectProc);
            this.Controls.Add(this.procInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ProcessList);
            this.Name = "ChooseProc";
            this.Text = "Select Window";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ChooseProc_FormClosed);
            this.Load += new System.EventHandler(this.ChooseProc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ProcessList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label procInfo;
        private System.Windows.Forms.Button SelectProc;
    }
}