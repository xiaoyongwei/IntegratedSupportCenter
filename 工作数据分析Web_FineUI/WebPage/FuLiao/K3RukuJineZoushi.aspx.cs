using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using 工作数据分析Web_FineUI.App_Code;

namespace 工作数据分析Web_FineUI.FuLiao
{
    public partial class K3RukuJineZoushi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            My.IsSession(Session, Response);

            InitTreeView(this.TextBoxSearch.Text.Trim());
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            DataTable dt = MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`物料金额走势`('" + TreeView1.SelectedValue + "');"); ;

            GridView1.DataSource = dt;
            GridView1.DataBind();

            //收集图标的X 和 Y 轴的数据
            List<string> listX = new List<string>();
            List<string> listY = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                listX.Add(row["日期"].ToString());
                listY.Add(row["含税单价"].ToString());
            }
            //剔除重复的价格
            List<int> listDelIndex = new List<int>();
            for (int i = 1; i < listY.Count; i++)
            {
                if (listY[i] == listY[i - 1])
                {
                    listDelIndex.Add(i - 1);
                }
            }
            listDelIndex.Reverse();
            foreach (int item in listDelIndex)
            {
                listX.RemoveAt(item);
                listY.RemoveAt(item);
            }
            listX.Reverse();
            listY.Reverse();

            //title属性说明
            //边框样式设置
            Chart1.ChartAreas["ChartArea1"].BorderColor = Color.Black;
            Chart1.ChartAreas["ChartArea1"].BorderWidth = 0;
            Chart1.ChartAreas[0].AxisX.Interval = 1;
            Chart1.ChartAreas[0].AxisX.IntervalOffset = 1;
            Chart1.ChartAreas[0].AxisX.LabelStyle.IsStaggered = true;

            Chart1.Series.Add("实际值");
            Chart1.Series["实际值"]["PixelPointWidth"] = "20";
            Chart1.Series["实际值"].Points.DataBindXY(listX, listY); //添加数据源，X、Y轴（结合这里是动态数组）
            for (int i = 0; i < listX.Count; i++)
            {
                Chart1.Series["实际值"].Points[i].Label = listY[i].ToString();//柱状图顶部添加说明数据
            }

            //设置图例说明
            Chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("微软雅黑", float.Parse("8"), FontStyle.Regular);
            Chart1.ChartAreas["ChartArea1"].AxisY.TitleForeColor = Color.FromName("Black");
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("微软雅黑", float.Parse("8"), FontStyle.Regular);
            Chart1.ChartAreas["ChartArea1"].AxisX.TitleForeColor = Color.FromName("Black");
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = TreeView1.SelectedValue + "-含税单价-入库时间";
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Angle = (listX.Count > 12 ? 60 : 0);
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
        }

        protected void ButtonH_Click(object sender, EventArgs e)
        {
            InitTreeView(this.TextBoxSearch.Text.Trim());
        }


        private void InitTreeView(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                searchText = "";
            }
            TreeView1.Nodes.Clear();
            foreach (DataRow dr in MySqlDbHelper.ExecuteDataTable("CALL `slbz`.`物料入库次数近1年`('" + searchText + "');").Rows)
            {
                TreeView1.Nodes.Add(new TreeNode(dr["物料名称"].ToString()));
            }

        }
    }
}