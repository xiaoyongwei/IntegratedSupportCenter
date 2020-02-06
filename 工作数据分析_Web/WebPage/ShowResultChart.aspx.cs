using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class WebPage_ShowResultChart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = MySqlDbHelper.ExecuteDataTable("SELECT `日期`,`入库面积`FROM `slbz`.`二期成品仓库近7天入库平方`");
        //表格
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //图标-柱状图
        List<string> dateList = new List<string>();
        List<double> areaList = new List<double>();
        foreach (DataRow dr in dt.Rows)
        {
            dateList.Add(dr["日期"].ToString());
            areaList.Add(Math.Round(Convert.ToDouble(dr["入库面积"])));
        }
        dateList.Reverse();
        areaList.Reverse();
        Chart1.Series[0].Points.DataBindXY(dateList, areaList); 
    }
}