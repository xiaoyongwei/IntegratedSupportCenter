using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.WebPage.Xiangpian
{
    public partial class XiangpianDangqianPaichengCaihe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          

            GridView1.DataSource = MySqlDbHelper.ExecuteDataTable(
                "SELECT *,round(订单数*宽度*长度/1000000)面积 FROM `slbz`.`瓦片当前排程` where (`订单号` like'C2%' OR `订单号` like'CL2%' OR `工单号` like'L2%')");
            GridView1.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, GridView1, "彩盒箱片当前排程", true);
        }
    }
}