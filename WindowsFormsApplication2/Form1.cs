using ShareMemLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        ShareMem MemDB = new ShareMem();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (MemDB.Init("YFMemTest", 10240) != 0)
            {
                //初始化失败
                MessageBox.Show("初始化失败");
            }
            else
            {
                btnOpen.Enabled = false;
                chkWrite.Enabled = true;
                tmrTime.Enabled = true;
            }
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            byte[] bytData = new byte[16];
            int intRet = MemDB.Read(ref bytData, 0, 16);
            lstData.Items.Clear();
            if (intRet == 0)
            {
                for (int i = 0; i < 16; i++)
                {
                    lstData.Items.Add(bytData[i].ToString());
                }

                if (chkWrite.Checked)
                {
                    bytData[0]++;
                    bytData[1] += 2;
                    if (bytData[0] > 200) bytData[0] = 0;
                    if (bytData[1] > 200) bytData[1] = 0;
                    MemDB.Write(bytData, 0, 16);
                }
            }           
        }
    }
}
