using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工作数据分析.WinForm.ChengPin
{
    public partial class Form选择入库类型 : Form
    {
        public string RukuLeixing = string.Empty;

        public Form选择入库类型()
        {
            InitializeComponent();
        }

        private void Form选择入库类型_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = MySqlDbHelper.ExecuteDataTable
                ("SELECT `类型`FROM `slbz`.`成品_入库类型表`");
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex<0||e.ColumnIndex<0)
            {
                return;
            }
            RukuLeixing = dataGridView1[0, e.RowIndex].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}
