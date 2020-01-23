using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace 工作数据.winForm.每日数据
{
    public partial class Form每日数据汇总_图表 : Form
    {
        public Form每日数据汇总_图表()
        {
            InitializeComponent();
        }
        Dictionary<string, int> dic = new Dictionary<string, int>();
        DataTable dt = MySqlDbHelper.ExecuteDataTable("SELECT * FROM `slbz`.`每日数据` ORDER BY `日期` DESC LIMIT 30");
        private void Form每日数据汇总_图表_Load(object sender, EventArgs e)
        {

            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            if (dt.Rows.Count > 0)
            {

                dic.Add("柱形图类型", 10);
                dic.Add("折线图类型", 3);
                dic.Add("面积图类型", 13);
                dic.Add("条形图类型", 7);
                dic.Add("盒须图类型", 28);
                dic.Add("气泡图类型", 2);
                dic.Add("K 线图类型", 20);
                dic.Add("圆环图类型", 18);
                dic.Add("误差条形图类型", 27);
                dic.Add("快速扫描线图类型", 6);
                dic.Add("快速点图类型", 1);
                dic.Add("漏斗图类型", 33);
                dic.Add("卡吉图类型", 31);                
                dic.Add("饼图类型", 17);
                dic.Add("点图类型", 0);
                dic.Add("点数图类型", 32);
                dic.Add("极坐标图类型", 26);
                dic.Add("棱锥图类型", 34);
                dic.Add("雷达图类型", 25);
                dic.Add("范围图类型", 21);
                dic.Add("范围条形图类型", 23);
                dic.Add("范围柱形图类型", 24);
                dic.Add("砖形图类型", 29);
                dic.Add("样条图类型", 4);
                dic.Add("样条面积图类型", 14);
                dic.Add("样条范围图类型", 22);
                dic.Add("堆积面积图类型", 15);
                dic.Add("百分比堆积面积图类型", 16);
                dic.Add("堆积条形图类型", 8);
                dic.Add("百分比堆积条形图类型", 9);
                dic.Add("堆积柱形图类型", 11);
                dic.Add("百分比堆积柱形图类型", 12);
                dic.Add("阶梯线图类型", 5);
                dic.Add("股价图类型", 19);
                dic.Add("新三值图类型", 30);

                foreach (string item in dic.Keys)
                {
                    comboBoxChartType.Items.Add(item);
                }
                comboBoxChartType.Text = "柱形图类型";
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.ColumnName.Contains("_"))
                    {
                        //comboBox.Items.Add(dc.ColumnName);
                        tview.Nodes.Add(dc.ColumnName);
                    }

                   
                }
                DateTime max = DateTime.Parse((dt.Compute("Max(日期)", "true").ToString()));
                DateTime min = DateTime.Parse((dt.Compute("Min(日期)", "true").ToString()));
                dateTimePicker1.Value = min;
                dateTimePicker2.Value = max;
                dateTimePicker1.MaxDate = max;
                dateTimePicker1.MinDate = min;
                dateTimePicker2.MaxDate = max;
                dateTimePicker2.MinDate = min;
                this.dateTimePicker1.ValueChanged += new System.EventHandler(this.comboBoxChartType_SelectedIndexChanged);
                this.dateTimePicker2.ValueChanged += new System.EventHandler(this.comboBoxChartType_SelectedIndexChanged);
                this.comboBoxChartType.SelectedIndexChanged += new EventHandler(comboBoxChartType_SelectedIndexChanged);
            }
        }

        void comboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        { ShowChart(); 
        }


      

        private void tview_AfterCheck(object sender, TreeViewEventArgs e)
        {
            ShowChart();
        }


        private void ShowChart()
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MY.ShowErrorMessage("开始时间不能大于结束时间");
                return;
            }

            if (dt.Rows.Count > 0)
            {
                //图表数据区，有多个重叠则循环添加
                ct.Series.Clear();
                foreach (TreeNode tn in tview.Nodes)
                {
                    if (tn.Checked)
                    {
                        List<DateTime> dt_list = new List<DateTime>();
                        List<double> tyData = new List<double>();
                        for (DateTime i = dateTimePicker1.Value; i <= dateTimePicker2.Value; i = i.AddDays(1))
                        {
                            dt_list.Add(i);
                        }
                        foreach (DataRow dr in dt.Select("1=1", "日期 asc"))
                        {
                            if (Convert.ToDateTime(dr["日期"]).Date >= dateTimePicker1.Value.Date
                                && Convert.ToDateTime(dr["日期"]).Date <= dateTimePicker2.Value.Date)
                            {
                                tyData.Add(Convert.ToDouble(dr[tn.Text]));
                            }
                        }

                        Series series = ct.Series.Add(tn.Text); //添加一个图表序列
                        //series.XValueType = ChartValueType.String;  //设置X轴上的值类型
                        series.Label = "#VAL";                //设置显示X Y的值    
                        series.LabelForeColor = Color.Red;
                        series.LabelBackColor = Color.White;
                        series.ToolTip = tn.Text+"\r#VALX\r#VAL";     //鼠标移动到对应点显示数值
                        // series.ChartArea = ;                   //设置图表背景框
                        series.ChartType = (SeriesChartType)dic[comboBoxChartType.Text];    //图类型(折线)
                        series.Points.DataBindXY(dt_list, tyData); //添加数据
                        Text = ct.Series.Count.ToString();
                        ////折线段配置
                        //series.Color = Color.Red;               //线条颜色
                        //series.BorderWidth = 3;                 //线条粗细
                        //series.MarkerBorderColor = Color.Red;   //标记点边框颜色
                        //series.MarkerBorderWidth = 3;             //标记点边框大小
                        //series.MarkerColor = Color.Red;       //标记点中心颜色
                        //series.MarkerSize = 5;                 //标记点大小
                        //series.MarkerStyle = MarkerStyle.Circle;  //标记点类型
                    }
                }
            }
        }
    }
}
