using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Label1.Text = "金蝶、易捷数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`	FROM `slbz`.`settingall`	where `Key`='LastGetTime'").ToString()
                + " , 制版线数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `结束时间`FROM `slbz`.`瓦片完成情况`ORDER BY `结束时间` DESC LIMIT 1").ToString();
   
    
    
    
    }
    protected void NavigationMenu_MenuItemClick(object sender, MenuEventArgs e)
    {
        
    }
}
