using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 工作数据.winForm.每日数据;
using 工作数据.winForm;

namespace 工作数据
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 每日数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form每日数据 formShuju = new Form每日数据();
            formShuju.MdiParent = this;
            formShuju.WindowState = FormWindowState.Maximized;
            formShuju.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void 物料管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form物料管理 guanli = new Form物料管理();
            guanli.MdiParent = this;
            guanli.WindowState = FormWindowState.Maximized;
            guanli.Show();
        }

        private void 基础数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 每日数据汇总ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form每日数据汇总 form汇总 = new Form每日数据汇总();
            form汇总.MdiParent = this;
            form汇总.WindowState = FormWindowState.Maximized;
            form汇总.Show();
        }

        private void 每日数据汇总图表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form每日数据汇总_图表 tubiao = new Form每日数据汇总_图表();
            tubiao.MdiParent = this;
            tubiao.WindowState = FormWindowState.Maximized;
            tubiao.Show();
        }

    }
}
