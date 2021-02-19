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
    public partial class yuanzhiGeleiZhanbi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable dt = MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`二期原纸仓库各类占比`");
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


            GridView1.Caption = MySqlDbHelper.ExecuteScalar(
               "SELECT CONCAT('总库存:',cast(sum(库存)/1000 as char),'吨,件数:',cast(count(批号)as char),'件')" +
               "	FROM `slbz`.`二期原纸仓库即时库存`").ToString();

            GridView1.DataSource = dt_temp;
            GridView1.DataBind();
        }
    }
}