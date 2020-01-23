using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using excelToTable_NPOI;

namespace OpenExcelToDgv
{
    public partial class FormPaiche : Form
    {
        public FormPaiche()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
                double baodiMianji = 2500;
                ExcelHelper excel = new ExcelHelper(@"D:\00.xls");
                DataSet ds = excel.ExcelToDataSet(true, true);
                this.Text = ds.DataSetName;
                foreach (DataTable dt in ds.Tables)
                {
                    //增加拼车费列
                    dt.Columns.Add("拼车费");
                    //增加二次堆码列
                    dt.Columns.Add("二次堆码");
                    //增加远距离算法的运费
                    dt.Columns.Add("运费远");

                    //按理货单,客户排序
                    dt.DefaultView.Sort = "理货单,客户 DESC";

                    List<string> zhuangchedanList = new List<string>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        string zhuangchedan = dr["理货单"].ToString();
                        if (zhuangchedan.IndexOf("ZX") == 0)
                        {
                            if (!zhuangchedanList.Contains(zhuangchedan))
                            {
                                zhuangchedanList.Add(zhuangchedan);
                            }
                        }
                    }

                    foreach (string zhuangchedan in zhuangchedanList)
                    {
                        List<DataRow> songhuodanRowList = new List<DataRow>();
                        double zongmianji = 0;
                        double maxKm=0;
                        foreach (DataRow dr in dt.Select("理货单='" + zhuangchedan + "'"))
                        {
                            songhuodanRowList.Add(dr);
                            zongmianji += Convert.ToDouble(dr["折算面积"].ToString());
                            maxKm=Math.Max(maxKm,Convert.ToDouble(dr["公里"]));
                        }
                        DataRow drow = songhuodanRowList[0];
                        if (zongmianji >= 2500)
                        {
                            drow["运费远"] = My.GetYunfei(Convert.ToDouble(drow["折算面积"]), maxKm);                                                 
                        }
                        else
                        {
                            drow["运费远"] = My.GetYunfei(baodiMianji, maxKm);
                        }
                        drow["拼车费"] = (songhuodanRowList.Count - 1) * 20;      
                    }



                    TabPage tp = new TabPage(dt.TableName);
                    tp.Name = dt.TableName;
                    DataGridView dgv = new DataGridView();
                    dgv.Dock = DockStyle.Fill;
                    dgv.DataSource = dt;
                    tp.Controls.Add(dgv);
                    tabControl1.TabPages.Add(tp);


                }
           
        }
    }
}
