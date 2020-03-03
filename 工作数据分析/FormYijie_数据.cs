using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using 综合保障中心.Comm;
using 甩纸数据;
using System.Reflection;
using 工作数据分析.WinForm;
using DBUtility;
using 工作数据分析.Properties;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using 工作数据分析.Data.DAL;
using excelToTable_NPOI;
using 工作数据分析.WinForm.WuLiu;

namespace 综合保障中心.其它
{
    public partial class FormYijie_数据 : Form
    {
        private string ZidongBeifen = "工作数据分析_自动获取.exe";

        public FormYijie_数据()
        {
            InitializeComponent();
        }


        
        private void FormYijiePojie_Load(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "易捷数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`	FROM `slbz`.`settingall`	where `Key`='LastGetTime'").ToString()
                + " , 制版线数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT max(`结束时间`)FROM `slbz`.`瓦片完成情况`").ToString();
            DataBaseList.InitSqlhelper();
        }



      

        private void 筛选数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form筛选数据 f = new Form筛选数据();
            f.MdiParent = this;
            f.Show();
        }

      

        private void 输入用纸清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form用纸情况 f = new Form用纸情况();
            f.MdiParent = this;
            f.Show();
        }

       


        private void 筛选二期订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form筛选二期订单 f = new Form筛选二期订单();
            f.MdiParent = this;
            f.Show();

        }

        private void 未甩纸明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form甩纸覆膜所需原纸 f = new Form甩纸覆膜所需原纸("未甩纸明细和原纸需求"
                , "SELECT*	FROM `slbz`.`未甩纸_原纸需求`"
                , "SELECT *FROM `slbz`.`未甩纸_原纸需求_纸类uv合并_汇总`");
            f.MdiParent = this;
            f.Show();
        }

        private void 未覆膜明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form甩纸覆膜所需原纸 f = new Form甩纸覆膜所需原纸("未覆膜明细和膜需求"
                , "SELECT*	FROM `slbz`.`未覆膜_门幅米数`"
                , "SELECT *FROM `slbz`.`未覆膜_预涂膜需求`");
            f.MdiParent = this;
            f.Show();
        }

        private void 辅料领料分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form辅料领料分析 f = new Form辅料领料分析();
            f.MdiParent = this;
            f.Show();
        }

        private void 原纸进纸需求ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form进纸需求 f = new Form进纸需求();
            f.MdiParent = this;
            f.Show();
        }

        private void 特殊工艺订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期特殊工艺订单", "CALL `slbz`.`二期特殊工艺订单`('0');");
            f.MdiParent = this;
            f.Show();
        }

        private void 排程查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form排程查询 f = new Form排程查询("","");
            f.MdiParent = this;
            f.Show();
        }

        private void 按UVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期原纸即时库存(按UV合并分类)", "SELECT * FROM `slbz`.`二期原纸仓库库存明细(uv合并)_分类`");
            f.MdiParent = this;
            f.Show();
        }

        private void 按品牌ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期原纸即时库存(按品牌分类)", "SELECT * FROM `slbz`.`二期原纸仓库库存明细(按品牌)_分类`");
            f.MdiParent = this;
            f.Show();
        }

        private void 库存明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期原纸即时库存(库存明细)", "SELECT * FROM `slbz`.`二期原纸仓库库存明细`");
            f.MdiParent = this;
            f.Show();
        }

        private void 库存明细分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期原纸即时库存(库存明细分类)", "SELECT * FROM `slbz`.`二期原纸仓库库存明细_分类`");
            f.MdiParent = this;
            f.Show();
        }

        private void 各工序订单情况ToolStripMenuItem_Click(object sender, EventArgs e)
        { Form各工序订单情况 f = new Form各工序订单情况();
            f.MdiParent = this;
            f.Show();
        }

        private void 瓦片未开订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期箱片未开订单", "SELECT * FROM `slbz`.`二期箱片未开订单`");
            f.MdiParent = this;
            f.Show();
        }

        private void 制版线查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form制版线查询 f = new Form制版线查询();
            f.MdiParent = this;
            f.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "易捷数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `Value`	FROM `slbz`.`settingall`	where `Key`='LastGetTime'").ToString()
                    + " , 制版线数据更新时间:" + MySqlDbHelper.ExecuteScalar("SELECT `结束时间`FROM `slbz`.`瓦片完成情况`ORDER BY `结束时间` DESC LIMIT 1").ToString();    
        }

        private void 打开自动备份程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(ZidongBeifen))
                {
                    if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(ZidongBeifen)).Length > 0)
                    {
                        My.ShowErrorMessage("程序已经在运行!");
                    }
                    else
                    {
                        Process.Start(ZidongBeifen); //打开自动备份程序
                    }
                }
                else
                {
                   My.ShowErrorMessage("相关程序不存在!");
                }
            }
            catch
            {
            }
        }

        private void 未完工订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期未完工订单", "CALL `slbz`.`二期未完工订单`('0');");
            f.MdiParent = this;
            f.Show();
        }

        private void 计划交期订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form计划交期订单 f = new Form计划交期订单();
            f.MdiParent = this;
            f.Show();
        }

        private void 各工序结余ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowData f = new FormShowData("二期各工序结余", "CALL `slbz`.`二期各工序结余`;");
            f.MdiParent = this;
            f.Show();
        }

        private void 筛选数据ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void 排车日报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form选择日期 selectDate = new Form选择日期(false);
            string sqlStr = "CALL `slbz`.`送货日报表`('" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "',2);";
            if (selectDate.ShowDialog()==DialogResult.OK)
            {
                sqlStr = "CALL `slbz`.`送货日报表`('" + selectDate.GetDateTime_S().ToString("yyyy-MM-dd") + "','" + selectDate.GetDateTime_E().ToString("yyyy-MM-dd") + "',2);";
                FormShowData f = new FormShowData("排车日报表", sqlStr);
                f.MdiParent = this;
                f.Show();           
            }
            
        }

        private void 物流数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form物流Mian f = new Form物流Mian();
            f.MdiParent = this;
            f.Show();
        }

       

    }
}

