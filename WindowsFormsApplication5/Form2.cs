using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        NamedPipeServerStream pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.InOut, 4, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                pipeServer.BeginWaitForConnection((o) =>
                {
                    NamedPipeServerStream server = (NamedPipeServerStream)o.AsyncState;
                    server.EndWaitForConnection(o);
                    StreamReader sr = new StreamReader(server);
                    StreamWriter sw = new StreamWriter(server);
                    string result = null;
                    string clientName = server.GetImpersonationUserName();
                    while (true)
                    {
                        result = sr.ReadLine();
                        if (result == null || result == "bye")
                            break;
                        this.Invoke((MethodInvoker)delegate { lsbMsg.Items.Add(clientName + " : " + result); });
                    }
                }, pipeServer);
            });
        }
    }
}
