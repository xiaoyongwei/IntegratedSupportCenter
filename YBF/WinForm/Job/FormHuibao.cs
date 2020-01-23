using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using System.IO;
using excelToTable_NPOI;

namespace YBF.WinForm.Job
{
    public partial class FormHuibao : Form
    {
        private DataTable dt_bancaiMingxi = new DataTable();
        private DataTable dt_sunhao = new DataTable();
        private DataTable dt_baoyang = new DataTable();
        private DataTable dt_yichang = new DataTable();
        DataTable dt_huizong = new DataTable();

        public FormHuibao()
        {
            InitializeComponent();
        }

        private void FormHuibao_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            this.buttonExportExcel.Enabled = false;
            this.dtpStart.Value = DateTime.Now.Date;
            this.dtpEnd.Value = DateTime.Now;
            this.comboBoxHuizongLeixing.SelectedIndex = 0;
            this.WindowState = FormWindowState.Maximized;
        }
        public class JiluInfo
        {
            public string jitai = "";
            public int yinbanshu = 0;
            public int taoshu = 0;
            public int sunhaoshu = 0;
            public string sunhaoYuanyin = "";

        }

        public class HuiZong
        {
            public DateTime dTime = DateTime.MinValue;
            public List<JiluInfo> jiluList = new List<JiluInfo>();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            dt_bancaiMingxi = new DataTable();
            dt_sunhao = new DataTable();
            dt_baoyang = new DataTable();
            dt_yichang = new DataTable();
            dt_huizong = new DataTable();


            if (dtpStart.Value.Date > dtpEnd.Value.Date)
            {
                dtpEnd.Value = dtpStart.Value;
            }

            //出版明细
            dt_bancaiMingxi = SQLiteList.YBF.ExecuteDataTable("SELECT date([时间])as'时间' ,[机台],[客户名],[文件名],[印版数量]FROM [作业扩展]where [时间]BETWEEN "
           + "datetime('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') AND "
            + "datetime('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') AND [出版]=1 AND [暂停]=0 order by 时间");


            //损耗明细
            dt_sunhao = SQLiteList.YBF.ExecuteDataTable("SELECT date([时间])as'时间',[机台ID],[数量],[原因]FROM [版材损耗]where [时间]BETWEEN "
           + "datetime('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') AND "
            + "datetime('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') order by 时间");

            //机台
            Dictionary<string, string> jitaiDic = new Dictionary<string, string>();
            foreach (DataRow row in SQLiteList.YBF.ExecuteDataTable("select * from[印刷机]where [启用]=1").Rows)
            {
                jitaiDic.Add(row["ID"].ToString(), row["机台"].ToString());
            }

            //汇总明细,包括正常使用和损耗
            List<HuiZong> huizongList = new List<HuiZong>();
            //正常使用的汇总
            foreach (DataRow row in dt_bancaiMingxi.Rows)
            {
                DateTime dt = Convert.ToDateTime(row["时间"]);
                string jitai = row["机台"].ToString();
                int num = Convert.ToInt32(row["印版数量"]);
                HuiZong huizong = null;
                switch (comboBoxHuizongLeixing.Text)
                {
                    case "按月汇总":
                        huizong = huizongList.Find(hz => (hz.dTime.Year == dt.Date.Year) && (hz.dTime.Month == dt.Date.Month));
                        break;
                    case "按日汇总":
                    default:
                        huizong = huizongList.Find(hz => hz.dTime.Date == dt.Date.Date);
                        break;
                }
                if (huizong == null)
                {
                    huizong = new HuiZong();
                    huizong.dTime = dt;
                    JiluInfo jilu = new JiluInfo();
                    if (num > 0)
                    {
                        jilu.taoshu = 1;
                    }
                    jilu.jitai = jitai;
                    jilu.yinbanshu = num;
                    huizong.jiluList.Add(jilu);
                    huizongList.Add(huizong);
                }
                else
                {
                    JiluInfo jilu = huizong.jiluList.Find(jl => jl.jitai == jitai);
                    if (jilu == null)
                    {
                        jilu = new JiluInfo();
                        jilu.jitai = jitai;
                        if (num > 0)
                        {
                            jilu.taoshu = 1;
                        }
                        jilu.yinbanshu = num;
                        huizong.jiluList.Add(jilu);
                    }
                    else
                    {
                        jilu.yinbanshu += num;
                        if (num > 0)
                        {
                            jilu.taoshu++;
                        }

                    }

                }

            }
            //损耗的汇总
            foreach (DataRow row in dt_sunhao.Rows)
            {
                DateTime dt = Convert.ToDateTime(row["时间"]);
                string jitai = jitaiDic[row["机台ID"].ToString()];
                int num = Convert.ToInt32(row["数量"]);
                string yuanyin = row["原因"].ToString();
                HuiZong huizong = null;
                switch (comboBoxHuizongLeixing.Text)
                {
                    case "按月汇总":
                        huizong = huizongList.Find(hz => (hz.dTime.Year == dt.Date.Year) && (hz.dTime.Month == dt.Date.Month));
                        break;
                    case "按日汇总":
                    default:
                        huizong = huizongList.Find(hz => hz.dTime.Date == dt.Date.Date);
                        break;
                }

                if (huizong == null)
                {
                    huizong.dTime = dt;
                    JiluInfo jilu = new JiluInfo();
                    jilu.sunhaoshu = num;
                    jilu.sunhaoYuanyin = yuanyin;
                    huizongList.Add(huizong);
                }
                else
                {
                    JiluInfo jilu = huizong.jiluList.Find(jl => jl.jitai == jitai);
                    if (jilu == null)
                    {
                        jilu = new JiluInfo();
                        jilu.jitai = jitai;
                        jilu.yinbanshu = num;
                        huizong.jiluList.Add(jilu);
                    }
                    else
                    {
                        jilu.sunhaoshu += num;
                        jilu.sunhaoYuanyin += (yuanyin + ":" + num + Environment.NewLine);
                    }

                }
            }
            //把损耗显示在明细表中
            foreach (HuiZong hz in huizongList)
            {
                foreach (JiluInfo jl in hz.jiluList)
                {
                    if (jl.sunhaoshu > 0)
                    {
                        DataRow dr = dt_bancaiMingxi.NewRow();
                        dr["时间"] = hz.dTime.ToString("yyyy-MM-dd");
                        dr["机台"] = jl.jitai;
                        dr["文件名"] = "损耗: " + jl.sunhaoYuanyin;
                        dr["印版数量"] = jl.sunhaoshu;
                        dt_bancaiMingxi.Rows.Add(dr);
                    }

                }
            }
            this.dgvBancai.DataSource = dt_bancaiMingxi;
            dgvBancai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBancai.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //把汇总表显示出来            
            dt_huizong.Columns.Add("日期");
            //各个机台的列
            foreach (string item in jitaiDic.Values)
            {
                dt_huizong.Columns.Add(item + "正常使用", int.MinValue.GetType());
                dt_huizong.Columns.Add(item + "套数", int.MinValue.GetType());
                dt_huizong.Columns.Add(item + "损耗", int.MinValue.GetType());
                dt_huizong.Columns.Add(item + "损耗原因");

            }

            foreach (HuiZong hz in huizongList)
            {
                foreach (JiluInfo jl in hz.jiluList)
                {

                    DataRow dr = dt_huizong.NewRow();
                    switch (comboBoxHuizongLeixing.Text)
                    {
                        case "按月汇总":
                            dr["日期"] = hz.dTime.ToString("yyyy年MM月");
                            break;
                        case "按日汇总":
                        default:
                            dr["日期"] = hz.dTime.ToString("yyyy年MM月dd日");
                            break;
                    }
                    //判断相应的行是不是存在
                    bool cunzai = false;
                    foreach (DataRow row in dt_huizong.Rows)
                    {
                        if (row["日期"].ToString() == dr["日期"].ToString())
                        {
                            cunzai = true;
                            row[jl.jitai + "正常使用"] = jl.yinbanshu;
                            row[jl.jitai + "套数"] = jl.taoshu;
                            row[jl.jitai + "损耗"] = jl.sunhaoshu;
                            row[jl.jitai + "损耗原因"] = jl.sunhaoYuanyin.Trim();
                            break;
                        }
                    }
                    if (!cunzai)
                    {
                        dr[jl.jitai + "正常使用"] = jl.yinbanshu;
                        dr[jl.jitai + "套数"] = jl.taoshu;
                        dr[jl.jitai + "损耗"] = jl.sunhaoshu;
                        dr[jl.jitai + "损耗原因"] = jl.sunhaoYuanyin.Trim();
                        dt_huizong.Rows.Add(dr);
                    }
                }
            }

            //小计数量
            if (dt_huizong.Rows.Count > 1)
            {
                DataRow dr = dt_huizong.NewRow();
                dr["日期"] = "小计数量";
                foreach (DataColumn col in dt_huizong.Columns)
                {
                    if (col.DataType == int.MinValue.GetType())
                    {
                        int sum = 0;
                        foreach (DataRow row in dt_huizong.Rows)
                        {
                            if (row[col] != DBNull.Value)
                            {
                                sum += Convert.ToInt32(row[col]);
                            }

                        }
                        dr[col] = sum;
                    }
                }
                dt_huizong.Rows.Add(dr);
            }


            dgvHuizong.DataSource = dt_huizong;
            dgvBancai.AutoResizeColumns();
            dgvHuizong.AutoResizeColumns();
            foreach (DataGridViewColumn col in dgvHuizong.Columns)
            {
                if (col.Name.Contains("损耗原因"))
                {
                    col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }


            //***显示保养记录表
            dt_baoyang = SQLiteList.YBF.ExecuteDataTable("SELECT[时间],[设备],[项目],[结果],[保养人]FROM [保养]where [时间]BETWEEN "
            + "datetime('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') AND "
             + "datetime('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') order by 时间");
            dgvBaoyang.DataSource = dt_baoyang;
            dgvBaoyang.AutoResizeColumns();
            dgvBaoyang.AutoResizeColumns();

            //***显示异常记录表            
            dt_yichang = SQLiteList.YBF.ExecuteDataTable("SELECT[发现时间],[设备或软件],[情况描述],[处理结果]FROM [异常]where [发现时间]BETWEEN "
        + "datetime('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') AND "
         + "datetime('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "') order by 发现时间");
            dgvYichang.DataSource = dt_yichang;
            dgvYichang.AutoResizeColumns();
            dgvYichang.AutoResizeColumns();


            splitContainer3.Panel1Collapsed = (dgvBaoyang.Rows.Count == 0);
            splitContainer3.Panel2Collapsed = (dgvYichang.Rows.Count == 0);
            splitContainer1.Panel2Collapsed = (dgvBaoyang.Rows.Count == 0 && dgvYichang.Rows.Count == 0);

            if (dt_bancaiMingxi.Rows.Count == 0
               && dt_huizong.Rows.Count == 0
               && dt_baoyang.Rows.Count == 0
               && dt_yichang.Rows.Count == 0)
            {
                this.buttonExportExcel.Enabled = false;
            }
            else
            {
                this.buttonExportExcel.Enabled = true;
            }
        }

        private void buttonExportExcel_Click(object sender, EventArgs e)
        {
            if (dt_bancaiMingxi.Rows.Count == 0
                && dt_huizong.Rows.Count == 0
                && dt_baoyang.Rows.Count == 0
                && dt_yichang.Rows.Count == 0)
            {
                return;
            }


            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel文件|*.xls";
            save.FileName = string.Format("CTP版房汇总表({0}-{1})", dtpStart.Value.ToString("yyyyMMddHHmmss"), dtpEnd.Value.ToString("yyyyMMddHHmmss"));
            if (save.ShowDialog() == DialogResult.OK)
            {
                dt_bancaiMingxi.TableName = "明细表";
                dt_sunhao.TableName = "损耗";
                dt_huizong.TableName = "汇总表";
                dt_baoyang.TableName = "保养记录";
                dt_yichang.TableName = "异常记录";
                new ExcelHelper(save.FileName).DataTableListToExcel(
                    new List<DataTable> { dt_bancaiMingxi, dt_huizong, dt_baoyang, dt_yichang });
            }

        }


    }
}
