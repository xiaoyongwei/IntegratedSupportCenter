using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebPage_ErqiFuliao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.TextBox_S.Text = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
        this.TextBox_E.Text = DateTime.Now.ToString("yyyy-MM-dd");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sqlstr = "SELECT *	FROM `slbz`.`金蝶_生产领料` where 日期 between "
                + "'" + TextBox_S.Text.Trim() + "' and '" + TextBox_E.Text.Trim() + "';";
        DataTable dt_mingxi = MySqlDbHelper.ExecuteDataTable(sqlstr);
        GridView1.DataSource = dt_mingxi;
        GridView1.DataBind();
        //每个物料的单价为:金蝶里面加权平均法的每个物料的单价
        //应该在数据库中建立个表用于存放这类数据
        sqlstr = "select 领料部门,sum(加权平均单价 * 实发数量)from ("
        + "SELECT *,(select `单价`from 金蝶_物料加权平均单价"
        + " where `slbz`.`金蝶_生产领料`.`物料长代码` = `金蝶_物料加权平均单价`.`物料长代码`) '加权平均单价'"
        + "FROM `slbz`.`金蝶_生产领料`where 日期 between '" + TextBox_S.Text.Trim()
        + "' and '" + TextBox_E.Text.Trim() + "')aa";
        DataTable dt_huizong = MySqlDbHelper.ExecuteDataTable(sqlstr);
        GridView2.DataSource = dt_huizong;
        GridView2.DataBind();
    }
}