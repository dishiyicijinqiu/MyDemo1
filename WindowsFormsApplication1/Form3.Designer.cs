namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageInfo = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadPic = new System.Windows.Forms.Button();
            this.btnSaveToMMF = new System.Windows.Forms.Button();
            this.btnLoadFromMMF = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "图片说明：";
            // 
            // txtImageInfo
            // 
            this.txtImageInfo.Location = new System.Drawing.Point(95, 10);
            this.txtImageInfo.Name = "txtImageInfo";
            this.txtImageInfo.Size = new System.Drawing.Size(409, 20);
            this.txtImageInfo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(28, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(476, 281);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.Location = new System.Drawing.Point(28, 330);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPic.TabIndex = 3;
            this.btnLoadPic.Text = "载入图片";
            this.btnLoadPic.UseVisualStyleBackColor = true;
            this.btnLoadPic.Click += new System.EventHandler(this.btnLoadPic_Click);
            // 
            // btnSaveToMMF
            // 
            this.btnSaveToMMF.Location = new System.Drawing.Point(109, 330);
            this.btnSaveToMMF.Name = "btnSaveToMMF";
            this.btnSaveToMMF.Size = new System.Drawing.Size(135, 23);
            this.btnSaveToMMF.TabIndex = 4;
            this.btnSaveToMMF.Text = "保存到内存映射文件";
            this.btnSaveToMMF.UseVisualStyleBackColor = true;
            this.btnSaveToMMF.Click += new System.EventHandler(this.btnSaveToMMF_Click);
            // 
            // btnLoadFromMMF
            // 
            this.btnLoadFromMMF.Location = new System.Drawing.Point(265, 330);
            this.btnLoadFromMMF.Name = "btnLoadFromMMF";
            this.btnLoadFromMMF.Size = new System.Drawing.Size(156, 23);
            this.btnLoadFromMMF.TabIndex = 6;
            this.btnLoadFromMMF.Text = "从内存文件中提取";
            this.btnLoadFromMMF.UseVisualStyleBackColor = true;
            this.btnLoadFromMMF.Click += new System.EventHandler(this.btnLoadFromMMF_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(439, 330);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 365);
            this.Controls.Add(this.btnLoadFromMMF);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSaveToMMF);
            this.Controls.Add(this.btnLoadPic);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtImageInfo);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImageInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadPic;
        private System.Windows.Forms.Button btnSaveToMMF;
        private System.Windows.Forms.Button btnLoadFromMMF;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}