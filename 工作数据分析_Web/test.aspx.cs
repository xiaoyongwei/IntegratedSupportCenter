using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //DataTable dt = new DataTable("SELECT `日期`,`入库面积`FROM `slbz`.`二期成品仓库近30天入库平方`");

        //Chart1.Series.Clear();
        //Series series = new Series();
        //List<string> dateList = new List<string>();
        //List<string> areaList = new List<string>();
        //foreach (DataRow dr in dt.Rows)
        //{
        //    dateList.Add(dr["日期"].ToString());
        //    dateList.Add(dr["入库面积"].ToString());
        //}
        //series.Points.DataBindXY(dateList, areaList);

        //Chart1.Series.Add(series);


        DataTable dt = MySqlDbHelper.ExecuteDataTable("SELECT `日期`,`入库面积`FROM `slbz`.`二期成品仓库近30天入库平方`");

       
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