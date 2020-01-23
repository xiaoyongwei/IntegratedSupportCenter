using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YBF.WinForm.Ywj;
using HandeJobManager.DAL;

namespace YBF.WinForm
{
    public partial class FormYwjSetting : Form
    {
       

        public FormYwjSetting()
        {
            InitializeComponent();
        }

        private void FormYwj_Load(object sender, EventArgs e)
        {
            this.dgv_ywj.Rows.Clear();
            DataTable dt = SQLiteList.YBF.ExecuteDataTable("select * from ywj");
            
            foreach (DataRow dr in dt.Rows)
            {
                int rowIndex = this.dgv_ywj.Rows.Add();
                this.dgv_ywj.Rows[rowIndex].Cells["ColumnID"].Value = dr["ID"];
                this.dgv_ywj.Rows[rowIndex].Cells["ColumnName"].Value = dr["Name"];
                this.dgv_ywj.Rows[rowIndex].Cells["ColumnPath"].Value = dr["Path"];
                this.dgv_ywj.Rows[rowIndex].Cells["ColumnPathMove"].Value = dr["PathMove"];
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            if ( this.dgv_ywj.SelectedRows.Count==0)
            {
                return;
            }
            if ( new FormYwjInformation(
                Convert.ToInt32(this.dgv_ywj.SelectedRows[0].Cells["ColumnID"].Value)
                ).ShowDialog()==DialogResult.OK)
            {
                FormYwj_Load(this, new EventArgs());
            }
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (new FormYwjInformation().ShowDialog()==DialogResult.OK)
            {
                FormYwj_Load(this, new EventArgs());
            }
        }

        private void dgv_ywj_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex<0||e.RowIndex<0)
            {
                return;
            }

        }

        private void tsmiPaiChu_Click(object sender, EventArgs e)
        {
            new FormYwjPaichu().ShowDialog();
        }

      
    }
}
