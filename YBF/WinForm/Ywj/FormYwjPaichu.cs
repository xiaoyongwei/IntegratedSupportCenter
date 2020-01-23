using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using HandeJobManager.DAL;

namespace YBF.WinForm.Ywj
{

    public partial class FormYwjPaichu : Form
    {

        private SQLiteDataAdapter da;
        private DataSet ds;

        public FormYwjPaichu()
        {
            InitializeComponent();
        }

        private void FormYwjPaichu_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //剔除空行并将正在编辑的行标记为已完成
            if (this.dgvPcmd.CurrentCell != null && this.dgvPcmd.CurrentCell.IsInEditMode)
            {
                this.dgvPcmd.CurrentCell.Value = this.dgvPcmd.CurrentCell.EditedFormattedValue;
            }

            SQLiteCommandBuilder ocb = new SQLiteCommandBuilder(da);
            da.Update(ds);
        }

        //true表示无效.false标识有效.
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {

            if (!this.dgvPcmd.CurrentCell.IsInEditMode && keyData == Keys.Escape)
            {
               this.Dispose();
            }

            return false;
        }

        private void tsmiReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            SQLiteConnection myConn = new SQLiteConnection(SQLiteList.YBF.GetConnectionString, true);
            da = new SQLiteDataAdapter("select * from Ywj_PaiChu  ", myConn);
            ds = new DataSet();
            da.Fill(ds);
            myConn.Close();
            this.dgvPcmd.DataSource = ds.Tables[0];
        }
    }
}
