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
    public partial class FormShowData1 : Form
    {
        public string selectRaId = "";
        public FormShowData1(DataTable dt)
        {
            InitializeComponent();
            dataGridView1.DataSource = dt;
        }

        private void FormShowData1_Load(object sender, EventArgs e)
        {

        }

        private void 选定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetSelectId();
        }

        private void SetSelectId()
        {
            if (dataGridView1.SelectedCells.Count>0)
            {
                this.selectRaId = dataGridView1.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SetSelectId();
        }
    }
}
