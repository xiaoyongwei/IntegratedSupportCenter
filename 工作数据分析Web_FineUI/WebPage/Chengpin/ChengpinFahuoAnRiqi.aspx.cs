using FineUIPro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Chengpin
{
    public partial class ChengpinFahuoAnRiqi : System.Web.UI.Page
    {
        private DataTable dt_huizong = new DataTable();
        private DataTable dt_mingxi = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (My.IsSession(Session, Response))
            {
                if (Page.IsPostBack)
                {
                   
                }
                else
                {
                    this.DatePickerStart.SelectedDate = DateTime.Now;
                    this.DatePickerEnd.SelectedDate = DateTime.Now;
                    Search();
                }

               
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        private void Search()
        {
            string sqlTemplate = My.GetSqlString("发货明细");

            if (string.IsNullOrWhiteSpace(this.DatePickerStart.Text))
            {
                this.DatePickerStart.Text = DateTime.Now.ToString("yyyy-MM-dd");
                this.DatePickerEnd.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }

            sqlTemplate = sqlTemplate.Replace("*开始时间*", DatePickerStart.Text).Replace("*结束时间*", DatePickerEnd.Text);

            GridView1.Caption = this.DatePickerStart.Text + "到" + this.DatePickerEnd.Text + "_" +
                "发货统计";
            dt_huizong =
             OracleHelper.ExecuteDataTable(
                "SELECT aa.业务归属,aa.送货类型,round(sum(箱片面积))送货面积,round(sum(金额))金额  from (" + sqlTemplate
                + ")aa  GROUP BY aa.业务归属,aa.送货类型 ORDER BY aa.业务归属,aa.送货类型");
            if (dt_huizong.Rows.Count>0)
            {
                DataRow newRow = dt_huizong.NewRow();
                newRow["业务归属"] = "合计:";
                newRow["送货类型"] = "";
                newRow["送货面积"] = dt_huizong.Compute("Sum(送货面积)", "1=1");
                newRow["金额"] = dt_huizong.Compute("Sum(金额)", "1=1");
                dt_huizong.Rows.Add(newRow);


               


                //只有开始时间和结束时间同一个月份才累计送货金额并且合并单元格
                if (DatePickerStart.Text.Substring(0,7).Equals(DatePickerEnd.Text.Substring(0, 7)))
                {
                    string[] dateArray = this.DatePickerEnd.Text.Split('-');
                    DataTable tableLeiji = OracleHelper.ExecuteDataTable(string.Format("select round(sum(case t.ordtyp when 'CB' then round(nvl(t.pacreage,0),4) * t.ACCNUMR  " +
                       "else round(nvl(t.acreage,0),4) * t.ACCNUMR end) ) 平方,round(sum(case t.ordtyp when 'CB' then round((t.ctinprice*round(t.pacreage,4) * t.ACCNUMR +" +
                       " nvl(t.dlvamt,0) + nvl(t.annamt,0) ),2)  else round(t.prices * t.accnumr,2) end ) ) 金额 from v_bcdx_ct t where t.objtyp='DL' and t.invtyp ='XD' " +
                       "and t.orgcde='KS03' and t.clientid='KS' and t.ordtyp='CL' and to_char(ptdate,'yyyy-MM-dd') >= '{0}-{1}-00'  and to_char(ptdate,'yyyy-MM-dd') <= '{0}-{1}-99'",
                       dateArray[0], dateArray[1]));
                    if (tableLeiji.Rows.Count > 0 && tableLeiji.Columns.Count > 1)
                    {
                        dt_huizong.Columns.Add("本月累计送货面积");
                        dt_huizong.Columns.Add("本月累计送货金额");
                    

                        dt_huizong.Rows[0]["本月累计送货面积"] = tableLeiji.Rows[0]["平方"].ToString();
                        dt_huizong.Rows[0]["本月累计送货金额"]=tableLeiji.Rows[0]["金额"].ToString();
                        
                    }
                }

                GridView1.DataSource = dt_huizong;
                GridView1.DataBind();
                dt_huizong.TableName = "发货汇总";

                //如果存在累计类,则合并单元格并且居中对齐
                if (dt_huizong.Columns.IndexOf("本月累计送货面积")>-1&& dt_huizong.Columns.IndexOf("本月累计送货金额") > -1)
                {
                    //合并单元格
                    GridView1.Rows[0].Cells[dt_huizong.Columns["本月累计送货面积"].Ordinal].RowSpan = GridView1.Rows.Count;
                    GridView1.Rows[0].Cells[dt_huizong.Columns["本月累计送货金额"].Ordinal].RowSpan = GridView1.Rows.Count;
                    GridView1.Rows[0].Cells[dt_huizong.Columns["本月累计送货面积"].Ordinal].VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Middle;
                    GridView1.Rows[0].Cells[dt_huizong.Columns["本月累计送货金额"].Ordinal].VerticalAlign = System.Web.UI.WebControls.VerticalAlign.Middle;
                    GridView1.Rows[0].Cells[dt_huizong.Columns["本月累计送货面积"].Ordinal].HorizontalAlign = HorizontalAlign.Center;
                    GridView1.Rows[0].Cells[dt_huizong.Columns["本月累计送货金额"].Ordinal].HorizontalAlign = HorizontalAlign.Center;
                    ////删除多余列
                    //GridView1.Columns.RemoveAt(GridView1.Columns.Count - 1);
                    //GridView1.Columns.RemoveAt(GridView1.Columns.Count - 1);
                }



                dt_mingxi = OracleHelper.ExecuteDataTable(sqlTemplate);
                GridView2.DataSource = dt_mingxi;
                GridView2.Caption = this.DatePickerStart.Text + "到" + this.DatePickerEnd.Text + "_发货明细";
                GridView2.DataBind();
                dt_mingxi.TableName = "发货明细";


                LabelKucun.Text = OracleHelper.ExecuteScalar(
                "select '库存面积:'||round(sum(面积))||'平方,库存金额:'||round(sum(金额))||'元' from(select t.accamt as 金额,round(t.invnum * t.acreage) as 面积"
                + " from v_bcdt_ct t where t.objtyp = 'CL'   and t.orgcde = 'KS03'   and t.clientid = 'KS' group by t.objtyp,"
                + "t.orgcde, t.clntnme, t.serial, t.mkpcde, t.ptdate, t.shdate, t.clntcde, t.specs, t.clientid, t.prdnme, t.sitloc,"
                + "t.invnum, t.prices, t.accamt, t.acreage, t.crrcde, t.matcde, t.remark)aa").ToString();
            }
            

            //this.LabelLeijiFahuo.Text = OracleHelper.ExecuteScalar(string.Format("select '{0}年{1}月累计发货:'||round(sum(case t.ordtyp when 'CB' then " +
            //    " round(nvl(t.pacreage,0),4) * t.ACCNUMR  else round(nvl(t.acreage,0),4) * t.ACCNUMR end) )  ||'平方,'||round(sum(case t.ordtyp  " +
            //    " when 'CB' then round((t.ctinprice*round(t.pacreage,4) * t.ACCNUMR + nvl(t.dlvamt,0) + nvl(t.annamt,0) ),2)  else round(t.prices * t.accnumr,2) end ) )" +
            //    "||'元。'from v_bcdx_ct t where t.objtyp='DL' and t.invtyp ='XD' and t.orgcde='KS03' and t.clientid='KS' and t.ordtyp='CL'  " +
            //    "and to_char(ptdate,'yyyy-MM-dd') >= '{0}-{1}-00'  and to_char(ptdate,'yyyy-MM-dd') <= '{0}-{1}-99'",dateArray[0],dateArray[1])).ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DatePickerEnd.SelectedDate<DatePickerStart.SelectedDate)
            {
                Alert alert = new Alert();
                alert.Message = "开始就不能大于结束时间";
                alert.Title = "错误";
                alert.MessageBoxIcon = MessageBoxIcon.Error;
                alert.Target = Target.Top;
                alert.Show();
            }
            else
            {
                Search();
            }
            
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, DivExport, "发货数据" + this.DatePickerStart.Text + "_" + this.DatePickerEnd.Text);
        }

        
    }
}