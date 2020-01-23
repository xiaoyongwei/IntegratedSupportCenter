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
    public partial class Form各工序订单情况 : Form
    {
        private string[] gongxus = { "总览","甩纸", "胶印", "表处", "裱胶", "压痕", "钉箱", "粘箱" };
        public Form各工序订单情况()
        {
            InitializeComponent();
        }

        private void Form各工序订单情况_Load(object sender, EventArgs e)
        {
            foreach (string gx in gongxus)
            {
                this.treeView.Nodes.Add(gx);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text)
            {
                case "总览":
                    
                default:
                    break;
            }
        }
    }
}
