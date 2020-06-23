using DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using 工作数据分析.Data.DAL;
using 工作数据分析.Properties;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form制版线实时 : Form
    {
        Thread thread;

        public Form制版线实时()
        {
            InitializeComponent();
        }


        private void 从瓦片线载入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此过程需要5-10分钟,确定要加载吗?", "加载?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Get1800制版线完成信息();
                Get2200制版线完成信息();
                Get2500制版线完成信息();
                My.ShowMessage("完成!\n" + DateTime.Now.ToString());
            }
        }

        private void Get2500制版线完成信息()
        {
            if (DataBaseList.sql制版线2500 != null)
            {
                DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工_2500);
                SubmitZhiBanXian(dt);
            }
        }
        private void Get2500制版线完成信息3天()
        {
            if (DataBaseList.sql制版线2500 != null)
            {
                DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工2500_3天);
                SubmitZhiBanXian(dt);
            }
        }

        private void Get2200制版线完成信息()
        {
            if (DataBaseList.sql制版线2200 != null)
            {
                DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工_2200);
                SubmitZhiBanXian(dt);
            }
        }
        private void Get2200制版线完成信息3天()
        {
            if (DataBaseList.sql制版线2200 != null)
            {
                DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工2200_3天);
                SubmitZhiBanXian(dt);
            }
        }


        private void Get1800制版线完成信息()
        {
            if (DataBaseList.sql制版线1800 != null)
            {
                DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工_1800);
                SubmitZhiBanXian(dt);
            }
        }
        private void Get1800制版线完成信息3天()
        {
            if (DataBaseList.sql制版线1800 != null)
            {
                DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工1800_3天);
                SubmitZhiBanXian(dt);
            }
        }

        private void SubmitZhiBanXian(DataTable dt)
        {
            List<string> sqlList = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                sqlList.Add("INSERT ignore  INTO `slbz`.`瓦片完成情况` (`工单号`,`客户名`,`门幅`,`楞型`,`材质`,`长度`,`宽度`,`压线`,`开始时间`,`结束时间`,`生产时间`,`备注`,`瓦片线`) VALUES"
        + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');"
        , row["工单号"], row["客户名"], row["门幅"], row["楞型"], row["材质"], row["长度"], row["宽度"]
        , row["压线"], row["开始时间"], row["结束时间"], row["生产时间"], row["备注"], row["瓦片线"]));

            }
            MySqlDbHelper.ExecuteSqlTran(sqlList);
        }

        private void button查询_Click(object sender, EventArgs e)
        {
            this.dtPicker_s.Value = this.dtPicker_s.Value.Date;
            this.dtPicker_e.Value = this.dtPicker_e.Value.Date.AddDays(1).AddSeconds(-1);

            dgv_wg.DataSource = MySqlDbHelper.ExecuteDataTable(string.Format("select * from `slbz`.`瓦片完成情况` where "
             + "`工单号`like'%{0}%' and `客户名`like'%{1}%' and `开始时间` between str_to_date('{2}','%Y-%m-%d %H:%i:%s') "
            + " and str_to_date('{3}','%Y-%m-%d %H:%i:%s') limit 1000;", textBox工单.Text.Trim(), textBox客户.Text.Trim()
            , dtPicker_s.Value.ToString("yyyy-MM-dd HH:mm:ss"), dtPicker_e.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            dgv_wg.AutoResizeColumns();
        }

        private void Form制版线查询_Load(object sender, EventArgs e)
        {
            this.dtPicker_s.Value = DateTime.Now.AddDays(-30);
            this.dtPicker_e.Value = DateTime.Now;

            thread = new Thread(new ThreadStart(InitShowData));
            backgroundWorker1.RunWorkerAsync();
        }


        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        /// <summary>
        /// 初始化刷新数据
        /// </summary>
        private  void InitShowData()
        {
            //dgv1800.Rows.Clear();
            //dgv2200.Rows.Clear();
            //dgv2500.Rows.Clear();
            //dgv24Hwangong.Rows.Clear();
            DataTable dt1800 = new DataTable();
            DataTable dt2200 = new DataTable();
            DataTable dt2500 = new DataTable();
            if (My.Ping(DataBaseList.IP_制版线1800)&& SqlHelper.IsConnection(DataBaseList.ConnString_制版线1800))
            {
                DataBaseList.sql制版线1800 = new SqlHelper(DataBaseList.ConnString_制版线1800);
                dgv1800.DataSource = DataBaseList.sql制版线1800.Querytable("SELECT [订单号],[客户名称],rtrim([楞别])'楞别',[订单数],[纸宽],[纸长],rtrim([生产纸质])'材质',[门幅],[序号] FROM [dbo].[bc]ORDER BY [序号]");
                dt1800 = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工1800当天1);
            }

            if (My.Ping(DataBaseList.IP_制版线2200) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2200))
            {
                DataBaseList.sql制版线2200 = new SqlHelper(DataBaseList.ConnString_制版线2200);
                dgv2200.DataSource = DataBaseList.sql制版线2200.Querytable("SELECT [订单号],[客户名称],rtrim([楞别])'楞别',[订单数],[纸宽],[纸长],rtrim([生产纸质])'材质',[门幅],[序号] FROM [dbo].[bc]ORDER BY [序号]");
                dt2200 = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工1800当天1);
            }

            if (My.Ping(DataBaseList.IP_制版线2500) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2500))
            {
                DataBaseList.sql制版线2500 = new SqlHelper(DataBaseList.ConnString_制版线2500);
                dgv2500.DataSource = DataBaseList.sql制版线2500.Querytable(Resources.制版线当前排程2500);
                dt2500 = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工2500当天1);
            }
            
            dt1800.Merge(dt2200,false);
            dt1800.Merge(dt2500,false);
            dgv24Hwangong.DataSource = dt1800;
            foreach (DataGridViewColumn column in dgv24Hwangong.Columns)
            {
                if (column.HeaderText=="结束时间")
                {
                    dgv24Hwangong.Sort(column, ListSortDirection.Descending);
                    break;
                }
            }
            SetDgvBackColor(dgv1800);
            SetDgvBackColor(dgv2200);
            SetDgvBackColor(dgv2500);

            Get1800制版线完成信息3天();
            Get2200制版线完成信息3天();
            Get2500制版线完成信息3天();

            this.groupBox1.Text = "当前队列(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")";
        }

       


       
        private void SetDgvBackColor(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name == "订单号" || column.Name == "工单"|| column.Name == "Cust_OrderID")
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (Regex.IsMatch(row.Cells[column.Name].Value.ToString(), "C\\d+"))
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                            row.DefaultCellStyle.SelectionBackColor = Color.Red;
                        }
                    }
                    break;
                }

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                InitShowData();
            }
        }

    }
}
