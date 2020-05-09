using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 综合保障中心
{
    public partial class FormYunfei2019 : Form
    {
        /// <summary>
        /// 装卸费:指的是装一次和卸一次的费用(0.011元/平方)
        /// </summary>
        private double ZXF = 0.011;

        public FormYunfei2019()
        {
            InitializeComponent();
        }

        //true表示无效.false表示有效.
        //此函数为全局更改(慎用!!!)
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {
            if ( keyData == Keys.F12)//计算
            {
                Submit();
            }
            else if (keyData == Keys.F11)
            {
                List<int> rowIndexList = new List<int>();
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    int rowIndex = cell.RowIndex;
                    if (!rowIndexList.Contains(rowIndex))
                    {
                        rowIndexList.Add(rowIndex);
                    }
                }
                foreach (int item in rowIndexList)
                {
                    dgv[Column2ciCbc.Index, item].Value = !Convert.ToBoolean(dgv[Column2ciCbc.Index, item].Value);
                }
            }

            return false;

        }
        private void FormYunfei_Load(object sender, EventArgs e)
        {
            this.checkBox1.Checked = true;
        }

        private void dgv_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[ColumnKm.Index].Value = 0;
            e.Row.Cells[ColumnArea.Index].Value = 0; 
            e.Row.Cells[Column2ciduima.Index].Value = 0;
        }

        private void textBoxCustomerCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            Submit();
           
        }

        private void Submit()
        {
            //先判断总公里数是否超过保底公里数
            //如果没有超过,则计算最长距离*系数
            //如果超过,则每个数据分别计算
            try
            {
                this.dgv.EndEdit();
                double areaSum = 0;

                int bottomSquare = Convert.ToInt32(textBoxBottomSquare.Text);
                int customerCount = Convert.ToInt32(textBoxCustomerCount.Text);

                List<int> kmList = new List<int>();
                List<double> areaList = new List<double>();
                if (customerCount > dgv.Rows.Count - 1)
                {
                    throw new Exception("客户数超过送货记录");
                }

                if (bottomSquare <= 0)
                {
                    throw new Exception("[保底平方]的数据输入错误!");
                }
                else if (customerCount <= 0)
                {
                    throw new Exception("[客户数]的数据输入错误!");
                }
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    int km = 0;
                    double area = 0;
                    double shangtiao = 0;
                    if (!int.TryParse(row.Cells[ColumnKm.Index].Value.ToString(), out km)
                        || km <= 0)
                    {
                        throw new Exception(string.Format("第{0}行的[公里数]输入错误!",row.Index+1));
                    }
                    if (!double.TryParse(row.Cells[ColumnArea.Index].Value.ToString(), out area)
                        || area <= 0)
                    {
                        throw new Exception(string.Format("第{0}行的[公里数]输入错误!",row.Index+1));
                    }
                    if (row.Cells[ColumnShangtiao.Index].Value==null
                        ||!double.TryParse(row.Cells[ColumnShangtiao.Index].Value.ToString(), out shangtiao))
                    {
                        shangtiao = 0;
                    }
                    kmList.Add(km);
                    areaList.Add(area*(1+shangtiao));
                }

                areaSum = areaList.Sum();


                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow)
                    {
                        continue;
                    }
                    double shangtiao = 0;
                    if (row.Cells[ColumnShangtiao.Index].Value == null
                       || !double.TryParse(row.Cells[ColumnShangtiao.Index].Value.ToString(), out shangtiao))
                    {
                        shangtiao = 0;
                    }


                    int km = 0;
                    double area = 0;
                    int.TryParse(row.Cells[ColumnKm.Index].Value.ToString(), out km);
                    double.TryParse(row.Cells[ColumnArea.Index].Value.ToString(), out area);
                    //总面积大于保底
                    if (areaSum > bottomSquare)
                    {
                        row.Cells[ColumnYunfei.Index].Value = GetFreight(km, area*(1+ shangtiao));
                    }
                    else //总面积小于保底
                    {
                        row.Cells[ColumnYunfei.Index].Value = GetFreight(km, area * (1 + shangtiao) / areaSum * bottomSquare);
                    }
                    row.Cells[ColumnZxf.Index].Value =Math.Round(area*ZXF*2,3);//装卸费
                    if (Convert.ToBoolean(row.Cells[Column2ciCbc.Index].Value))
                    {
                        row.Cells[Column2ciduima.Index].Value = Math.Round(area * ZXF);//二次堆码费
                    }
                    else
                    {
                        row.Cells[Column2ciduima.Index].Value = 0;
                    }
                    row.Cells[ColumnZyf.Index].Value = Math.Round(Convert.ToDouble(row.Cells[ColumnYunfei.Index].Value) 
                        + Convert.ToDouble(row.Cells[ColumnZxf.Index].Value)
                        //+ Convert.ToDouble(row.Cells[Column2ciduima.Index].Value)
                        ,3);
                }

                if (dgv.Rows.Count > 1)
                {
                    double yunfeiGongji = 0;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow)
                        {
                            continue;
                        }
                        yunfeiGongji += Convert.ToDouble(row.Cells[ColumnZyf.Index].Value) + Convert.ToDouble(row.Cells[Column2ciduima.Index].Value);
                    }
                    yunfeiGongji += (customerCount - 1) * 10;

                    this.textBoxgongji.Text = "运费:" + Math.Round(yunfeiGongji, 2).ToString() + " 面积:" + Math.Round(areaSum,2) + " 平方价:" + Math.Round(Math.Round(yunfeiGongji, 2) / areaSum, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dgv_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            this.dgv.EndEdit();
            int km = 0;
            double area = 0;

            if (!int.TryParse(dgv.Rows[e.RowIndex].Cells[ColumnKm.Index].Value.ToString(), out km)
                || !double.TryParse(dgv.Rows[e.RowIndex].Cells[ColumnArea.Index].Value.ToString(), out area)
                || km == 0 || area == 0)
            {
                MessageBox.Show("输入的数据不正确", "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /// <summary>
        /// 获取运费
        /// </summary>
        /// <param name="km"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        private double GetFreight(int km, double area)
        {
            //double freight = 0;
            //if (km <= 15)
            //{
            //    freight = 0.07 * area;
            //}
            //else if (16 <= km && km <= 20) { freight = 0.076 * area; }
            //else if (21 <= km && km <= 25) { freight = 0.082 * area; }
            //else if (26 <= km && km <= 30) { freight = 0.088 * area; }
            //else if (31 <= km && km <= 35) { freight = 0.094 * area; }
            //else if (36 <= km && km <= 40) { freight = 0.1 * area; }
            //else if (41 <= km && km <= 45) { freight = 0.106 * area; }
            //else if (46 <= km && km <= 50) { freight = 0.112 * area; }
            //else if (51 <= km && km <= 55) { freight = 0.118 * area; }
            //else if (56 <= km && km <= 60) { freight = 0.124 * area; }
            //else if (61 <= km && km <= 65) { freight = 0.13 * area; }
            //else if (66 <= km && km <= 70) { freight = 0.136 * area; }
            //else if (71 <= km && km <= 75) { freight = 0.142 * area; }
            //else if (76 <= km && km <= 80) { freight = 0.148 * area; }
            //else if (81 <= km && km <= 85) { freight = 0.154 * area; }
            //else if (86 <= km && km <= 90) { freight = 0.16 * area; }
            //else if (91 <= km && km <= 95) { freight = 0.166 * area; }
            //else if (96 <= km && km <= 100) { freight = 0.172 * area; }
            //else if (101 <= km && km <= 105) { freight = 0.178 * area; }
            //else if (106 <= km && km <= 110) { freight = 0.184 * area; }
            //else if (111 <= km && km <= 115) { freight = 0.19 * area; }
            //else if (116 <= km && km <= 120) { freight = 0.196 * area; }
            //else if (121 <= km && km <= 125) { freight = 0.202 * area; }
            //else if (126 <= km && km <= 130) { freight = 0.208 * area; }
            //else if (131 <= km && km <= 135) { freight = 0.214 * area; }
            //else if (136 <= km && km <= 140) { freight = 0.22 * area; }
            //else if (141 <= km && km <= 145) { freight = 0.226 * area; }
            //else if (146 <= km && km <= 150) { freight = 0.232 * area; }
            //else if (151 <= km && km <= 155) { freight = 0.238 * area; }
            //else if (156 <= km && km <= 160) { freight = 0.244 * area; }
            //else if (161 <= km && km <= 165) { freight = 0.25 * area; }
            //else//[(公里数-15)*0.0012+0.07]*平方数
            //{
            //    freight = ((km - 15) * 0.0012 + 0.07) * area;
            //}


            double freight = (Math.Truncate(1.0*(km - 1) / 5) * 0.006 + 0.035)*area;
            return Math.Round(freight, 3);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = this.checkBox1.Checked;
        }

     
        private void FormYunfei_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
