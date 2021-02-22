using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Xiangpian
{
    public partial class XiangpianChukuFenxi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            this.GridView1.DataSource = My.GetSqlTxt_Datatable("纸板出库分析");
            this.GridView1.DataBind();
        }
    }
}