using FineUIPro;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.WebPage.Wuliu
{
    public partial class WuliuHuidan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (My.IsSession(Session,Response))
            {
                GridView1.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * FROM `slbz`.`送货回单情况` where `回单正常`<>'Y'ORDER BY `送货单号` DESC ");
                GridView1.DataBind();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, GridView1, "回单异常_" +My.GetDatetimeNow_yyyMMdd());
        }
    }
}