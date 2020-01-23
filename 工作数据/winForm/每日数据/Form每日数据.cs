using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 工作数据
{
    public partial class Form每日数据 : Form
    {
        public Form每日数据()
        {
            InitializeComponent();
        }

        private void Form每日数据_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            this.dateTimePicker1.Value = DateTime.Now.AddDays(-1);

            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);

            
            GetDataByDate();
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)//刷新
            {
                GetDataByDate();
            }
            if (keyData == Keys.F4)//关闭
            {
                this.Dispose();
            }
            else if (keyData == (Keys.Control | Keys.S))//保存
            {
                Save();
            }
            return false;

        }

        private void Save()
        {
            string sqlStr = "";
            bool isEmpty = true;
            Dictionary<string, string> dic_shujju = new Dictionary<string, string>();
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                string cellvalue = MY.GetCellDefault(dgvRow.Cells["columnShuju"]);
                dic_shujju.Add(dgvRow.Cells["columnXiangmu"].Value.ToString()
                    , cellvalue);
                if (isEmpty && !string.IsNullOrWhiteSpace(cellvalue))
                { isEmpty = false; }
            }
            if (isEmpty)
            {
                MY.ShowErrorMessage("数据全部为空,不能保存");
                return;
            }

            //判断是否存在
            if (MySqlDbHelper.ExecuteDataTable(
                string.Format("select * from `每日数据` where `日期`='{0}'"
                , dateTimePicker1.Value.ToString("yyyy-MM-dd"))).Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder("UPDATE `每日数据`SET ");
                foreach (string xiangmu in dic_shujju.Keys)
                {
                    sb.AppendFormat("`{0}`='{1}',", xiangmu, dic_shujju[xiangmu]);
                }
                sb.Remove(sb.Length - 1, 1);
                sqlStr = sb.ToString() + "WHERE `日期`='"
                    + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";
            }
            else
            {
                StringBuilder sb1 = new StringBuilder("INSERT INTO `每日数据`(");
                StringBuilder sb2 = new StringBuilder("VALUES(");
                foreach (string xiangmu in dic_shujju.Keys)
                {
                    sb1.AppendFormat("`{0}`,", xiangmu);
                    sb2.AppendFormat("'{0}',", dic_shujju[xiangmu]);
                }
                sb1.Append("日期)");
                sb2.Append("'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "');");
                sqlStr = sb1.ToString() + sb2.ToString();
            }
            if (!MySqlDbHelper.ExecuteSqlTran(sqlStr))
            {
                MY.ShowErrorMessage("保存失败!");
            }
            else
            { GetDataByDate(); }
        }

        private void GetDataByDate()
        {
            this.dateTimePicker1.MaxDate = DateTime.Now;
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            DataTable dt =
            MySqlDbHelper.ExecuteDataTable(
                string.Format("select * from `每日数据` where `日期`='{0}'",
                dateTimePicker1.Value.ToString("yyyy-MM-dd")));
            dgv.Columns.Add("columnXiangmu", "项目");
            dgv.Columns.Add("columnShuju", "数据");
            foreach (DataColumn dc in dt.Columns)
            {
                if (dc.ColumnName.Contains('_'))
                {
                    DataGridViewRow dgvRow = dgv.Rows[dgv.Rows.Add()];
                    dgvRow.Cells["columnXiangmu"].Value = dc.ColumnName;
                    if (dt.Rows.Count > 0)
                    {
                        dgvRow.Cells["columnShuju"].Value = dt.Rows[0][dc].ToString();
                    }
                }
            }
            dgv.AutoResizeColumns();//自适应列宽
            dgv.ReadOnly = false;
            if (dt.Rows.Count>0)
            {
                if (Convert.ToBoolean(dt.Rows[0]["审核"]))
                {
                    dgv.ReadOnly =true;
                }
                labelOrtherInfo.Text = "最后修改时间：" + dt.Rows[0]["最后修改时间"].ToString() + "，修改人：";
            }
            labelOrtherInfo.Text = "最后修改时间：，修改人：。";
            SetButtonsState();//按钮的状态
            dgv.Columns["columnXiangmu"].ReadOnly = true;
        }

        private void buttonShuaxin_Click(object sender, EventArgs e)
        {
            GetDataByDate();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            GetDataByDate();
        }

        private void buttonShenhe_Click(object sender, EventArgs e)
        {
            Save();
            if (MySqlDbHelper.ExecuteSqlTran(string.Format(
                "UPDATE `slbz`.`每日数据`SET `审核` = 1	WHERE `日期`='{0}'"
                , dateTimePicker1.Value.ToString("yyyy-MM-dd"))))
            {
                dgv.ReadOnly = true;
                SetButtonsState();
            }
        }

        private void SetButtonsState()
        {
            this.buttonShenhe.Enabled = !dgv.ReadOnly;
            this.buttonFanshenhe.Enabled = dgv.ReadOnly;
            if (dgv.ReadOnly)
            {
                dgv.DefaultCellStyle.BackColor = Color.LightGray;
            }
            else
            {
                dgv.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void buttonFanshenhe_Click(object sender, EventArgs e)
        {
            if (MySqlDbHelper.ExecuteSqlTran(string.Format(
               "UPDATE `slbz`.`每日数据`SET `审核` = 0	WHERE `日期`='{0}'"
               , dateTimePicker1.Value.ToString("yyyy-MM-dd"))))
            {
                dgv.ReadOnly = false;
                SetButtonsState();
            }
        }

        private void buttonUpDay_Click(object sender, EventArgs e)
        {
            DateTime dt_new =new DateTime();
            switch (((Button)sender).Text)
            {
                case "前一日":
                    dt_new = this.dateTimePicker1.Value.AddDays(-1);
                    break;
                case "后一日":
                    dt_new = this.dateTimePicker1.Value.AddDays(1);
                    break;
                default:
                    break;
            }          
             
            if (dt_new>=dateTimePicker1.MinDate&&dt_new<=dateTimePicker1.MaxDate)
            {
                dateTimePicker1.Value = dt_new;
            }
        }

       
    }
}
