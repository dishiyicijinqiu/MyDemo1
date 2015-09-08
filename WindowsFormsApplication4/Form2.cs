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
    public partial class Form2 : Form
    {
        MessageQueue mq;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mq.Send(richTextBox1.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //新建消息循环队列或连接到已有的消息队列
            string path = ".\\private$\\killf";
            if (MessageQueue.Exists(path))
            {
                mq = new MessageQueue(path);
            }
            else
            {
                mq = MessageQueue.Create(path);
            }
            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
        }
    }
}