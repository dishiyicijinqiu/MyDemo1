using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form3 : Form
    {

        NamedPipeClientStream pipeClient =
                new NamedPipeClientStream("127.0.0.1", "testpipe",
                    PipeDirection.InOut, PipeOptions.Asynchronous,
                    TokenImpersonationLevel.None);
        StreamWriter sw = null;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            pipeClient.Connect();
            sw = new StreamWriter(pipeClient);
            sw.AutoFlush = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sw.WriteLine(textBox1.Text);
        }
    }
}
