using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WebPage_ChengpinCangku : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //大于180天内
        //90-180天
        //60-90天
        //30-60天
        //小于30天
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        short tryInt = -1;
        if (!Int16.TryParse(TextBoxTianshu_S.Text, out tryInt)||
            !Int16.TryParse(TextBoxTianshu_E.Text, out tryInt))
        {
            Response.Write("<script language=javascript >alert('输入错误！');</Script>");
            return;
        }
        
        PanelShowData.Controls.Clear();
        DataTable dt = new DataTable();
        dt = MySqlDbHelper.ExecuteDataTable(string.Format(
            "SELECT 业务员,sum(`面积`)'面积' FROM `slbz`.`成品_库存明细`where 天数 between {0} and {1} group by 业务员"
    + " union select '合计',sum(`面积`)FROM `slbz`.`成品_库存明细`where 天数 between {0} and {1}"
            , Convert.ToInt16(TextBoxTianshu_S.Text), Convert.ToInt16(TextBoxTianshu_E.Text)));
        GridView gv_0 = new GridView();
        gv_0.DataSource = dt;
        gv_0.DataBind();
        PanelShowData.Controls.Add(gv_0);
        if (dt.Rows.Count>0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                GridView gv = new GridView();
                string whereStr=string.Format("(天数 between {0} and {1} )and(业务员='{2}')"
                    , Convert.ToInt16(TextBoxTianshu_S.Text), Convert.ToInt16(TextBoxTianshu_E.Text), dr["业务员"]);

                gv.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `仓库`,`生产单号`,`客户`,`名称`,`规格`,`天数`,`数量`,`备注`"
                    +"FROM `slbz`.`成品_库存明细`where "+whereStr);
                gv.DataBind();
                gv.Caption = string.Format("{0}的库存明细({1}天-{2}天)-合计:{3}平方"
                    , dr["业务员"], TextBoxTianshu_S.Text, TextBoxTianshu_E.Text,
                    MySqlDbHelper.ExecuteScalar("SELECT sum(`面积`)FROM `slbz`.`成品_库存明细`where "+whereStr)
                    );
                PanelShowData.Controls.Add(gv);
                Label la = new Label();
                la.Text = " <br/>";
                PanelShowData.Controls.Add(la);
            }
        }
    }
}