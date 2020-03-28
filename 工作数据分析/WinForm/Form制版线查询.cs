using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using 工作数据分析.Data.DAL;
using 工作数据分析.Properties;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm
{
    public partial class Form制版线查询 : Form
    {


        public Form制版线查询()
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

        private void Get2200制版线完成信息()
        {
            if (DataBaseList.sql制版线2200 != null)
            {
                DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工_2200);
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
            this.dtPicker_s.Value = DateTime.Now.AddDays(-90);
            this.dtPicker_e.Value = DateTime.Now;
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "1.8米制版线":
                    if (My.Ping(DataBaseList.IP_制版线1800))
                    {
                        DataBaseList.sql制版线1800 = new SqlHelper(DataBaseList.ConnString_制版线1800);
                        dgv.DataSource = DataBaseList.sql制版线1800.Querytable("SELECT *FROM [dbo].[bc]ORDER BY [序号]");
                    }
                    else
                    {
                        My.ShowErrorMessage("制版线没有开机!\n" + DateTime.Now.ToString());
                    }
                    break;
                case "2.2米制版线":
                    if (My.Ping(DataBaseList.IP_制版线2200))
                    {
                        DataBaseList.sql制版线2200 = new SqlHelper(DataBaseList.ConnString_制版线2200);
                        dgv.DataSource = DataBaseList.sql制版线2200.Querytable("SELECT *FROM [dbo].[bc]ORDER BY [序号]");
                    }
                    else
                    {
                        My.ShowErrorMessage("2.2米制版线没有开机!\n" + DateTime.Now.ToString());
                    }
                    break;
                case "2.5米制版线":
                    if (My.Ping(DataBaseList.IP_制版线2500))
                    {
                        DataBaseList.sql制版线2500 = new SqlHelper(DataBaseList.ConnString_制版线2500);
                        dgv.DataSource = DataBaseList.sql制版线2500.Querytable("exec GetOrderitemsMTest @ProdLineLevelCnt=2,@size=2000,@Page=1");
                    }
                    else
                    {
                        My.ShowErrorMessage("2.5米制版线没有开机!\n" + DateTime.Now.ToString());
                    }
                    break;
                default:
                    break;
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }




    }
}
