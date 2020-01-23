using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using 综合保障中心.Comm;

namespace 甩纸数据
{
    public partial class Form用纸情况 : Form
    {

        private string Da_Sql = "";

        private MySqlDataAdapter Da;
        private DataSet Ds;
        private DataTable Dt;


        public Form用纸情况()
        {
            InitializeComponent();
        }

        private void Form用纸情况_Load(object sender, EventArgs e)
        {
            dateTimePicker_s.Value = DateTime.Now.AddDays(-5);
            dateTimePicker_e.Value = DateTime.Now;            
        }
        /// <summary>
        /// 保存
        /// </summary>
        private void Save()
        {
            try
            {
                ////剔除空行并将正在编辑的行标记为已完成
                //if (this.dgv.CurrentCell != null && this.dgv.CurrentCell.IsInEditMode)
                //{
                //    this.dgv.CurrentCell.Value = this.dgv.CurrentCell.EditedFormattedValue;
                //}

                MySqlCommandBuilder ocb = new MySqlCommandBuilder(Da);
                Da.Update(Ds);
                toolStripStatusLabel1.Text = DateTime.Now.ToString() + "保存成功!";
            }
            catch (Exception ex)
            {
                My.ShowErrorMessage(ex.Message);
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            GetDate();
        }

        private void GetDate()
        {

            Da_Sql = string.Format(
               "SELECT `工单号`,`报工日期`,`报工人`,`材质`,`品牌`,`客户`,`产品`,`规格(WxL)`,`报工数`,`实际克重`,`实际门幅`,`对应批号`FROM `slbz`.`甩纸数据` where `工序`='甩纸' AND  `报工日期` between '{0}' and '{1}' and `工单号` like '%{2}%' 	ORDER BY `报工日期` DESC LIMIT 1000"
                , dateTimePicker_s.Value.ToString("yyyy-MM-dd HH:mm:ss")
               , dateTimePicker_e.Value.ToString("yyyy-MM-dd HH:mm:ss")
               , textBoxGdh.Text.Trim());
            MySqlConnection myConn = new MySqlConnection(MySqlDbHelper.GetConnectionString());
            Da = new MySqlDataAdapter(Da_Sql, myConn);
            Ds = new DataSet();
            Da.Fill(Ds);
            myConn.Close();
            this.dgv.DataSource = Ds.Tables[0];
            Dt = Ds.Tables[0]; 


            dgv.AutoResizeColumns();
            string[] cols = { "实际克重", "实际门幅", "对应批号" };
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (!cols.Contains(col.Name))
                {
                    col.ReadOnly = true;
                }
            }
            toolStripStatusLabel2.Text = "共" + dgv.Rows.Count + "项!";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count>0)
            {
                dgv.CommitEdit((DataGridViewDataErrorContexts)123);
                dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
                Save();
            }
           
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            //this.Text = keyData.GetHashCode().ToString();

            ////打开拼版软件
            //if (keyData.GetHashCode()==262225)
            //{
            //    this.tsmiMakeupJob_Click(this, new EventArgs());
            //}
            if (keyData == Keys.F5)//刷新
            {
                GetDate();
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                dgv.CommitEdit((DataGridViewDataErrorContexts)123);
                dgv.BindingContext[dgv.DataSource].EndCurrentEdit();
                Save();
            }
            else if (keyData == (Keys.Control | Keys.F))
            {
                textBoxGdh.Focus();
                textBoxGdh.SelectAll();
            }
            return false;

        }
    }
}
