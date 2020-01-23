using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HandeJobManager.DAL;
using YBF.Class.Comm;

namespace YBF.WinForm.Printer
{
    public partial class FormPrintingMachine : Form
    {
        public FormPrintingMachine()
        {
            InitializeComponent();
        }
        private void FormPrintingMachine_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }
            Reload();
        }
        private void tsmiReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            dgv.DataSource = SQLiteList.YBF.ExecuteDataTable("SELECT [印刷机].[ID],[机台],[辅料].[名称] 'PS版材',[咬口外角线],[最大过纸],[最大印刷],[最小过纸],[最小印刷],[印刷机].[启用],[印刷机].[备注],[自动出版提交路径]FROM [印刷机]join [辅料]on[辅料].[ID]=[PS版材]");
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            if (new FormPrintingMachineInformation().ShowDialog() == DialogResult.OK)
            {
                Reload();
            }
        }

        private void tsmiUpdate_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dgv.SelectedCells)
            {
                if (new FormPrintingMachineInformation(Convert.ToInt32(cell.OwningRow.Cells["ID"].Value)).ShowDialog() == DialogResult.OK)
                {
                    Reload();
                }
                break;
            }
           
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (SQLiteList.YBF.ExecuteNonQuery("DELETE FROM [印刷机]WHERE ID="+row.Cells["ID"].Value.ToString())>0)
                {
                    MessageBox.Show("删除成功！");
                    Reload();
                }
                else
                {
                    Comm_Method.ShowErrorMessage("删除失败！");
                }
                break;
            }
        }
       
    }
}
