using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YBF.Class.Comm;

namespace YBF.WinForm
{
    public partial class FormAppSetting : Form
    {
        FolderBrowserDialog FolderBrowser = new FolderBrowserDialog();

        public FormAppSetting()
        {
            InitializeComponent();
        }

        private void FormAppSetting_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            AppConfig_Local.InitAppConfig();
            //[设计部文件路径]
            foreach (string item in AppConfig_Local.SjbYwjFolder)
            {
                this.listViewSjbYwj.Items.Add(item);
            }
            //[CTP原文件路径]
            this.textBoxCtpYwj.Text = AppConfig_Local.CTPYwjFolder;
            //[自动精炼路径]
            this.textBoxZidongJinglian.Text = AppConfig_Local.RefinePdfHolderFolder;
            //[已转好PDF]
            this.textBoxConvertedPDF.Text = AppConfig_Local.ConversionPdfFolder;
            //[已下单PDF]
            this.textBoxOrderedPdf.Text = AppConfig_Local.OrderedPdfFolder;
        }

        private bool IsRemove()
        {
            return MessageBox.Show("确定要移除吗？", "移除？", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
        /// <summary>
        /// 往ListView中添加项
        /// </summary>
        /// <param name="listView"></param>
        private void AddListViewPath(ListView listView)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                foreach (ListViewItem item in listView.Items)
                {
                    if (item.Text == FolderBrowser.SelectedPath)
                    {
                        Comm_Method.ShowErrorMessage("路径：" + FolderBrowser.SelectedPath + "\n已经存在！");
                        return;
                    }
                }
                listView.Items.Add(FolderBrowser.SelectedPath);
            }
        }
        /// <summary>
        /// 移除ListView中选中的项
        /// </summary>
        /// <param name="listView"></param>
        private void RemoveListViewPath(ListView listView)
        {
            if (listView.Items.Count != 0 && IsRemove())
            {
                foreach (ListViewItem lvi in listView.SelectedItems)
                {
                    listView.Items.Remove(lvi);
                }
            }
        }
        /// <summary>
        /// 往TextBox中添加路径
        /// </summary>
        /// <param name="textBox"></param>
        private void AddTextBoxPath(TextBox textBox)
        {
            if (FolderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (textBox.Text == FolderBrowser.SelectedPath)
                {
                    Comm_Method.ShowErrorMessage("路径：" + FolderBrowser.SelectedPath + "\n已经存在！");
                    return;
                }
            }
            textBox.Text = FolderBrowser.SelectedPath;
        }

        private void buttonSjbYwjAdd_Click(object sender, EventArgs e)
        {
            AddListViewPath(listViewSjbYwj);
        }

        private void buttonSjbYwjRemove_Click(object sender, EventArgs e)
        {
            RemoveListViewPath(listViewSjbYwj);
        }

        private void buttonCtpYwj_Click(object sender, EventArgs e)
        {
            AddTextBoxPath(textBoxCtpYwj);
        }

        private void buttonZidongJinglian_Click(object sender, EventArgs e)
        {
            AddTextBoxPath(textBoxZidongJinglian);
        }

        private void buttonConvertedPDF_Click(object sender, EventArgs e)
        {
            AddTextBoxPath(textBoxConvertedPDF);
        }

        private void buttonOrderedPdf_Click(object sender, EventArgs e)
        {
            AddTextBoxPath(textBoxOrderedPdf);
        }
        private void buttonOrderedPdfFolderAdd_Click(object sender, EventArgs e)
        {
            AddListViewPath(listViewArchivePdfFolder);
        }

        private void buttonOrderedPdfFolderRemove_Click(object sender, EventArgs e)
        {
            RemoveListViewPath(listViewArchivePdfFolder);
        }
        private void buttonArchivePdfFolderAdd_Click(object sender, EventArgs e)
        {
            AddListViewPath(listViewArchivePdfFolder);
        }

        private void buttonArchivePdfFolderRemove_Click(object sender, EventArgs e)
        {
            RemoveListViewPath(listViewArchivePdfFolder);
        }


        private void buttonHelp_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<string, string> dic = Comm_Method.GetPredefinitionDic();
            foreach (string item in dic.Keys)
            {
                sb.AppendLine(item + ":" + dic[item]);
            }
            MessageBox.Show(sb.ToString());
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            //[设计部文件路径]
            foreach (ListViewItem item in listViewSjbYwj.Items)
            {
                list.Add(item.Text);
            }
            AppConfig_Local.SjbYwjFolder = list;
            //[CTP原文件路径]
            AppConfig_Local.CTPYwjFolder = this.textBoxCtpYwj.Text.Trim();
            //[自动精炼路径]
            AppConfig_Local.RefinePdfHolderFolder = this.textBoxZidongJinglian.Text.Trim();
            //[已转好PDF]            
            AppConfig_Local.ConversionPdfFolder = this.textBoxConvertedPDF.Text.Trim();
            //[已下单PDF]            
            AppConfig_Local.OrderedPdfFolder = this.textBoxOrderedPdf.Text.Trim();
            //[PDF存档路径]
            list=new List<string>();
            foreach (ListViewItem item in this.listViewArchivePdfFolder.Items)
            {                
                if (!string.IsNullOrWhiteSpace(item.Text))
                {
                    list.Add(item.Text);
                }
            }
            AppConfig_Local.PdfArchiveFolder = list;


            if (AppConfig_Local.Save())
            {
                this.Dispose();
            }
            else
            {
                Comm_Method.ShowErrorMessage("保存失败");
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            StringBuilder sb_all = new StringBuilder();
            StringBuilder sb = new StringBuilder();

            foreach (ListViewItem item in listViewSjbYwj.Items)
            {
                sb.AppendLine(Comm_Method.GetCustoString(item.Text));
            }
            if (sb.Length > 0)
            {
                sb_all.AppendLine("设计部原文件路径:");
                sb_all.AppendLine(sb.ToString());
            }
            sb.Clear();
            if (!string.IsNullOrWhiteSpace(textBoxCtpYwj.Text))
            {
                sb_all.AppendLine("CTP原文件路径:");
                sb_all.AppendLine(Comm_Method.GetCustoString(textBoxCtpYwj.Text));
                sb_all.AppendLine();
            }
            if (!string.IsNullOrWhiteSpace(textBoxZidongJinglian.Text))
            {
                sb_all.AppendLine("自动精炼PDF路径:");
                sb_all.AppendLine(Comm_Method.GetCustoString(textBoxZidongJinglian.Text));
                sb_all.AppendLine();
            }
            if (!string.IsNullOrWhiteSpace(textBoxConvertedPDF.Text))
            {
                sb_all.AppendLine("已转好PDF路径:");
                sb_all.AppendLine(Comm_Method.GetCustoString(textBoxConvertedPDF.Text));
                sb_all.AppendLine();
            }
            if (!string.IsNullOrWhiteSpace(textBoxOrderedPdf.Text))
            {
                sb_all.AppendLine("已下单PDF路径:");
                sb_all.AppendLine(Comm_Method.GetCustoString(textBoxOrderedPdf.Text));
                sb_all.AppendLine();
            }
            sb.Clear();
            foreach (ListViewItem item in listViewArchivePdfFolder.Items)
            {
                sb.AppendLine(Comm_Method.GetCustoString(item.Text));
            }
            if (sb.Length > 0)
            {
                sb_all.AppendLine("存档的PDF路径:");
                sb_all.AppendLine(sb.ToString());
            }

            if (sb_all.Length>0)
            {
                MessageBox.Show(sb_all.ToString());
            }
        }

        
       

    }
}
