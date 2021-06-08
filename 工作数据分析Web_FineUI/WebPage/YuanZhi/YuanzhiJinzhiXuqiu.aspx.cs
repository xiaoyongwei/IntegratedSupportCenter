using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.WebPage.YuanZhi
{
    public partial class YuanzhiJinzhiXuqiu : System.Web.UI.Page
    {
        string sql = "SELECT *FROM `slbz`.`二期原纸进纸需求(安全库存)`" +
                " ORDER BY `纸类` , `代码` , `门幅` ";

        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            this.GridView1.DataSource = MySqlDbHelper.ExecuteDataTable(sql);
            this.GridView1.DataBind();
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, GridView1, "二期原纸进纸需求(安全库存)", true);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}