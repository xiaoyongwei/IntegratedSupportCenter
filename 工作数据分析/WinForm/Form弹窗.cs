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
    public partial class Form弹窗 : Form
    {
        public Form弹窗(string ts)
        {
            InitializeComponent();
            label1.Text = ts;
        }

        private void Form弹窗_Load(object sender, EventArgs e)
        {
            //1、在屏幕的右下角显示窗体
            //这个区域不包括任务栏的
            Rectangle ScreenArea = System.Windows.Forms.Screen.GetWorkingArea(this);;
            int width1 = ScreenArea.Width; //屏幕宽度
            int height1 = ScreenArea.Height; //屏幕高度
            this.Location = new System.Drawing.Point(width1 - this.Width, height1 - this.Height); //指定窗体显示在右下角
            this.TopMost = true;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Dispose();
        }
   }
}
