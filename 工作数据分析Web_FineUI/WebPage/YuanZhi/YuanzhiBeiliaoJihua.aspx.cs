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
    public partial class yuanzhi2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = MySqlDbHelper.ExecuteDataSet("CALL `slbz`.`原纸备料计划1`();");
            ds = My.Dst_zero(ds);

            GridView1.DataSource = ds.Tables[1];
            GridView1.Caption = ds.Tables[0].Rows[0][0].ToString();
            GridView1.DataBind();

            GridView2.DataSource = ds.Tables[3];
            GridView2.Caption = ds.Tables[2].Rows[0][0].ToString();
            GridView2.DataBind();

            GridView3.DataSource = ds.Tables[5];
            GridView3.Caption = ds.Tables[4].Rows[0][0].ToString();
            GridView3.DataBind();

            GridView4.DataSource = ds.Tables[7];
            GridView4.Caption = ds.Tables[6].Rows[0][0].ToString();
            GridView4.DataBind();
        }
    }
}