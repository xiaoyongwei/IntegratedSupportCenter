using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebPage_erqiCaiheKucunQingkuang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = GetSqlTxt_Datatable("彩盒库存明细");

        //    开始添加到sql中
        List<string> sqlList = new List<string>();

        StringBuilder sb_Insert = new StringBuilder(" INSERT  INTO `slbz`.`二期彩盒库存明细`(");
        foreach (DataColumn dc in dt.Columns)//添加列
        {
            sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
        }
        sb_Insert.Remove(sb_Insert.Length - 1, 1);
        sb_Insert.AppendLine(")VALUES");
        StringBuilder sb_values = new StringBuilder("(");
        foreach (DataRow dr in dt.Rows)
        {
            sb_values = new StringBuilder("(");
            foreach (DataColumn dc in dt.Columns)
            {
                sb_values.AppendFormat("'{0}',", dr[dc].ToString());
            }
            sb_values.Remove(sb_values.Length - 1, 1);
            sb_values.AppendLine(");");
            sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
        }
        if (sqlList.Count > 0)
        {
            sqlList.Insert(0, "truncate table `slbz`.`二期彩盒库存明细`;");
        }


        if (MySqlDbHelper.ExecuteSqlTran(sqlList))
        {
            //开始分配
            LabelGenxinShijian.Text = "未发货彩盒库存,统计时间为:" + DateTime.Now.ToString("yyyy年MM月dd日HH时");
            #region 第1版
            // GridView1_0_7.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='00-07天' and 业务归属='一期' group by 客户 ,业务员)"
            // + "union"
            // + "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '00-07天' and 业务归属 = '一期'))a ORDER BY 面积");
            // GridView1_0_7.DataBind();
            // GridView1_8_14.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='08-14天' and 业务归属='一期' group by 客户 ,业务员)"
            //+ "union"
            //+ "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '08-14天' and 业务归属 = '一期'))a ORDER BY 面积");
            // GridView1_8_14.DataBind();
            // GridView1_15_30.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='15-30天' and 业务归属='一期' group by 客户 ,业务员)"
            //+ "union"
            //+ "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '15-30天' and 业务归属 = '一期'))a ORDER BY 面积");
            // GridView1_15_30.DataBind();
            // GridView1_31jiyishang.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='31天及以上' and 业务归属='一期' group by 客户 ,业务员)"
            //+ "union"
            //+ "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '31天及以上' and 业务归属 = '一期'))a ORDER BY 面积");
            // GridView1_31jiyishang.DataBind();





            // GridView2_0_7.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='00-07天' and 业务归属='二期' group by 客户 ,业务员)"
            // + "union"
            // + "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '00-07天' and 业务归属 = '二期'))a ORDER BY 面积");
            // GridView2_0_7.DataBind();
            // GridView2_8_14.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='08-14天' and 业务归属='二期' group by 客户 ,业务员)"
            //+ "union"
            //+ "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '08-14天' and 业务归属 = '二期'))a ORDER BY 面积");
            // GridView2_8_14.DataBind();
            // GridView2_15_30.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='15-30天' and 业务归属='二期' group by 客户 ,业务员)"
            //+ "union"
            //+ "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '15-30天' and 业务归属 = '二期'))a ORDER BY 面积");
            // GridView2_15_30.DataBind();
            // GridView2_31jiyishang.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where 库存天数范围='31天及以上' and 业务归属='二期' group by 客户 ,业务员)"
            //+ "union"
            //+ "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where 库存天数范围 = '31天及以上' and 业务归属 = '二期'))a ORDER BY 面积");
            // GridView2_31jiyishang.DataBind(); 
            #endregion


            #region 第2版
            // GridView1_1qi.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where  业务归属='一期' group by 客户 ,业务员)"
            // + "union"
            // + "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where  业务归属 = '一期'))a ORDER BY 面积");
            // GridView1_1qi.DataBind();

            // GridView1_2qi.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * from ((SELECT`客户`,sum(`总面积`)'面积',sum(`金额`)'金额',`业务员`FROM `slbz`.`二期彩盒库存明细` where  业务归属='二期' group by 客户 ,业务员)"
            //+ "union"
            //+ "(select '汇总:' as'客户', sum(`总面积`)'面积', sum(`金额`)'金额', '-' as'业务员'FROM `slbz`.`二期彩盒库存明细` where  业务归属 = '二期'))a ORDER BY 面积");
            // GridView1_2qi.DataBind(); 
            #endregion

            #region 第3版
            GridView1_1qi.DataSource = MySqlDbHelper.ExecuteDataTable("(SELECT `业务员`,`客户`,sum(`总面积`)as '总库存(㎡)',(select sum(`总面积`) "
            + " FROM `slbz`.`二期彩盒库存明细`k WHERE k.`交货日期`<DATE_FORMAT(SYSDATE(), '%Y-%m-%d') and k.客户=t.客户)'到交期库存(㎡)'"
            + " FROM `slbz`.`二期彩盒库存明细`t where `业务归属`='一期' GROUP BY `业务员`,`客户`order by 业务员)"
            + "union"
            + "(select ' ' as 业务员,'汇总'as 客户,sum(`总面积`)as '总库存(㎡)',(select sum(`总面积`) FROM `slbz`.`二期彩盒库存明细`k "
            + " WHERE k.`交货日期`< DATE_FORMAT(SYSDATE(), '%Y-%m-%d') and `业务归属`='一期')'到交期库存(㎡)' FROM `slbz`.`二期彩盒库存明细` where `业务归属`= '一期')");
            GridView1_1qi.DataBind();

            GridView1_2qi.DataSource = MySqlDbHelper.ExecuteDataTable("(SELECT 	`业务员`,`客户`,sum(`总面积`)as '总库存(㎡)',(select sum(`总面积`)  "
            + " FROM `slbz`.`二期彩盒库存明细`k WHERE k.`交货日期`< DATE_FORMAT(SYSDATE(), '%Y-%m-%d') and k.客户 = t.客户)'到交期库存(㎡)'"
            + " FROM `slbz`.`二期彩盒库存明细`t where `业务归属`= '二期' GROUP BY `业务员`,`客户`order by 业务员) "
            + "union"
            + "(select ' ' as 业务员,'汇总'as 客户,sum(`总面积`)as '总库存(㎡)',(select sum(`总面积`) FROM `slbz`.`二期彩盒库存明细`k "
            + " WHERE k.`交货日期`< DATE_FORMAT(SYSDATE(), '%Y-%m-%d') and `业务归属`='二期')'到交期库存(㎡)' FROM `slbz`.`二期彩盒库存明细` where `业务归属`= '二期')");
            GridView1_2qi.DataBind();
            #endregion
        }
        else
        {
        }


    }

    protected DataTable GetSqlTxt_Datatable(string txtFileName)
    {
        return OracleHelper.ExecuteDataTable(CommandType.Text,
        new StreamReader(
                new FileStream(
                  Server.MapPath("~\\sqltxt\\" + txtFileName + ".txt"),
                    FileMode.Open, FileAccess.Read, FileShare.Read)).ReadToEnd(), null);
    }
}