using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.WebPage.Xiangpian
{
    public partial class XiangpianDangqianPaicheng : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            if (!IsPostBack)
            {
                ButtonShowCaihe.OnClientClick = Window1.GetShowReference("~/WebPage/Xiangpian/XiangpianDangqianPaichengCaihe.aspx", "彩盒排程");
                ButtonShowAll.OnClientClick = Window1.GetShowReference("~/WebPage/Xiangpian/XiangpianDangqianPaichengAll.aspx", "全部排程");

            }


            InitShowData();
        }
        private void InitShowData()
        {
            GridView1800.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `订单号`,`客户`,`楞型`,`订单数`,`宽度`,`长度`,`材质`,`门幅`,`序号`,`备注` FROM  `slbz`.`瓦片当前排程` where 生产线='制版线1800' ORDER by 序号");
            GridView1800.Caption = "制版线1800E-还剩" + MySqlDbHelper.ExecuteScalar("SELECT ifnull(round(sum(订单数*宽度*长度/1000000),0),0)FROM `slbz`.`瓦片当前排程` where 订单号 like'C2%' and 生产线='制版线1800'").ToString()
                + "平方";
            GridView1800.DataBind();

            GridView1800F.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `订单号`,`客户`,`楞型`,`订单数`,`宽度`,`长度`,`材质`,`门幅`,`序号`,`备注` FROM  `slbz`.`瓦片当前排程` where 生产线='制版线1800F' ORDER by 序号");
            GridView1800F.Caption = "制版线1800F-还剩" + MySqlDbHelper.ExecuteScalar("SELECT ifnull(round(sum(订单数*宽度*长度/1000000),0),0)FROM `slbz`.`瓦片当前排程` where 订单号 like'C2%' and 生产线='制版线1800F'").ToString()
                + "平方";
            GridView1800F.DataBind();

            GridView2200.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `订单号`,`客户`,`楞型`,`订单数`,`宽度`,`长度`,`材质`,`门幅`,`序号`,`备注` FROM  `slbz`.`瓦片当前排程` where 生产线='制版线2200' ORDER by 序号");
            GridView2200.Caption = "制版线2200-还剩" + MySqlDbHelper.ExecuteScalar("SELECT ifnull(round(sum(订单数*宽度*长度/1000000),0),0)FROM `slbz`.`瓦片当前排程` where 订单号 like'C2%' and 生产线='制版线2200'").ToString()
                + "平方";
            GridView2200.DataBind();

            GridView2500.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `订单号`,`客户`,`楞型`,`订单数`,`宽度`,`长度`,`材质`,`门幅`,`序号`,`备注` FROM  `slbz`.`瓦片当前排程` where 生产线='制版线2500' ORDER by 序号");
            GridView2500.Caption = "制版线2500-还剩" + MySqlDbHelper.ExecuteScalar("SELECT ifnull(round(sum(订单数*宽度*长度/1000000),0),0)FROM `slbz`.`瓦片当前排程` where 订单号 like'C2%' and 生产线='制版线2500'").ToString()
                + "平方";
            GridView2500.DataBind();

            GridViewPublished.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT `工单号`,`客户名`,`楞型`,`材质`,`数量`,`长度`,`宽度`, "
                + "date_format(`结束时间`, '%Y-%m-%d %H:%i:%s')'结束时间',`备注`,`瓦片线`FROM `slbz`.`瓦片完成情况`"
                + " WHERE date_format(`结束时间`, '%Y-%m-%d') BETWEEN date_format(date_add(now(), interval - 1 day), '%Y-%m-%d') AND date_format(now(), '%Y-%m-%d')"
                + " AND 工单号 LIKE 'C2%'ORDER  BY  `结束时间` desc");
            GridViewPublished.DataBind();


            foreach (GridViewRow row in GridView1800.Rows)
            {
                if (Regex.IsMatch(row.Cells[0].Text, "^C\\d+", RegexOptions.IgnoreCase))
                {
                    row.BackColor = Color.Yellow;
                }
            }

            foreach (GridViewRow row in GridView1800F.Rows)
            {
                if (Regex.IsMatch(row.Cells[0].Text, "^C\\d+", RegexOptions.IgnoreCase))
                {
                    row.BackColor = Color.Yellow;
                }
            }

            foreach (GridViewRow row in GridView2200.Rows)
            {
                if (Regex.IsMatch(row.Cells[0].Text, "^C\\d+", RegexOptions.IgnoreCase))
                {
                    row.BackColor = Color.Yellow;
                }
            }
            foreach (GridViewRow row in GridView2500.Rows)
            {
                if (Regex.IsMatch(row.Cells[0].Text, "^C\\d+", RegexOptions.IgnoreCase))
                {
                    row.BackColor = Color.Yellow;
                }
            }
            this.Lable1.Text = "数据更新时间:" + App_Code.MySqlDbHelper.ExecuteScalar("SELECT `Value`FROM `slbz`.`settingall`where `key`='制版线当前排程更新时间'")
                +",未排面积:"+My.GetSqlTxt_Datatable("箱片未排面积").Rows[0][0].ToString()
                +"平方,已排未完成:"+ MySqlDbHelper .ExecuteScalar(
                    "SELECT ifnull(round(sum(订单数*宽度*长度/1000000),0),0)FROM `slbz`.`瓦片当前排程` where 订单号 like'C2%'").ToString()
                    + "平方.";
        }


        protected void Timer1_Tick(object sender, EventArgs e)
        {
            InitShowData();
        }
    }
}