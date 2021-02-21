using System;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinChaoDingdanRuku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || string.IsNullOrWhiteSpace(Session["username"].ToString()))
            {
                Session.Abandon();
                Response.Redirect("~/WebPage/Login/Login.aspx");
            }
            else
            {
                this.GridView1.Caption = "超订单入库";
                this.GridView1.DataSource = My.GetSqlTxt_Datatable("超订单入库明细");
                this.GridView1.DataBind();
            }

          
        }
    }
}