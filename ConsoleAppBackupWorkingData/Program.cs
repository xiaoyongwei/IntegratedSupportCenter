using ConsoleAppBackupWorkingData.Properties;
using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using 工作数据分析.Data.DAL;
using 综合保障中心.Comm;

namespace ConsoleAppBackupWorkingData
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 0;
            PrintToConsole("启动程序");
            while (true)
            {
                //达到一定次数则清空原来的输出
                if (num++ > 100)
                {
                    num = 0;
                    Console.Clear();
                }
                try
                {
                    //0.初始化数据库连接
                    PrintToConsole("开始初始化数据库连接");
                    DataBaseList.InitSqlhelper();
                    PrintToConsole("完成初始化数据库连接");
                    //1.备份制版线1800E的当前排程
                    PrintToConsole("开始备份制版线1800E的当前排程",false);
                    if (My.Ping(DataBaseList.IP_制版线1800) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线1800))
                    {
                        DataBaseList.sql制版线1800 = new SqlHelper(DataBaseList.ConnString_制版线1800);
                        if (SubmitZhiBanXianCurrentMysql(DataBaseList.sql制版线1800.Querytable("SELECT [订单号],[客户名称]'客户',rtrim([楞别])'楞型',[订单数],[纸宽]'宽度',[纸长]'长度',rtrim([生产纸质])'材质',[门幅],rtrim([生产备注])'备注',[序号] FROM [dbo].[bc]ORDER BY [序号]"), "制版线1800"))
                        {
                            PrintToConsole("备份制版线1800E当前排程情况成功!");
                        }
                        else
                        {
                            PrintToConsole("备份制版线1800E当前排程情况失败!");
                        }

                    }
                    else
                    {
                        PrintToConsole("制版线1800E数据库连接失败!");
                    }
                    //2.备份制版线1800F的当前排程
                    //3.备份制版线2200的当前排程
                    PrintToConsole("开始备份制版线2200的当前排程", false);
                    if (My.Ping(DataBaseList.IP_制版线2200) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2200))
                    {
                        DataBaseList.sql制版线2200 = new SqlHelper(DataBaseList.ConnString_制版线2200);
                        if (SubmitZhiBanXianCurrentMysql(DataBaseList.sql制版线2200.Querytable("SELECT [订单号],[客户名称]'客户',rtrim([楞别])'楞型',[订单数],[纸宽]'宽度',[纸长]'长度',rtrim([生产纸质])'材质',[门幅],rtrim([生产备注])'备注',[序号] FROM [dbo].[bc]ORDER BY [序号]"), "制版线2200"))
                        {
                            PrintToConsole("备份制版线2200当前排程情况成功!");
                        }
                        else
                        {
                            PrintToConsole("备份制版线2200当前排程情况失败!");
                        }

                    }
                    else
                    {
                        PrintToConsole("制版线2200数据库连接失败!");
                    }
                    //4.备份制版线2500的当前排程
                    PrintToConsole("开始备份制版线2500的当前排程", false);
                    if (My.Ping(DataBaseList.IP_制版线2500) && SqlHelper.IsConnection(DataBaseList.ConnString_制版线2500))
                    {
                        DataBaseList.sql制版线2500 = new SqlHelper(DataBaseList.ConnString_制版线2500);
                        if (SubmitZhiBanXianCurrentMysql(DataBaseList.sql制版线2500.Querytable(Resources.制版线当前排程2500), "制版线2500"))
                        {
                            PrintToConsole("备份制版线2500当前排程情况成功!");
                        }
                        else
                        {
                            PrintToConsole("备份制版线2500当前排程情况失败!");
                        }

                    }
                    else
                    {
                        PrintToConsole("制版线2500数据库连接失败!");
                    }
                    //5.备份制版线1800E的完成记录
                    PrintToConsole("开始备份制版线1800E的完成记录", false);
                    if (DataBaseList.sql制版线1800 != null)
                    {
                        DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工_1800);
                        PrintToConsole(SubmitZhiBanXianPublishedMysql(dt) ? "备份制版线1800完成情况成功!" : "备份制版线1800完成情况失败!");
                    }
                    else
                    {
                        PrintToConsole("制版线1800E数据库连接失败!");
                    }
                    //6.备份制版线1800F的完成记录

                    //7.备份制版线2200的完成记录
                    PrintToConsole("开始备份制版线2200的完成记录", false);
                    if (DataBaseList.sql制版线2200 != null)
                    {
                        DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工_2200);
                        PrintToConsole(SubmitZhiBanXianPublishedMysql(dt) ? "备份制版线2200完成情况成功!" : "备份制版线2200完成情况失败!");
                    }
                    else
                    {
                        PrintToConsole("制版线2200数据库连接失败!");
                    }
                    //8.备份制版线2500的完成记录
                    PrintToConsole("开始备份制版线2500的完成记录", false);
                    if (DataBaseList.sql制版线2500 != null)
                    {
                        DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工_2500);

                        PrintToConsole(SubmitZhiBanXianPublishedMysql(dt) ? "备份制版线2500完成情况成功!" : "备份制版线2500完成情况失败!");
                    }
                    else
                    {
                        PrintToConsole("制版线2500数据库连接失败!");
                    }
                    //9.备份金蝶外购入库明细(仓库代码从13到16)
                    Get二期仓库入库明细();
                    //10.备份金蝶生产领料明细(仓库代码从13到16,或领料部门是二期)
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
                    PrintToConsole(ex.Message);
                }

                //下一个循环提示
                PrintToConsole("等待进入下一个循环",true,ConsoleColor.Blue);
                Thread.Sleep(60000);
            }
        }


        private static void Get二期胶印纸箱仓库即时库存()
        {
            PrintToConsole("开始获取二期胶印纸箱仓库即时库存", false);
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
                PrintToConsole("获取[二期胶印纸箱仓库即时库存]成功! ");

            }
            else
            {
                PrintToConsole("财务系统没有连接!");
            }

        }

        private static void Get二期辅料仓库即时库存()
        {
            PrintToConsole("开始获取二期辅料仓库即时库存", false);
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
                    PrintToConsole("获取[二期辅料仓库即时库存]失败×××××! ");
                }
                else
                {
                    PrintToConsole("获取[二期辅料仓库即时库存]成功! ");
                }
            }
            else
            {
                PrintToConsole("财务系统没有连接!");

            }
        }

        private static void Get二期原纸仓库即时库存()
        {
            PrintToConsole("开始获取二期原纸仓库即时库存", false);
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
                    PrintToConsole("获取[二期原纸仓库即时库存]成功! ");
                }
                else
                {
                    PrintToConsole("获取[二期原纸仓库即时库存]失败! ");
                }
                
            }
            else
            {
                PrintToConsole("财务系统没有连接!");

            }
        }


        private  static void Get二期辅料仓库领料明细()
        {
            PrintToConsole("开始获取二期辅料仓库领料明细", false);
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

                    PrintToConsole("获取[二期辅料仓库领料明细]失败! ");
                }
                else
                {
                    PrintToConsole("获取[二期辅料仓库领料明细]成功! ");
                }
            }
            else
            {
                PrintToConsole("财务系统没有连接!");

            }
        }


        private static void Get二期仓库入库明细()
        {
            PrintToConsole("开始获取二期仓库入库明细", false);
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

                    PrintToConsole("获取[二期仓库入库明细]失败! ");
                }
                else
                {
                    PrintToConsole("获取[二期仓库入库明细]成功! ");
                }
            }
            else
            {
                PrintToConsole("财务系统没有连接!");

            }


        }



        private static void PrintToConsole(string txt,bool isNewLine=true,ConsoleColor color=ConsoleColor.Gray)
        {
            Console.ForegroundColor =color;
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")+"  "+txt+(isNewLine?"\n":""));
        }

      

        private static bool SubmitZhiBanXianPublishedMysql(DataTable dt)
        {
            List<string> sqlList = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                sqlList.Add("INSERT ignore  INTO `slbz`.`瓦片完成情况` (`工单号`,`客户名`,`门幅`,`楞型`,`材质`,`长度`,`宽度`,`压线`,`开始时间`,`结束时间`,`生产时间`,`备注`,`瓦片线`,`数量`) VALUES"
        + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}');"
        , row["工单号"], row["客户名"], row["门幅"], row["楞型"], row["材质"], row["长度"], row["宽度"]
        , ' ', ' ', row["结束时间"].ToString(), ' ', ' ', row["瓦片线"], row["数量"]));

            }
            return MySqlDbHelper.ExecuteSqlTran(sqlList);
        }

        private static bool  SubmitZhiBanXianCurrentMysql(DataTable dt,string scx)
        {
            List<string> sqlList = new List<string>();
            sqlList.Add("truncate table `slbz`.`瓦片当前排程`;");
            foreach (DataRow row in dt.Rows)
            {
                sqlList.Add("INSERT INTO `slbz`.`瓦片当前排程` (`订单号`,`客户`,`楞型`,`订单数`,`宽度`,`长度`,`材质`,`门幅`,`序号`,`备注`,`生产线`) VALUES"
        + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');"
        , row["订单号"], row["客户"], row["楞型"], row["订单数"], row["宽度"], row["长度"], row["材质"]
        , row["门幅"], row["序号"], row["备注"],scx));

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
