namespace WindowsFormsApplication2
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
            this.btnOpen = new System.Windows.Forms.Button();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.chkWrite = new System.Windows.Forms.CheckBox();
            this.lstData = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(161, 322);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "button1";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // chkWrite
            // 
            this.chkWrite.AutoSize = true;
            this.chkWrite.Location = new System.Drawing.Point(47, 326);
            this.chkWrite.Name = "chkWrite";
            this.chkWrite.Size = new System.Drawing.Size(80, 17);
            this.chkWrite.TabIndex = 1;
            this.chkWrite.Text = "checkBox1";
            this.chkWrite.UseVisualStyleBackColor = true;
            // 
            // lstData
            // 
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(25, 12);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(288, 290);
            this.lstData.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 357);
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.chkWrite);
            this.Controls.Add(this.btnOpen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.CheckBox chkWrite;
        private System.Windows.Forms.ListBox lstData;
    }
}

