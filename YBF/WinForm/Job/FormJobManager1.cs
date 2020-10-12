using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using YBF.Class.Comm;
using YBF.Properties;
using 工作数据分析.Data.DAL.Oracle;
using Resources = YBF.Properties.Resources;

namespace YBF.WinForm.Job
{
    public partial class FormJobManager1 : Form
    {
        /// <summary>
        /// PDF文件集合
        /// </summary>
        private FileInfo[] pdfFiles;

        public FormJobManager1()
        {
            InitializeComponent();
        }

        private void FormJobManager1_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }

            //初始化控件
            ControlsInit();
            //使用默认值获取易捷数据
            dgvYijie.DataSource = OracleHelper.ExecuteDataTable(GetSqlByConrrol());
            //获取PDF文件列表
            InitPdfList();
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        private void ControlsInit()
        {
            //日期为一个月内
            dateTimePickerS.Value = DateTime.Now.AddDays(-30);
            dateTimePickerE.Value = DateTime.Now;
            //审核默认为"N-否"
            comboBoxShenhe.SelectedIndex = 0;
            //稿袋号默认为空
            textBoxGdh.Text = "";
            //添加设备控件到集合中
            this.comboBoxShebei.Items.Add("全部");
            foreach (DataRow item in OracleHelper.ExecuteDataTable("SELECT MACNME 设备 FROM EJSH.V_ORD_SCH  WHERE  ORGCDE='KS03' and OBJTYP='CL'and OSTATUS='Y'  AND PRCTYPNME='胶印凹印' AND MACNME IS  NOT  null  GROUP BY MACNME").Rows)
            {
                this.comboBoxShebei.Items.Add(item[0].ToString());
            }
            //设备默认为全部
            this.comboBoxShebei.SelectedIndex = 0;
            //客户默认为空
            this.textBoxKehu.Text = "";
            //产品默认为空
            this.textBoxChanpin.Text = "";
        }

        /// <summary>
        /// 根据各个控件查询条件生成SQL查询语句
        /// </summary>
        private string GetSqlByConrrol(int limit=500)
        {
            //SQL查询语句
            StringBuilder sb = new StringBuilder(Resources.SQLYijie);

            //开单日期
            sb.Append(" AND to_char( ptdate, 'yyyy-mm-dd' ) >= '" + dateTimePickerS.Value.ToString(dateTimePickerS.CustomFormat)+"' ");
            sb.Append(" AND to_char( ptdate, 'yyyy-mm-dd' ) <= '" + dateTimePickerE.Value.ToString(dateTimePickerE.CustomFormat) + "' ");
            //审核
            sb.AppendFormat(" AND PLTSTS ='{0}' ", this.comboBoxShenhe.Text[0] == 'Y' ? "Y" : "N");
            //稿袋号
            if (!string.IsNullOrWhiteSpace(this.textBoxGdh.Text))
            {
                sb.AppendFormat(" AND SPCSHW like '%{0}%'", this.textBoxGdh.Text.Trim());
            }
            //设备
            if (this.comboBoxShebei.Text!="全部")
            {
                sb.AppendFormat(" AND MACNME = '{0}' ", this.comboBoxShebei.Text);
            }
            //客户
            if (!string.IsNullOrWhiteSpace(this.textBoxKehu.Text))
            {
                sb.AppendFormat(" AND SMPNME like '%{0}%'", this.textBoxKehu.Text.Trim());
            }
            //产品
            if (!string.IsNullOrWhiteSpace(this.textBoxChanpin.Text))
            {
                sb.AppendFormat(" AND prdnme like '%{0}%'", this.textBoxChanpin.Text.Trim());
            }
            //数据行数限制
            if (limit<1 || limit > 500)
            {
                limit = 500;
            }
            sb.AppendFormat(" AND ROWNUM<=" + limit);


            //返回数据
            return sb.ToString();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //根据各个查询条件生成SQL查询语句
            string sql = GetSqlByConrrol();

            dgvYijie.DataSource = OracleHelper.ExecuteDataTable(sql);

            //重新获取PDF文件集合
            if (dgvYijie.Rows.Count>0)
            {
                InitPdfList();
            }
            
        }

        private void InitPdfList()
        {
            string pdfPath = @"\\EvoServer\JobData\PDF";
            if (Comm_Method.IsConnectPath(pdfPath))
            {
                pdfFiles = new DirectoryInfo(pdfPath).GetFiles("*.pdf", System.IO.SearchOption.AllDirectories);
            }

        }

       

        private void dgvYijie_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            //获取产品名称
            string cpmc = dgvYijie.Rows[e.RowIndex].Cells["产品"].Value.ToString();
            //获取稿袋号
            string gdh = dgvYijie.Rows[e.RowIndex].Cells["稿袋号"].Value.ToString();
            //****根据产品名称获取与其匹配度最高的PDF文件****
            //1.建立一个表格
            DataTable dt = new DataTable();
            dt.Columns.Add("匹配", System.Type.GetType("System.Decimal"));
            dt.Columns.Add("文件名");
            dt.Columns.Add("修改时间");
            dt.Columns.Add("大小MB");
            dt.Columns.Add("路径");
            //2.遍历PDF并与之匹配,
            //匹配的条件1:如果文件名包含稿袋号则匹配度加0.5,并且继续第2步
            //条件2:字符串相似匹配度要在0.5(50%)以上的才能添加到候选表格中,匹配度按字符串相似度累加


            //开始遍历
            foreach (FileInfo file in pdfFiles)
            {
                //匹配度
                double ppd = 0;

                //1.先判断文件是否包含稿袋号
                //如果稿袋号为空则直接第二步
                if (!string.IsNullOrWhiteSpace(gdh)
                    && Regex.IsMatch(Path.GetFileNameWithoutExtension(file.Name), "^" + gdh))
                {
                    ppd += 0.5;
                }

                //2.比较2个字符串的相似度
                double xsd = Comm_Method.Similarity(cpmc, Path.GetFileNameWithoutExtension(file.Name));
                //匹配度累加
                ppd += xsd;

                //如果匹配度度在0.5以上则添加候选
                if (ppd > 0.5)
                {
                    //新行
                    DataRow dr = dt.NewRow();
                    dr["匹配"] = ppd;
                    dr["文件名"] = file.Name;
                    dr["修改时间"] = file.LastWriteTime;
                    dr["大小MB"] = Math.Round(1.0 * file.Length / 1024 / 1024, 3);
                    dr["路径"] = file.DirectoryName;
                    dt.Rows.Add(dr);//添加行                    
                }
            }
            //dt.DefaultView.Sort = "匹配 DESC";
            ////dgvPdf.DataSource = dt;
            ////dgvPdf.AutoResizeColumns();










            //listViewFile
            this.listViewFile.Items.Clear();


            //开始遍历
            foreach (DataRow dr in dt.Select("1=1", "匹配 DESC"))
            {
                //新行
                    ListViewItem lvi = new ListViewItem(
                        new string[]{
                        dr["匹配"].ToString(),
                        dr["文件名"].ToString(),
                        dr["修改时间"].ToString(),
                        dr["大小MB"].ToString(),
                        dr["路径"].ToString()
                    });
                    this.listViewFile.Items.Add(lvi);
                
            }
            this.listViewFile.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        /// <summary>
        /// 打开文件夹或文件
        /// </summary>
        private void OpenListViewTtem()
        {

            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                string newPath = item.Tag.ToString();
                //判断是目录还是文件
                if (File.Exists(newPath))
                    Process.Start(newPath); //打开文件
            }

            //if (listViewFile.SelectedItems.Count > 0)
            //{
            //    string newPath = listViewFile.SelectedItems[0].Tag.ToString();
            //    //判断是目录还是文件
            //    if (File.Exists(newPath))
            //        Process.Start(newPath); //打开文件
            //}

        }

        #region Drag and drop
        /// <summary>
        /// Called when we start dragging an item out of our listview
        /// </summary>
        private void listViewFile_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            string[] files = GetSelection();
            if (files != null)
            {
                DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy /* | DragDropEffects.Move | DragDropEffects.Link */);
            }
        }
        /// <summary>
        /// Routine to get the current selection from the listview
        /// </summary>
        /// <returns>Seletced items or null if no selection</returns>
        private string[] GetSelection()
        {
            if (listViewFile.SelectedItems.Count == 0)
                return null;

            string[] files = new string[listViewFile.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in listViewFile.SelectedItems)
            {
                string fileFullName = item.Tag.ToString();
                if (Comm_Method.IsConnectPath(fileFullName))
                {
                    files[i++] = fileFullName;
                }
            }
            return files;
        }
        #endregion

        private void listViewFile_ItemActivate(object sender, EventArgs e)
        {
            OpenListViewTtem();
        }
    }
}
