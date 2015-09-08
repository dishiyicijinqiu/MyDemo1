using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        //MessageQueue queue = new MessageQueue("SRV-MESSAGINGTechRepublic");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }
    }
}
