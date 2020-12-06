using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using WindowsServiceBackupWorkingData.Properties;
using 工作数据分析.Data.DAL;
using 综合保障中心.Comm;


namespace WindowsServiceBackupWorkingData
{
    public partial class BackupWorkingData : ServiceBase
    {
        public BackupWorkingData()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
           
            WriteTxtLog("启动程序");
            while (true)
            {
                try
                {
                    //0.初始化数据库连接
                    WriteTxtLog("开始初始化数据库连接");
                    DataBaseList.InitSqlhelper();
                    WriteTxtLog("完成初始化数据库连接");
                    //1.备份制版线1800E的当前排程
                    WriteTxtLog("开始备份制版线1800E的当前排程");
                    if (My.Ping(DataBaseList.IP_制版线1800) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线1800))
                    {
                        DataBaseList.sql制版线1800 = new SqlHelper(DataBaseList.ConnString_制版线1800);
                        if (SubmitZhiBanXianCurrentMysql(DataBaseList.sql制版线1800.Querytable("SELECT [订单号],[客户名称]'客户',rtrim([楞别])'楞型',[订单数],[纸宽]'宽度',[纸长]'长度',rtrim([生产纸质])'材质',[门幅],rtrim([生产备注])'备注',[序号] FROM [dbo].[bc]ORDER BY [序号]"), "制版线1800"))
                        {
                            WriteTxtLog("备份制版线1800E当前排程情况成功!");
                        }
                        else
                        {
                            WriteTxtLog("备份制版线1800E当前排程情况失败!");
                        }

                    }
                    else
                    {
                        WriteTxtLog("制版线1800E数据库连接失败!");
                    }
                    //2.备份制版线1800F的当前排程
                    WriteTxtLog("开始备份制版线1800F的当前排程");
                    if (My.Ping(DataBaseList.IP_制版线1800F) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线1800F))
                    {
                        DataBaseList.sql制版线1800F = new SqlHelper(DataBaseList.ConnString_制版线1800F);
                        if (SubmitZhiBanXianCurrentMysql(DataBaseList.sql制版线1800F.Querytable("SELECT [订单号],[客户名称]'客户',rtrim([楞别])'楞型',[订单数],[纸宽]'宽度',[纸长]'长度',rtrim([生产纸质])'材质',[门幅],rtrim([生产备注])'备注',[序号] FROM [dbo].[bc]ORDER BY [序号]"), "制版线1800F"))
                        {
                            WriteTxtLog("备份制版线1800F当前排程情况成功!");
                        }
                        else
                        {
                            WriteTxtLog("备份制版线1800F当前排程情况失败!");
                        }

                    }
                    else
                    {
                        WriteTxtLog("制版线1800F数据库连接失败!");
                    }

                    //3.备份制版线2200的当前排程
                    WriteTxtLog("开始备份制版线2200的当前排程");
                    if (My.Ping(DataBaseList.IP_制版线2200) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2200))
                    {
                        DataBaseList.sql制版线2200 = new SqlHelper(DataBaseList.ConnString_制版线2200);
                        if (SubmitZhiBanXianCurrentMysql(DataBaseList.sql制版线2200.Querytable("SELECT [订单号],[客户名称]'客户',rtrim([楞别])'楞型',[订单数],[纸宽]'宽度',[纸长]'长度',rtrim([生产纸质])'材质',[门幅],rtrim([生产备注])'备注',[序号] FROM [dbo].[bc]ORDER BY [序号]"), "制版线2200"))
                        {
                            WriteTxtLog("备份制版线2200当前排程情况成功!");
                        }
                        else
                        {
                            WriteTxtLog("备份制版线2200当前排程情况失败!");
                        }

                    }
                    else
                    {
                        WriteTxtLog("制版线2200数据库连接失败!");
                    }
                    //4.备份制版线2500的当前排程
                    WriteTxtLog("开始备份制版线2500的当前排程");
                    if (My.Ping(DataBaseList.IP_制版线2500) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2500))
                    {
                        DataBaseList.sql制版线2500 = new SqlHelper(DataBaseList.ConnString_制版线2500);
                        if (SubmitZhiBanXianCurrentMysql(DataBaseList.sql制版线2500.Querytable(Resources.制版线当前排程2500), "制版线2500"))
                        {
                            WriteTxtLog("备份制版线2500当前排程情况成功!");
                        }
                        else
                        {
                            WriteTxtLog("备份制版线2500当前排程情况失败!");
                        }

                    }
                    else
                    {
                        WriteTxtLog("制版线2500数据库连接失败!");
                    }
                    //5.备份制版线1800E的完成记录
                    WriteTxtLog("开始备份制版线1800E的完成记录");
                    if (DataBaseList.sql制版线1800 != null)
                    {
                        //获取最后备份时间
                        string lastBackupTime = MySqlDbHelper.ExecuteScalar(
                            "SELECT date_sub(max(`结束时间`), interval 1 day) FROM `slbz`.`瓦片完成情况`where 瓦片线='1.8米制版线'").ToString();

                        DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工_1800.Replace("dateadd(dd,-30,GETDATE())", "'" + lastBackupTime + "'"));
                        WriteTxtLog(SubmitZhiBanXianPublishedMysql(dt) ? "备份制版线1800完成情况成功!" : "备份制版线1800完成情况失败!");
                    }
                    else
                    {
                        WriteTxtLog("制版线1800E数据库连接失败!");
                    }
                    //6.备份制版线1800F的完成记录
                    WriteTxtLog("开始备份制版线1800F的完成记录");
                    if (DataBaseList.sql制版线1800F != null)
                    {
                        //获取最后备份时间
                        string lastBackupTime = MySqlDbHelper.ExecuteScalar(
                            "SELECT date_sub(max(`结束时间`), interval 1 day) FROM `slbz`.`瓦片完成情况`where 瓦片线='1.8米制版线F'").ToString();

                        DataTable dt = DataBaseList.sql制版线1800F.Querytable(Resources.制版线完工_1800F.Replace("dateadd(dd,-30,GETDATE())", "'" + lastBackupTime + "'"));
                        WriteTxtLog(SubmitZhiBanXianPublishedMysql(dt) ? "备份制版线1800F完成情况成功!" : "备份制版线1800F完成情况失败!");
                    }
                    else
                    {
                        WriteTxtLog("制版线1800F数据库连接失败!");
                    }

                    //7.备份制版线2200的完成记录
                    WriteTxtLog("开始备份制版线2200的完成记录");
                    if (DataBaseList.sql制版线2200 != null)
                    {
                        //获取最后备份时间
                        string lastBackupTime = MySqlDbHelper.ExecuteScalar(
                            "SELECT date_sub(max(`结束时间`), interval 1 day) FROM `slbz`.`瓦片完成情况`where 瓦片线='2.2米制版线'").ToString();
                        DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工_2200.Replace("dateadd(dd,-30,GETDATE())", "'" + lastBackupTime + "'"));
                        WriteTxtLog(SubmitZhiBanXianPublishedMysql(dt) ? "备份制版线2200完成情况成功!" : "备份制版线2200完成情况失败!");
                    }
                    else
                    {
                        WriteTxtLog("制版线2200数据库连接失败!");
                    }
                    //8.备份制版线2500的完成记录
                    WriteTxtLog("开始备份制版线2500的完成记录");
                    if (DataBaseList.sql制版线2500 != null)
                    {
                        //获取最后备份时间
                        string lastBackupTime = MySqlDbHelper.ExecuteScalar(
                            "SELECT date_sub(max(`结束时间`), interval 1 day) FROM `slbz`.`瓦片完成情况`where 瓦片线='2.5米制版线'").ToString();

                        DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工_2500.Replace("dateadd(dd,-30,GETDATE())", "'" + lastBackupTime + "'"));
                        WriteTxtLog(SubmitZhiBanXianPublishedMysql(dt) ? "备份制版线2500完成情况成功!" : "备份制版线2500完成情况失败!");
                    }
                    else
                    {
                        WriteTxtLog("制版线2500数据库连接失败!");
                    }
                    //9.备份金蝶外购入库明细(仓库代码从13到16)
                    Get二期仓库入库明细();
                    //10.备份金蝶生产领料明细(仓库代码从13到16, 或领料部门是二期)
                    Get二期辅料仓库领料明细();
                    //11.备份金蝶原纸即时库存
                    Get二期原纸仓库即时库存();
                    //12.备份金蝶辅料即时库存
                    Get二期辅料仓库即时库存();
                    //13.备份金蝶胶印纸箱仓库即时库存
                    Get二期胶印纸箱仓库即时库存();

                }
                catch (Exception ex)
                {
                    WriteTxtLog(ex.Message);
                }

                //下一个循环提示
                WriteTxtLog("等待进入下一个循环");
                Thread.Sleep(60000);
            }
        }

        protected override void OnStop()
        {
        }

        private static void Get二期胶印纸箱仓库即时库存()
        {
            WriteTxtLog("开始获取二期胶印纸箱仓库即时库存");
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
                WriteTxtLog("获取[二期胶印纸箱仓库即时库存]成功! ");

            }
            else
            {
                WriteTxtLog("财务系统没有连接!");
            }

        }

        private static void Get二期辅料仓库即时库存()
        {
            WriteTxtLog("开始获取二期辅料仓库即时库存");
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
                    WriteTxtLog("获取[二期辅料仓库即时库存]失败×××××! ");
                }
                else
                {
                    WriteTxtLog("获取[二期辅料仓库即时库存]成功! ");
                }
            }
            else
            {
                WriteTxtLog("财务系统没有连接!");

            }
        }

        private static void Get二期原纸仓库即时库存()
        {
            WriteTxtLog("开始获取二期原纸仓库即时库存");
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
                if (MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    WriteTxtLog("获取[二期原纸仓库即时库存]成功! ");
                }
                else
                {
                    WriteTxtLog("获取[二期原纸仓库即时库存]失败! ");
                }

            }
            else
            {
                WriteTxtLog("财务系统没有连接!");

            }
        }


        private static void Get二期辅料仓库领料明细()
        {
            WriteTxtLog("开始获取二期辅料仓库领料明细");
            List<string> sqlList = new List<string>();
            if (DataBaseList.sql财务 != null)
            {
                //1.确定更新的时间(MYSQL中的时间往前一天)
                //2.从金蝶LOG中读取时间范围内的有变动的单号
                //3.从MYSQL中删除有变动的单号
                //4.从金蝶数据库中读取有变动的领料明细
                //5.正常插入到MYSQL中

                //-------------------------------------------------

                //1.确定更新的时间(MYSQL中的时间往前一天)
                DateTime dTime = Convert.ToDateTime(MySqlDbHelper.ExecuteScalar("SELECT date_add(max(`日期`),interval -1 day)FROM `slbz`.`金蝶_生产领料`"));
                //2.从金蝶LOG中读取时间范围内的有变动的单号
                List<string> danhaoList = new List<string>();
                foreach (DataRow dataRow in DataBaseList.sql财务.Querytable(
                    "SELECT [FDescription]FROM [dbo].[t_Log]WHERE FDescription LIKE'%单据%' and FDescription LIKE'%SOUT%' and  FStatement=3 and fdate>='" + dTime.ToString("yyyy-MM-dd") + "'").Rows)
                {
                    string danhao = Regex.Match(dataRow[0].ToString(), "SOUT\\d+").Value;
                    if (!danhaoList.Contains(danhao))
                    {
                        danhaoList.Add(danhao);
                    }
                }
                //3.从MYSQL中删除有变动的单号
                foreach (string danhao in danhaoList)
                {
                    sqlList.Add("DELETE FROM `slbz`.`金蝶_生产领料`	WHERE `单据编号`='" + danhao + "';");
                }
                if (MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    WriteTxtLog("删除有变动的单据编号成功! ");
                }
                else
                {
                    WriteTxtLog("删除有变动的单据编号失败!");
                    return;
                }
                sqlList.Clear();
                //4.从金蝶数据库中读取有变动的领料明细
                //SQL语句
                StringBuilder sb = new StringBuilder(Resources.二期原纸辅料领料明细.Replace(")llfx", ""));
                sb.Append(" and v1.FBillNo in(''");
                foreach (string danhao in danhaoList)
                {
                    sb.Append(",'" + danhao + "'");
                }
                sb.Append(") )llfx");
                //5.正常插入到MYSQL中
                DataTable dt = DataBaseList.sql财务.Querytable(sb.ToString());
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
                //if (sqlList.Count > 0)
                //{
                //    sqlList.Insert(0, "DELETE FROM `slbz`.`金蝶_生产领料`	WHERE `日期`  "
                //    + "BETWEEN date_format(date_add(now(), interval -60 day), '%Y-%m-%d') AND  date_format(now(), '%Y-%m-%d');");
                //}
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {

                    WriteTxtLog("获取[二期辅料仓库领料明细]失败! ");
                }
                else
                {
                    WriteTxtLog("获取[二期辅料仓库领料明细]成功! ");
                }
            }
            else
            {
                WriteTxtLog("财务系统没有连接!");

            }
        }


        private static void Get二期仓库入库明细()
        {
            WriteTxtLog("开始获取二期仓库入库明细");
            if (DataBaseList.sql财务 != null)
            {
                List<string> sqlList = new List<string>();

                //1.确定更新的时间(MYSQL中的时间往前一天)
                //2.从金蝶LOG中读取时间范围内的有变动的单号
                //3.从MYSQL中删除有变动的单号
                //4.从金蝶数据库中读取有变动的入库明细
                //5.正常插入到MYSQL中

                //-------------------------------------------------
                //1.确定更新的时间(MYSQL中的时间往前一天)
                DateTime dTime = Convert.ToDateTime(MySqlDbHelper.ExecuteScalar("SELECT date_add(max(`日期`),interval -1 day)FROM `slbz`.`金蝶_外购入库`"));
                //2.从金蝶LOG中读取时间范围内的有变动的单号
                List<string> danhaoList = new List<string>();
                foreach (DataRow dataRow in DataBaseList.sql财务.Querytable(
                    "SELECT [FDescription]FROM [dbo].[t_Log]WHERE FDescription LIKE'%单据%' and  FStatement=3 and fdate>='" + dTime.ToString("yyyy-MM-dd") + "'").Rows)
                {
                    string danhao = Regex.Match(dataRow[0].ToString(), "\\d{8,}").Value;
                    if (!danhaoList.Contains(danhao))
                    {
                        danhaoList.Add(danhao);
                    }
                }
                //3.从MYSQL中删除有变动的单号
                foreach (string danhao in danhaoList)
                {
                    sqlList.Add("DELETE FROM `slbz`.`金蝶_外购入库`	WHERE `单据编号`='" + danhao + "';");
                }
                if (MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    WriteTxtLog("删除有变动的单据编号成功!");
                }
                else
                {
                    WriteTxtLog("删除有变动的单据编号失败!");
                    return;
                }
                sqlList.Clear();
                //4.从金蝶数据库中读取有变动的入库明细
                //SQL语句
                StringBuilder sb = new StringBuilder(Resources.二期仓库入库);
                sb.Append(" and v1.FBillNo in(''");
                foreach (string danhao in danhaoList)
                {
                    sb.Append(",'" + danhao + "'");
                }
                sb.Append(")");
                //连接金蝶数据库
                DataTable dt = DataBaseList.sql财务.Querytable(sb.ToString());
                //5.正常插入到MYSQL中
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

                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {

                    WriteTxtLog("获取[二期仓库入库明细]失败! ");
                }
                else
                {
                    WriteTxtLog("获取[二期仓库入库明细]成功! ");
                }
            }
            else
            {
                WriteTxtLog("财务系统没有连接!");

            }
        }



        private static void WriteTxtLog(string txt)
        {
            File.AppendAllText(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) 
                + "\\Log\\"+DateTime.Now.ToString("yyyy-MM-dd")+".txt",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")+"\t"+txt + Environment.NewLine);
        }



        private static bool SubmitZhiBanXianPublishedMysql(DataTable dt)
        {
            List<string> sqlList = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                sqlList.Add("INSERT ignore  INTO `slbz`.`瓦片完成情况` (`工单号`,`客户名`,`门幅`,`楞型`,`材质`,`长度`,`宽度`,`压线`,`开始时间`,`结束时间`,`生产时间`,`备注`,`瓦片线`,`数量`) VALUES"
        + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');"
        , row["工单号"], row["客户名"], row["门幅"], row["楞型"], row["材质"], row["长度"], row["宽度"]
        , ' ', ' ', row["结束时间"].ToString(), ' ', row["备注"], row["瓦片线"], row["数量"]));

            }
            return MySqlDbHelper.ExecuteSqlTran(sqlList);
        }

        private static bool SubmitZhiBanXianCurrentMysql(DataTable dt, string scx)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add("delete from `slbz`.`瓦片当前排程` where `生产线`='" + scx + "';");
            foreach (DataRow row in dt.Rows)
            {
                sqlList.Add("INSERT INTO `slbz`.`瓦片当前排程` (`订单号`,`客户`,`楞型`,`订单数`,`宽度`,`长度`,`材质`,`门幅`,`序号`,`备注`,`生产线`) VALUES"
        + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');"
        , row["订单号"], row["客户"], row["楞型"], row["订单数"], row["宽度"], row["长度"], row["材质"]
        , row["门幅"], row["序号"], row["备注"], scx));

            }
            if (sqlList.Count > 0)
            {
                sqlList.Add(string.Format("UPDATE `slbz`.`settingall`SET `Value` ='{0}'  WHERE `Key` ='{1}' "
                    , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "制版线当前排程更新时间"));
            }
            return MySqlDbHelper.ExecuteSqlTran(sqlList);
        }
    }
}
