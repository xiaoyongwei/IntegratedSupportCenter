using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_WebPageSpace : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void buttonComplete_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        string sqlstr = 
            "UPDATE `slbz`.`订单_生产单`	SET `完工` = 1	WHERE 生产单号='"+ button.ID + "';";
        
    }
    
}