using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.YuanZhi
{
    public partial class yuanzhi1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            if (!IsPostBack)
            {
                BindGrid();
            }
        }


        private void BindGrid()
        {
            string sqlStr = "SELECT * FROM `slbz`.`二期原纸仓库库存明细` ";

            GridView1.DataSource = MySqlDbHelper.ExecuteDataTable(sqlStr);
            GridView1.DataBind();


            //DataTable dt = MySqlDbHelper.ExecuteDataTable(sqlStr);

            //foreach (DataColumn column in dt.Columns)
            //{//Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名"

            //    BoundField bf = new BoundField();
            //    bf.DataField = column.ColumnName;
            //    bf.HeaderText = column.ColumnName;
            //    bf.DataFormatString = "{0}";
            //   // bf.Width = 100;
            //    Grid1.Columns.Add(bf);
            //}

            //Grid1.DataSource = dt;
            //Grid1.DataBind();
        }
        
        protected void ButtonRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            // 方法重写

        }
        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, GridView1, "原纸库存明细",true);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Attributes.Add("style", "vnd.ms-excel.numberformat:@");
            }
        }
    }
}