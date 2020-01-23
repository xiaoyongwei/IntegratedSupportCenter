using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BestString
{
    public partial class Form1 : Form
    {
        string[] datas = null;

        public Form1()
        {
            InitializeComponent();

            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Application.StartupPath;
        }
       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            QueryHelper.Query(textBox2.Text, datas, (key, result, elapsed) => this.Invoke(new MethodInvoker(() =>
            {
                if (result == null) result = new string[0];

                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                listBox1.Items.AddRange(result.Take(1000).ToArray());
                listBox1.EndUpdate();
            })));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            datas = Directory.GetFiles(@"\\128.1.30.144\JobData\pdf\转好PDF文件"
                , "*.pdf", SearchOption.AllDirectories);
        }
    }
}
