using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Xiangpian
{
    public partial class XiangpianKucun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            this.GridView1.DataSource = My.GetSqlTxt_Datatable("纸板库存情况");
            this.GridView1.DataBind();

          
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, GridView1, "箱片库存明细", true);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}