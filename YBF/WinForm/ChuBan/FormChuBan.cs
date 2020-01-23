using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using YBF.Class.Model;
using YBF.Class.Comm;
using System.Globalization;
using HandeJobManager.DAL;
using excelToTable_NPOI;

namespace YBF.WinForm.ChuBan
{
    public partial class FormChuBan : Form
    {
         Dictionary<string, string> dic_jitai = new Dictionary<string, string>();
        //null_2017_06_11
        private string Path_Excel = "D:\\Users\\Downloads";
        public FormChuBan()
        {
            InitializeComponent();
        }

        private void tsmiInit_Click(object sender, EventArgs e)
        {
            //初始化
            Init();
        }

        private void Init()
        {
            this.treeViewExcel.Nodes.Clear();
            this.dgvJob.DataSource = new DataTable();
            List<ExcelFileInfo> excelFileList = new List<ExcelFileInfo>();
            Regex regex = new Regex("null_\\d+_\\d+_\\d+.*\\.xls", RegexOptions.IgnoreCase);
            foreach (string excelFile in
                Directory.EnumerateFiles(Path_Excel, "*.xls"))
            {
                //符合要求的文件
                if (regex.IsMatch(excelFile)
                    && File.GetCreationTime(excelFile) >= DateTime.Now.AddMonths(-1))
                {
                    excelFileList.Add(new ExcelFileInfo(excelFile));
                }
            }
            //按从晚到早的时间排序
            for (int i = 0; i < excelFileList.Count - 1; i++)
            {
                for (int j = i + 1; j <= excelFileList.Count - 1; j++)
                {
                    if (excelFileList[i].CreateTime < excelFileList[j].CreateTime)
                    {
                        ExcelFileInfo tempExcel = excelFileList[i];
                        excelFileList[i] = excelFileList[j];
                        excelFileList[j] = tempExcel;
                    }
                }
            }
            //保留最近的15项
            int lastNum = 15;
            if (excelFileList.Count > lastNum)
            {
                excelFileList.RemoveRange(lastNum, excelFileList.Count - lastNum);
            }
            //将排序好的显示在treeView中
            foreach (ExcelFileInfo excelFile in excelFileList)
            {
                TreeNode tn = new TreeNode(
                    Path.GetFileNameWithoutExtension(excelFile.FileFullName));
                tn.Tag = excelFile;
                this.treeViewExcel.Nodes.Add(tn);
            }
        }

        private void FormChuBan_Load(object sender, EventArgs e)
        {
            ////关闭多余的窗体
            //foreach (Form f in this.ParentForm.MdiChildren)
            //{
            //    if (f.Name == this.Name && f.Handle != this.Handle)
            //    {
            //        f.Dispose();
            //    }
            //}

            dic_jitai.Add("高宝162", "904");
            dic_jitai.Add("罗兰9047", "904");
            dic_jitai.Add("罗兰9055", "905");
            dic_jitai.Add("罗兰双色", "罗双");
            dic_jitai.Add("罗兰700", "700");
            dic_jitai.Add("罗兰704", "700");
            dic_jitai.Add("罗兰705", "700");
            dic_jitai.Add("良明750", "750");
            dic_jitai.Add("良明660", "660");
            
            //初始化
            Init();
        }

        private void tsmiShow_Click(object sender, EventArgs e)
        {
            this.dgvJob.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dgvJob.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //this.dgvJob.Rows.Clear();
            List<DataTable> dtList = new List<DataTable>();
            foreach (TreeNode item in this.treeViewExcel.Nodes)
            {
                if (item.Checked)
                {
                    ExcelFileInfo excel = item.Tag as ExcelFileInfo;
                    DataTable dt = Comm_Method.GetPublishDataTableFromExcelFile(excel.FileFullName);
                    if (dt!=null&&dt.Rows.Count>0)
                    {
                        dtList.Add(dt);
                    }
                }
            }
            
            if (dtList.Count <1)
            {              
                return;
            }

           // AddToDgv(dtList);


            //**********
            DataTable dtAll = dtList[0].Clone();
            foreach (DataTable item in dtList)
            {
                dtAll.Merge(item);
            }
           //删除重复的数据
            for (int i = dtAll.Rows.Count-1; i >0; i--)
            {
                bool isCome = true;
                foreach (DataRow row in dtAll.Rows)
                {
                    foreach (DataColumn column in dtAll.Columns)
                    {
                        if (!dtAll.Rows[i][column].ToString().Equals(row[column].ToString()))
                        {
                            isCome = false;
                            break;
                        }
                    }
                    if (isCome)
                    {
                        break;
                    }
                }
                if (isCome)
                {
                    dtAll.Rows.RemoveAt(i);
                }
            }

            this.dgvJob.DataSource = dtAll;

            this.dgvJob.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvJob.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void AddToDgv(List<DataTable> dtList)
        {            
            this.dgvJob.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            this.dgvJob.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            if (dtList.Count<1)
            {
                return;
            }
            foreach (DataColumn dc in dtList[0].Columns)
            {
                this.dgvJob.Columns.Add("column" + PinYinConverter.Get(dc.ColumnName), dc.ColumnName);
            }

            foreach (DataTable dt in dtList)
            {
                foreach (DataRow row in dt.Rows)
                {
                    int rowIndex = this.dgvJob.Rows.Add();
                    foreach (DataColumn col in dt.Columns)
                    {
                        this.dgvJob["column" + PinYinConverter.Get(col.ColumnName), rowIndex].Value
                            = row[col].ToString();
                    }
                    //this.dgvJob["ColumnExcelFile", rowIndex].Value= dt.TableName;
                    //this.dgvJob["ColumnPublished", rowIndex].Value = false;
                }
            }
            
            this.dgvJob.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvJob.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private string FirstToUp(string text)
        {
            return text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1);

        }

        private void treeViewExcel_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.Checked = !e.Node.Checked;
        }

        //private void tsmiChuBan_Click(object sender, EventArgs e)
        //{
        //    //获取选择到的列和行
        //    List<int>  selectRows= new List<int>();
        //   // List<int> selectColumns = new List<int>();

        //    foreach (DataGridViewCell cell in this.dgvJob.SelectedCells)
        //    {
        //        if (!selectRows.Contains(cell.RowIndex))
        //        {
        //            selectRows.Add(cell.RowIndex);
        //        }
        //        //if (!selectColumns.Contains(cell.ColumnIndex))
        //        //{
        //        //    selectColumns.Add(cell.ColumnIndex);
        //        //}
        //    }
        //    List <string> sqlList=new List<string>() ;
        //    foreach (int selectRowIndex in selectRows)
        //    {                
        //        DataGridViewRow dgvr = this.dgvJob.Rows[selectRowIndex];
        //        string InsertString = "INSERT INTO [JobPublished]([gdh],[sjjt],"
        //                + "[khjc],[cpmc],[zzcc],[mzcc],[ss1],[ss2],[sbs],[bz],[yk],"
        //                + "[ExcelFile],[Published])VALUES("
        //                +"'" +this.dgvJob["ColumnGdh", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnSjjt", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnKhjc", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnCpmc", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnZzcc", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnMzcc", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnSs1", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnSs2", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnSbs", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnBz", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnYk", selectRowIndex].Value.ToString() + "',"
        //                + "'" + this.dgvJob["ColumnExcelFile", selectRowIndex].Value.ToString() + "',"
        //                + 1+");";
        //        sqlList.Add(InsertString);
        //    }
        //    SQLiteList.YbfSQLite.ExecuteSqlTran(sqlList);
        //}

        private void tsmiStatistics_Click(object sender, EventArgs e)
        {            
            List<DataTable> dtList = new List<DataTable>();
            foreach (TreeNode item in this.treeViewExcel.Nodes)
            {
                try
                {
                    if (item.Checked)
                    {
                        ExcelFileInfo excel = item.Tag as ExcelFileInfo;
                        DataTable dt = Comm_Method.GetPublishDataTableFromExcelFile(excel.FileFullName);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dtList.Add(dt);
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
            if (dtList.Count>0)
            {
                DataTable dtAll = dtList[0].Clone();
                foreach (DataTable item in dtList)
                {
                    dtAll.Merge(item);
                }
                //分类汇总               
                Dictionary<string, int> dicCount = new Dictionary<string, int>();
                foreach (DataRow row in dtAll.Rows)
                {
                    try
                    {
                        string jitai = row["上机机台"].ToString();
                        if (dic_jitai.ContainsKey(jitai))
                        {
                            jitai = dic_jitai[jitai];
                        }
                        int shuliang = Convert.ToInt32(row["晒版数"]);
                        if (dicCount.ContainsKey(jitai))
                        {
                            dicCount[jitai] += shuliang;
                        }
                        else
                        {
                            dicCount.Add(jitai, shuliang);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                //显示数量
                StringBuilder sb = new StringBuilder();
                int sum = 0;
                foreach (string key in dicCount.Keys)
                {
                    sb.AppendLine(key + ":" + dicCount[key]);
                    sum += dicCount[key];
                }
                if (sum>0&&sb.Length>0)
                {
                    sb.AppendLine("------------");
                    sb.AppendLine("  共计："+sum);
                }
                MessageBox.Show(sb.ToString());
            }
            else 
            {
                return;
            }
        }

        FormFindOld findOld = null;
        private void tsmiSearchFile_Click(object sender, EventArgs e)
        {
            if (this.dgvJob.SelectedCells.Count>0)
            {
                DataGridViewRow row=this.dgvJob.SelectedCells[0].OwningRow;
                JobInfo job = new JobInfo();
                job.Sjjt = row.Cells["上机机台"].Value.ToString();
                job.Khjc = row.Cells["客户简称"].Value.ToString();
                job.Cpmc = row.Cells["产品名称"].Value.ToString();
                job.Zzcc = row.Cells["制造尺寸"].Value.ToString();
                job.Mzcc = row.Cells["面纸尺寸"].Value.ToString();
                job.Ss1 = row.Cells["色数1"].Value.ToString();
                job.Ss2 = row.Cells["色数2"].Value.ToString();

                
                findOld = new FormFindOld(job);
                findOld.WindowState = FormWindowState.Maximized;
                findOld.MdiParent = this.ParentForm;
                findOld.Show();
            }
        }

        private void tsmiBaoBiao_Click(object sender, EventArgs e)
        {
           char[] InvalidFileNameChars= Path.GetInvalidFileNameChars();
            string[] pdfFiles = Directory.GetFiles(@"\\128.1.30.144\JobData\pdf\已下单PDF"
                , "*.pdf", SearchOption.AllDirectories);
            List<DataTable> dtList = new List<DataTable>();
            foreach (TreeNode item in this.treeViewExcel.Nodes)
            {
                if (item.Checked)
                {
                    ExcelFileInfo excel = item.Tag as ExcelFileInfo;
                    DataTable dt = Comm_Method.GetPublishDataTableFromExcelFile(excel.FileFullName);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        dtList.Add(dt);
                    }
                }
            }
            if (dtList.Count > 0)
            {
                DataTable dtAll = dtList[0].Clone();
                foreach (DataTable item in dtList)
                {
                    dtAll.Merge(item);
                }
                

                //剔除旧版
                DataTable dt_baobiao = new DataTable();
                dt_baobiao.Columns.Add("日期");
                dt_baobiao.Columns.Add("产品名称");
                dt_baobiao.Columns.Add("制造尺寸");
                dt_baobiao.Columns.Add("面纸尺寸");
                dt_baobiao.Columns.Add("输出颜色");
                dt_baobiao.Columns.Add("网线");
                dt_baobiao.Columns.Add("机台");
                dt_baobiao.Columns.Add("咬口");
                dt_baobiao.Columns.Add("备注");
                foreach (DataRow row in dtAll.Select("备注<>'旧版'"))
                {
                    DataRow newRow = dt_baobiao.NewRow();
                    newRow["日期"] = DateTime.Now.AddHours(-6).ToString("yyyy-MM-dd");
                    //newRow["产品名称"] = row["客户简称"].ToString()+row["产品名称"].ToString();
                   // newRow["产品名称"] = pdfFiles.First<string>(pp => pp.Contains(row["产品名称"].ToString()));
                    newRow["制造尺寸"]=row["制造尺寸"].ToString().Replace('x','*');
                    newRow["面纸尺寸"] = row["面纸尺寸"].ToString().Replace('x', '*');                   
                    newRow["网线"]="175";
                    string jitai = row["上机机台"].ToString();
                    newRow["机台"] = dic_jitai.ContainsKey(jitai) ? dic_jitai[jitai] : jitai;
                    newRow["咬口"] = "";
                    newRow["备注"] = "";

                    //***确认产品名称
                    string cpmc = row["产品名称"].ToString().Replace('*', 'x');
                    bool cunzai = false;
                    foreach (string pdffile in pdfFiles)
                    {
                        foreach (char Invalid in InvalidFileNameChars)
                        {
                           cpmc= cpmc.Replace(Invalid, '-');
                        }
                        if (pdffile.ToLower().Contains(cpmc.ToLower()))
                        {
                            cpmc = Path.GetFileNameWithoutExtension(pdffile);
                            cunzai = true;
                            break;
                        }
                    }
                    if (cunzai)
                    {
                        newRow["产品名称"] = cpmc;
                    }
                    else
                    {
                        newRow["产品名称"] ="【【" +cpmc+"】】";
                    }
                    
                    //输出颜色
                    string scys = "";
                    string ss1 = row["色数1"].ToString();
                    string ss2 = row["色数2"].ToString();
                    if (ss1=="4")
                    {
                        scys = "CMYK";                        
                    }
                    if (!string.IsNullOrWhiteSpace(ss2))
                    {
                        if (ss2 == "1")
                        {
                            scys +=( string.IsNullOrWhiteSpace(ss1)?"专":"+专");
                        }
                        else
                        {
                            string zs = string.Format("{0}专", ss2);
                            scys += (string.IsNullOrWhiteSpace(ss1) ? zs : "+"+zs);
                        }

                    }
                    newRow["输出颜色"] = scys;

                    //进行AB面完全一致的判断
                    bool isAB = false;
                    foreach (DataRow row_Baobiao in dt_baobiao.Rows)
                    {
                        isAB = IsABside(row_Baobiao, newRow);
                        if (isAB)
                        {
                            if (row_Baobiao["输出颜色"].ToString().Contains('+'))
                            {
                                row_Baobiao["输出颜色"] = "(" + row_Baobiao["输出颜色"] + ")*2";
                            }
                            else
                            {
                                row_Baobiao["输出颜色"] = row_Baobiao["输出颜色"] +"*2";
                            }
                            row_Baobiao["产品名称"] = row_Baobiao["产品名称"].ToString().Replace("B面", "A面").Replace("b面", "A面");
                            break;
                        }
                        
                    }
                    if (isAB)
                    {
                        continue;
                    }
                    dt_baobiao.Rows.Add(newRow);
                }
                new FormBaoBiao(dt_baobiao).ShowDialog();
            }
            else
            {
                return;
            }
        }

        private bool IsABside(DataRow Adr, DataRow Bdr)
        {
            return
            (Adr["产品名称"].ToString().Replace("A面", "B面").Equals(Bdr["产品名称"].ToString(), StringComparison.CurrentCultureIgnoreCase)
            || Adr["产品名称"].ToString().Replace("B面", "A面").Equals(Bdr["产品名称"].ToString(), StringComparison.CurrentCultureIgnoreCase))
                && Adr["机台"].ToString().Equals(Bdr["机台"].ToString(), StringComparison.CurrentCultureIgnoreCase)
                && Adr["制造尺寸"].ToString().Equals(Bdr["制造尺寸"].ToString(), StringComparison.CurrentCultureIgnoreCase)
                //&& Adr["面纸尺寸"].ToString().Equals(Bdr["面纸尺寸"].ToString(), StringComparison.CurrentCultureIgnoreCase)
                && Adr["输出颜色"].ToString().Equals(Bdr["输出颜色"].ToString(), StringComparison.CurrentCultureIgnoreCase);           
               
        }

        private void tsmiStatistics1_Click(object sender, EventArgs e)
        {
            tsmiStatistics_Click(this, new EventArgs());
        }

        private void tsmiBaoBiao1_Click(object sender, EventArgs e)
        {
            tsmiBaoBiao_Click(this, new EventArgs());
        }

        private void tsmiSelectAllNode_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in this.treeViewExcel.Nodes)
            {
                tn.Checked = !tn.Checked;
            }
        }

        private void FormChuBan_SizeChanged(object sender, EventArgs e)
        {
            int size = 0;
            foreach (TreeNode tn in this.treeViewExcel.Nodes)
            {
                if (tn.Text.Length>size)
                {
                    size = tn.Text.Length;
                }
            }
            if (size>0)
            {
                this.splitContainer1.SplitterDistance = size*7 + 10;
            }
            
         
        }


    }
}
