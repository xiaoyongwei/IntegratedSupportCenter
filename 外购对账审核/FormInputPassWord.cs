using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 综合保障中心.Comm;

namespace 外购对账审核
{
    public partial class FormInputPassWord : Form
    {
        private string PassWord;

        public FormInputPassWord()
        {
            InitializeComponent();
        }

        public FormInputPassWord(string passWord)
        {
            InitializeComponent();
            this.PassWord = passWord;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (this.textBoxPw.Text.Trim()==PassWord)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                My.ShowErrorMessage("密码错误!");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
