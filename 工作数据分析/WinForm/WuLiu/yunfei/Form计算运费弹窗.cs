using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 工作数据分析.Data.DAL.Oracle;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.WuLiu
{
    public partial class Form计算运费弹窗 : Form
    {
        private List<string> IDList = new List<string>();
        public Form计算运费弹窗(List<string> idList)
        {
            InitializeComponent();
            IDList = idList;
        }

        private void Form计算运费弹窗_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            double baodi = 0;
            double diquYunfei = 0;

            double.TryParse(this.textBoxBaodi.Text,out baodi);
            double.TryParse(this.textBoxDiquYunfei.Text,out diquYunfei);
            if (baodi>0&&diquYunfei>0&& IDList.Count>0)
            {
                string idIn = "";
                foreach (string id in IDList)
                {
                    idIn += (id + ",");
                }
                idIn = idIn.TrimEnd(',');

                double sumAreas = Convert.ToDouble(OracleHelper.ExecuteScalar(
                    "SELECT sum((select nvl(sum(i.ratios * i.acreage * i.ACCNUMR),0) from v_bcdx_ct i where i.clientid = t.clientid " +
                    "and i.orgcde = t.orgcde and i.PONO = t.pono))FROM EJSH.DLV_FARE t WHERE id IN(" + idIn + ")"));
                double zongYunfei = 0;
                if (sumAreas>=baodi)
                {
                    zongYunfei = (diquYunfei / baodi+0.03) * sumAreas;
                }
                else
                {
                    zongYunfei = diquYunfei + sumAreas * 0.03;
                }

                zongYunfei = Math.Round(zongYunfei, 4);

                string SQL = string.Format("UPDATE EJSH.DLV_FARE t SET ACCAMT =round( (select nvl(sum(i.ratios * i.acreage * i.ACCNUMR),0) from v_bcdx_ct i " +
                "where i.clientid = t.clientid and i.orgcde = t.orgcde and i.PONO = t.pono)/ {0} * {1},2) WHERE PAYSTS = 'N' and ID in({2}) "
                , sumAreas, zongYunfei, idIn);
                if (OracleHelper.ExecuteNonQuery(SQL)>0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    My.ShowErrorMessage("计算运费失败!!");
                }
            }
            else
            {
                My.ShowErrorMessage("数据填写错误!!");
            }
        }
    }
}
