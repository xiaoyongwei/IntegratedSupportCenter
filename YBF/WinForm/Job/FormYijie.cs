using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using YBF.Class.Comm;
using System.Text.RegularExpressions;

namespace YBF.WinForm.Job
{
    public partial class FormYijie : Form
    {
        private enum WebAfter
        {
            无,
            登录,
            获取关联信息,
            跳转到印版确认,
            获取印版确认的所有数据,
            完成并退出
        }


        private WebAfter WA = WebAfter.无;
        /// <summary>
        /// ids列表
        /// </summary>
        public List<string> idsList = new List<string>();
        private List<string> idsList_empty = new List<string>();

        public FormYijie()
        {
            InitializeComponent();
        }


        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            switch (WA)
            {
                case WebAfter.登录:
                    WebLogin();
                    break;
                case WebAfter.获取关联信息:
                    foreach (HtmlElement item in webBrowser.Document.GetElementsByTagName("TABLE"))
                    {
                        if (item.InnerHtml.Contains("订单信息查询界面")
                            && Regex.Match(item.OuterHtml, "C\\d{9}").Success
                            && SQLiteList.YBF.ExecuteNonQuery("UPDATE [印版确认]SET [工单号] = '" +
                                Regex.Match(item.OuterHtml, "C\\d{9}").Value + "'WHERE[ids]='" + idsList_empty[0] + "';") > 0)
                        {
                            idsList_empty.RemoveAt(0);
                            break;
                        }
                    }
                    GetAllInformaction();
                    break;
                case WebAfter.跳转到印版确认:
                    GotoWebUrl("http://21.ej-sh.net:9191/ordSchCt/plt.shtml?status=N", WA = WebAfter.无);

                    break;
                case WebAfter.获取印版确认的所有数据:
                    获取印版信息ToolStripMenuItem_Click(获取印版信息ToolStripMenuItem, new EventArgs());
                    break;
                case WebAfter.完成并退出:
                    this.DialogResult = DialogResult.OK;
                    break;
                case WebAfter.无:
                default:
                    break;
            }
        }

        private void FormYijie_Load(object sender, EventArgs e)
        {
            //登录
            GotoWebUrl("http://21.ej-sh.net:9191/login.shtml?method:exit", WebAfter.登录);
        }

        private void GotoWebUrl(string url, WebAfter webAfter)
        {
            WA = webAfter;
            webBrowser.Navigate(url);
        }


        private void WebLogin()
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
                            em.SetAttribute("value", "123456");//密码，保存在序列化的student类中 
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
                WA = WebAfter.跳转到印版确认;
                webBrowser.Document.GetElementById("sublogin").InvokeMember("click");
                //isLogin = true;
                //btn.InvokeMember("click"); //触发submit事件 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WA = WebAfter.无;
            webBrowser.Refresh();
        }

        private void 获取印版信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idsList.Clear();
            DataTable dt = new DataTable();
            //table标签的内容
            foreach (HtmlElement he_table in webBrowser.Document.GetElementsByTagName("TABLE"))
            {
                //筛选出包含指定内容的Table
                if (he_table.OuterText.Contains("审核") &&
                    he_table.OuterText.Contains("打印") &&
                    he_table.OuterText.Contains("甩纸") &&
                    he_table.OuterText.Contains("稿袋号") &&
                    he_table.OuterText.Contains("设备"))
                {
                    HtmlElementCollection he_tr_coll = he_table.GetElementsByTagName("TR");


                    //如果只包含第一行的空行和标题行的话,则退出
                    if (he_tr_coll.Count <= 2)
                    {
                        return;
                    }
                    else
                    {
                        //table标签下的tr标签的内容
                        foreach (HtmlElement td_column in he_tr_coll[1].GetElementsByTagName("TD"))
                        {
                            DataColumn dc = new DataColumn(td_column.InnerText);
                            if (string.IsNullOrWhiteSpace(dc.ColumnName))
                            {
                                dc.ColumnName = "ids";
                            }
                            dt.Columns.Add(dc);
                        }
                        dt.Columns.Add("工单号");
                        //table标签下的tr标签的内容                      
                        for (int i = 2; i < he_tr_coll.Count; i++)
                        {
                            DataRow dr = dt.NewRow();
                            //tr标签下的td标签的内容
                            HtmlElementCollection he_td_coll = he_tr_coll[i].GetElementsByTagName("TD");
                            dr["ids"] = he_tr_coll[i].Id;
                            dr["审核"] = he_td_coll[1].InnerText;
                            dr["打印"] = he_td_coll[2].InnerText;
                            dr["甩纸"] = he_td_coll[3].InnerText;
                            dr["稿袋号"] = GetText(he_td_coll[4].InnerText);
                            dr["设备"] = GetText(he_td_coll[5].InnerText);
                            dr["客户"] = GetText(he_td_coll[6].InnerText);
                            dr["产品"] = GetText(he_td_coll[7].InnerText);
                            dr["规格"] = GetText(he_td_coll[8].InnerText);
                            dr["面纸加料"] = GetText(he_td_coll[9].InnerText);
                            dr["版类"] = GetText(he_td_coll[10].InnerText);
                            dr["专色"] = GetText(he_td_coll[11].InnerText);
                            dr["颜色"] = GetText(he_td_coll[12].InnerText);
                            dr["版数量"] = GetText(he_td_coll[13].InnerText);
                            dr["订单日期"] = GetText(he_td_coll[14].InnerText);
                            dr["交货日期"] = GetText(he_td_coll[15].InnerText);
                            dr["要求"] = GetText(he_td_coll[16].InnerText);
                            dt.Rows.Add(dr);

                            //ids列表
                            idsList.Add(he_tr_coll[i].Id);
                        }

                    }
                }

            }
            List<string> sqlList = new List<string>();
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            List<string> idsList_ALL = new List<string>();
            foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("SELECT [ids]FROM [印版确认]").Rows)
            {
                idsList_ALL.Add(row[0].ToString());
            }
            List<string> idsList_Insert = new List<string>();
            List<string> idsList_Update = new List<string>();




            foreach (string item in idsList)
            {
                if (!idsList_ALL.Contains(item))
                {
                    idsList_Insert.Add(item);
                }
            }
            foreach (string item in idsList)
            {
                if (idsList_ALL.Contains(item))
                {
                    idsList_Update.Add(item);
                }
            }



            //需要新增的数据
            foreach (string item in idsList_Insert)
            {
                DataRow row = dt.Select("ids=" + item)[0];
                sqlList.Add(string.Format(
                   "INSERT INTO [印版确认]([ids],[工单号],[客户名],[产品名称],[稿袋号],[制造尺寸],[下料尺寸],[新旧版],[机台],[印版数],[工艺要求])VALUES(" +
                   "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}');"
                   , row["ids"].ToString(), "", row["客户"].ToString(), row["产品"].ToString(), row["稿袋号"].ToString(),
                   row["规格"].ToString(), row["面纸加料"].ToString(), row["版类"].ToString(), row["设备"].ToString().Replace("（二期）", ""),
                   row["版数量"].ToString(), row["要求"].ToString()));

            }
            //需要更新的数据
            foreach (string item in idsList_Update)
            {
                DataRow row = dt.Select("ids=" + item)[0];
                sqlList.Add(string.Format(
                  "UPDATE [印版确认]SET" +
                "[工单号] = '{0}'" +
                ",[客户名] = '{1}'" +
                ",[产品名称] ='{2}'" +
                ",[稿袋号] ='{3}'" +
                ",[制造尺寸] = '{4}'" +
                ",[下料尺寸] = '{5}'" +
                ",[新旧版] ='{6}'" +
                ",[机台] = '{7}'" +
                ",[印版数] = '{8}'" +
                ",[工艺要求] ='{9}'" +
                 "WHERE [ids] = '{10}';"
                 , "", row["客户"].ToString(), row["产品"].ToString(), row["稿袋号"].ToString(),
                 row["规格"].ToString(), row["面纸加料"].ToString(), row["版类"].ToString(), row["设备"].ToString().Replace("（二期）", ""),
                  row["版数量"].ToString(), row["要求"].ToString(), item));
            }
            if (SQLiteList.YBF.ExecuteSqlTran(sqlList))
            {
                idsList_empty.Clear();
                foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("SELECT [ids]FROM [印版确认] WHERE[工单号]=''").Rows)
                {
                    idsList_empty.Add(row[0].ToString());
                }
                GetAllInformaction();

                MessageBox.Show("请等待页面跳转完成!");
            }
            else
            {
                Comm_Method.ShowErrorMessage("操作失败!");
            }
        }

        private string GetText(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? "" : text;
        }

        private void GetAllInformaction()
        {
            if (idsList_empty.Count > 0)
            {
                GotoWebUrl("http://21.ej-sh.net:9191/clOrd/mtv.shtml?method:mtvform=&id=" + idsList_empty[0], WebAfter.获取关联信息);
            }
            else
            {
                WA = WebAfter.跳转到印版确认;
                StringBuilder sb = new StringBuilder();
                foreach (string item in idsList)
                {
                    sb.Append(item + ",");
                }
                sb.Append(0);
                dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("select * from[印版确认]where ids in(" + sb.ToString() + ")");
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void 导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idsList.Clear();
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                idsList.Add(row.Cells["ids"].Value.ToString());
            }
            this.DialogResult = DialogResult.OK;
        }

        private void 导入并审核ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            导入ToolStripMenuItem_Click(this, new EventArgs());
            foreach (HtmlElement he in webBrowser.Document.GetElementsByTagName("INPUT"))
            {
                if (he.GetAttribute("type") == "checkbox" && he.GetAttribute("name") == "ids"
                    && idsList.Contains(he.GetAttribute("value")))
                {
                    he.SetAttribute("checked", "true");
                }
            }
            WA = WebAfter.完成并退出;
            webBrowser.Document.GetElementById("audt").InvokeMember("click");
        }
    }
}
