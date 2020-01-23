using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 外购对账审核
{
    public partial class FormInputText : Form
    {
        public string wsgdh = "";
        public FormInputText()
        {
            InitializeComponent();
            //this.SongHuoDan = songhuodan;
            //this.GongDan = gongdan;
        }

        private void FormInputText_Load(object sender, EventArgs e)
        {

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            wsgdh = this.textBoxInput.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}
