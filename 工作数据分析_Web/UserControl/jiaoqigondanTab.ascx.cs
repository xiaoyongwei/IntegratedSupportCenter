using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class jiaoqigondanTab : System.Web.UI.UserControl
{
    public string gdh = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelGongdan.Text = ID;
        LabelKehu.Text = OracleHelper.ExecuteScalar("select SMPNME from pb_clnt  where orgcde = 'KS03' and clntcde = (select clntcde FROM \"EJSH\".\"ORD_CT\" WHERE SERIAL='" + ID + "')").ToString();
        LabelMingcheng.Text = OracleHelper.ExecuteScalar("SELECT PRDNME FROM \"EJSH\".\"ORD_CT\"WHERE  SERIAL='" + ID + "'").ToString();
        LabelDingDan.Text= OracleHelper.ExecuteScalar("SELECT ACCNUM FROM \"EJSH\".\"ORD_CT\"WHERE  SERIAL='" + ID + "'").ToString();
        LabelMianji.Text= OracleHelper.ExecuteScalar("SELECT round(ACCNUM*ACREAGE) FROM \"EJSH\".\"ORD_CT\"WHERE  SERIAL='" + ID + "'").ToString();
        LabelRuku.Text= OracleHelper.ExecuteScalar("SELECT NVL(SUM(ACCNUML),0)FROM EJSH.V_BCDR WHERE OBJTYP='CL' AND SERIAL='" + ID + "'").ToString();

    }
}