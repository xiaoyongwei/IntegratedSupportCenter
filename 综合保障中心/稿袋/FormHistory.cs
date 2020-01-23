using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;

namespace 综合保障中心.稿袋
{
    public partial class FormHistory : Form
    {
        string gdh;
        public FormHistory(string gdh)
        {
            this.gdh = gdh;
            InitializeComponent();
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            dgv.DataSource = SQLiteList.GD.ExecuteDataTable(
                    "select * from [历史记录]where[稿袋号]like'" + gdh + "%'ORDER BY [最后修改时间]DESC");
        }
    }
}
