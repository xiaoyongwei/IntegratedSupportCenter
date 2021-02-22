using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.YuanZhi
{
    public partial class YuanzhiFeileiHuizong : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            DataTable dt = new DataTable();
            //A类纸
            dt = MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`二期原纸仓库库存明细分类汇总`('A')");
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
            if (dt.Rows.Count > 0)
            {
                this.GridViewA.Caption = "分类汇总(A类纸)";
                this.GridViewA.DataSource = My.Table_deletezero(dt);
                this.GridViewA.DataBind();
            }

            //B类纸
            dt = MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`二期原纸仓库库存明细分类汇总`('B')");
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
            if (dt.Rows.Count > 0)
            {
                this.GridViewB.Caption = "分类汇总(B类纸)";
                this.GridViewB.DataSource = My.Table_deletezero(dt);
                this.GridViewB.DataBind();
            }
        }
    }
}