using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_wuliu_YunfeiJiesuanPingzheng : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Page.Title = "运费核对单";
            this.TextBox_time_S.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
            this.TextBox_time_E.Text = DateTime.Now.ToString("yyyy-MM-dd");
            foreach (DataRow row in MySqlDbHelper.ExecuteDataTable("SELECT `司机`FROM `slbz`.`物流_司机信息`").Rows)
            {
                this.DropDownListJiashiyuan.Items.Add(row[0].ToString());
            }
        }
        
        
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {

        

        //1.收集所有信息(根据实际和驾驶员)

        string sql = string.Format("SELECT (SELECT smpnme FROM v_dlv_fare WHERE v_dlv_fare.PONO = t.pono AND ORGCDE = 'KS03')客户名称"
        + ",(select round(nvl(sum(i.ratios * i.acreage * i.ACCNUMR), 0),2) from v_bcdx_ct i where i.clientid = t.clientid and i.orgcde = t.orgcde "
        + " and i.PONO = t.pono) as 装载平方,pono 送货单号, nvl(DISTANCE, 0) 里程,PAYCDE 结算单号 ,nvl(ANNAMT, 0) 附加费,AUDNME 结算人, DRIVER 司机"
        + ", LNCCDE 车牌, nvl(PLNCDE, pono) 装车单号,nvl(ACCAMT, 0) 运费,to_char(CREATED, 'yyyy-mm-dd') 日期,nvl(USMARK, ' ') 备注"
        + "  FROM EJSH.DLV_FARE t WHERE orgcde = 'KS03'AND DRIVER = '{0}'and to_char(ptdate, 'yyyy-mm-dd') >='{1}'"
        + "   and to_char(ptdate, 'yyyy-mm-dd') <='{2}' ORDER BY CREATED desc",DropDownListJiashiyuan.Text,TextBox_time_S.Text,TextBox_time_E.Text);

        DataTable dt = OracleHelper.ExecuteDataTable(sql);

        

        //2.收集装车单号
        List<string> PlncdeList = new List<string>();
        foreach (DataRow row in dt.Rows)
        {
            string plncde = row["装车单号"].ToString();
            if (PlncdeList.Contains(plncde))
            {
                continue;
            }
            else
            {
                PlncdeList.Add(plncde);
            }
            
        }
        //3.遍历收集到的装车单号
        foreach (string plncde in PlncdeList)
        {
            //4.添加自定义控件
            //声明一个自定义控件的实例
            WebUserControl_Yunfeidan yunfeidan =(WebUserControl_Yunfeidan) LoadControl("~/UserControl/Yunfeidan.ascx");
            yunfeidan.plncde = plncde;
            yunfeidan.dataTable = dt;
            PlaceHolder1.Controls.Add(yunfeidan);

        }
       

        


        
       



       
    }
}