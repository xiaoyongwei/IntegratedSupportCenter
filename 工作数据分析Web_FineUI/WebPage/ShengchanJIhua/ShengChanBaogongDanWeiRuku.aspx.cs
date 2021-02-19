using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.ShengchanJIhua
{
    public partial class ShengChanBaogongDanWeiRuku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.DataSource = My.GetSqlTxt_Datatable("报工但未入库");
            this.GridView1.DataBind();

        }
    }
}