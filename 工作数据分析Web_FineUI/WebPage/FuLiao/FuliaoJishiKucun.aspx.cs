using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.FuLiao
{
    public partial class FuliaoJishiKucun : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            GridView1.Caption = "辅料即时库存一览表";

            GridView1.DataSource = MySqlDbHelper.ExecuteDataTable("select * from `slbz`.`二期辅料仓库即时库存一览`;");
            GridView1.DataBind();
        }
    }
}