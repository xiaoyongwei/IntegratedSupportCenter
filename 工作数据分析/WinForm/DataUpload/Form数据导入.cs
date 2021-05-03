using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 工作数据分析.WinForm.DataUpload
{
    public partial class Form数据导入 : Form
    {
        public Form数据导入()
        {
            InitializeComponent();
        }

        private void Form数据导入_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
