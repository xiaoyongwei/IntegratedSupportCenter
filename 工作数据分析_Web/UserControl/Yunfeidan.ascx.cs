using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_wuliu_WebUserControl_Yunfeidan : System.Web.UI.UserControl
{

    /// <summary>
    /// 装车单号
    /// </summary>
    public string zcdh = "";
    /// <summary>
    /// 送货单集合
    /// </summary>
    public List<string> ponoList = new List<string>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(zcdh))
        {

            this.LabelZhuangchedanhao.Text = zcdh;
        }
    }
}