using System;
using System.Windows.Forms;
using 工作数据分析.Data.DAL.Oracle;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.WuLiu.yunfei
{
    public partial class Form拼车距离弹窗 : Form
    {
        private string ID = string.Empty;
        public Form拼车距离弹窗(String id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            double km = 0;
            double.TryParse(this.textBoxKm.Text, out km);
            if (km > 0)
            {
                if (SetPinCheFei(km))
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    My.ShowErrorMessage("修改拼车费失败!!!");
                    DialogResult = DialogResult.None;
                }

            }
            else
            {
                My.ShowErrorMessage("拼车距离错误!!!\n必须是大于0的有效小数或整数");
                DialogResult = DialogResult.None;
            }
        }

        /// <summary>
        /// 设置拼车费
        /// </summary>
        private bool SetPinCheFei(double km)
        {
            string SQL = string.Format("UPDATE FERP.DLV_FARE "
            + " SET ANNAMT2 = NVL(ANNAMT2, 0) + (case when {0} > 5 then round(20 + ({0} - 5) * 2,2) ELSE 20 End) "
            + " ,USMARK = USMARK || '{2}拼车距离{0}km+' || (case when {0} > 5 then round(20 + ({0} - 5) * 2,2) ELSE 20 End)|| ',' "
            + " WHERE PAYSTS = 'N' AND(usmark NOT like '%拼车%' OR USMARK IS null)   and ID = {1}", km, ID, this.textBoxMiaosu.Text.Trim());

            return OracleHelper.ExecuteNonQuery(SQL) > 0;
        }

        private void Form拼车距离弹窗_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.textBoxMiaosu.Text.Trim() + "拼车距离" + this.textBoxKm.Text.Trim() + "km+***,");
        }
    }
}
