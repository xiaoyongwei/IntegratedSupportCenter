using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 综合保障中心.其它
{
    public partial class FormSelectDateTime : Form
    {
        public FormSelectDateTime()
        {
            InitializeComponent();
        }


        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            this.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            this.DialogResult = DialogResult.OK;
        }
    }
}
