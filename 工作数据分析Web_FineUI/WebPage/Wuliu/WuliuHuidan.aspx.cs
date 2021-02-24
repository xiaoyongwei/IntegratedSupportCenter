using FineUIPro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 工作数据分析Web_FineUI.WebPage.Wuliu
{
    public partial class WuliuHuidan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

                ddlPageSize.SelectedValue = Grid1.PageSize.ToString();
            }
        }

        #region LoadData

        private void BindGrid()
        {
            // 1.设置总项数
            Grid1.RecordCount = GetTotalCount();

            // 2.获取当前分页数据
            DataTable table = GetPagedDataTable(Grid1.PageIndex, Grid1.PageSize);

            // 3.绑定到Grid
            Grid1.DataSource = table;
            Grid1.DataBind();
        }

        /// <summary>
        /// 模拟返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return 0;// DataSourceUtil.GetDataTable2().Rows.Count;
        }

        /// <summary>
        /// 模拟数据库分页（实际项目中请直接使用SQL语句返回分页数据！）
        /// </summary>
        /// <returns></returns>
        private DataTable GetPagedDataTable(int pageIndex, int pageSize)
        {
            DataTable source = new DataTable();// DataSourceUtil.GetDataTable2();

            DataTable paged = source.Clone();

            int rowbegin = pageIndex * pageSize;
            int rowend = (pageIndex + 1) * pageSize;
            if (rowend > source.Rows.Count)
            {
                rowend = source.Rows.Count;
            }

            for (int i = rowbegin; i < rowend; i++)
            {
                paged.ImportRow(source.Rows[i]);
            }

            return paged;
        }

        #endregion

        #region Events

        protected void Button1_Click(object sender, EventArgs e)
        {
            labResult.Text = "";// HowManyRowsAreSelected(Grid1);
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            //Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grid1.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);


            BindGrid();
        }

        #endregion
    }
}