using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.WuLiao
{
    public partial class WuliaoShuaizhi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            this.GridView1.Caption = "未甩纸明细";
            this.GridView2.Caption = "未甩纸总结";
            this.GridView1.DataSource = My.GetSqlTxt_Datatable("未甩纸明细");
            this.GridView1.DataBind();
            this.GridView2.DataSource =My. GetSqlTxt_Datatable("未甩纸总结");
            this.GridView2.DataBind();
        }
    }
}