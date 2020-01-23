using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 工作数据.winForm.每日数据
{
    public partial class Form每日数据汇总 : Form
    {
        public Form每日数据汇总()
        {
            InitializeComponent();
        }

        private void Form每日数据汇总_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            GetDataLast100();
        }

        /// <summary>
        /// 获取最近100条数据
        /// </summary>
        private void GetDataLast100()
        {
           dgv.DataSource=MySqlDbHelper.ExecuteDataTable("SELECT * FROM `slbz`.`每日数据` ORDER BY `日期` DESC LIMIT 100");
        }

    }
}
