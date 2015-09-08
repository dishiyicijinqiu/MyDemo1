using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateMemoryMapFile();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private const int FILE_SIZE = 512;
        /// <summary>  
        /// 引用内存映射文件  
        /// </summary>  
        private MemoryMappedFile memoryFile = null;
        /// <summary>  
        /// 用于访问内存映射文件的存取对象  
        /// </summary>  
        private MemoryMappedViewAccessor accessor1, accessor2, accessor;
        /// <summary>  
        /// 创建内存映射文件  
        /// </summary>  
        private void CreateMemoryMapFile()
        {
            try
            {
                memoryFile = MemoryMappedFile.CreateFromFile("MyFile.dat", FileMode.OpenOrCreate, "MyFile", FILE_SIZE);
                //访问文件前半段  
                accessor1 = memoryFile.CreateViewAccessor(0, FILE_SIZE / 2);
                //访问文件后半段  
                accessor2 = memoryFile.CreateViewAccessor(FILE_SIZE / 2, FILE_SIZE / 2);
                //访问全部文件  
                accessor = memoryFile.CreateViewAccessor();
                //InitFileContent();  
                lblInfo.Text = "内存文件创建成功";
                ShowFileContents();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
        /// <summary>  
        /// 关闭并释放资源  
        /// </summary>  
        private void DisposeMemoryMapFile()
        {
            if (accessor1 != null)
                accessor1.Dispose();
            if (accessor2 != null)
                accessor2.Dispose();
            if (memoryFile != null)
                memoryFile.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DisposeMemoryMapFile();
        }

        private void btnWrite1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                lblInfo.Text = "请输入一个字符";
                return;
            }
            char[] chs = textBox1.Text.ToCharArray();
            char ch = chs[0];

            for (int i = 0; i < FILE_SIZE / 2; i += 2)
                accessor1.Write(i, ch);

            lblInfo.Text = "字符“" + ch + "”已写到文件前半部份";
            ShowFileContents();  
        }
        /// <summary>  
        /// 显示文件内容  
        /// </summary>  
        private void ShowFileContents()
        {
            StringBuilder sb = new StringBuilder(FILE_SIZE);
            sb.Append("上半段内容：\n");

            int j = 0;
            for (int i = 0; i < FILE_SIZE / 2; i += 2)
            {
                sb.Append("\t");
                char ch = accessor.ReadChar(i);
                sb.Append(j);
                sb.Append(":");
                sb.Append(ch);
                j++;
            }
            sb.Append("\n下半段内容：\n");

            for (int i = FILE_SIZE / 2; i < FILE_SIZE; i += 2)
            {
                sb.Append("\t");
                char ch = accessor.ReadChar(i);
                sb.Append(j);
                sb.Append(":");
                sb.Append(ch);
                j++;
            }
            richTextBox1.Text = sb.ToString();
        }  
        private void btnWrite2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                lblInfo.Text = "请输入一个字符";
                return;
            }
            char[] chs = textBox2.Text.ToCharArray();
            char ch = chs[0];

            for (int i = 0; i < FILE_SIZE / 2; i += 2)
                accessor2.Write(i, ch);
            lblInfo.Text = "字符“" + ch + "”已写到文件后半部份";
            ShowFileContents();  
        }
    }
}
