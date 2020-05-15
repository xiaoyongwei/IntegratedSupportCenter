using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_K3Waigou : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonRestart_Click(object sender, EventArgs e)
    {
        this.TextBoxDjbh.Text = string.Empty;
        this.TextBoxFzsx.Text = string.Empty;
        this.TextBoxGgxh.Text = string.Empty;
        this.TextBoxPh.Text = string.Empty;
        this.TextBoxRiqi.Text = string.Empty;
        this.TextBoxSlck.Text = string.Empty;
        this.TextBoxWlmc.Text = string.Empty;
    }



    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("SELECT *FROM `slbz`.`金蝶_外购入库`where ");
        sb.AppendFormat("日期 like'%{0}%'", this.TextBoxPh.Text.Trim());
        sb.AppendFormat("单据编号 like'%{0}%'", this.TextBoxPh.Text.Trim());
        sb.AppendFormat("收料仓库 like'%{0}%'", this.TextBoxPh.Text.Trim());
        sb.AppendFormat("物料名称 like'%{0}%'", this.TextBoxPh.Text.Trim());
        sb.AppendFormat("批号 like'%{0}%'", this.TextBoxPh.Text.Trim());
        sb.AppendFormat("批号 like'%{0}%'", this.TextBoxPh.Text.Trim());
        sb.AppendFormat("批号 like'%{0}%'", this.TextBoxPh.Text.Trim());
        sb.Append("LIMIT 500; ");
    }
}