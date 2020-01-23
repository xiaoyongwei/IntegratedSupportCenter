using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 工作数据分析.WinForm.物流
{
    public partial class Form发货通知单 : Form
    {
        public Form发货通知单()
        {
            InitializeComponent();
        }

        private void Form发货通知单_Load(object sender, EventArgs e)
        {

        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form发货通知单Add().ShowDialog();
        }
    }
}
