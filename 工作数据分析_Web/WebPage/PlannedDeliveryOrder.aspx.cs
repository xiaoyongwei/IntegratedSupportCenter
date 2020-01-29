using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebPage_PlannedDeliveryOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (DataRow item in MySqlDbHelper.ExecuteDataTable("SELECT `计划交期`FROM `slbz`.`订单_生产单`where `所属`='二期'group by `计划交期`ORDER BY `计划交期` DESC LIMIT 100").Rows)
        {
            DropDownList1.Items.Add(item[0].ToString());
        }
    }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string dateStr = DropDownList1.SelectedValue;
            DateTime dTime = new DateTime();
            if (DateTime.TryParse(dateStr, out dTime))
            {
                GridView1.DataSource = MySqlDbHelper.ExecuteDataTable(string.Format("CALL `slbz`.`二期计划交期订单`('{0}','{0}')", dateStr));
                GridView1.DataBind();
            }
            else
            {
                Response.Write("<script>alert('错误: 字符串不是正确的日期格式!');</script>");
            }
        }
}