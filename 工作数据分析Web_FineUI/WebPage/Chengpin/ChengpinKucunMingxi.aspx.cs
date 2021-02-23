using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.Chengpin
{
    public partial class ChengpinKucunMingxi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            GridView1.Caption = "彩盒库存明细";

            this.GridView1.DataSource = My.GetSqlTxt_Datatable("彩盒库存明细");
            this.GridView1.DataBind();

            Label1.Text = OracleHelper.ExecuteScalar(
            "select '库存:'||round(sum(面积))||'平方, '||round(sum(金额))||'元' from(select t.accamt as 金额,round(t.invnum * t.acreage) as 面积"
            + " from v_bcdt_ct t where t.objtyp = 'CL'   and t.orgcde = 'KS03'   and t.clientid = 'KS' group by t.objtyp,"
            + "t.orgcde, t.clntnme, t.serial, t.mkpcde, t.ptdate, t.shdate, t.clntcde, t.specs, t.clientid, t.prdnme, t.sitloc,"
            + "t.invnum, t.prices, t.accamt, t.acreage, t.crrcde, t.matcde, t.remark)aa").ToString();
        }
    }
}