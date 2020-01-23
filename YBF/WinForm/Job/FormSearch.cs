using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;

namespace YBF.WinForm.Job
{
    public partial class FormSearch : Form
    {
        public string WhereTime = "";
        public string WhereField = "";

        private string[] comboBoxes = 
        { "当日", "7日内", "30日内", "90日内", "300日内","所有", "自定义" };

        public FormSearch()
        {
            InitializeComponent();
            comboBoxDate.Items.AddRange(comboBoxes);
            this.comboBoxDate.Text = "所有";
            WhereTime = "";
            WhereField = "";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            StringBuilder sqlComm = new StringBuilder();

            //时间范围
            DateTime dtStart = this.dateTimePickerStart.Value;
            DateTime dtEnd = this.dateTimePickerEnd.Value;
            //获取时间范围内的作业
            if (comboBoxDate.Text == "所有")
            {
                WhereTime = "";
            }
            else
            {
                WhereTime = string.Format(" ([时间] BETWEEN datetime('{0}') AND  datetime('{1}'))  ",
                              dtStart.ToString("s"), dtEnd.ToString("s"));
            }
            

            if (!string.IsNullOrWhiteSpace(this.textBoxGongdan.Text))
            {
                sqlComm.AppendFormat("AND(工单号 like '%{0}%')", this.textBoxGongdan.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.textBoxGaodai.Text))
            {
                sqlComm.AppendFormat("AND(稿袋号 like '%{0}%')", this.textBoxGaodai.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.textBoxKehu.Text))
            {
                sqlComm.AppendFormat("AND(客户名 like '%{0}%')", this.textBoxKehu.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.textBoxWenjian.Text))
            {
                sqlComm.AppendFormat("AND(文件名 like '%{0}%')", this.textBoxWenjian.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.comboBoxJitai.Text))
            {
                sqlComm.AppendFormat("AND(机台 like '%{0}%')", this.comboBoxJitai.SelectedValue);
            }
            if (!string.IsNullOrWhiteSpace(this.textBoxYaokou.Text))
            {
                sqlComm.AppendFormat("AND(咬口印能捷 like '%{0}%')", this.textBoxYaokou.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.textBoxZzcc.Text))
            {
                sqlComm.AppendFormat("AND(制造尺寸 like '%{0}%')", this.textBoxZzcc.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.textBoxXlcc.Text))
            {
                sqlComm.AppendFormat("AND(下料尺寸 like '%{0}%')", this.textBoxXlcc.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.comboBoxBancaileixing.Text))
            {
                sqlComm.AppendFormat("AND(印版类型 like '%{0}%')", this.comboBoxBancaileixing.Text.Trim());
            }
            if (!string.IsNullOrWhiteSpace(this.textBoxBeizhu.Text))
            {
                sqlComm.AppendFormat("AND(备注 like '%{0}%')", this.textBoxBeizhu.Text.Trim());
            }

            this.WhereField = sqlComm.Length > 5 ? sqlComm.Replace("AND", "", 1, 4).ToString() : sqlComm.ToString();
            this.DialogResult = DialogResult.OK;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if ((control is ComboBox)
                    &&(control.Name==comboBoxJitai.Name||control.Name==comboBoxBancaileixing.Name))
                {
                    ((ComboBox)control).Text = "";
                }
            }
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            comboBoxJitai.DataSource = SQLiteList.YBF.ExecuteDataTable("select [ID],[机台]from[印刷机]");
            comboBoxJitai.ValueMember="ID";
            comboBoxJitai.DisplayMember="机台";
            comboBoxJitai.Text = "";
        }   

        private void buttonClose_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void comboBoxDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dateTimePickerStart.Enabled = false;
            this.dateTimePickerEnd.Enabled = false;
            DateTime time = DateTime.Now.AddDays(1).Date;
            dateTimePickerEnd.Value = time;
            switch (comboBoxDate.Text)
            {
                case "当日":
                    dateTimePickerStart.Value = time.Date;
                    break;
                case "7日内":
                    dateTimePickerStart.Value = time.AddDays(-7).Date;
                    break;
                case "30日内":
                    dateTimePickerStart.Value = time.AddDays(-30).Date;
                    break;
                case "90日内":
                    dateTimePickerStart.Value = time.AddDays(-90).Date;
                    break;
                case "300日内":
                    dateTimePickerStart.Value = time.AddDays(-300).Date;
                    break;
                case "所有":
                    dateTimePickerStart.Value = DateTimePicker.MinimumDateTime;
                    dateTimePickerEnd.Value = DateTimePicker.MaximumDateTime;
                    break;
                default:
                    this.dateTimePickerStart.Enabled = true;
                    this.dateTimePickerEnd.Enabled = true;
                    break;
            }
        }

        private void FormSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBoxJitai.Text = "";
        }
    }
}
