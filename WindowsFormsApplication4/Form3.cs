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
    public partial class Form3 : Form
    {
        MessageQueue mq;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
            mq.ReceiveCompleted += mq_ReceiveCompleted;
            mq.BeginReceive();
        }
        void mq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            MessageQueue mq = (MessageQueue)sender;
            System.Messaging.Message m = mq.EndReceive(e.AsyncResult);
            //处理消息
            string str = m.Body.ToString();
            this.richTextBox1.Invoke(new Action<string>(ShowMsg), str);

            //继续下一条消息
            mq.BeginReceive();
        }
        private void ShowMsg(string msg)
        {
            this.richTextBox1.Text = this.richTextBox1.Text + msg + Environment.NewLine;
            return;
        }
    }
}
