using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using 工作数据分析.Class;
using 工作数据分析.Data.DAL;
using 工作数据分析.Properties;
using 甩纸数据;
using 综合保障中心.Comm;

namespace 综合保障中心.其它
{
    public partial class FormYijie_自动获取 : Form
    {
        public FormYijie_自动获取()
        {
            InitializeComponent();
        }


        private void AddtbShow(string text)
        {
            string addtext = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + text + Environment.NewLine;
            this.tbShow.AppendText(addtext);
            My.InsertMysqlBackupLog(text);
        }
       
        private void toolStripMenuItem一键获取_Click(object sender, EventArgs e)
        {
            OneKeyGet();
        }


        /// <summary>
        /// 一键获取
        /// </summary>
        private void OneKeyGet()
        {
            this.timerBackup.Stop();
            AddtbShow("关闭计数器");

            AddtbShow("开始{一键获取}");

            DataBaseList.InitSqlhelper();
            Get二期辅料仓库领料明细();
            Get二期原纸仓库即时库存();
            Get二期胶印纸箱仓库即时库存();
            Get二期辅料仓库即时库存();
            Get二期仓库入库明细();
            Get1800制版线完成信息();
            Get2200制版线完成信息();
            Get2500制版线完成信息();

            this.timerBackup.Start();
            AddtbShow("开启计数器");
        }

        private void Get二期辅料仓库即时库存()
        {
            if (DataBaseList.sql财务 != null)
            {
                DataTable dt = DataBaseList.sql财务.Querytable(Resources.二期辅料仓库即时库存);
                List<string> sqlList = new List<string>();

                StringBuilder sb_Insert = new StringBuilder("INSERT INTO `slbz`.`金蝶_二期辅料仓库即时库存`(");
                foreach (DataColumn dc in dt.Columns)//添加列
                {
                    sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
                }
                sb_Insert.Remove(sb_Insert.Length - 1, 1);
                sb_Insert.AppendLine(")VALUES");
                StringBuilder sb_values = new StringBuilder("(");
                foreach (DataRow dr in dt.Rows)
                {
                    sb_values = new StringBuilder("(");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb_values.AppendFormat("'{0}',", dr[dc].ToString());
                    }
                    sb_values.Remove(sb_values.Length - 1, 1);
                    sb_values.AppendLine(");");
                    sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
                }
                if (sqlList.Count > 0)
                {
                    sqlList.Insert(0, "truncate table `slbz`.`金蝶_二期辅料仓库即时库存`;");
                }
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    AddtbShow("获取[二期辅料仓库即时库存]失败×××××! " );
                }
                else
                {
                    AddtbShow("获取[二期辅料仓库即时库存]成功! " );
                }
            }
            else
            {
                AddtbShow("财务系统没有连接!" );

            }
        }
        private void Get待入库的订单()
        {


        }
        private void Get二期辅料仓库安全库存分析()
        {
            ////1.读取需要备安全库存的物料明细(物料名称,安全库存,备料天数)
            //DataTable dt_aqkc = MySqlDbHelper.ExecuteDataTable("SELECT*FROM `slbz`.`辅料_安全库存`");
            ////2.读取并分析每个物料近6个月的领料明细
            //DataTable dt_llmx = MySqlDbHelper.ExecuteDataTable("SELECT 物料名称 ,sum(实发数量)'实发数量'FROM `slbz`.`金蝶_生产领料`group by 物料名称");
            ////3.根据领料明细生成每日消耗情况
            //DataTable dt_rjllsl = MySqlDbHelper.ExecuteDataTable("SELECT 物料名称,sum(实发数量)/180 '日均领料数量'FROM `slbz`.`金蝶_生产领料`"
            //    + "where 日期 between date_format(date_add(now(), interval -6 month),'%Y-%m-%d') and date_format(now(), '%Y-%m-%d')"
            //    + "group by 物料名称;");
            ////4.按每个物料的采购周期为期限备安全库存(安全库存=日均消耗*备料天数)
            ////5.读取当前辅料仓库即时库存
            ////6.如果安全库存少于即时库存,则备料

            //-----------------------------
            //1.读取需要备安全库存的物料明细(物料名称,安全库存,备料天数)
            DataTable dt_aqkc = MySqlDbHelper.ExecuteDataTable("SELECT*FROM `slbz`.`辅料_安全库存`");
            //2.读取即时库存
        }
        private void Get二期辅料仓库领料明细()
        {

            if (DataBaseList.sql财务 != null)
            {
                //1.先读取60天内的所有明细(考虑到一个账期的时间为一个自然月)
                //2.删除mysql中这个时间段内的所有数据(防止有删除或较大的变动)
                //3.删除读取过来的明细里面的所领料单号(防止有改动)
                //4.插入到mysql中
                //开始添加到sql中
                DataTable dt = DataBaseList.sql财务.Querytable(Resources.二期原纸辅料领料明细);
                List<string> sqlList = new List<string>();



                StringBuilder sb_Insert = new StringBuilder("INSERT INTO `slbz`.`金蝶_生产领料`(");
                foreach (DataColumn dc in dt.Columns)//添加列
                {
                    sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
                }
                sb_Insert.Remove(sb_Insert.Length - 1, 1);
                sb_Insert.AppendLine(")VALUES");
                StringBuilder sb_values = new StringBuilder("(");
                foreach (DataRow dr in dt.Rows)
                {
                    sb_values = new StringBuilder("(");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb_values.AppendFormat("'{0}',", dr[dc].ToString());
                    }
                    sb_values.Remove(sb_values.Length - 1, 1);
                    sb_values.AppendLine(");");
                    sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
                }
                if (sqlList.Count > 0)
                {
                    sqlList.Insert(0, "DELETE FROM `slbz`.`金蝶_生产领料`	WHERE `日期`  "
                    + "BETWEEN date_format(date_add(now(), interval -60 day), '%Y-%m-%d') AND  date_format(now(), '%Y-%m-%d');");
                }
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    
                    AddtbShow("获取[二期辅料仓库领料明细]失败×××××! " );
                }
                else
                {
                    AddtbShow("获取[二期辅料仓库领料明细]成功! " );
                }
            }
            else
            {
                AddtbShow("财务系统没有连接!" );

            }
        }

        private void Get二期仓库入库明细()
        {
            if (DataBaseList.sql财务 != null)
            {
                //1.先读取60天内的所有明细(考虑到一个账期的时间为一个自然月)
                //2.删除mysql中这个时间段内的所有数据(防止有删除或较大的变动)
                //3.删除读取过来的明细里面的所有入库单号(防止有改动)
                //4.插入到mysql中
                DataTable dt = DataBaseList.sql财务.Querytable(Resources.二期仓库入库);
                List<string> sqlList = new List<string>();

                StringBuilder sb_Insert = new StringBuilder("INSERT INTO `slbz`.`金蝶_外购入库`(");
                foreach (DataColumn dc in dt.Columns)//添加列
                {
                    sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
                }
                sb_Insert.Remove(sb_Insert.Length - 1, 1);
                sb_Insert.AppendLine(")VALUES");
                StringBuilder sb_values = new StringBuilder("(");
                foreach (DataRow dr in dt.Rows)
                {
                    sb_values = new StringBuilder("(");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb_values.AppendFormat("'{0}',", dr[dc].ToString());
                    }
                    sb_values.Remove(sb_values.Length - 1, 1);
                    sb_values.AppendLine(");");
                    sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
                }
                if (sqlList.Count > 0)
                {
                    sqlList.Insert(0, "DELETE FROM `slbz`.`金蝶_外购入库`	WHERE `日期`  "
                    + "BETWEEN   date_format(date_add(now(), interval -60 day), '%Y-%m-%d')AND   date_format(now(), '%Y-%m-%d') ");
                }
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    
                    AddtbShow("获取[二期仓库入库明细]失败×××××! " );
                }
                else
                {
                    AddtbShow("获取[二期仓库入库明细]成功! " );
                }
            }
            else
            {
                AddtbShow("财务系统没有连接!" );

            }


        }

        private void Get二期胶印纸箱仓库即时库存()
        {
            if (DataBaseList.sql财务 != null)
            {
                DataTable dt = DataBaseList.sql财务.Querytable(Resources.二期胶印纸箱仓库即时库存);
                List<string> sqlList = new List<string>();
                sqlList.Add("TRUNCATE `slbz`.`二期胶印纸箱仓库即时库存`;");
                foreach (DataRow row in dt.Rows)
                {
                    sqlList.Add("INSERT INTO `slbz`.`二期胶印纸箱仓库即时库存` (`物料长代码`,`物料名称`,`批号`,`基本单位`,`库存`,`换算率`,`辅助单位`,`辅助数量`,`仓库名称`,`仓库代码`) VALUES"
            + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}');"
            , row["物料长代码"], row["物料名称"], row["批号"], row["基本单位"], row["库存"], row["换算率"], row["辅助单位"], row["辅助数量"], row["仓库名称"], row["仓库代码"]));

                }
                MySqlDbHelper.ExecuteSqlTran(sqlList);
                AddtbShow("获取[二期胶印纸箱仓库即时库存]成功! " );

            }
            else
            {
                AddtbShow("财务系统没有连接!" );
            }

        }

        private void Get2500制版线完成信息()
        {
            if (DataBaseList.sql制版线2500 != null)
            {
                DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工_2500);
                SubmitZhiBanXian(dt);
                AddtbShow("获取[2500制版线完成信息]成功! " );
            }
            else
            {
                AddtbShow("2500制版线系统没有连接!" );
            }

        }

        private void Get2200制版线完成信息()
        {
            if (DataBaseList.sql制版线2200 != null)
            {
                DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工_2200);
                SubmitZhiBanXian(dt);
                AddtbShow("获取[2200制版线完成信息]成功! " );
            }
            else
            {
                AddtbShow("2200制版线系统没有连接!" );
            }
        }

        private void Get1800制版线完成信息()
        {
            if (DataBaseList.sql制版线1800 != null)
            {
                DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工_1800);
                SubmitZhiBanXian(dt);
                AddtbShow("获取[1800制版线完成信息]成功! " );
            }
            else
            {
                AddtbShow("1800制版线系统没有连接!" );
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
        , row["压线"], row["开始时间"].ToString(), row["结束时间"].ToString(), row["生产时间"], row["备注"], row["瓦片线"]));

            }
            MySqlDbHelper.ExecuteSqlTran(sqlList);
        }

        private void Get二期原纸仓库即时库存()
        {
            if (DataBaseList.sql财务 != null)
            {
                DataTable dt = DataBaseList.sql财务.Querytable(Resources.二期原纸仓库即时库存);
                List<string> sqlList = new List<string>();
                sqlList.Add("TRUNCATE `slbz`.`二期原纸仓库即时库存`;");
                foreach (DataRow row in dt.Rows)
                {
                    sqlList.Add("INSERT INTO `slbz`.`二期原纸仓库即时库存` (`物料长代码`,`物料名称`,`批号`,`门幅`,`单位`,`库存`,`仓库名称`) VALUES"
            + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}');"
            , row["物料长代码"], row["物料名称"], row["批号"], row["门幅"], row["单位"], row["库存"], row["仓库名称"]));

                }
                MySqlDbHelper.ExecuteSqlTran(sqlList);
                AddtbShow("获取[二期原纸仓库即时库存]成功! " );
            }
            else
            {
                AddtbShow("财务系统没有连接!" );

            }
        }

        

        private void timerClr_Tick(object sender, EventArgs e)
        {
            this.tbShow.Clear();
        }

        private void FormYijie_自动获取_Load(object sender, EventArgs e)
        {

        }
    }
}

