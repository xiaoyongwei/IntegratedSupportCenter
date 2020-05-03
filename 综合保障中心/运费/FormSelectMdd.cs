using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YBF.Class.Comm;

namespace 综合保障中心.运费
{
    public partial class FormSelectMdd : Form
    {
        //YunfeiMdd mdd = new YunfeiMdd();
        DataTable dt = new DataTable();
        public FormSelectMdd()
        {
            InitializeComponent();
        }

        private void FormSelectMdd_Load(object sender, EventArgs e)
        {
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable
                ("SELECT `区域`,`目的地`,`里程`,`小车`,`大车`FROM `slbz`.`纸箱运费价格表` Order by `选择次数` DESC;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0||e.ColumnIndex<0)
            {
                return;
            }
            DataGridViewRow row = dgv.Rows[e.RowIndex];

            //mdd = new YunfeiMdd();
        }
    }
}
