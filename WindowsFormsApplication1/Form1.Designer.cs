namespace WindowsFormsApplication1
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
            this.lblInfo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnWrite1 = new System.Windows.Forms.Button();
            this.btnWrite2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblInfo.Location = new System.Drawing.Point(0, 250);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(37, 68);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            // 
            // btnWrite1
            // 
            this.btnWrite1.Location = new System.Drawing.Point(166, 20);
            this.btnWrite1.Name = "btnWrite1";
            this.btnWrite1.Size = new System.Drawing.Size(249, 23);
            this.btnWrite1.TabIndex = 5;
            this.btnWrite1.Text = "向文件前半段写入此字符";
            this.btnWrite1.UseVisualStyleBackColor = true;
            this.btnWrite1.Click += new System.EventHandler(this.btnWrite1_Click);
            // 
            // btnWrite2
            // 
            this.btnWrite2.Location = new System.Drawing.Point(166, 66);
            this.btnWrite2.Name = "btnWrite2";
            this.btnWrite2.Size = new System.Drawing.Size(249, 23);
            this.btnWrite2.TabIndex = 6;
            this.btnWrite2.Text = "向文件后半段写入此字符";
            this.btnWrite2.UseVisualStyleBackColor = true;
            this.btnWrite2.Click += new System.EventHandler(this.btnWrite2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(49, 95);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(353, 139);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 263);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnWrite2);
            this.Controls.Add(this.btnWrite1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnWrite1;
        private System.Windows.Forms.Button btnWrite2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

