using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using 综合保障中心.Comm;
using 综合保障中心.登录;

namespace 综合保障中心
{
    public partial class FormLogin : Form
    {
       
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxUN.Text))
            {
                My.ShowErrorMessage("用户名不能为空!");
                return;
            }
            if (string.IsNullOrWhiteSpace(this.textBoxPW.Text))
            {
                My.ShowErrorMessage("密码不能为空!");
                return;
            }
            string userName = this.textBoxUN.Text.Trim();
            string passWord = this.textBoxPW.Text.Trim();

            DataTable dtUser = SQLiteList.GD.ExecuteDataTable(string.Format("select * from [用户] where [用户名]='{0}'AND[密码]='{1}'", userName, passWord));
            if (dtUser.Rows.Count!=1)
            {
                My.ShowErrorMessage("用户名不存在,或密码不正确!");
                return;
            }
            else
            {
                User.UserName = userName;
                User.UserPassWord = passWord;
                User.FullName = dtUser.Rows[0]["姓名"].ToString();
                User.Note = dtUser.Rows[0]["备注"].ToString();
                User.稿袋查看权限 =Convert.ToBoolean( dtUser.Rows[0]["权限_稿袋_查看"]);
                User.稿袋管理权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_稿袋_管理"]);
                User.开单查看权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_开单_查看"]);
                User.开单管理权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_开单_管理"]);
                User.生产计划查看权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_生产计划_查看"]);
                User.生产计划管理权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_生产计划_管理"]);
                User.数码单查看权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_数码单_查看"]);
                User.数码单管理权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_数码单_管理"]);
                User.系统管理员权限 = Convert.ToBoolean(dtUser.Rows[0]["权限_系统管理员"]);

                this.DialogResult = DialogResult.OK;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.textBoxUN.Text = "xyw";
            this.textBoxPW.Text = "1234";
        }

        private void buttonShenqing_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormShenqing().ShowDialog();
            this.Show();
        }
    }
}
