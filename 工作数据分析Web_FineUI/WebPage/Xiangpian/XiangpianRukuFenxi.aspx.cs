using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.WebPage.Xiangpian
{
    public partial class XiangpianRukuFenxi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);


            //1.读取15天内的瓦片完成情况(总表,包含后续工序和入库,2列)
            //2.读取20天内纸板入库情况
            //3.删除已经入库的工单
            //4.读取20天内已经报工的工单(裱,压,钉,粘,打包)
            //5.判断"后续工序"的列的值
            //6.读取20天内已经入库的工单
            //7.判断"入库"的列的值
            //8.显示


            //1.读取15天内的瓦片完成情况(总表,包含后续工序和入库,2列)
            string sqlStrTemp = "SELECT trim(`工单号`)'工单号',`客户名`,`楞型`,`数量`,DATE_FORMAT(`结束时间`,'%Y-%m-%d %H:%i:%s')结束时间," +
                " '' as '后续工序','' as '成品入库' FROM `slbz`.`瓦片完成情况` where (工单号 like'C2%' OR 工单号 like'CL2%') and 结束时间>= " +
                "date_format(date_add(now(),  interval - 15 day), '%Y-%m-%d')  order BY `结束时间` desc";
            DataTable dt = MySqlDbHelper.ExecuteDataTable(sqlStrTemp);
            //2.读取20天内纸板入库情况
            sqlStrTemp = "SELECT serial FROM  FERP.V_DY_ZB_INQ_BCDR_ROWS  WHERE INVTYP='RA'AND ACCNUML>0  " +
                " and  OBJTYP='ZB' and ORGCDE='03' and to_char(PTDATE,'YYYY-MM-DD')>(select to_char(sysdate - interval '20' day,'yyyy-mm-dd') " +
                "from dual) GROUP BY SERIAL";
            List<DataRow> drowList = new List<DataRow>();
            foreach (DataRow oracleRow in OracleHelper.ExecuteDataTable(sqlStrTemp).Rows)
            {
                foreach (DataRow mysqlRow in dt.Rows)
                {
                    if (oracleRow[0].ToString().Equals(mysqlRow["工单号"].ToString()))
                    {
                        drowList.Add(mysqlRow);
                        break;
                    }
                }
            }
            //3.删除已经入库的工单
            foreach (DataRow row in drowList)
            {
                dt.Rows.Remove(row);
            }

            //4.读取20天内已经报工的工单(裱,压,钉,粘,打包)
            sqlStrTemp = "SELECT	t.serial FROM	FERP.V_HR_PIECE_DATA t WHERE	t.ORGCDE = '03' 	and  t.objtyp='CL'	" +
                "  and t.PRCTYP IN ('08','09','25','03','07','16','17')	" +
                "  AND to_char( t.CREATED, 'yyyy-mm-dd' ) >= (select   to_char(sysdate - interval '20' day,'yyyy-mm-dd')   " +
                " from dual)	AND to_char( t.CREATED, 'yyyy-mm-dd' ) <=( select to_char(sysdate,'yyyy-mm-dd') from dual) " +
                "   group BY t.serial ";
            //5.判断"后续工序"的列的值
            foreach (DataRow oracleRow in OracleHelper.ExecuteDataTable(sqlStrTemp).Rows)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (oracleRow[0].ToString().Equals(row["工单号"].ToString()))
                    {
                        row["后续工序"] = "完工";
                    }
                }
            }
            //6.读取20天内已经入库的工单
            sqlStrTemp = "select t.serial from FERP.PB_BCDR_CT t where t.objtyp = 'CL' and t.orgcde = '03' and " +
                "to_char(t.CREATED, 'yyyy-mm-dd') >= (select to_char(sysdate - interval '20' day, 'yyyy-mm-dd')from dual)" +
                "AND to_char(t.CREATED, 'yyyy-mm-dd') <= (select to_char(sysdate, 'yyyy-mm-dd')	from dual)	group by t.serial";
            //7.判断"入库"的列的值
            foreach (DataRow oracleRow in OracleHelper.ExecuteDataTable(sqlStrTemp).Rows)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (oracleRow[0].ToString().Equals(row["工单号"].ToString()))
                    {
                        row["成品入库"] = "入库";
                    }
                }
            }
            //8.显示
            this.GridView1.DataSource = dt;
            this.GridView1.DataBind();


        }


        protected void ButtonDownload_Click(object sender, EventArgs e)
        {
            My.DownloadExcel(Response, GridView1, "箱片入库分析", true);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}