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
    public partial class FormGaodaiInfo : Form
    {
        string gdh;
        bool isChange;
        public FormGaodaiInfo(string gdh, bool isChange)
        {
            InitializeComponent();
            this.gdh = gdh;
            this.isChange = isChange;
        }

        private void FormGaodaiInfo_Load(object sender, EventArgs e)
        {
            this.textBoxKhcm.ReadOnly = !isChange;
            this.textBoxCpmc.ReadOnly = !isChange;
            this.textBoxZt.ReadOnly = !isChange;
            this.textBoxCfwz.ReadOnly = !isChange;
            this.textBoxBz.ReadOnly = !isChange;
            this.buttonSave.Visible = isChange;


            DataTable dt = SQLiteList.GD.ExecuteDataTable("select * from [稿袋]where[稿袋号]='" + gdh + "'");
            if (dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                this.textBoxGdh.Text = dr["稿袋号"].ToString();
                this.textBoxKhcm.Text = dr["客户名称"].ToString();
                this.textBoxCpmc.Text = dr["产品名称"].ToString();
                this.textBoxZt.Text = dr["状态"].ToString();
                this.textBoxCjsj.Text = dr["创建时间"].ToString();
                this.textBoxCjr.Text = dr["创建人"].ToString();
                this.textBoxZhxgsj.Text = dr["最后修改时间"].ToString();
                this.textBoxZhxgr.Text = dr["最后修改人"].ToString();
                this.textBoxCfwz.Text = dr["存放位置"].ToString();
                this.textBoxBz.Text = dr["备注"].ToString();
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE [稿袋]SET" +
                "[客户名称] = '" + this.textBoxKhcm.Text.Trim() + "'" +
                ",[产品名称] = '" + this.textBoxCpmc.Text.Trim() + "'" +
                ",[状态] = '" + this.textBoxZt.Text.Trim() + "'" +
                ",[最后修改人] = '" + User.FullName + "'" +
                ",[存放位置] = '" + this.textBoxKhcm.Text.Trim() + "'" +
                ",[备注] = '" + this.textBoxKhcm.Text.Trim() + "'" +
                "WHERE  [稿袋号] = '" + gdh+ "';";





            this.DialogResult = DialogResult.OK;
        }


    }
}
