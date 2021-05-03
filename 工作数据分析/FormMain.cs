using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 工作数据分析.WinForm.ChengPin;
using 工作数据分析.WinForm.DataUpload;

namespace 工作数据分析
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 入库分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form成品入库分类 rkfl = new Form成品入库分类();
            rkfl.WindowState = FormWindowState.Maximized;
            rkfl.MdiParent = this;
            rkfl.Show();
        }

        private void 成品仓库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 入库明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form数据导入 sjdr = new Form数据导入();
            sjdr.WindowState = FormWindowState.Maximized;
            sjdr.MdiParent = this;
            sjdr.Show();
        }
    }
}
