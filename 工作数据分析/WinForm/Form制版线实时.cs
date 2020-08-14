using DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            try
            {
                if (DataBaseList.sql制版线2500 != null)
                {
                    DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工_2500);
                    SubmitZhiBanXian(dt);
                }
            }
            catch
            {
            }
        }
        private void Get2500制版线完成信息1天()
        {
            try
            {
                if (DataBaseList.sql制版线2500 != null)
                {
                    DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工2500_1天);
                    SubmitZhiBanXian(dt);
                }
            }
            catch
            {
            }
        }

        private void Get2200制版线完成信息()
        {
            try
            {


                if (DataBaseList.sql制版线2200 != null)
                {
                    DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工_2200);
                    SubmitZhiBanXian(dt);
                }
            }
            catch
            {
            }
        }
        private void Get2200制版线完成信息1天()
        {
            try
            {
                if (DataBaseList.sql制版线2200 != null)
                {
                    DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工2200_1天);
                    SubmitZhiBanXian(dt);
                }
            }
            catch
            {
            }
        }


        private void Get1800制版线完成信息()
        {
            try
            {
                if (DataBaseList.sql制版线1800 != null)
                {
                    DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工_1800);
                    SubmitZhiBanXian(dt);
                }
            }
            catch
            {
            }
        }
        private void Get1800制版线完成信息1天()
        {
            try
            {
                if (DataBaseList.sql制版线1800 != null)
                {
                    DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工1800_1天);
                    SubmitZhiBanXian(dt);
                }
            }
            catch
            {
            }
        }

        private bool Insert制版线当前排程(DataTable dt,string zhibanxian)
        {
            List<string> sqlList = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string sql = "INSERT INTO `slbz`.`生产线当前排程`"
                + "(`订单号`,`客户`,`楞型`,`订单数`,`宽度`,`长度`,`材质`,`门幅`,`序号`,`生产线`)VALUES("
                + "'" + row["订单号"].ToString() + "',"
                + "'" + row["客户"].ToString() + "',"
                + "'" + row["楞型"].ToString() + "',"
                + "'" + row["订单数"].ToString() + "',"
                + "'" + row["宽度"].ToString() + "',"
                + "'" + row["长度"].ToString() + "',"
                + "'" + row["材质"].ToString() + "',"
                + "'" + row["门幅"].ToString() + "',"
                + "'" + row["序号"].ToString() + "',"
                + "'" + zhibanxian + "');";
                sqlList.Add(sql);
            }
           return  MySqlDbHelper.ExecuteSqlTran(sqlList);
        }

        private void SubmitZhiBanXian(DataTable dt)
        {
            List<string> sqlList = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                sqlList.Add("INSERT ignore  INTO `slbz`.`瓦片完成情况` (`工单号`,`客户名`,`门幅`,`楞型`,`材质`,`长度`,`宽度`,`压线`,`开始时间`,`结束时间`,`生产时间`,`备注`,`瓦片线`) VALUES"
        + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}');"
        , row["工单号"], row["客户名"], row["门幅"], row["楞型"], row["材质"], row["长度"], row["宽度"]
        , row["压线"], row["开始时间"], row["结束时间"].ToString(), row["生产时间"].ToString(), row["备注"], row["瓦片线"]));

            }
            MySqlDbHelper.ExecuteSqlTran(sqlList);
            //File.AppendAllLines("D:\\sqllist.txt", sqlList);
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
            刷新ToolStripMenuItem.Enabled = false;
            从瓦片线载入数据ToolStripMenuItem.Enabled = false;
            this.dtPicker_s.Value = DateTime.Now.AddDays(-30);
            this.dtPicker_e.Value = DateTime.Now;

            //初始化dgv的列
            foreach (DataColumn col in MySqlDbHelper.ExecuteDataTable("SELECT * FROM `slbz`.`生产线当前排程` LIMIT 1").Columns)
            {
                dgv1800.Columns.Add("dgv1800"+col.ColumnName,col.ColumnName);
                dgv2200.Columns.Add("dgv2200"+col.ColumnName,col.ColumnName);
                dgv2500.Columns.Add("dgv2500"+col.ColumnName,col.ColumnName);
            }



            InitShowData();
        }


        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage当前排程)
            {
                InitShowData();
            }
        }





        /// <summary>
        /// 初始化刷新数据
        /// </summary>
        private void InitShowData()
        {
            this.timer1.Stop();
            //将制版线当前排程备份到中间数据库
            MySqlDbHelper.ExecuteSqlTran("TRUNCATE TABLE`slbz`.`生产线当前排程`;");

            try
            {
                if (My.Ping(DataBaseList.IP_制版线1800) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线1800))
                {
                    DataBaseList.sql制版线1800 = new SqlHelper(DataBaseList.ConnString_制版线1800);
                    Insert制版线当前排程( DataBaseList.sql制版线1800.Querytable("SELECT [订单号],[客户名称]'客户',rtrim([楞别])'楞型',[订单数],[纸宽]'宽度',[纸长]'长度',rtrim([生产纸质])'材质',[门幅],[序号] FROM [dbo].[bc]ORDER BY [序号]"),"制版线1800");
                   groupBox1800.Text= "1800制版线(运行中)";
                   // groupBox1800.ForeColor = Color.Blue;
                }
                else
                {
                    groupBox1800.Text = "1800制版线(停机)";
                    //groupBox1800.ForeColor = Color.Red;
                }
            }
            catch
            {
                groupBox1800.Text = "1800制版线(停机)";
                    //groupBox1800.ForeColor = Color.Red;
            }
            try
            {
                if (My.Ping(DataBaseList.IP_制版线2200) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2200))

                {
                    DataBaseList.sql制版线2200 = new SqlHelper(DataBaseList.ConnString_制版线2200);
                    Insert制版线当前排程(DataBaseList.sql制版线2200.Querytable("SELECT [订单号],[客户名称]'客户',rtrim([楞别])'楞型',[订单数],[纸宽]'宽度',[纸长]'长度',rtrim([生产纸质])'材质',[门幅],[序号] FROM [dbo].[bc]ORDER BY [序号]"), "制版线2200");
                    groupBox2200.Text = "2200制版线(运行中)";
                    //groupBox2200.ForeColor = Color.Blue;
                }
                else
                {
                    groupBox2200.Text = "2200制版线(停机)";
                    //groupBox2200.ForeColor = Color.Red;
                }
            }
            catch
            {
                groupBox2200.Text = "2200制版线(停机)";
                //groupBox2200.ForeColor = Color.Red;
            }

            try
            {
                if (My.Ping(DataBaseList.IP_制版线2500) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2500))
                {
                    DataBaseList.sql制版线2500 = new SqlHelper(DataBaseList.ConnString_制版线2500);
                    Insert制版线当前排程(DataBaseList.sql制版线2500.Querytable(Resources.制版线当前排程2500), "制版线2500");
                    groupBox2500.Text = "2500制版线(运行中)";
                   // groupBox2500.ForeColor = Color.Blue;
                }
                else
                {
                    groupBox2500.Text = "2500制版线(停机)";
                    //groupBox2500.ForeColor = Color.Red;
                }
            }
            catch
            {
                groupBox2500.Text = "2500制版线(停机)";
                //groupBox2500.ForeColor = Color.Red;
            }
            //将制版线已经完成排程备份到中间数据库
            Get1800制版线完成信息1天();
            Get2200制版线完成信息1天();
            Get2500制版线完成信息1天();

            //开始从中间数据库读取当前排程和已经完成的排程
            //dgv1800.DataSource=MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`生产线当前排程` WHERE 生产线='制版线1800';");
            //dgv2200.DataSource=MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`生产线当前排程` WHERE 生产线='制版线2200';");
            //dgv2500.DataSource=MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`生产线当前排程` WHERE 生产线='制版线2500';");

            SqlToDgv(MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`生产线当前排程` WHERE 生产线='制版线1800';"), dgv1800, "订单号");
            SqlToDgv(MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`生产线当前排程` WHERE 生产线='制版线2200';"), dgv2200, "订单号");
            SqlToDgv(MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`生产线当前排程` WHERE 生产线='制版线2500';"), dgv2500, "订单号");

            dgv1800.Sort(dgv1800.Columns["序号"],ListSortDirection.Ascending);
            dgv2200.Sort(dgv2200.Columns["序号"],ListSortDirection.Ascending);
            dgv2500.Sort(dgv2500.Columns["序号"], ListSortDirection.Ascending);

            dgv24Hwangong.DataSource = MySqlDbHelper.ExecuteDataTable(
             "SELECT `工单号`,`客户名`,`门幅`,`楞型`,`材质`,`长度`,`宽度`,`结束时间`,`瓦片线`"
            +"FROM `slbz`.`瓦片完成情况`where 结束时间 >= (NOW() - interval 24 hour) and 工单号 like'C%'"
            +"order by 结束时间 desc");            

           
            SetDgvBackColor(dgv1800);
            SetDgvBackColor(dgv2200);
            SetDgvBackColor(dgv2500);
           

            this.groupBox1.Text = "当前队列(" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ")";
            dgv1800.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgv2200.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgv2500.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.timer1.Start();
        }

        private void SqlToDgv(DataTable dt, DataGridView dgv, string keyColumnName)
        {
            foreach (DataRow dtRow in dt.Rows)
            {
                bool isExist = false;
                foreach (DataGridViewRow dgvRow in dgv.Rows)
                {
                    if (dgvRow.Cells[keyColumnName].Value.ToString()==dtRow[keyColumnName].ToString())
                    {
                        isExist = true;
                        break;
                    }                   
                }
                if (isExist==false)
                {
                    DataGridViewRow newRow = dgv.Rows[dgv.Rows.Add()];

                    newRow.Cells["订单号"].Value = dtRow["订单号"].ToString();
                    newRow.Cells["客户"].Value = dtRow["客户"].ToString();
                    newRow.Cells["楞型"].Value = dtRow["楞型"].ToString();
                    newRow.Cells["订单数"].Value = dtRow["订单数"].ToString();
                    newRow.Cells["宽度"].Value = dtRow["宽度"].ToString();
                    newRow.Cells["长度"].Value = dtRow["长度"].ToString();
                    newRow.Cells["材质"].Value = dtRow["材质"].ToString();
                    newRow.Cells["门幅"].Value = dtRow["门幅"].ToString();
                    newRow.Cells["序号"].Value = dtRow["序号"].ToString();
                }
            }

            List<DataGridViewRow> dgvRowList = new List<DataGridViewRow>();
            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                bool isExist = false;
                foreach (DataRow dtRow in dt.Rows)
                {
                    if (dgvRow.Cells[keyColumnName].Value.ToString() == dtRow[keyColumnName].ToString())
                    {
                        isExist = true;
                        break;
                    }
                }
                if (isExist == false)
                {
                    dgvRowList.Add(dgvRow);
                }
            }
            foreach (DataGridViewRow item in dgvRowList)
            {
                dgv.Rows.Remove(item);
            }
        }



        private void SetDgvBackColor(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Name == "订单号" || column.Name == "工单" || column.Name == "Cust_OrderID")
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage当前排程)
            {
                InitShowData();
            }
        }

        private void Form制版线实时_SizeChanged(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer2.Width / 3;
            splitContainer3.SplitterDistance = splitContainer3.Width / 2;
        }

       
    }
}
