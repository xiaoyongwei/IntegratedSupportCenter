using System;
using System.Windows.Forms;

namespace 工作数据分析.WinForm.WuLiu
{
    public partial class Form物流Mian : Form
    {
        public Form物流Mian()
        {
            InitializeComponent();
        }


       
       
        private void 回单管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = this.MdiChildren.Length-1; i >=0 ; i--)
            {
                if (this.MdiChildren[i] is Form回单管理)
                {
                    this.MdiChildren[i].Dispose();
                }
            }

            Form回单管理 huidan = new Form回单管理();
            huidan.WindowState = FormWindowState.Maximized;
            huidan.MdiParent = this;
            huidan.Show();
        }

        private void 运费结算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = this.MdiChildren.Length - 1; i >= 0; i--)
            {
                if (this.MdiChildren[i] is Form运费结算)
                {
                    this.MdiChildren[i].Dispose();
                }
            }

            Form运费结算 yunfei = new Form运费结算();
            yunfei.WindowState = FormWindowState.Maximized;
            yunfei.MdiParent = this;
            yunfei.Show();
        }
    }
}
