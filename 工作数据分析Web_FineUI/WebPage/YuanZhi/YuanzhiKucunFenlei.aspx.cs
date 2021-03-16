using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.YuanZhi
{
    public partial class yuanzhiKucunFenlei : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            GridView1.Caption=MySqlDbHelper.ExecuteScalar(
                "SELECT CONCAT('总库存:',cast(sum(库存)/1000 as char),'吨,件数:',cast(count(批号)as char),'件')" +
                "	FROM `slbz`.`二期原纸仓库即时库存`").ToString();

            GridView1.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * FROM `slbz`.`二期原纸仓库库存明细_分类`");
            GridView1.DataBind();
        }


        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, DivExport, "箱片库存分类", true);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}