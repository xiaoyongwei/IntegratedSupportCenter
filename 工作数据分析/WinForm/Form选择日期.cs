using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 工作数据分析.WinForm
{
    public partial class Form选择日期 : Form
    {
        /// <summary>
        /// 开始日期
        /// </summary>
        private DateTime dTime_S;
        /// <summary>
        /// 结束日期
        /// </summary>
        private DateTime dTime_E;
        /// <summary>
        /// true表示开始日期和结束日期始终保持一致
        /// false表示开始日期和结束日期不一致
        /// </summary>
        private bool isEndIsStart=true;

        /// <summary>
        /// 实例化选择日期窗口
        /// true表示开始日期和结束日期始终保持一致
        /// false表示开始日期和结束日期不一致
        /// </summary>
        /// <param name="isEndIsStart"></param>
        public Form选择日期(bool isEndIsStart)
        {
            InitializeComponent();
            this.isEndIsStart = isEndIsStart;
            dTime_S = new DateTime();
            dTime_E = new DateTime();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No; 
        }

        private void 确定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dTime_S = monthCalendar1.SelectionRange.Start;
            dTime_E = monthCalendar1.SelectionRange.End;
            this.DialogResult = DialogResult.OK;
        }

        private void Form选择日期_Load(object sender, EventArgs e)
        {
            monthCalendar1.TodayDate = DateTime.Now;
            textBox_S.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            textBox_E.Text = monthCalendar1.SelectionEnd.ToString("yyyy-MM-dd");
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.SelectionEnd = isEndIsStart? monthCalendar1.SelectionStart:monthCalendar1.SelectionEnd ;
            textBox_S.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            textBox_E.Text = monthCalendar1.SelectionEnd.ToString("yyyy-MM-dd");
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            monthCalendar1.SelectionEnd = isEndIsStart? monthCalendar1.SelectionStart:monthCalendar1.SelectionEnd ;
            textBox_S.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            textBox_E.Text = monthCalendar1.SelectionEnd.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// 获取开始时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime_S()
        {
            return dTime_S;
        }
        /// <summary>
        /// 获取结束时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetDateTime_E()
        {
            return dTime_E;
        }
    }
}
