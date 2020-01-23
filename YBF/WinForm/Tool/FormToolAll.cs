using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using YBF.Class.Comm;

namespace YBF.WinForm.Tool
{
    public partial class FormToolAll : Form
    {
        public FormToolAll()
        {
            InitializeComponent();
        }

        private void buttonKillJPrinterJTP_Click(object sender, EventArgs e)
        {
            Stop_JPrinterJTP("128.1.30.144");
        }

        private void buttonKillJPrinterJTP_xiaoji_Click(object sender, EventArgs e)
        {
            Stop_JPrinterJTP("128.1.130.31");
        }

        private void Stop_JPrinterJTP(string ip)
        {
            if (MessageBox.Show("确定要停止进程'JPrinterJTP'吗?"
              + "\n\n以下进程将受影响:"
              + "\n1.打印到设备"
              + "\n2.打印到高分辨率文件"
              + "\n3.打印到低分辨率文件", "确认?"
              , MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show(Comm_Method.ExecuteCom("taskkill /S "+ip+" /U Administrator /P creo /IM JPrinterJTP.exe",true));
            }
        }
    }
}
