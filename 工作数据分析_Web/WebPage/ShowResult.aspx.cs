using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class WebPage_ShowResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code = Request.QueryString.Count > 0 ? Request.QueryString["sqlcode"].ToString().Trim() : "";
        string sqlStr = "";
        string gridTitle = "";
        switch (code)
        {
            case "1":
                sqlStr = "SELECT * FROM `slbz`.`二期原纸仓库库存明细`";
                gridTitle = "二期原纸仓库库存明细_详情";
                break;
            case "2":
                sqlStr = "SELECT * FROM `slbz`.`二期原纸仓库库存明细_分类`";
                gridTitle = "二期原纸仓库库存明细_分类";
                break;
            case "3":
                sqlStr = "SELECT * FROM `slbz`.`二期原纸仓库库存明细(按品牌)_分类`";
                gridTitle = "二期原纸仓库库存明细_按品牌分类";
                break;
            case "4":
                sqlStr = "SELECT * FROM `slbz`.`二期原纸仓库库存明细(uv合并)_分类`";
                gridTitle = "二期原纸仓库库存明细_按UV合并分类";
                break;
            
            //case "9":
            //    sqlStr = "CALL `slbz`.`二期原纸仓库库存明细分类汇总`('A')";
            //    gridTitle = "分类汇总(A类纸)";
            //    break;
            //case "10":
            //    sqlStr = "CALL `slbz`.`二期原纸仓库库存明细分类汇总`('B')";
            //    gridTitle = "分类汇总(B类纸)";
            //    break;
            case "11":
                sqlStr = "CALL `slbz`.`二期原纸仓库各类占比`;";
                gridTitle = "二期原纸仓库各类占比";
                break;
           
            case "13":
                sqlStr = "select * from `slbz`.`二期辅料仓库即时库存一览`;";
                gridTitle = "二期辅料仓库即时库存一览";
                break;
            case "14":
                sqlStr = "select * from `slbz`.`二期辅料库存补库明细`;";
                gridTitle = "二期辅料库存补库明细";
                break;
            case "15":
                sqlStr = "select * from `slbz`.`二期成品仓库近30天入库平方`;";
                gridTitle = "二期成品仓库近30天入库平方";
                break;
            case "16":
                sqlStr = "CALL `slbz`.`二期成品仓库超期一览`();";
                gridTitle = "二期成品仓库超期一览";
                break;
            case "18":
                sqlStr = "CALL `slbz`.`二期送货运费明细近90天`();";
                gridTitle = "二期送货运费明细近90天";
                break;
            case "19":
                sqlStr = "CALL `slbz`.`二期库存情况`();";
                gridTitle = "二期库存情况";
                break;
            default:
                break;
        }

        if (gridTitle.Contains("原纸"))
        {
            gridTitle = gridTitle + " <br />" +
                MySqlDbHelper.ExecuteScalar("SELECT CONCAT('总库存:',cast(sum(库存)/1000 as char),'吨,件数:',cast(count(批号)as char),'件')	FROM `slbz`.`二期原纸仓库即时库存`");
        }
        this.GridView1.Caption = gridTitle;
        if (!string.IsNullOrWhiteSpace(sqlStr))
        {
            //if (gridTitle.Contains("分类汇总("))
            //{
            //    DataTable dt = new DataTable();
            //    dt = MySqlDbHelper.ExecuteDataTable(sqlStr);
            //    for (int i = dt.Columns.Count - 1; i >= 0; i--)
            //    {
            //        if (dt.Columns[i].ColumnName == "代码" || dt.Columns[i].ColumnName == "门幅")
            //        {
            //            continue;
            //        }
            //        int sum = 0;
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            try
            //            {
            //                sum += Convert.ToInt32(dr[i]);
            //                if (sum > 0)
            //                {
            //                    continue;
            //                }
            //            }
            //            catch
            //            {
            //                continue;
            //            }
            //        }
            //        if (sum == 0)
            //        {
            //            dt.Columns.RemoveAt(i);
            //        }
            //    }
            //    this.GridView1.DataSource = My.Table_deletezero(dt);
            //    this.GridView1.DataBind();


            //}
            //else
                if (gridTitle.Contains("二期原纸仓库各类占比"))
                {
                    DataTable dt = MySqlDbHelper.ExecuteDataTable(sqlStr);
                    DataTable dt_temp = dt.Clone();
                    foreach (DataColumn dc in dt_temp.Columns)
                    {
                        dc.DataType = Type.GetType("System.String");
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr_new = dt_temp.NewRow();
                        foreach (DataColumn dc in dt.Columns)
                        {
                            if (dt.Rows[i][dc.ColumnName].ToString() == "0"
                                || dt.Rows[i][dc.ColumnName].ToString() == "0.00%")
                            {
                                dr_new[dc.ColumnName] = "";
                            }
                            else
                            {
                                dr_new[dc.ColumnName] = dt.Rows[i][dc.ColumnName].ToString();
                            }
                        }
                        dt_temp.Rows.Add(dr_new);
                    }

                    this.GridView1.DataSource = dt_temp;
                    this.GridView1.DataBind();
                }
                else
                {
                    this.GridView1.DataSource = MySqlDbHelper.ExecuteDataTable(sqlStr);
                    this.GridView1.DataBind();
                }

        }
    }



    protected void Button1_Click(object sender, EventArgs e)
    {

        string fileName = "ce2.rar";//客户端保存的文件名
        string filePath = Server.MapPath("keji.rar");//路径

        //以字符流的形式下载文件
        FileStream fs = new FileStream(filePath, FileMode.Open);
        byte[] bytes = new byte[(int)fs.Length];
        fs.Read(bytes, 0, bytes.Length);
        fs.Close();
        Response.ContentType = "application/octet-stream";
        //通知浏览器下载文件而不是打开
        Response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();

    }
}