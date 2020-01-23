using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;

namespace YBF.WinForm.Accessories
{
    public partial class FormFuliaoKucunJilu : Form
    {
        public FormFuliaoKucunJilu()
        {
            InitializeComponent();
        }

        private void FormFuliaoKucunJilu_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
           dgv.DataSource= SQLiteList.YBF.ExecuteDataTable("SELECT [时间],[辅料].[名称],[数量],[摘要],[辅料使用记录].[备注]FROM [辅料使用记录]join [辅料] on [辅料].[ID]=[辅料ID]order by [时间]");
           dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
           dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
