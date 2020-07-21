using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 纸箱纸板性能分析.WinForm;

namespace 外购对账审核
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void 数据维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new FormInputPassWord("123456").ShowDialog() == DialogResult.OK)
            {
                new FormWeihu("select * from 外购类型 where ID>0  order by ID", "类型维护").ShowDialog();
            }
        }

        private void 对账表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormDuizhangbiao().ShowDialog();     
        }

        private void 账簿分类ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new FormInputPassWord("123456").ShowDialog()==DialogResult.OK)
            {
                new FormWeihu("select * from 外购对账簿 order by  ID desc limit 20 ", "对账簿维护").ShowDialog(); 
            }


   
        }

        private void 金蝶未入库明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormWeihu("SELECT *FROM [未入库明细top500]ORDER BY [送货日期]desc LIMIT 500", "金蝶未入库明细",true).ShowDialog();
        }
    }
}
