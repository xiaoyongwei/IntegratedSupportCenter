using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.FuLiao
{
    public partial class K3WaigouRuku : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);
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
            sb.Append("SELECT cast(`日期`as char)'日期',`单据编号`,`供应商`,`物料长代码`,`物料名称`,`规格型号`,`辅助属性`");
            sb.Append(",`批号`,`基本单位`,`实收数量`,`辅助单位`,`辅助数量`,`含税单价`,`含税金额`,`收料仓库`,`备注`");
            sb.Append(" FROM `slbz`.`金蝶_外购入库`where ");
            sb.AppendFormat("日期 like'%{0}%' and ", this.TextBoxRiqi.Text.Trim());
            sb.AppendFormat("单据编号 like'%{0}%' and ", this.TextBoxDjbh.Text.Trim());
            sb.AppendFormat("收料仓库 like'%{0}%' and ", this.TextBoxSlck.Text.Trim());
            sb.AppendFormat("物料名称 like'%{0}%' and ", this.TextBoxWlmc.Text.Trim());
            sb.AppendFormat("批号 like'%{0}%' and ", this.TextBoxPh.Text.Trim());
            sb.AppendFormat("规格型号 like'%{0}%' and ", this.TextBoxGgxh.Text.Trim());
            sb.AppendFormat("辅助属性 like'%{0}%'", this.TextBoxFzsx.Text.Trim());
            sb.Append(" order by `日期` desc LIMIT 500; ");

            GridView.DataSource = MySqlDbHelper.ExecuteDataTable(sb.ToString());
            GridView.DataBind();
        }
    }
}