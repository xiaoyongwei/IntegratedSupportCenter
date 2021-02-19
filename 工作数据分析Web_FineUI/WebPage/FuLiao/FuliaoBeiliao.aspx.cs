using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.FuLiao
{
    public partial class FuliaoBeiliao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            GridView1.Caption = "辅料备料技术分析(10天安全库存)";

            GridView1.DataSource = MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`辅料备料技术分析`();");
            GridView1.DataBind();
        }
    }
}