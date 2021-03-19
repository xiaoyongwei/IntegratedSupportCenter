using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinRukuAnRiqi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);


            if (Page.IsPostBack)
            {

            }
            else
            {
                this.DatePickerS.SelectedDate= DateTime.Now.AddDays(-3);
                this.DatePickerEnd.SelectedDate = DateTime.Now;
                //this.TextBoxDateS.Text = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd");
                //this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            Search();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
        private void Search()
        {
            string sqlTemplate = My.GetSqlString("入库明细2");


            //if (string.IsNullOrWhiteSpace(this.TextBoxDateS.Text))
            //{
            //    this.TextBoxDateS.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //    this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
            //}

            //sqlTemplate = sqlTemplate.Replace("*开始时间*", TextBoxDateS.Text).Replace("*结束时间*", TextBoxDateE.Text);


            //GridView1.DataSource = OracleHelper.ExecuteDataTable(
            //    "select nvl(a.入库类型,'总计:')总计,sum(a.总面积)面积,sum(a.金额)金额 from(" + sqlTemplate
            //    + ")a group by rollup( a.入库类型)");
            //GridView1.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_入库概况";
            //GridView1.DataBind();

            //GridView2.DataSource = OracleHelper.ExecuteDataTable(sqlTemplate);
            //GridView2.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_入库明细";
            //GridView2.DataBind();


            sqlTemplate = sqlTemplate.Replace("*开始时间*", this.DatePickerS.Text).Replace("*结束时间*", DatePickerEnd.Text);


            GridView1.DataSource = OracleHelper.ExecuteDataTable(
                "select nvl(a.入库类型,'总计:')总计,sum(a.总面积)面积,sum(a.金额)金额 from(" + sqlTemplate
                + ")a group by rollup( a.入库类型)");
            GridView1.Caption = this.DatePickerS.Text + "到" + this.DatePickerEnd.Text + "_入库概况";
            GridView1.DataBind();

            GridView2.DataSource = OracleHelper.ExecuteDataTable(sqlTemplate);
            GridView2.Caption = this.DatePickerS.Text + "到" + this.DatePickerEnd.Text + "_入库明细";
            GridView2.DataBind();



            Label1.Text = OracleHelper.ExecuteScalar(
            "select '库存:'||round(sum(面积))||'平方, '||round(sum(金额))||'元' from(select t.accamt as 金额,round(t.invnum * t.acreage) as 面积"
            + " from v_bcdt_ct t where t.objtyp = 'CL'   and t.orgcde = 'KS03'   and t.clientid = 'KS' group by t.objtyp,"
            + "t.orgcde, t.clntnme, t.serial, t.mkpcde, t.ptdate, t.shdate, t.clntcde, t.specs, t.clientid, t.prdnme, t.sitloc,"
            + "t.invnum, t.prices, t.accamt, t.acreage, t.crrcde, t.matcde, t.remark)aa").ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, divExport, "入库数据" + this.DatePickerS.Text + "_" + this.DatePickerEnd.Text);
        }
    }
}