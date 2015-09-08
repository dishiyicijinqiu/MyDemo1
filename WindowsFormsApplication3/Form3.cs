using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form3 : Form1
    {
        public Form3()
        {
            InitializeComponent();
            this.OnReceiveString += Form3_OnReceiveString;
        }

        void Form3_OnReceiveString(object sender, uint flag, string str)
        {
            this.listBox1.Items.Add(string.Format("{0},{1},{2}", flag, str, sender));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.SendString("Form2", 0, "你好，我是Form3");
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
