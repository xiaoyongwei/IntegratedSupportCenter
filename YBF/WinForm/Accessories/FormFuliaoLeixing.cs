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

namespace YBF.WinForm.Accessories
{
    public partial class FormFuliaoLeixing : Form
    {

        private SQLiteDataAdapter da;
        private DataSet ds;

        public FormFuliaoLeixing()
        {
            InitializeComponent();
        }

        private void FormFuliaoLeixing_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            SQLiteConnection myConn = new SQLiteConnection(SQLiteList.YBF.GetConnectionString, true);
            da = new SQLiteDataAdapter("select * from 辅料类型", myConn);
            ds = new DataSet();
            da.Fill(ds);
            myConn.Close();
            this.dgv.DataSource = ds.Tables[0];
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            //剔除空行并将正在编辑的行标记为已完成
            if (this.dgv.CurrentCell != null && this.dgv.CurrentCell.IsInEditMode)
            {
                this.dgv.CurrentCell.Value = this.dgv.CurrentCell.EditedFormattedValue;
            }
            dgv.EndEdit();
            SQLiteCommandBuilder ocb = new SQLiteCommandBuilder(da);
            da.Update(ds);
        }

        private void tsmiReload_Click(object sender, EventArgs e)
        {
            FormFuliaoLeixing_Load(this, new EventArgs());
        }
    }
}
