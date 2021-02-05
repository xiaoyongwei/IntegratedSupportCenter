using FineUIPro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;
using BoundField = FineUIPro.BoundField;

namespace 工作数据分析Web_FineUI.YuanZhi
{
    public partial class yuanzhi1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sqlStr = "SELECT * FROM `slbz`.`二期原纸仓库库存明细` ";
            DataTable dt = MySqlDbHelper.ExecuteDataTable(sqlStr);
          
            foreach (DataColumn column in dt.Columns)
            {//Width="100px" DataField="Name" DataFormatString="{0}" HeaderText="姓名"

                BoundField bf = new BoundField();
                bf.DataField = column.ColumnName;
                bf.HeaderText = column.ColumnName;
                bf.DataFormatString = "{0}";
               // bf.Width = 100;
                Grid1.Columns.Add(bf);
            }

            Grid1.DataSource = dt;
            Grid1.DataBind();
        }


    }
}