using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_ShowCurrentZhibanxian : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {          
            InitShowData();
    }

    private void InitShowData()
    {
        GridView1800.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`瓦片当前排程` where 生产线='制版线1800' ORDER by 序号");
        GridView1800.DataBind();

        GridView2200.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`瓦片当前排程` where 生产线='制版线2200' ORDER by 序号");
        GridView2200.DataBind();

        GridView2500.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT *FROM  `slbz`.`瓦片当前排程` where 生产线='制版线2500' ORDER by 序号");
        GridView2500.DataBind();

        GridViewPublished.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `工单号`,`客户名`,`楞型`,`材质`,`数量`,`长度`,`宽度`, "
            + "date_format(`结束时间`, '%Y-%m-%d %H:%i:%s')'结束时间',`备注`,`瓦片线`FROM `slbz`.`瓦片完成情况`"
            + " WHERE date_format(`结束时间`, '%Y-%m-%d') BETWEEN date_format(date_add(now(), interval - 1 day), '%Y-%m-%d') AND date_format(now(), '%Y-%m-%d')"
            + " AND 工单号 LIKE 'C2%'ORDER  BY  `结束时间` desc");
        GridViewPublished.DataBind();


        foreach (GridViewRow row in GridView1800.Rows)
        {
            if (Regex.IsMatch(row.Cells[0].Text, "^C\\d+", RegexOptions.IgnoreCase))
            {
                row.BackColor = Color.Yellow;
            }
        }
        foreach (GridViewRow row in GridView2200.Rows)
        {
            if (Regex.IsMatch(row.Cells[0].Text, "^C\\d+", RegexOptions.IgnoreCase))
            {
                row.BackColor = Color.Yellow;
            }
        }
        foreach (GridViewRow row in GridView2500.Rows)
        {
            if (Regex.IsMatch(row.Cells[0].Text, "^C\\d+", RegexOptions.IgnoreCase))
            {
                row.BackColor = Color.Yellow;
            }
        }
        this.Lable1.Text = "数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`FROM `slbz`.`settingall`where `key`='制版线当前排程更新时间'");
    }

}