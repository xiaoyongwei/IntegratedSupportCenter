using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 工作数据分析.WinForm.WuLiu.yunfei
{
    public partial class Form为客户设置地区 : Form
    {
        private string Customer = "";
        public Form为客户设置地区(string customer)
        {
            InitializeComponent();
            this.Customer = customer;
        }

        private void Form为客户设置地区_Load(object sender, EventArgs e)
        {
            InitControls();
        }


        private void comboBoxQuyu_TextChanged(object sender, EventArgs e)
        {

            this.comboBoxMudidi.TextChanged -= comboBoxMudidi_TextChanged;
            this.comboBoxMudidi.Items.Clear();

            foreach (DataRow item in MySqlDbHelper.ExecuteDataTable(
                "SELECT  `目的地` FROM `slbz`.`物流_纸箱运费价格表`where `区域`='" + this.comboBoxQuyu.Text + "'").Rows)
            {
                this.comboBoxMudidi.Items.Add(item["目的地"].ToString());
            }
            if (this.comboBoxMudidi.Items.Count > 0)
            {
                this.comboBoxMudidi.TextChanged += comboBoxMudidi_TextChanged;
                this.comboBoxMudidi.Text = this.comboBoxMudidi.Items[0].ToString();
            }

        }

        private void InitControls()
        {
            this.textBoxKehu.Text = this.Customer;
            this.comboBoxQuyu.TextChanged -= comboBoxQuyu_TextChanged;
            this.comboBoxQuyu.Items.Clear();
            foreach (DataRow item in MySqlDbHelper.ExecuteDataTable("SELECT `区域`FROM `slbz`.`物流_纸箱运费价格表` group by 区域").Rows)
            {
                this.comboBoxQuyu.Items.Add(item[0].ToString());
            }
            if (this.comboBoxQuyu.Items.Count > 0)
            {
                this.comboBoxQuyu.TextChanged += comboBoxQuyu_TextChanged;
                this.comboBoxQuyu.Text = this.comboBoxQuyu.Items[0].ToString();
            }

        }

        private void comboBoxMudidi_TextChanged(object sender, EventArgs e)
        {

            MySqlDataReader reader = MySqlDbHelper.ExecuteReader(
                "SELECT `里程`,`小车`,`大车`FROM `slbz`.`物流_纸箱运费价格表`where `区域`='"
                + this.comboBoxQuyu.Text + "' and 目的地='" + this.comboBoxMudidi.Text + "'");
            if (reader.Read())
            {
                this.textBoxKm.Text = reader["里程"].ToString();
                this.textBoxXiaocheYunfei.Text = reader["小车"].ToString();
                this.textBoxDacheYunfei.Text = reader["大车"].ToString();
            }
            reader.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            InitControls();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string SQL = string.Format("replace into `slbz`.`物流_客户地区对应表`(`客户`,`区域`,`目的地`) VALUES('{0}','{1}','{2}')"
                , this.Customer, this.comboBoxQuyu.Text, this.comboBoxMudidi.Text);
            if (MySqlDbHelper.ExecuteNonQuery(SQL) > 0)
            {
                My.ShowMessage("提交成功!");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                My.ShowErrorMessage("提交失败!");
            }
        }
    }
}
