using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        //消息标识
        private const int WM_COPYDATA = 0x004A;
        //消息数据类型(typeFlag以上二进制，typeFlag以下字符)
        private const uint typeFlag = 0x8000;
        /// <summary>
        /// 重载CopyDataStruct
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;
        }
        //
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(
               int hWnd,                                  // handle to destination window
               int Msg,                              // message
               int wParam,                               // first message parameter
               ref COPYDATASTRUCT lParam    // second message parameter
               );
        //
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        //接收到数据委托与事件定义
        public delegate void ReceiveStringEvent(object sender, uint flag, string str);
        public delegate void ReceiveBytesEvent(object sender, uint flag, byte[] bt);
        public event ReceiveStringEvent OnReceiveString;
        public event ReceiveBytesEvent OnReceiveBytes;
        //发送数据委托与事件定义
        public delegate void SendStringEvent(object sender, uint flag, string str);
        public delegate void SendBytesEvent(object sender, uint flag, byte[] bt);
        public event SendStringEvent OnSendString;
        public event SendBytesEvent OnSendBytes;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        ///重载窗口消息处理函数
        /// </summary>
        /// <param name="m"></param>
        protected override void DefWndProc(ref System.Windows.Forms.Message m)
        {

            switch (m.Msg)
            {
                //接收CopyData消息，读取发送过来的数据
                case WM_COPYDATA:
                    COPYDATASTRUCT cds = new COPYDATASTRUCT();
                    Type mytype = cds.GetType();
                    cds = (COPYDATASTRUCT)m.GetLParam(mytype);
                    uint flag = (uint)(cds.dwData);
                    byte[] bt = new byte[cds.cbData];
                    Marshal.Copy(cds.lpData, bt, 0, bt.Length);
                    if (flag <= typeFlag)
                    {
                        if (OnReceiveString != null)
                        {
                            OnReceiveString(this, flag, System.Text.Encoding.Default.GetString(bt));
                        }
                    }
                    else
                    {
                        if (OnReceiveBytes != null)
                        {
                            OnReceiveBytes(this, flag, bt);
                        }
                    }
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
        /// <summary>
        /// 发送字符串格式数据
        /// </summary>
        /// <param name="destWindow">目标窗口标题</param>
        /// <param name="flag">数据标志</param>
        /// <param name="str">数据</param>
        /// <returns></returns>
        public bool SendString(string destWindow, uint flag, string str)
        {
            if (flag > typeFlag)
            {
                MessageBox.Show("要发送的数据不是字符格式");
                return false;
            }
            int WINDOW_HANDLER = FindWindow(null, @destWindow);
            if (WINDOW_HANDLER == 0) return false;
            try
            {
                byte[] sarr = System.Text.Encoding.Default.GetBytes(str);
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)flag;
                cds.cbData = sarr.Length;
                cds.lpData = Marshal.AllocHGlobal(sarr.Length);
                Marshal.Copy(sarr, 0, cds.lpData, sarr.Length);
                SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref cds);
                if (OnSendString != null)
                {
                    OnSendString(this, flag, str);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        /// <summary>
        /// 发送二进制格式数据
        /// </summary>
        /// <param name="destWindow">目标窗口</param>
        /// <param name="flag">数据标志</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public bool SendBytes(string destWindow, uint flag, byte[] data)
        {
            if (flag <= typeFlag)
            {
                MessageBox.Show("要发送的数据不是二进制格式");
                return false;
            }
            int WINDOW_HANDLER = FindWindow(null, @destWindow);
            if (WINDOW_HANDLER == 0) return false;
            try
            {
                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)flag;
                cds.cbData = data.Length;
                cds.lpData = Marshal.AllocHGlobal(data.Length);
                Marshal.Copy(data, 0, cds.lpData, data.Length);
                SendMessage(WINDOW_HANDLER, WM_COPYDATA, 0, ref cds);
                if (OnSendBytes != null)
                {
                    OnSendBytes(this, flag, data);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
    }
}
