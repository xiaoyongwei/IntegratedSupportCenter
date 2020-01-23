using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.稿袋;
using 综合保障中心.其它;

namespace 综合保障中心
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //if (new FormLogin().ShowDialog() != DialogResult.OK)
            //{ this.Dispose(true); }
            //this.tsslUserFullName.Text = "欢迎你:" + User.FullName;
            //this.稿袋管理ToolStripMenuItem.Visible = User.稿袋查看权限 || User.稿袋管理权限;
            //this.开单辅助ToolStripMenuItem.Visible = User.开单查看权限 || User.开单管理权限;
            //this.生产计划管理ToolStripMenuItem.Visible = User.生产计划查看权限 || User.生产计划管理权限;
            //this.数码单进出管理ToolStripMenuItem.Visible = User.数码单查看权限 || User.数码单管理权限;
            //this.用户管理ToolStripMenuItem.Visible = User.系统管理员权限;
            //this.系统设置ToolStripMenuItem.Visible = User.系统管理员权限;
            //this.其它功能ToolStripMenuItem.Visible = User.UserName == "xyw";



            this.WindowState = FormWindowState.Maximized;
        }

        private void 稿袋管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGaodaiManager gaodai = new FormGaodaiManager();
            gaodai.MdiParent = this;
            gaodai.WindowState = FormWindowState.Maximized;
            gaodai.Show();
        }

        private void 易捷按钮破解ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormYijie().ShowDialog();
        }

        private void 运费计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormYunfei().ShowDialog();
        }
    }
}
