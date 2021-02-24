using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinJiaohuoChaoqiKaohe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string rukuDatetime = DatePicker1.SelectedDate.Value.AddDays(-2).ToString("yyyy-MM-dd");
            string jiaoqiDatetime = DatePicker1.SelectedDate.Value.AddDays(-7).ToString("yyyy-MM-dd");

            GridView1.Caption = "二期彩盒库存交货超期明细(截止" + DatePicker1.Text + ")";
            GridView1.DataSource = OracleHelper.ExecuteDataTable(
                My.GetSqlString("交货超期考核").Replace("*入库时间点*", rukuDatetime)
                .Replace("*交期时间点*", jiaoqiDatetime));
            GridView1.DataBind();
        }
    }
}