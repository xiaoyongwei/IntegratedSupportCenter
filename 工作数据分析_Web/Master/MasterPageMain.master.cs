using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Master_MasterPageMain : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

        }
        else
        {
            Menu1.Items.Clear();
            MenuItem mi_cpck = new MenuItem();
            mi_cpck.Text = "成品仓库";
            MenuItem mi_cpck_chkcmx = new MenuItem();
            mi_cpck_chkcmx.Text = "彩盒库存明细";
            mi_cpck.ChildItems.Add(mi_cpck_chkcmx);
            MenuItem mi_cpck_rkqkarq = new MenuItem();
            mi_cpck_rkqkarq.Text = "入库情况(按日期)";
            mi_cpck.ChildItems.Add(mi_cpck_rkqkarq);
        }
    }
}
