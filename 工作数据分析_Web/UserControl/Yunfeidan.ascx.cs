using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl_Yunfeidan : System.Web.UI.UserControl
{

    /// <summary>
    /// 装车单号
    /// </summary>
    public string plncde = "";    
    /// <summary>
    /// 信息表(从此表中读取并汇总信息)
    /// </summary>
    public DataTable dataTable = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(plncde))
        {
            

            DataTable dt = dataTable.Clone();
            foreach (DataRow row in dataTable.Select("装车单号='"+ plncde+"'"))
            {
                dt.Rows.Add(row.ItemArray);
            }
            
            //表头和表尾的数据
            LabelRiqi.Text = dt.Rows[0]["日期"].ToString();
            LabelChepai.Text = dt.Rows[0]["车牌"].ToString();
            LabelSiji.Text = dt.Rows[0]["司机"].ToString();
            this.LabelZhuangchedanhao.Text = plncde;
            LabelPingfangheji.Text = dt.Compute("sum(装载平方)","").ToString();
            LabelZongyunfei.Text = (Convert.ToDouble(dt.Compute("sum(运费)", ""))+ Convert.ToDouble(dt.Compute("sum(附加费)", ""))).ToString();
            LabelDaochuriqi.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //删除不需要的列
            for (int i = dt.Columns.Count-1; i >=0; i--)
            {
                if (!new string[] { "客户名称", "装载平方", "送货单号", "里程", "结算单号", "附加费", "结算人","备注" }.Contains(dt.Columns[i].ColumnName))
                {
                    dt.Columns.RemoveAt(i);
                }
            }

            //绑定数据
            GridViewQingdan.DataSource = dt;
            GridViewQingdan.DataBind();

            //给附加费加上颜色
            foreach (GridViewRow row in GridViewQingdan.Rows)
            {
                row.Cells[5].ForeColor = Color.Magenta;
            }
        }
    }
}