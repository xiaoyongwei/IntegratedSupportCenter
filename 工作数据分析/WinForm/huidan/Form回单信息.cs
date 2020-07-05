using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 工作数据分析.WinForm.huidan
{
    public partial class Form回单信息 : Form
    {
        private string shdh;
        public Form回单信息(string shdh)
        {
            this.shdh = shdh;
            InitializeComponent();
        }

        private void Form回单信息_Load(object sender, EventArgs e)
        {
            MySqlDataReader reader = MySqlDbHelper.ExecuteReader("SELECT * FROM `slbz`.`送货回单情况`where 送货单号='" + shdh + "'");
            reader.Read();
            this.textBoxshdh.Text = reader["送货单号"].ToString();
            this.textBoxshrq.Text = reader["送货日期"].ToString();
            this.textBoxkhjc.Text = reader["客户简称"].ToString();
            this.textBoxshsj.Text = reader["司机"].ToString();
            this.textBoxycyy.Text = reader["异常原因"].ToString();
            this.textBoxyccl.Text = reader["异常处理"].ToString();
            reader.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            MySqlDbHelper.ExecuteNonQuery("UPDATE `slbz`.`送货回单情况`SET `异常原因` = '"
                + textBoxycyy.Text.Trim() + "',`异常处理` ='" + textBoxyccl.Text.Trim()
                + "'	WHERE `送货单号`='" + this.shdh + "';");
            this.DialogResult = DialogResult.OK;
        }
    }
}
