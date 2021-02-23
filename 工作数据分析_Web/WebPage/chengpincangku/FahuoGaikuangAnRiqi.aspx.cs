using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_FahuoGaikuangAnRiqi : System.Web.UI.Page
{

    private DataTable dt_huizong = new DataTable(); 
    private DataTable dt_mingxi = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {

        }
        else
        {
            this.TextBoxDateS.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            this.TextBoxDateE.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
        }
       
        Search();
    }

    private void Search()
    {
        string sqlTemplate = My.GetSqlTxt("发货明细");


        if (string.IsNullOrWhiteSpace(this.TextBoxDateS.Text))
        {
            this.TextBoxDateS.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.TextBoxDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        sqlTemplate=sqlTemplate.Replace("*开始时间*", TextBoxDateS.Text).Replace("*结束时间*", TextBoxDateE.Text);

        GridView1.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_" +
            "发货统计";
        dt_huizong =
         OracleHelper.ExecuteDataTable(
            "SELECT aa.业务归属,aa.送货类型,sum(箱片面积)送货面积,sum(金额)金额  from (" + sqlTemplate
            + ")aa  GROUP BY aa.业务归属,aa.送货类型 ORDER BY aa.业务归属,aa.送货类型");
        DataRow newRow=dt_huizong.NewRow();
        newRow["业务归属"] = "合计:";
        newRow["送货类型"] = "";
        newRow["送货面积"] = dt_huizong.Compute("Sum(送货面积)", "1=1");
        newRow["金额"] = dt_huizong.Compute("Sum(金额)", "1=1");
        dt_huizong.Rows.Add(newRow);
        GridView1.DataSource = dt_huizong;
        GridView1.DataBind();
        dt_huizong.TableName = "发货汇总";

        dt_mingxi= OracleHelper.ExecuteDataTable(sqlTemplate);
        GridView2.DataSource = dt_mingxi;
        GridView2.Caption = this.TextBoxDateS.Text + "到" + this.TextBoxDateE.Text + "_发货明细";
        GridView2.DataBind();
        dt_mingxi.TableName = "发货明细";

        Label1.Text = OracleHelper.ExecuteScalar(
            "select '库存:'||round(sum(面积))||'平方, '||round(sum(金额))||'元' from(select t.accamt as 金额,round(t.invnum * t.acreage) as 面积"
            + " from v_bcdt_ct t where t.objtyp = 'CL'   and t.orgcde = 'KS03'   and t.clientid = 'KS' group by t.objtyp,"
            + "t.orgcde, t.clntnme, t.serial, t.mkpcde, t.ptdate, t.shdate, t.clntcde, t.specs, t.clientid, t.prdnme, t.sitloc,"
            + "t.invnum, t.prices, t.accamt, t.acreage, t.crrcde, t.matcde, t.remark)aa").ToString();


        this.ButtonDownLoad.Enabled = this.TextBoxDateE.Text.Equals(this.TextBoxDateS.Text);
        this.ButtonDownLoad.Visible = this.Button1.Enabled;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Search();
    }

    protected void ButtonDownLoad_Click(object sender, EventArgs e)
    {
        string[] dateArray = this.TextBoxDateE.Text.Split('-');
        string strServerPath = Server.MapPath("~") + "/TmpDownFile/销售12部彩盒发货" +
            string.Format("{0}年{1}月{2}日",
            dateArray[0], dateArray[1], dateArray[2]) + ".xls";//待下载服务器文件路径
        ExcelHelper excel = new ExcelHelper(strServerPath);
        List<DataTable> dtList = new List<DataTable>();
        dtList.Add(dt_huizong);
        dtList.Add(dt_mingxi);
        excel.DataTableListToExcel(dtList);

        FileInfo f = new FileInfo(strServerPath);
        Response.Clear();
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(f.Name));
        Response.AddHeader("Content-Length", f.Length.ToString());
        Response.ContentType = "application/x-bittorrent";
        Response.WriteFile(f.FullName);
        // Response.End();
        ApplicationInstance.CompleteRequest();


       
    }
}