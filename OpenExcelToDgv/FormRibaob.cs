using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using excelToTable_NPOI;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.IO;

namespace OpenExcelToDgv
{
    public partial class FormRibaob : Form
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
            获取工序
        }
        /// <summary>
        /// 浏览器加载后执行的动作
        /// </summary>
        private WebAfter wAfter = WebAfter.无;


        public FormRibaob()
        {
            InitializeComponent();
        }


        private void 生产发货日报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel(*.xls)|*.xls";
            save.FileName = "销售日报表-" + DateTime.Now.ToString("yyyy-MM-dd");
            if (save.ShowDialog() == DialogResult.OK
                && new ExcelHelper(save.FileName).DataTableToExcel(MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`送货日报表`('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',2)")
                , DateTime.Now.ToString("MM-dd"), true) > 2
                && MessageBox.Show("保存完成,是否打开?", "打开?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //ExcelHelper excel = new ExcelHelper(save.FileName);

                Process.Start(save.FileName);
            }
            //}
            //catch (Exception ex)
            //{
            //    My.ShowErrorMessage(ex.Message);
            //}
        }

        private void FormRibaob_Load(object sender, EventArgs e)
        {

        }


        private void LoginWeb()
        {
            webBrowser.Navigate("http://21.ej-sh.net:9191/login.shtml");
        }

        private void 导入数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void OneKeyGet(bool IsReturnResult)
        {
            dic.Clear();

            //运费管理-霍红海
            dic.Add("http://21.ej-sh.net:9191/dlvFare/sl.shtml?strdats=" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd")
              + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&driver=" + Uri.EscapeUriString("霍红海") + "&rowsPerPage=5000", WebAfter.运费管理);
            //运费管理-郑二毛
            dic.Add("http://21.ej-sh.net:9191/dlvFare/sl.shtml?strdats=" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd")
              + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&driver=" + Uri.EscapeUriString("郑二毛") + "&rowsPerPage=5000", WebAfter.运费管理);
            //运费管理-郑荷伟
            dic.Add("http://21.ej-sh.net:9191/dlvFare/sl.shtml?strdats=" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd")
              + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&driver=" + Uri.EscapeUriString("郑荷伟") + "&rowsPerPage=5000", WebAfter.运费管理);
            //运费管理-周晓军
            dic.Add("http://21.ej-sh.net:9191/dlvFare/sl.shtml?strdats=" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd")
              + "&endates=" + DateTime.Now.ToString("yyyy-MM-dd") + "&driver=" + Uri.EscapeUriString("周晓军") + "&rowsPerPage=5000", WebAfter.运费管理);

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = "易捷 " + webBrowser.Url;
            //加载完成后的操作
            switch (wAfter)
            {
                case WebAfter.无:
                case WebAfter.None:
                    break;

                case WebAfter.运费管理:
                    YunfeiGuanli();
                    break;
                case WebAfter.送货明细:
                    GetSonghuoMingxi();
                    break;
                case WebAfter.下个明细:
                    GotoWebUrlByDic();
                    break;
                case WebAfter.完成:
                    MySqlDbHelper.ExecuteNonQuery("UPDATE `slbz`.`settingall`	SET Value='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' 	WHERE `Key` = 'LastGetTime';");
                    this.toolStripStatusLabel1.Text = "易捷数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`	FROM `slbz`.`settingall`	where `Key`='LastGetTime'").ToString();
                    break;
                default:
                    break;
            }
        }

        private void YunfeiGuanli()
        {
            if (!(webBrowser.DocumentText.Contains("<span style=\"color: #ff0000;\">运费结算</span></a>") &&
             webBrowser.DocumentText.Contains("运费结算")))
            {
                My.ShowErrorMessage("当前页面非[运费结算]页面");
                dic.Clear();
                wAfter = WebAfter.下个明细;
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
                    sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
                }
                if (!MySqlDbHelper.ExecuteSqlTran(sqlList))
                {
                    dic.Clear();
                    My.ShowErrorMessage("获取[运费管理]失败!");
                }
            }
            wAfter = WebAfter.下个明细;
        }

        private void GotoWebUrl(string url, WebAfter after)
        {
            wAfter = after;
            webBrowser.Navigate(url);
        }


        /// <summary>
        /// 送货记录
        /// </summary>
        private void GetSonghuoMingxi()
        {
            if (!(webBrowser.Url.ToString().Contains("21.ej-sh.net:9191/ctBcdx/dlv.shtml")))
            {
                My.ShowErrorMessage("当前页面非[送货查询]页面");
                dic.Clear();
                wAfter = WebAfter.下个明细;
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

                StringBuilder sb_Insert = new StringBuilder("INSERT IGNORE  INTO `slbz`.`成品_送货明细`(");
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
                    My.ShowErrorMessage("获取[送货记录]失败!");
                }
            }
            wAfter = WebAfter.下个明细;
        }

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
                JisuanRukuMianjie();
            }
        }

        private void GotoHomePage()
        {
            GotoWebUrl("http://21.ej-sh.net:9191", WebAfter.None);
        }
    }
}
