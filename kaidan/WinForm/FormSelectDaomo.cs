using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace kaidan.WinForm
{
    public partial class FormSelectDaomo : Form
    {
        public string selectDaomoBianhao = "";
        private DataTable dt_daomo = new DataTable();
        public FormSelectDaomo(DataTable dt)
        {
            dt_daomo = dt;
            InitializeComponent();
        }

        private void FormSelectDaomo_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            this.dgv.DataSource = dt_daomo;
        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1&&e.ColumnIndex>-1)
            {
                this.selectDaomoBianhao =dgv.Rows[e.RowIndex].Cells["C"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void 选择ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                this.selectDaomoBianhao = cell.OwningRow.Cells["C"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                break;
            }
        }
    }
}
