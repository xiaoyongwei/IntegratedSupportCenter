using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebPage_ShowResult : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string code =Request.QueryString.Count>0? Request.QueryString["sqlcode"].ToString().Trim():""
            ;
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
            case "8":
                sqlStr = "SELECT *FROM `slbz`.`二期特殊工艺订单`";
                gridTitle = "特殊工艺订单";
                break;
            case "9":
                sqlStr = "CALL `slbz`.`二期原纸仓库库存明细分类汇总`('A')";
                gridTitle = "分类汇总(A类纸)";
                break;
            case "10":
                sqlStr = "CALL `slbz`.`二期原纸仓库库存明细分类汇总`('B')";
                gridTitle = "分类汇总(B类纸)";
                break;
            case "11":
                sqlStr = "CALL `slbz`.`二期原纸仓库各类占比`;";
                gridTitle = "二期原纸仓库各类占比";
                break;
 case "12":
                sqlStr = "CALL `slbz`.`二期未完工订单`;";
                gridTitle = "二期未完工订单";
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
            if (gridTitle.Contains("分类汇总("))
            {
                DataTable dt = new DataTable();
                dt = MySqlDbHelper.ExecuteDataTable(sqlStr);
                for (int i = dt.Columns.Count - 1; i >= 0; i--)
                {
                    if (dt.Columns[i].ColumnName == "代码" || dt.Columns[i].ColumnName == "门幅")
                    {
                        continue;
                    }
                    int sum = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        try
                        {
                            sum += Convert.ToInt32(dr[i]);
                            if (sum > 0)
                            {
                                continue;
                            }
                        }
                        catch 
                        {
                            continue;
                        }
                    }
                    if (sum == 0)
                    {
                        dt.Columns.RemoveAt(i);
                    }
                }
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
            }
            else if (gridTitle.Contains("二期原纸仓库各类占比"))
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
                            dr_new[dc.ColumnName]="";
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
            else if (gridTitle=="二期未完工订单")
            {
                DataTable dt = MySqlDbHelper.ExecuteDataTable(sqlStr);
                dt.DefaultView.Sort="所处工序";
                this.GridView1.DataSource = dt;
                this.GridView1.DataBind();
            }
            else
            {
                this.GridView1.DataSource = MySqlDbHelper.ExecuteDataTable(sqlStr);
                this.GridView1.DataBind();
            }

        }
    }



}