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

namespace 综合保障中心.登录
{
    public partial class FormAddGaodai : Form
    {
        int MaxXuhaoNum = 0;

        public FormAddGaodai()
        {
            InitializeComponent();
        }

        private void FormAddGaodai_Load(object sender, EventArgs e)
        {
            string maxXuhao = SQLiteList.GD.ExecuteScalar("SELECT [最大序号]FROM [常量]").ToString();
            if (maxXuhao == null || string.IsNullOrWhiteSpace(maxXuhao))
            {
                maxXuhao = "0";
            }
            MaxXuhaoNum = Convert.ToInt32(maxXuhao);
            this.label1.Text = "当前最大的序号是:" + maxXuhao
                + "\n请在下面输入需要增加到的序号\n(不能超过999)";

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("此操作无法撤销,确认要生成吗?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }
                int xuhaoAdd = Convert.ToInt32(this.textBoxXuhao.Text);
                if (xuhaoAdd <= MaxXuhaoNum)
                {
                    throw new Exception("输入的序号不能小于当前的最大序号");
                }
                if (xuhaoAdd > 999)
                {
                    throw new Exception("输入的序号不能大于999");
                }
                for (char qz = 'A'; qz <= 'Z'; qz++)
                {
                    List<string> sqlList = new List<string>();
                    for (int i = MaxXuhaoNum + 1; i <= xuhaoAdd; i++)
                    {
                        string gaodaihao = qz.ToString() + i.ToString().PadLeft(3, '0');
                        sqlList.Add("INSERT INTO [稿袋]([稿袋号],[客户名称],[产品名称],[状态],[创建时间],[创建人],[最后修改时间],[最后修改人],[存放位置])" +
                            "SELECT '" + gaodaihao + "'" +
                            ",''" +
                            ",''" +
                            ",'空白'" +
                            ",datetime('now','localtime')" +
                            ",'" + User.FullName + "'" +
                            ",datetime('now','localtime')" +
                            ",'" + User.FullName + "'" +
                            ",''" +
                            "where not exists(select* from [稿袋]where [稿袋号]='" + gaodaihao + "');");
                    }
                    if (!SQLiteList.GD.ExecuteSqlTran(sqlList))
                    {
                        throw new Exception("插入失败!");
                    }
                }
                SQLiteList.GD.ExecuteNonQuery("UPDATE [常量]SET [最大序号] = " + xuhaoAdd);
                MessageBox.Show("插入成功!");
                FormAddGaodai_Load(this, new EventArgs());
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }

        }
    }
}
