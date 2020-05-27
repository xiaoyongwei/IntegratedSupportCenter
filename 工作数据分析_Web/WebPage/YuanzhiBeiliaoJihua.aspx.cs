using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebPage_YuanzhiBeiliaoJihua : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = MySqlDbHelper.ExecuteDataSet("CALL `slbz`.`原纸备料计划1`();");
        ds = My.Dst_zero(ds);

        GridView1.DataSource = ds.Tables[1];
        GridView1.Caption = ds.Tables[0].Rows[0][0].ToString();
        GridView1.DataBind();

        GridView2.DataSource = ds.Tables[3];
        GridView2.Caption = ds.Tables[2].Rows[0][0].ToString();
        GridView2.DataBind();

        GridView3.DataSource = ds.Tables[5];
        GridView3.Caption = ds.Tables[4].Rows[0][0].ToString();
        GridView3.DataBind();

        GridView4.DataSource = ds.Tables[7];
        GridView4.Caption = ds.Tables[6].Rows[0][0].ToString();
        GridView4.DataBind();

        //ds = MySqlDbHelper.ExecuteDataSet("CALL `slbz`.`原纸备料计划`('B');");
        //ds = My.Dst_zero(ds);

        //GridView5.DataSource = ds.Tables[1];
        //GridView5.Caption = ds.Tables[0].Rows[0][0].ToString();
        //GridView5.DataBind();

        //GridView6.DataSource = ds.Tables[3];
        //GridView6.Caption = ds.Tables[2].Rows[0][0].ToString();
        //GridView6.DataBind();

        //GridView7.DataSource = ds.Tables[5];
        //GridView7.Caption = ds.Tables[4].Rows[0][0].ToString();
        //GridView7.DataBind();

        //GridView8.DataSource = ds.Tables[7];
        //GridView8.Caption = ds.Tables[6].Rows[0][0].ToString();
        //GridView8.DataBind();
    }
}