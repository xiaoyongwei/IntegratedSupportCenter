using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Xiangpian
{
    public partial class XiangpianDangqianKucun1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable table = My.GetSqlTxt_Datatable("纸板库存情况");
            //只保留库区,工单,客户3个列
            string[] columnArray = { "库区", "生产单号", "客户" };

            for (int i = table.Columns.Count - 1; i >= 0; i--)
            {
                if (!columnArray.Contains(table.Columns[i].ColumnName))
                {
                    table.Columns.RemoveAt(i);
                }
            }

            if (table.Rows.Count > 40)
            {
                this.GridView1.DataSource = 
                    table.AsEnumerable().Take(Convert.ToInt32(Math.Ceiling(table.Rows.Count / 2.0))).CopyToDataTable();
                this.GridView1.DataBind();

                this.GridView2.DataSource = 
                    table.AsEnumerable().Skip(Convert.ToInt32(Math.Ceiling(table.Rows.Count / 2.0))).CopyToDataTable();
                this.GridView2.DataBind();
            }
            else
            {
                this.GridView1.DataSource = table;
                this.GridView1.DataBind();
            }
            table.Dispose();
        }

        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, DivExport, "箱片库存明细", true);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}