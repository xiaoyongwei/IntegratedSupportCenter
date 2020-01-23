using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 甩纸数据
{
    public partial class Form筛选数据 : Form
    {
        public Form筛选数据()
        {
            InitializeComponent();
        }

        private void Form筛选数据_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            dateTimePicker_s.Value = DateTime.Now.AddDays(-7);
            dateTimePicker_e.Value = DateTime.Now;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            dgv.DataSource=MySqlDbHelper.ExecuteDataTable(
                string.Format("SELECT * FROM `slbz`.`甩纸数据` where `报工日期` between '{0}' and '{1}' ORDER BY `报工日期` DESC limit 1000"
                ,dateTimePicker_s.Value.ToString("yyyy-MM-dd HH:mm:ss") 
                ,dateTimePicker_e.Value.ToString("yyyy-MM-dd HH:mm:ss")));
            dgv.AutoResizeColumns();
        }
    }
}
