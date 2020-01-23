using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using YBF.Class.Comm;
using System.Text.RegularExpressions;
using 综合保障中心.稿袋;
using 综合保障中心.Comm;

namespace 综合保障中心
{
    public partial class FormAutoMake : Form
    {


        DataTable dt_all = new DataTable();

        public FormAutoMake()
        {
            InitializeComponent();
        }
        public FormAutoMake(bool isGongyong, string gdh)
        {
            InitializeComponent();
            this.radioButtonZhiding.Checked = true;
            this.textBoxGaodai.Text = gdh;
        }

        private void FormAutoMake_Load(object sender, EventArgs e)
        {



            InitGaodaiAll();

        }

        private void InitGaodaiAll()
        {
            dt_all = SQLiteList.GD.ExecuteDataTable("select * from [稿袋] where [客户名称]!=''and[产品名称]!=''");
            dt_all.Columns.Add("kehupinyin");
            dt_all.Columns.Add("chanpinpinyin");
            foreach (DataRow dr in dt_all.Rows)
            {
                dr["kehupinyin"] = PinYinConverter.GetFirstAndFull(dr["客户名称"].ToString());
                dr["chanpinpinyin"] = PinYinConverter.GetFirstAndFull(dr["产品名称"].ToString());
            }
        }

        private void ShowDgv()
        {
            this.dgv.Rows.Clear();
            string customer = this.textBoxCustomer.Text.Trim();
            string chanpin = string.IsNullOrWhiteSpace(this.textBoxChanpin.Text) ? "*" : this.textBoxChanpin.Text.Trim();
            if (string.IsNullOrWhiteSpace(customer)&&string.IsNullOrWhiteSpace(chanpin))
            {
                return;
            }
            foreach (DataRow dr in dt_all.Select(
                "(客户名称 like'%" + customer + "%' OR kehupinyin like'%" + customer + "%')" +
                "AND( 产品名称 like '%" + chanpin + "%'OR  产品名称 like'" + chanpin + "')"))
            {
                dgv.Rows.Add(new string[] { dr["客户名称"].ToString(), dr["产品名称"].ToString(), dr["稿袋号"].ToString() });
            }
            if (this.radioButtonZhiding.Checked)
            {
                return;
            }
            if (dgv.Rows.Count > 0)
            {
                bool isSomeGdh = true;
                string gdh = dgv.Rows[0].Cells["ColumnGaodai"].Value.ToString().Split('-')[0];
                for (int i = 1; i < dgv.Rows.Count; i++)
                {
                    if (gdh != dgv.Rows[i].Cells["ColumnGaodai"].Value.ToString().Split('-')[0])
                    {
                        isSomeGdh = false;
                        break;
                    }
                }
                if (isSomeGdh)
                {
                    textBoxGaodai.Text = gdh.Split('-')[0];
                }
                else
                {
                    textBoxGaodai.Text = "";
                }
            }
            else
            {
                textBoxGaodai.Text = "";
            }
            
        }


        private void textBoxCustomer_TextChanged(object sender, EventArgs e)
        {
            ShowDgv();
        }

        //private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex > -1 && e.RowIndex > -1)
        //    {
        //        if (textBoxCustomer.Focused)
        //        {
        //            string name = dgv.Rows[e.RowIndex].Cells[ColumnCustomer.Index].Value.ToString();
        //            this.textBoxCustomer.Text = name.Substring(0, name.IndexOf("------"));
        //        }
        //        else if (textBoxChanpin.Focused)
        //        {
        //            string name = dgv.Rows[e.RowIndex].Cells[ColumnChanpin.Index].Value.ToString();
        //        }
        //    }
        //}



        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (this.dgv.Rows[e.RowIndex].Cells[ColumnGaodai.Index].Value != null)
                {
                    this.textBoxGaodai.Text = this.dgv.Rows[e.RowIndex].Cells[ColumnGaodai.Index].Value.ToString().Split('-')[0];
                }
                else
                {
                    this.textBoxGaodai.Text = "";
                }
            }
        }

        private void buttonMake_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxCustomer.Text))
            {
                MessageBox.Show("客户不能为空!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(this.textBoxChanpin.Text))
            {
                MessageBox.Show("产品名称不能为空!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string customer = this.textBoxCustomer.Text.Trim();
            string product = this.textBoxChanpin.Text.Trim();

            List<string> sqlList = new List<string>();
            string newGaodai = "";
            if (radioButtonShunxu.Checked)//按顺序生成
            {
                newGaodai = SQLiteList.GD.ExecuteScalar
                   ("SELECT Max([稿袋号])FROM [稿袋]	where [客户名称]!=''and[产品名称]!=''").ToString();
                if (string.IsNullOrWhiteSpace(newGaodai))
                {
                    newGaodai = "A001";
                }
                else
                {
                    int zuidaxuhao = Convert.ToInt32(SQLiteList.GD.ExecuteScalar
                  ("SELECT [最大序号]FROM [常量]"));
                    int dangqianxuaho = Convert.ToInt32(Regex.Match(newGaodai, "\\d+").Value);
                    char qianzhui = newGaodai[0];
                    if (dangqianxuaho + 1 > zuidaxuhao)
                    {
                        dangqianxuaho = 1;
                        qianzhui++;
                        if (qianzhui > 'Z')
                        {
                            throw new Exception("按顺序生成的方式操作,目前序号已经用完!\n"
                            + "请[挑选空白的稿袋]或[指定稿袋号]");
                        }
                    }
                    else
                    {
                        dangqianxuaho++;
                    }
                    newGaodai = qianzhui.ToString() + dangqianxuaho.ToString().PadLeft(3, '0');
                }

            }
            else if (radioButtonKongbai.Checked)//挑选空白的稿袋
            {
                newGaodai = SQLiteList.GD.ExecuteScalar
                    ("SELECT Min([稿袋号])FROM [稿袋]	where [客户名称]=''and[产品名称]=''").ToString();
            }
            else if (radioButtonZhiding.Checked)//指定的稿袋
            {
                //判断是否是空白稿袋
                DataTable dt_temp = SQLiteList.GD.ExecuteDataTable("select * from [稿袋]where [稿袋号]=='" + this.textBoxGaodai.Text.Trim() + "'");
                if (dt_temp.Rows.Count > 0)
                {
                    if (new FormGaodaiHebing(this.textBoxGaodai.Text.Trim()
                        , dt_temp.Rows[0]["客户名称"].ToString()
                        , dt_temp.Rows[0]["产品名称"].ToString()
                        , customer, product).ShowDialog() == DialogResult.Yes)
                    {
                        //生成共用稿袋号(比如:A001-1,A001-2的格式)
                        string gaodai_temp = SQLiteList.GD.ExecuteScalar(
                            "select max(稿袋号) from 稿袋 where 稿袋号 like'" +
                        this.textBoxGaodai.Text.Trim() + "%';").ToString();
                        if (gaodai_temp==this.textBoxGaodai.Text.Trim())
                        {
                            newGaodai += "-1";
                        }
                        else
                        {
                          newGaodai=this.textBoxGaodai.Text.Trim()+"-"+
                              (Convert.ToInt16(Regex.Match(Regex.Match(gaodai_temp, "-\\d+").Value,"\\d+").Value)+1).ToString();
                        }

                        sqlList.Clear();
                        sqlList.Add("INSERT INTO [稿袋]([稿袋号],[客户名称],[产品名称],[状态],[创建时间],[创建人],[最后修改时间],[最后修改人],[存放位置])" +
                           "VALUES('" + newGaodai + "'" +
                           ",''" +
                           ",''" +
                           ",'空白'" +
                           ",datetime('now','localtime')" +
                           ",'" + User.FullName + "'" +
                           ",datetime('now','localtime')" +
                           ",'" + User.FullName + "'" +
                           ",'');") ;
                        if (!SQLiteList.GD.ExecuteSqlTran(sqlList))
                        {
                            throw new Exception("共用稿袋生产失败!");
                        }
                    }
                }                
            }
            if (SQLiteList.GD.ExecuteDataTable("select * from [稿袋] where [稿袋号]='"+newGaodai+"';").Rows.Count==0)
            {
                throw new Exception("稿袋号:" + newGaodai + "\n不存在!");
            }
            string sqlStr = "UPDATE [稿袋]" +
                    "SET [客户名称] = '" + this.textBoxCustomer.Text.Trim() + "'" +
                    ",[产品名称] = '" + this.textBoxChanpin.Text.Trim() + "'" +
                    ",[状态] = '正常'" +
                    ",[最后修改人] =  '" + User.FullName + "'" +
                    ",[存放位置] =  ''" +
                    "WHERE [稿袋号]='" + newGaodai + "';";
            sqlList = new List<string>();
            sqlList.Add(sqlStr);
            if (SQLiteList.GD.ExecuteSqlTran(sqlList))
            {
                InitGaodaiAll();
                ShowDgv();
                buttonCopy_Click(this, new EventArgs());
            }
            else
            {
                My.ShowErrorMessage("生产稿袋失败!");
            }

        }



        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                DataGridViewRow row = cell.OwningRow;
                switch (tsmi.Text)
                {
                    case "选客户":
                        this.textBoxCustomer.Text = row.Cells[ColumnCustomer.Index].Value.ToString();
                        break;
                    case "选产品名称":
                        this.textBoxChanpin.Text = row.Cells[ColumnChanpin.Index].Value.ToString();
                        break;
                    case "选稿袋":
                        this.textBoxCustomer.Text = row.Cells[ColumnGaodai.Index].Value.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.textBoxGaodai.Text))
            {
                Clipboard.SetText(this.textBoxGaodai.Text);
            }
        }

        private void 复制稿袋号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgv.SelectedRows)
            {
                string gaodai = row.Cells["ColumnGaodai"].Value.ToString();
                if (string.IsNullOrWhiteSpace(gaodai))
                {
                    Clipboard.SetText(gaodai);
                }
                break;
            }

        }

        private void radioButtonZhiding_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxGaodai.ReadOnly = false;
        }

        private void radioButtonShunxu_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxGaodai.ReadOnly = true;
        }

        private void radioButtonKongbai_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxGaodai.ReadOnly = true;
        }

        private void textBoxGaodai_Leave(object sender, EventArgs e)
        {
            this.textBoxGaodai.Text = this.textBoxGaodai.Text.ToUpper();
        }


    }
}
