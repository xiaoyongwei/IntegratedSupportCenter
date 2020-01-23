using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using 综合保障中心.Comm;
using 甩纸数据;
using System.Reflection;
using 工作数据分析.WinForm;
using DBUtility;
using 工作数据分析.Properties;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using 工作数据分析.Data.DAL;

namespace 综合保障中心.其它
{
    public partial class FormYijie_自动获取 : Form
    {

        Dictionary<string, WebAfter> dic = new Dictionary<string, WebAfter>();

        private enum WebAfter
        {
            None,
            无,
            下个明细,
            登录,
            保存,
            获取关联信息,
            彩印维护_初步,
            数码维护_初步_循环,
            数码维护_初步_单个,
            彩印维护_精准_循环,
            彩印维护_精准_单个,
            数码维护_精准_循环,
            数码维护_精准_单个,
            获取二期库存列表,
            运费管理,
            甩纸作业,
            报工查询,
            入库明细,
            出库明细,
            库存明细,
            送货明细,
            排程查询,
            导入生产单_数码,
            导入生产单_彩印,
            导入生产单_水印,
            完成,
            完成并重新登录,
            获取工序,
            纸箱排车,
            获取运费报价,
            计算入库面积
        }
        /// <summary>
        /// 浏览器加载后执行的动作
        /// </summary>
        private WebAfter wAfter = WebAfter.无;

        public FormYijie_自动获取()
        {
            InitializeComponent();
        }



        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = "易捷 " + webBrowser.Url;
            //加载完成后的操作
            switch (wAfter)
            {
                case WebAfter.无:
                case WebAfter.None:
                    break;
                case WebAfter.登录:
                    WebLogin();
                    break;
                case WebAfter.保存:
                    break;
                case WebAfter.获取关联信息:
                    break;
                case WebAfter.彩印维护_初步:
                    break;
                case WebAfter.数码维护_初步_循环:
                    break;
                case WebAfter.数码维护_初步_单个:
                    break;
                case WebAfter.彩印维护_精准_循环:
                    break;
                case WebAfter.彩印维护_精准_单个:
                    break;
                case WebAfter.数码维护_精准_循环:
                    break;
                case WebAfter.数码维护_精准_单个:
                    break;
                case WebAfter.获取二期库存列表:
                    GetErqiCangku();
                    break;
                case WebAfter.运费管理:
                    YunfeiGuanli();
                    break;
                case WebAfter.甩纸作业:
                    GetShuaizhiJob();
                    break;
                case WebAfter.报工查询:
                    GetShuaizhiBaogong();
                    break;
                case WebAfter.入库明细:
                    GetRukuMingxi();
                    break;
                case WebAfter.出库明细:
                    GetChukuMingxi();
                    break;
                case WebAfter.库存明细:
                    GetKucunMingxi();
                    break;
                case WebAfter.送货明细:
                    GetSonghuoMingxi();
                    break;
                case WebAfter.排程查询:
                    GetPaichengChaxun();
                    break;
                case WebAfter.导入生产单_彩印:
                    GetShengchandan("彩印");
                    break;
                case WebAfter.导入生产单_数码:
                    GetShengchandan("数码");
                    break;
                case WebAfter.导入生产单_水印:
                    GetShengchandan("水印");
                    break;
                case WebAfter.计算入库面积:
                    JisuanRukuMianjie();
                    break;
                case WebAfter.下个明细:
                    GotoWebUrlByDic();
                    break;
                case WebAfter.完成:
                    MySqlDbHelper.ExecuteNonQuery("UPDATE `slbz`.`settingall`	SET Value='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' 	WHERE `Key` = 'LastGetTime';");
                    this.toolStripStatusLabel1.Text = "易捷数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`	FROM `slbz`.`settingall`	where `Key`='LastGetTime'").ToString()
                + " , 制版线数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `结束时间`FROM `slbz`.`瓦片完成情况`ORDER BY `结束时间` DESC LIMIT 1").ToString();
                    dic.Clear();   
                GotoWebUrlByDic();    
                break;
                case WebAfter.获取工序:
                    GotoGongxu();
                    break;
                case WebAfter.纸箱排车:
                    Get纸箱排车();
                    break;
                case WebAfter.获取运费报价:
                    Get运费报价();
                    break;
                default:
                    break;
            }
        }

        private void Get运费报价()
        {
            //INSERT IGNORE INTO `slbz`.`物料_报价运费`(`工单号`,`报价运费`)VALUES(<工单号, VARCHAR(15)>,<报价运费, DOUBLE>)
            if (!(webBrowser.DocumentText.Contains("装车理货")))
            {
                AddtbShow("当前页面非[装车理货]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[4].GetElementsByTagName("tr");

            if (hec.Count > 3)
            {
                DataTable dt = new DataTable();
                MessageBox.Show(hec[1].InnerText);
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    MessageBox.Show(item.InnerText);
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }
                //只保留生产单和报价运费2个列
                for (int i = dt.Columns.Count - 1; i >= 0; i--)
                {
                    if (dt.Columns[i].ColumnName != "生产单" && dt.Columns[i].ColumnName != "报价运费")
                    {
                        dt.Columns.RemoveAt(i);
                    }
                }

                //开始添加到sql中
                List<string> sqlList = new List<string>();
                StringBuilder sb_Insert = new StringBuilder(" INSERT IGNORE  INTO `slbz`.`物流_报价运费`(");
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
                    dic.Clear();
                    AddtbShow("获取[报价运费]失败!");
                }
                AddtbShow("获取[报价运费]成功!");
            }




            wAfter = WebAfter.下个明细;
        }

        private void Get纸箱排车()
        {
            if (!(webBrowser.DocumentText.Contains("理货查询")))
            {
                AddtbShow("当前页面非[理货查询]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;
            }
            AddtbShow("开始添加运费报价ID");
            List<string> idList = new List<string>();
            Regex regex = new Regex("name=\"ids\" value=\"\\d+\"");
            foreach (Match item in regex.Matches(webBrowser.DocumentText))
            {
                idList.Add(Regex.Match(item.Value, "\\d+").Value);
            }

            //http://21.ej-sh.net:9191/dlvAuto.shtml?method:form=&id=183207&actype=D

            foreach (string item in idList)
            {
                dic.Add("http://21.ej-sh.net:9191/dlvAuto.shtml?method:form=&id=" + item + "&actype=D", WebAfter.获取运费报价);
            }

            AddtbShow("添加[运费报价ID]成功!数量为:" + idList.Count + "个!!");
            wAfter = WebAfter.下个明细;

        }

        /// <summary>
        /// 获取工序
        /// </summary>
        private void GotoGongxu()
        {
            if (!webBrowser.DocumentText.Contains("<td><a href=\"/pbProcesses.shtml?method:list=\"><span style=\"color: #ff0000;\">工序管理</span></a>"))
            {
                AddtbShow("当前页面非[工序管理]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;

            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[0].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }
                //添加到datatable中完成
                dt.Columns.RemoveAt(0);
                //开始添加到sql中
                List<string> sqlList = new List<string>();
                sqlList.Add("truncate `slbz`.`工序管理`; ");
                StringBuilder sb_Insert = new StringBuilder(" INSERT IGNORE  INTO `slbz`.`工序管理`(");
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
                    dic.Clear();
                    AddtbShow("获取[工序管理]失败!");
                }
            }
            AddtbShow("获取[工序管理]成功!");
            wAfter = WebAfter.下个明细;
        }

        /// <summary>
        /// 排程查询
        /// </summary>
        private void GetPaichengChaxun()
        {
            if (!webBrowser.DocumentText.Contains("<td><a href=\"/ordSchRead.shtml\"><span style=\"color: #ff0000;\">排程查询</span></a></td>"))
            {
                AddtbShow("当前页面非[排程查询]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;

            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }
                //添加到datatable中完成
                dt.Columns.RemoveAt(0);
                //开始添加到sql中
                List<string> sqlList = new List<string>();
                StringBuilder sb_Insert = new StringBuilder("replace  INTO `slbz`.`排程查询`(");
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
                //File.AppendAllLines("E:\\11.txt", sqlList);
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    dic.Clear();
                    AddtbShow("获取[排程查询]失败!");
                }
            }
            AddtbShow("获取[排程查询]成功!");
            wAfter = WebAfter.下个明细;
        }

        private void GetShengchandan(string leixing)
        {
            if (!(webBrowser.DocumentText.Contains("水印订单维护") || webBrowser.DocumentText.Contains("彩印订单维护") || webBrowser.DocumentText.Contains("数码订单维护")))
            {
                AddtbShow("当前页面非[彩印,数码,水印 订单]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }

                //    添加到datatable中完成
                dt.Columns.RemoveAt(0);

                //    开始添加到sql中
                List<string> sqlList = new List<string>();

                StringBuilder sb_Insert = new StringBuilder(" replace   INTO `slbz`.`订单_生产单`(`类型`,");
                foreach (DataColumn dc in dt.Columns)//添加列
                {
                    sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
                }
                sb_Insert.Remove(sb_Insert.Length - 1, 1);
                sb_Insert.AppendLine(")VALUES");
                StringBuilder sb_values = new StringBuilder();
                foreach (DataRow dr in dt.Rows)
                {
                    sb_values = new StringBuilder("('" + leixing + "',");
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sb_values.AppendFormat("'{0}',", dr[dc].ToString());
                    }
                    sb_values.Remove(sb_values.Length - 1, 1);
                    sb_values.AppendLine(");");
                    sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
                }
                if (sqlList.Count > 0 && leixing == "彩印")
                {
                    sqlList.Add("UPDATE `slbz`.`订单_生产单`	SET `所属` = '二期'	WHERE 类型='彩印';");
                    sqlList.Add("UPDATE `slbz`.`订单_生产单`	SET `计划交期` = (CASE WHEN LENGTH (`建立/送货`)>10 AND`建立/送货`like'%-%'THEN RIGHT(`建立/送货`,10)else '1990-01-01' end )WHERE  `计划交期` = '1990-01-01'");
                    // File.WriteAllLines("D:\\11.txt", sqlList);
                }

                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    dic.Clear();
                    AddtbShow("获取[订单明细]失败!");
                }
            }
            AddtbShow("获取[订单明细]成功!");
            wAfter = WebAfter.下个明细;
        }

        /// <summary>
        /// 库存明细
        /// </summary>
        private void GetKucunMingxi()
        {
            if (!(webBrowser.DocumentText.Contains("<td><a href=\"/ctInquiry.shtml?method:bcdt=\"><span style=\"color: #ff0000;\">库存明细</span></a></td>")))
            {
                AddtbShow("当前页面非[库存明细]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }

                //    添加到datatable中完成
                dt.Columns.RemoveAt(0);
                //删除S和W开头的工单
                //删除仓库不包含二期的工单
                foreach (DataRow row in dt.Select("(生产单号 like 'W%') OR (生产单号 like 'S%') OR (仓库 not like '%二期%')and(生产单号 not like 'C%')"))
                {
                    dt.Rows.Remove(row);
                }

                //    开始添加到sql中
                List<string> sqlList = new List<string>();

                StringBuilder sb_Insert = new StringBuilder(" INSERT IGNORE  INTO `slbz`.`成品_库存明细`(");
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
                    sqlList.Insert(0, "truncate table `slbz`.`成品_库存明细`;");
                }


                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    dic.Clear();
                    AddtbShow("获取[库存明细]失败!");
                }


            } AddtbShow("获取[库存明细]成功!");
            wAfter = WebAfter.下个明细;

        }

        /// <summary>
        /// 入库明细
        /// </summary>
        private void GetRukuMingxi()
        {
            if (!(webBrowser.DocumentText.Contains("<td><a href=\"/ctInquiry.shtml?method:bcdr=\"><span style=\"color: #ff0000;\">入库明细</span></a></td>") &&
                webBrowser.DocumentText.Contains("入库单号类型")))
            {
                AddtbShow("当前页面非[入库明细]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }



                //    添加到datatable中完成
                dt.Columns.RemoveAt(0);
                //删除S和W开头的工单
                //删除仓库不包含二期的工单
                foreach (DataRow row in dt.Select("(生产单号 like 'W%') OR (生产单号 like 'S%')"))
                {
                    dt.Rows.Remove(row);
                }

                //    开始添加到sql中
                List<string> sqlList = new List<string>();

                //统计入库单号
                List<string> rukudanList = new List<string>();
                //遍历入库单号的信息
                foreach (DataRow row in dt.Rows)
                {
                    string rukudan = row["入库单号"].ToString();
                    if (!string.IsNullOrWhiteSpace(rukudan) && !rukudanList.Contains(rukudan))
                    {
                        rukudanList.Add(rukudan);
                    }
                    sqlList.Add("DELETE FROM `slbz`.`成品_入库明细`WHERE `入库单号`='" + rukudan + "';");
                }


                StringBuilder sb_Insert = new StringBuilder("INSERT IGNORE  INTO `slbz`.`成品_入库明细`(");
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
                sqlList.Add("UPDATE `slbz`.`成品_库存明细` SET `订单类型` = '彩印' WHERE `订单类型`=''and`生产单号` like 'C%';");
                sqlList.Add("UPDATE `slbz`.`成品_库存明细` SET `订单类型` = '数码' WHERE `订单类型`=''and`生产单号` like 'A%';");
                sqlList.Add("UPDATE `slbz`.`成品_库存明细` SET `订单类型` = '纸箱' WHERE `订单类型`=''and`生产单号` like 'Z%';");
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    dic.Clear();
                    AddtbShow("获取[入库明细]失败!");
                }
            }
            AddtbShow("获取[入库明细]成功!");
            wAfter = WebAfter.下个明细;
        }
        /// <summary>
        /// 甩纸报工
        /// </summary>
        private void GetShuaizhiBaogong()
        {
            if (!(webBrowser.DocumentText.Contains("<td><span style=\"color: #ff0000;\">报工情况查询</span></td>")))
            {
                AddtbShow("当前页面非[报工查询]页面");
                dic.Clear();
                GotoWebUrlByDic();
                return;
            }
            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }

                //    添加到datatable中完成
                dt.Columns.RemoveAt(0);
                //    开始添加到sql中
                List<string> sqlList = new List<string>();
                StringBuilder sb_Insert = new StringBuilder("INSERT IGNORE  INTO `slbz`.`报工查询`(");
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
                    dic.Clear();
                    AddtbShow("获取[报工查询]失败!");
                }
            }
            AddtbShow("获取[报工查询]成功!");
            wAfter = WebAfter.下个明细;
        }


        private void GetShuaizhiJob()
        {
            if (!webBrowser.DocumentText.Contains("<td><a href=\"/ordSchCt/bcp.shtml\"><span style=\"color: #ff0000;\">甩纸作业</span></a></td>"))
            {
                AddtbShow("当前页面非[甩纸作业]页面");

                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }
                //添加到datatable中完成
                dt.Columns.RemoveAt(0);
                //开始添加到sql中
                List<string> sqlList = new List<string>();
                StringBuilder sb_Insert = new StringBuilder("replace   INTO `slbz`.`甩纸_作业`(");
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
                    dic.Clear();
                    AddtbShow("获取[甩纸作业]失败!");
                }
            }
            AddtbShow("获取[甩纸作业]成功!");
            wAfter = WebAfter.下个明细;
        }

        private void YunfeiGuanli()
        {
            if (!(webBrowser.DocumentText.Contains("<span style=\"color: #ff0000;\">运费结算</span></a>") &&
             webBrowser.DocumentText.Contains("运费结算")))
            {
                AddtbShow("当前页面非[运费结算]页面");
                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }


                //    添加到datatable中完成
                dt.Columns.RemoveAt(0);


                //    开始添加到sql中
                List<string> sqlList = new List<string>();

                StringBuilder sb_Insert = new StringBuilder("replace  INTO `slbz`.`运费管理`(");
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
                    sb_values.Replace("\\", "\\\\");
                    sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
                }
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    dic.Clear();
                    AddtbShow("获取[运费管理]失败!");
                }
            }
            AddtbShow("获取[运费管理]成功!");
            wAfter = WebAfter.下个明细;
        }

        private void GetErqiCangku()
        {
            List<string> sqlList = new List<string>();
            List<string> gdhList = new List<string>();
            string[] htmlArray = webBrowser.DocumentText.Replace("\t", "").Replace(" ", "").Replace("\n", "").Split('\r');
            for (int i = 0; i < htmlArray.Length; i++)
            {
                if (Regex.IsMatch(htmlArray[i], "<td>.*二期.*</td>")
                    && Regex.IsMatch(htmlArray[i + 1], "<td>(C|Z|A)\\d+</td>", RegexOptions.IgnoreCase))
                {
                    gdhList.Add(htmlArray[i + 1].Trim("</td>".ToArray()));
                }
            }
            foreach (string gdh in gdhList)
            {
                sqlList.Add(string.Format("INSERT IGNORE INTO `仓库`.`成品_二期仓库工单`(`工单号`)VALUES('{0}');", gdh));
            }

            wAfter = WebAfter.下个明细;
        }

        void tsmiUrl_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(webBrowser.Url.ToString());
        }


        void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            string text = tsmi.Text;
            foreach (HtmlElement he in webBrowser.Document.All)
            {
                string type = he.GetAttribute("type");
                string value = he.GetAttribute("value");
                if ((type.Equals("submit", StringComparison.OrdinalIgnoreCase) || type.Equals("button", StringComparison.OrdinalIgnoreCase))
                    && value.Equals(text, StringComparison.OrdinalIgnoreCase))
                {
                    wAfter = WebAfter.无;
                    he.InvokeMember("click");
                    return;
                }
            }



        }

        private void FormYijiePojie_Load(object sender, EventArgs e)
        {
            this.toolStripComboBox1.SelectedIndex = 0;
            this.toolStripStatusLabel1.Text = "易捷数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`	FROM `slbz`.`settingall`	where `Key`='LastGetTime'").ToString()
                   + " , 制版线数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `结束时间`FROM `slbz`.`瓦片完成情况`ORDER BY `结束时间` DESC LIMIT 1").ToString();
            GotoWebUrl("http://21.ej-sh.net:9191/login.shtml?method:exit", WebAfter.登录);
        }



        private void GotoWebUrl(string url, WebAfter after)
        {
            wAfter = after;
            webBrowser.Navigate(url);
        }

        private void WebLogin()
        {
            if (webBrowser.DocumentText.Contains("登录帐号"))
            {
                foreach (HtmlElement em in webBrowser.Document.All) //轮循 
                {
                    string str = em.Id;
                    if (string.IsNullOrWhiteSpace(str))
                    {
                        str = em.Name;
                    }
                    // if ((str == "usrcde") || str == "passwd" || str == "sublogin") //减少处理 
                    if ((str == "usrcde") || str == "passwd") //减少处理 
                    {
                        switch (str)
                        {
                            case "usrcde":
                                em.SetAttribute("value", "WL0254");//账号，保存在序列化的student类中 
                                break; //填表 
                            case "passwd":
                                em.SetAttribute("value", "123");//密码，保存在序列化的student类中 
                                break; //填表 
                            //case "sublogin":
                            //    btn = em;
                            //  break;
                            default: break;
                        }
                    }
                }
                // bool isLogin = false;
                try
                {
                    wAfter = WebAfter.无;
                    webBrowser.Document.GetElementById("sublogin").InvokeMember("click");
                    AddtbShow("登录成功！");
                    //isLogin = true;
                    //btn.InvokeMember("click"); //触发submit事件 
                }
                catch (Exception ex)
                {
                    AddtbShow("登录失败_____" + ex.Message);
                }
            }

        }

        private void AddtbShow(string text)
        {
            string addtext = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + text + Environment.NewLine;
            this.tbShow.AppendText(addtext);
            File.AppendAllText("Log\\log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", addtext);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = e.Node;

            if ((tn.Tag != null) && !string.IsNullOrWhiteSpace(tn.Tag.ToString()))
            {
                GotoWebUrl(tn.Tag.ToString(), WebAfter.无);
            }
        }

        private void 获取二期库位表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdt=&sitloc=%E4%BA%8C%E6%9C%9F&rowsPerPage=1000", WebAfter.获取二期库存列表);
        }

        private void 下载送货清单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/pbDsql/exp.shtml?rptcde=R18010066&format=XLS&strdats=2019-04-19&endates=2019-04-19", WebAfter.无);
        }

        private void 郑二毛ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl(string.Format("http://21.ej-sh.net:9191/dlvFare/sl.shtml?driver={0}&strdats={1}&endates={2}&rowsPerPage=1000"
                , Uri.EscapeDataString(((ToolStripMenuItem)sender).Text), DateTime.Now.AddMonths(-2).ToString("yyyy-MM-dd")
                , DateTime.Now.ToString("yyyy-MM-dd")), WebAfter.运费管理);

        }

        private void 甩纸作业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ordSchCt/bcp.shtml?strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
                + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&status=&rowsPerPage=1000", WebAfter.甩纸作业);
        }

        private void 甩纸报工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ordSchCt/overlist.shtml?strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
                + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&&prccde=41&rowsPerPage=1000", WebAfter.报工查询);
        }

        private void 筛选数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form筛选数据().ShowDialog();
        }

        private void 登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/login.shtml?method:exit", WebAfter.无);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            GetShuaizhiBaogong();
        }

        private void 手动导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetShuaizhiJob();
        }

        private void 跳转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ordSchCt/bcp.shtml?strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
                + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&status=&rowsPerPage=1000", WebAfter.无);

        }

        private void 跳转ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ordSchCt/overlist.shtml?strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
               + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&&prccde=41&rowsPerPage=1000", WebAfter.无);

        }

        private void 输入用纸清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form用纸情况().ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/clOrd/mt.shtml?status=Y", WebAfter.None);
        }

        private void 自动导入近3天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdr=&strdats=" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
               + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.入库明细);
        }

        private void 跳转ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdr=", WebAfter.无);
        }

        private void 手动导入ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            GetRukuMingxi();
        }

        private void 自动导入3天ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdx=&strdats=" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
               + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.出库明细);
        }

        private void 跳转ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdx=", WebAfter.无);
        }

        private void 手动导入ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetChukuMingxi();
        }

        /// <summary>
        /// 出库明细
        /// </summary>
        private void GetChukuMingxi()
        {
            if (!(webBrowser.DocumentText.Contains("<td><a href=\"/ctInquiry.shtml?method:bcdx=\"><span style=\"color: #ff0000;\">出库明细</span></a></td>") &&
             webBrowser.DocumentText.Contains("出库单号类型")))
            {
                AddtbShow("当前页面非[出库明细]页面");
                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }


                //    添加到datatable中完成
                dt.Columns.RemoveAt(0);
                //删除S和W开头的工单
                //删除仓库不包含二期的工单
                foreach (DataRow row in dt.Select("(生产单号 like 'W%') OR (生产单号 like 'S%') OR (仓库 not like '%二期%')and(生产单号 not like 'C%')"))
                {
                    dt.Rows.Remove(row);
                }

                //    开始添加到sql中
                List<string> sqlList = new List<string>();

                StringBuilder sb_Insert = new StringBuilder("INSERT IGNORE  INTO `slbz`.`成品_出库明细`(");
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
                    dic.Clear();
                    AddtbShow("获取[出库明细]失败!");
                }
            }
            AddtbShow("获取[出库明细]成功!");
            wAfter = WebAfter.下个明细;
        }

        private void 获取成品库存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdt=&rowsPerPage=5000", WebAfter.库存明细);
        }

        private void 自动导入近3天ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctBcdx/dlv.shtml?strdats=" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
              + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.送货明细);
        }

        private void 跳转ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/dlv.shtml", WebAfter.None);
        }

        private void 手动导入ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            GetSonghuoMingxi();
        }


        /// <summary>
        /// 送货记录
        /// </summary>
        private void GetSonghuoMingxi()
        {
            if (!(webBrowser.Url.ToString().Contains("21.ej-sh.net:9191/ctBcdx/dlv.shtml")))
            {
                AddtbShow("当前页面非[送货查询]页面");
                dic.Clear();
                GotoWebUrlByDic();
                return;
            }

            HtmlElementCollection hec = webBrowser.Document.GetElementsByTagName("table")[3].GetElementsByTagName("tr");

            if (hec.Count > 2)
            {
                DataTable dt = new DataTable();
                foreach (HtmlElement item in hec[1].GetElementsByTagName("td"))
                {
                    dt.Columns.Add(item.OuterText);
                }
                for (int trI = 2; trI < hec.Count; trI++)
                {
                    List<object> listObj = new List<object>();
                    foreach (HtmlElement item in hec[trI].GetElementsByTagName("td"))
                    {
                        listObj.Add(item.OuterText);
                    }
                    dt.Rows.Add(listObj.ToArray());
                }


                //    添加到datatable中完成
                dt.Columns.RemoveAt(0);

                //    开始添加到sql中
                List<string> sqlList = new List<string>();
                List<string> songhuodanList = new List<string>();
                //遍历相同的送货单号
                foreach (DataRow row in dt.Rows)
                {
                    string songhuodan = row["送货单"].ToString();
                    if (!string.IsNullOrWhiteSpace(songhuodan) && !songhuodanList.Contains(songhuodan))
                    {
                        songhuodanList.Add(songhuodan);
                        sqlList.Add("DELETE FROM `slbz`.`成品_送货明细` WHERE `送货单`='" + songhuodan + "';");
                    }

                }

                StringBuilder sb_Insert = new StringBuilder("INSERT  INTO `slbz`.`成品_送货明细`(");
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
                    dic.Clear();
                    AddtbShow("获取[送货记录]失败!");
                }
            }
            AddtbShow("获取[送货记录]成功!");
            wAfter = WebAfter.下个明细;
        }

        private void 引入外购入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 引入生产领料ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 计算入库面积ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JisuanRukuMianjie();
        }
        /// <summary>
        /// 计算入库面积
        /// </summary>
        private void JisuanRukuMianjie()
        {
            List<string> sqlList = new List<string>();
            foreach (DataRow row in MySqlDbHelper.ExecuteDataTable("SELECT `仓库`,`生产单号`,`入库单号`,`入库数量`FROM `slbz`.`成品_入库明细`WHERE 面积=0").Rows)
            {
                sqlList.Add(string.Format(
                    "UPDATE `slbz`.`成品_入库明细`SET 面积 = IFNULL((SELECT `面积` FROM `slbz`.`订单_生产单`WHERE 生产单号 = '{0}'),0)* `入库数量`WHERE `生产单号` = '{0}';"
                    , row["生产单号"].ToString()));
            }
            if (sqlList.Count >= 0
                && !MySqlDbHelper.ExecuteSqlTran(sqlList))
            {
                dic.Clear();
                AddtbShow("[计算入库面积]失败!");
            }
            AddtbShow("计算入库面积]成功!");
            wAfter = WebAfter.下个明细;
        }

        //彩印
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/clOrd/mt.shtml?status=Y&strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
              + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.导入生产单_彩印);

        }
        //数码
        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/cdOrd/mt.shtml?status=Y&strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
            + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.导入生产单_数码);
        }
        //水印
        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctOrd/mt.shtml?status=Y&strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
            + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.导入生产单_水印);
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/cdOrd/mt.shtml?status=Y", WebAfter.None);
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            GotoWebUrl("http://21.ej-sh.net:9191/ctOrd/mt.shtml?status=Y", WebAfter.None);
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            GetShengchandan("彩印");
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            GetShengchandan("数码");
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            GetShengchandan("水印");
        }

        private void toolStripMenuItem一键获取_Click(object sender, EventArgs e)
        {
            OneKeyGet(true, false);
        }

        /// <summary>
        /// 一键获取
        /// </summary>
        /// <param name="IsReturnResult">true表示显示错误结果</param>
        /// <param name="YunfeiOnly">true表示只备份送货方面的数据</param>
        private void OneKeyGet(bool IsReturnResult, bool YunfeiOnly)
        {
            dic.Clear();
            AddtbShow("开始{一键获取}");
            if (this.toolStripComboBox1.Text == "全部获取" || this.toolStripComboBox1.Text == "只获取易捷数据")
            {

                List<string> erqiSiji = new List<string>();
                foreach (DataRow row in MySqlDbHelper.ExecuteDataTable("SELECT `司机`FROM `slbz`.`物流_司机信息`").Rows)
                {
                    erqiSiji.Add(row[0].ToString());
                }

                ////纸箱排车
                //dic.Add("http://21.ej-sh.net:9191/dlvAuto.shtml?status=&rowsPerPage=1&strdats="
                //    + DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd")+"&endates=" + DateTime.Now.ToString("yyyy-MM-dd")
                //    , WebAfter.纸箱排车);

                //成品入库
                dic.Add("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdr=&strdats=" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
                   + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.入库明细);
                //发货记录
                dic.Add("http://21.ej-sh.net:9191/ctBcdx/dlv.shtml?strdats=" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
                  + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000&pageSize=1", WebAfter.送货明细);
                //运费管理
                foreach (string siji in erqiSiji)
                {
                    dic.Add("http://21.ej-sh.net:9191/dlvFare/sl.shtml?strdats=" + DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd")
                  + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&driver=" + Uri.EscapeUriString(siji) + "&rowsPerPage=5000", WebAfter.运费管理);
                }
                dic.Add("http://21.ej-sh.net:9191/dlvFare/sl.shtml?pono=ZX&strdats=" + DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd")
                  + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&driver=&rowsPerPage=5000", WebAfter.运费管理);


                if (!YunfeiOnly)
                {
                    //彩印
                    dic.Add("http://21.ej-sh.net:9191/clOrd/mt.shtml?status=Y&strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
                      + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.导入生产单_彩印);
                    //数码
                    dic.Add("http://21.ej-sh.net:9191/cdOrd/mt.shtml?status=Y&strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
                    + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.导入生产单_数码);
                    //水印
                    dic.Add("http://21.ej-sh.net:9191/ctOrd/mt.shtml?status=Y&strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
                    + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.导入生产单_水印);
                    //甩纸作业
                    dic.Add("http://21.ej-sh.net:9191/ordSchCt/bcp.shtml?strdats=" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd")
                        + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&status=&rowsPerPage=1000", WebAfter.甩纸作业);
                    //报工查询
                    dic.Add("http://21.ej-sh.net:9191/ordSchCt/overlist.shtml?strdats=" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
                        + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.报工查询);
                    //排程查询-彩盒
                    for (DateTime i = DateTime.Now.AddDays(-5); i <= DateTime.Now; i = i.AddDays(1))
                    {
                        dic.Add("http://21.ej-sh.net:9191/ordSchRead.shtml?strdats=" + i.ToString("yyyy-MM-dd")
                       + "&endates=" + i.ToString("yyyy-MM-dd") + "&objtyp=CL&daytyp=P&rowsPerPage=5000", WebAfter.排程查询);
                    }
                    //排程查询-数码
                    for (DateTime i = DateTime.Now.AddDays(-5); i <= DateTime.Now; i = i.AddDays(1))
                    {
                        dic.Add("http://21.ej-sh.net:9191/ordSchRead.shtml?strdats=" + i.ToString("yyyy-MM-dd")
                       + "&endates=" + i.ToString("yyyy-MM-dd") + "&objtyp=CD&daytyp=P&rowsPerPage=5000", WebAfter.排程查询);
                    }
                    //成品出库
                    dic.Add("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdx=&strdats=" + DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
                       + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&rowsPerPage=5000", WebAfter.出库明细);
                    //成品库存
                    dic.Add("http://21.ej-sh.net:9191/ctInquiry.shtml?method:bcdt=&rowsPerPage=5000", WebAfter.库存明细);
                    //获取工序
                    dic.Add("http://21.ej-sh.net:9191/pbProcesses.shtml?rowsPerPage=2000", WebAfter.获取工序);
                    //返回
                    dic.Add("http://21.ej-sh.net:9191/ctInquiry.shtml", WebAfter.计算入库面积);
                }
            }
            if (this.toolStripComboBox1.Text == "全部获取" || this.toolStripComboBox1.Text == "只获取其它数据")
            {
                DataBaseList.InitSqlhelper();
                Get二期原纸仓库即时库存();
                Get二期胶印纸箱仓库即时库存();
                Get1800制版线完成信息();
                Get2200制版线完成信息();
                Get2500制版线完成信息();
            }
                //完成提示;
                dic.Add("http://21.ej-sh.net:9191", WebAfter.完成);
            //开始逐步获取并备份数据
            GotoWebUrlByDic();
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
                    sqlList.Add("INSERT INTO `slbz`.`二期胶印纸箱仓库即时库存` (`物料长代码`,`物料名称`,`基本单位`,`库存`,`换算率`,`辅助单位`,`辅助数量`,`仓库名称`,`仓库代码`) VALUES"
            + string.Format("('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');"
            , row["物料长代码"], row["物料名称"], row["基本单位"], row["库存"], row["换算率"], row["辅助单位"], row["辅助数量"], row["仓库名称"], row["仓库代码"]));

                }
                MySqlDbHelper.ExecuteSqlTran(sqlList);
            }
            AddtbShow("获取[二期胶印纸箱仓库即时库存]成功!");
        }

        private void Get2500制版线完成信息()
        {
            if (DataBaseList.sql制版线2500 != null)
            {
                DataTable dt = DataBaseList.sql制版线2500.Querytable(Resources.制版线完工_2500);
                SubmitZhiBanXian(dt);
                AddtbShow("获取[2500制版线完成信息]成功!");
            }

        }

        private void Get2200制版线完成信息()
        {
            if (DataBaseList.sql制版线2200 != null)
            {
                DataTable dt = DataBaseList.sql制版线2200.Querytable(Resources.制版线完工_2200);
                SubmitZhiBanXian(dt);
                AddtbShow("获取[2200制版线完成信息]成功!");
            }

        }

        private void Get1800制版线完成信息()
        {
            if (DataBaseList.sql制版线1800 != null)
            {
                DataTable dt = DataBaseList.sql制版线1800.Querytable(Resources.制版线完工_1800);
                SubmitZhiBanXian(dt);
                AddtbShow("获取[1800制版线完成信息]成功!");
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
                AddtbShow("获取[二期原纸仓库即时库存]成功!");
            }
        }

        /// <summary>
        /// 逐步获取并备份数据
        /// </summary>
        private void GotoWebUrlByDic()
        {
            string url = "http://21.ej-sh.net:9191";
            WebAfter wa = WebAfter.None;
            if (dic.Count > 0)
            {
                foreach (string item in dic.Keys)
                {
                    url = item;
                    wa = dic[url];
                    break;
                }
                dic.Remove(url);
                GotoWebUrl(url, wa);
            }
            else
            {
                GotoWebUrl("http://21.ej-sh.net:9191/login.shtml?method:exit", WebAfter.登录);
            }
        }

        //private void GotoHomePage()
        //{
        //    GotoWebUrl("http://21.ej-sh.net:9191", WebAfter.None);
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            try
            {
                OneKeyGet(true, false);
            }
            finally
            {
                this.timer1.Start();
            }

        }

       

        private void 备份送货数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OneKeyGet(true, true);
        }

       


    }
}

