using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 综合保障中心.Comm
{
   public static class My
    {
        /// <summary>
        /// 显示错误弹窗
        /// </summary>
        /// <param name="mess"></param>
        public static void ShowErrorMessage(string mess)
        {
            MessageBox.Show(mess, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
