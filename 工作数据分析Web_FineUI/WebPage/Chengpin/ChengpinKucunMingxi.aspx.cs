using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.Chengpin
{
    public partial class ChengpinKucunMingxi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         

            GridView1.Caption = "彩盒库存明细";

            this.GridView1.DataSource = My.GetSqlTxt_Datatable("彩盒库存明细");
            this.GridView1.DataBind();
        }
    }
}