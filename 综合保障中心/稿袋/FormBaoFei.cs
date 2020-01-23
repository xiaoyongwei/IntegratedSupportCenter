using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;

namespace 综合保障中心.稿袋
{
    public partial class FormBaoFei : Form
    {
        string gdh = "";
        public FormBaoFei(string gdh)
        {
            this.gdh = gdh;
            InitializeComponent();
        }

        private void FormBaoFei_Load(object sender, EventArgs e)
        {
            DataTable dt = SQLiteList.GD.ExecuteDataTable("select * from [稿袋] where [稿袋号]='" + gdh + "'");
            this.textBoxGdh.Text = gdh;
            this.textBoxCustomer.Text = dt.Rows[0]["客户名称"].ToString();
            this.textBoxProduct.Text = dt.Rows[0]["产品名称"].ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string sql_BaofeiDengji = string.Format(
                "INSERT INTO [稿袋报废]([稿袋号],[客户名称],[产品名称],[报废时间],[报废人],[报废原因],[备注])VALUES("
                + "'{0}','{1}','{2}','{3}','{4}','{5}','{6}');"
                , gdh, this.textBoxCustomer.Text, this.textBoxProduct.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                , User.FullName, this.textBoxCause.Text, textBoxNote.Text);

            string sqlStr = "";
            //如果包含字符'-',则表示是附属稿袋
            if (gdh.Contains('-'))
            {
                sqlStr = "DELETE FROM [稿袋] WHERE [稿袋号]='" + gdh + "';";
            }
            else
            {
                sqlStr = "UPDATE [稿袋]SET "
                    + "[客户名称] = ''"
                    + ",[产品名称] =''"
                    + ",[状态] = ''"
                    + ",[最后修改人] ='" + User.FullName + "'"
                    + ",[存放位置] =''"
                    + ",[备注] =''"
                    + "WHERE [稿袋号]='" + gdh + "';";
            }
            this.DialogResult =
            SQLiteList.GD.ExecuteSqlTran(sqlStr)
            && SQLiteList.GD.ExecuteSqlTran(sql_BaofeiDengji)
            ? DialogResult.OK : DialogResult.No;

        }
    }
}
