using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_wuliu_YunfeiJiesuanPingzheng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.TextBox_time_S.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
        this.TextBox_time_E.Text = DateTime.Now.ToString("yyyy-MM-dd");
        this.DropDownListJiashiyuan.Items.Add("霍红海");
        this.DropDownListJiashiyuan.Items.Add("郑二毛");
        this.DropDownListJiashiyuan.Items.Add("郑荷伟");
        this.DropDownListJiashiyuan.Items.Add("周晓军");
        this.DropDownListJiashiyuan.Items.Add("杨冬冬");
        this.DropDownListJiashiyuan.Items.Add("娄绍勇");
        this.DropDownListJiashiyuan.Items.Add("郑华东");
        this.DropDownListJiashiyuan.Items.Add("陶明凯");
        this.DropDownListJiashiyuan.Items.Add("董美枝");
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        
    }
}