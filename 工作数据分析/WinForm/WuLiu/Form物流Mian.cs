using System;
using System.Windows.Forms;

namespace 工作数据分析.WinForm.WuLiu
{
    public partial class Form物流Mian : Form
    {
        public Form物流Mian()
        {
            InitializeComponent();
        }

        private void InitDgv()
        {
            //SELECT *FROM `slbz`.`物流_发货通知单`ORDER BY `ID` DESC LIMIT 500
            dgv.DataSource = MySqlDbHelper.ExecuteDataTable("SELECT * FROM `slbz`.`物流_发货通知单` ORDER BY `ID` DESC LIMIT 500");
            dgv.AutoResizeColumns();
        }


        private void 添加报货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form添加报货 add = new Form添加报货();
            if (add.ShowDialog() == DialogResult.OK)
            {
                InitDgv();
            }
        }

        private void 当日报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form物流当日分析().ShowDialog();
        }

        private void Form物流Mian_Load(object sender, EventArgs e)
        {
            InitDgv();
        }
    }
}
