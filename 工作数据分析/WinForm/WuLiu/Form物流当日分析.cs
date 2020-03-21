using System;
using System.Windows.Forms;

namespace 工作数据分析.WinForm.WuLiu
{
    public partial class Form物流当日分析 : Form
    {
        public Form物流当日分析()
        {
            InitializeComponent();
        }

        private void Form物流当日分析_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT sum(折算面积)'总面积'," +
 "(select count(kk.A)from (select count(装车单号)'A' from " +
 "`slbz`.`运费管理` WHERE 日期 BETWEEN date_format(now(), '%m/%d') AND date_format(date_add(now(), interval 1 day), '%m/%d') and 装车单号 like'ZX%' group by 装车单号)kk)'车次'," +
 "(select sum(折算面积)FROM `slbz`.`运费管理`" +
 "WHERE 装车单号 like'ZX%' and  日期 BETWEEN date_format(now(), '%m/%d') AND date_format(date_add(now(), interval 1 day), '%m/%d'))/" +
 "(select count(*) from(select 装车单号 from `slbz`.`运费管理` WHERE 日期 BETWEEN date_format(now(), '%m/%d') AND date_format(date_add(now(), interval 1 day), '%m/%d') and 装车单号 like'ZX%' group by 装车单号)kka)'每车装载' " +
 "FROM `slbz`.`运费管理`" +
 "WHERE 装车单号 like'ZX%' and  日期 BETWEEN date_format(now(), '%m/%d') AND date_format(date_add(now(), interval 1 day), '%m/%d') ;");

            dataGridView2.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * FROM `slbz`.`运费管理`" +
 "WHERE 日期 BETWEEN date_format(now(), '%m/%d') AND date_format(date_add(now(), interval 1 day), '%m/%d');");

            dataGridView3.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT 装车单号,司机,sum(折算面积)'总装载面积' FROM `slbz`.`运费管理`"
 + "WHERE 日期  BETWEEN date_format(now(), '%m/%d') AND date_format(date_add(now(), interval 1 day), '%m/%d') group by 装车单号,司机;");

            dataGridView4.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT	`客户`,sum(((SELECT `面积`FROM `slbz`.`订单_生产单` WHERE 生产单号=工单号)*`送货数量`))'报货面积'"
 + "FROM `slbz`.`物流_发货通知单` where date_format(`报货时间`, '%Y-%m-%d')=date_format(now(), '%Y-%m-%d')group by `客户`;");

            dataGridView5.DataSource = MySqlDbHelper.ExecuteDataTable("select `客户`,sum((`需要送货数量`-`实际送货数量`)*`单个面积`)as'未送面积'"
+ ",sum((`需要送货数量`-`实际送货数量`)*`折算面积`)AS '未送折算面积'"
+ "from `slbz`.`报货送货对比` where `实际送货数量`<`需要送货数量` group by`客户`;");

            dataGridView6.DataSource = MySqlDbHelper.ExecuteDataTable("select * from `slbz`.`报货送货对比` where `实际送货数量`<`需要送货数量`;");
        }
    }
}
