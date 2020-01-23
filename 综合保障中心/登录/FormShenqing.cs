using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;
using HandeJobManager.DAL;

namespace 综合保障中心.登录
{
    public partial class FormShenqing : Form
    {
        public FormShenqing()
        {
            InitializeComponent();
        }

        private void buttonShenqing_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.textBoxUsername.Text))
                {
                    throw new Exception("用户名不能为空!");
                }
                if (string.IsNullOrWhiteSpace(this.textBoxPassword.Text))
                {
                    throw new Exception("密码不能为空!");
                }
                if (string.IsNullOrWhiteSpace(this.textBoxFullName.Text))
                {
                    throw new Exception("姓名不能为空!");
                }
                //判断是否有重复的用户名和重复的姓名
                if (SQLiteList.GD.ExecuteDataTable(
                    "select * from [用户] where [用户名]='" + this.textBoxUsername.Text.Trim() + "'").Rows.Count > 0)
                {
                    throw new Exception("用户名已经存在!");
                }
                if (SQLiteList.GD.ExecuteDataTable(
                    "select * from [用户] where [姓名]='" + this.textBoxFullName.Text.Trim() + "'").Rows.Count > 0)
                {
                    throw new Exception("姓名已经存在!");
                }
                //插入数据
                string insertSql = "INSERT INTO [用户]([用户名],[密码],[姓名])VALUES("
                    + "'" + this.textBoxUsername.Text.Trim() + "',"
                    + "'" + this.textBoxPassword.Text.Trim() + "',"
                    + "'" + this.textBoxFullName.Text.Trim() + "');";
                if (SQLiteList.GD.ExecuteSqlTran(new List<string>(new string[] { insertSql })))
                {
                    MessageBox.Show("申请成功\n请联系管理员授权后才能登陆操作");
                    this.Dispose();
                }
                else
                {
                    throw new Exception("申请失败!");
                }
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void FormShenqing_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }
    }
}
