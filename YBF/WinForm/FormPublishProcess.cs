using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using HanDe_ClassLibrary;
using System.Text.RegularExpressions;
using HanDe_ClassLibrary.Common.Path;
using HandeJobManager.DAL;




namespace HanDe_ToolBox_Form
{
    public partial class FormPublishProcess : Form
    {

        private string SearchTxt = "";
        public FormPublishProcess()
        {
            InitializeComponent();
        }

        private void FormPublishProcess_Load(object sender, EventArgs e)
        {
            
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DateTime dt_s = DateTime.Now;
            // 此列表存放出版记录       
            List<EvoProcessInfo> processList = new List<EvoProcessInfo>(300);

            this.SearchTxt = this.textBox1.Text.Trim();
            string sql =
                "select * from filename where ProcessCreationInfo like'%"
                + this.SearchTxt.Trim() + "%' order by CompleteTime desc limit 100";
            foreach (DataRow row in SQLiteList.BackupProcess.ExecuteDataTable(sql).Rows)
            {
                processList.Add(GetProcessInfoList(row));
            }


            //DataTable
            DataTable dt = new DataTable();
            dt.Columns.Add("提交时间");
            dt.Columns.Add("文件名");
            dt.Columns.Add("板材");
            dt.Columns.Add("Guid");
            dt.Columns.Add("完成时间");


            if (processList.Count < 1)
            {
                MessageBox.Show("没有符合要求的出版记录");
                return;
            }
            foreach (EvoProcessInfo pro in processList)
            {
                if (dt.Select("GUID='" + pro.Guid + "'").Length > 0)
                {
                    continue;
                }
                DataRow dr = dt.NewRow();
                dr["提交时间"] = pro.SubmissionDate.ToString("yyyy-MM-dd HH:mm:ss");
                dr["文件名"] = pro.GetFileNameString();
                dr["板材"] = pro.Plant;
                dr["GUID"] = pro.Guid;
                dr["完成时间"] = pro.CompletionTime.ToString("yyyy-MM-dd HH:mm:ss");

                dt.Rows.Add(dr);

            }

            this.DgvShow.DataSource = dt;
            this.DgvShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvShow.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.DgvShow.Sort(this.DgvShow.Columns["完成时间"], ListSortDirection.Descending);
            MessageBox.Show("查找完毕\n历时：" + (DateTime.Now - dt_s).ToString("hh\\:mm\\:ss"));
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
        }
        private EvoProcessInfo GetProcessInfoList(DataRow row)
        {
            //FileStream fs = null;
            //StreamReader sr = null;
            //List<ProcessInfo> processInfoList = new List<ProcessInfo>();
            EvoProcessInfo process = new EvoProcessInfo();
            try
            {
                string[] AllLine = row["ProcessCreationInfo"].ToString()
                    .Replace("\r\n","\n").Split('\n');
                int index = AllLine[3].IndexOf(':') + 1;
                //提取出时间                    
                string str = AllLine[3].Substring(index).Trim();
                char[] split = new char[] { '-', '.' };
                string[] dateStr = str.Split(split, 8);
                DateTime dateTime = new DateTime(Convert.ToInt32(dateStr[0])
                    , Convert.ToInt32(dateStr[1])
                    , Convert.ToInt32(dateStr[2])
                    , Convert.ToInt32(dateStr[3])
                    , Convert.ToInt32(dateStr[4])
                    , Convert.ToInt32(dateStr[5])
                    );
                process.SubmissionDate = dateTime;
                //提取出GUID
                index = AllLine[2].IndexOf(":") + 1;
                str = AllLine[2].Substring(index).Trim();
                process.Guid = str;

                //提取文件名
                for (int i = 12; i < AllLine.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(AllLine[i]))
                    {
                        continue;
                    }
                    process.FileList.Add(AllLine[i]);

                }
               // process.FileNameString = fileName.Trim();

                //读取里面的所有的内容,保存到字符串

                string allText = row["PrintingToDevice"].ToString();

                int lastIndex;
                //提取板材
                if (string.IsNullOrWhiteSpace(process.Plant))
                {
                    index = allText.IndexOf("/Ct (");
                    lastIndex = allText.IndexOf("\n", index + 2);
                    str = allText.Substring(index, lastIndex - index);
                    //定位下划线
                    index = str.LastIndexOf('_');
                    //定位符合')'
                    lastIndex = str.LastIndexOf(')');
                    str = str.Substring(index + 1, lastIndex - index - 1);
                    Regex regex = new Regex(@"\d+");
                    MatchCollection mc = regex.Matches(str);
                    process.Plant = mc[0].Value + "*" + mc[1].Value;
                }
                //完成时间
                process.CompletionTime = Convert.ToDateTime(row["CompleteTime"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            return process;
        }

        //private List<ProcessInfo> GetProcessInfoList(string searchPath)
        //{
        //    FileStream fs = null;
        //    StreamReader sr = null;
        //    List<ProcessInfo> processInfoList = new List<ProcessInfo>();
        //    ProcessInfo process = null;
        //    try
        //    {

        //        //判断路径是否有效
        //        if (!Directory.Exists(searchPath))
        //        {
        //            return processInfoList;
        //        }


        //        foreach (FileInfo item in new DirectoryInfo(searchPath).GetFiles("*-3{printing-to-device}.out.jtk", SearchOption.AllDirectories))
        //        {
        //            string pubPath = Path.GetDirectoryName(item.DirectoryName);
        //            //声明一个Process实例
        //            process = new ProcessInfo();
        //            //判断ProcessCreationInfo.txt是否存在
        //            string ProcessCreationInfo = pubPath + "\\ProcessCreationInfo.txt";
        //            if (!File.Exists(ProcessCreationInfo))
        //            {
        //                continue;
        //            }
        //            string[] AllLine = File.ReadAllLines(ProcessCreationInfo);
        //            int index = AllLine[3].IndexOf(':') + 1;
        //            //提取出时间                    
        //            string str = AllLine[3].Substring(index).Trim();
        //            char[] split = new char[] { '-', '.' };
        //            string[] dateStr = str.Split(split, 8);
        //            DateTime dateTime = new DateTime(Convert.ToInt32(dateStr[0])
        //                , Convert.ToInt32(dateStr[1])
        //                , Convert.ToInt32(dateStr[2])
        //                , Convert.ToInt32(dateStr[3])
        //                , Convert.ToInt32(dateStr[4])
        //                , Convert.ToInt32(dateStr[5])
        //                );
        //            //对时间进行判断,如果是在要求的时间范围内则继续,如果不是在要求的时间内则跳过
        //            if (dateTime < this.dateTimePickerStart.Value || dateTime > this.dateTimePickerEnd.Value)
        //            {
        //                continue;
        //            }
        //            process.SubmitTime = dateTime;
        //            //提取出GUID
        //            index = AllLine[2].IndexOf(":") + 1;
        //            str = AllLine[2].Substring(index).Trim();
        //            Guid guid = new Guid(str);
        //            process.Guid = guid;

        //            //提取文件名
        //            string fileName = "";
        //            for (int i = 12; i < AllLine.Length; i++)
        //            {
        //                fileName += (GradingPath.ReadFile
        //                    (AllLine[12], 1, Direction.RTL, false)
        //                    + Environment.NewLine);

        //            }
        //            if (fileName.IndexOf(this.SearchTxt, StringComparison.OrdinalIgnoreCase) == -1)
        //            {
        //                continue;
        //            }
        //            process.FileName = fileName.Trim();

        //            //读取里面的所有的内容,保存到字符串
        //            fs = new FileStream(item.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //            sr = new StreamReader(fs);
        //            string allText = sr.ReadToEnd();
        //            sr.Dispose();
        //            fs.Dispose();
        //            int lastIndex;
        //            //提取板材
        //            if (string.IsNullOrWhiteSpace(process.Plates))
        //            {
        //                index = allText.IndexOf("/Ct (");
        //                lastIndex = allText.IndexOf("\n", index + 2);
        //                str = allText.Substring(index, lastIndex - index);
        //                //定位下划线
        //                index = str.LastIndexOf('_');
        //                //定位符合')'
        //                lastIndex = str.LastIndexOf(')');
        //                str = str.Substring(index + 1, lastIndex - index - 1);
        //                Regex regex = new Regex(@"\d+");
        //                MatchCollection mc = regex.Matches(str);
        //                process.Plates = mc[0].Value + "*" + mc[1].Value;
        //            }
        //            //完成时间
        //            process.CompleteTime = item.LastWriteTime;
        //            //判断GUID是否已经存在,并累加数量
        //            int findIndex = processInfoList.FindIndex(gu => gu.Guid.Equals(process.Guid));
        //            if (findIndex < 0)
        //            {
        //                processInfoList.Add(process);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //    finally
        //    {
        //        if (sr != null)
        //        {
        //            sr.Dispose();
        //        }
        //        if (fs != null)
        //        {
        //            fs.Dispose();
        //        }
        //    }
        //    return processInfoList;
        //}

        private void dataGridViewShow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            string guid = this.DgvShow.Rows[e.RowIndex].Cells["GUID"].Value.ToString();
            //object obj = SQLiteDbHelper.ExecuteScalar
            //    ("select PrintingToDevice from filename where ProcessID='" + guid + "';");
            //if (obj!=null&&string.IsNullOrWhiteSpace(obj.ToString()))
            //{
            //    string ptdTxt = obj.ToString();
            //}
            EvoProcessInfo pro = new EvoProcessInfo(guid);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("文件名:\n" + pro.GetFileNameString());
            sb.AppendLine("\n文件所在目录:\n" + pro.GetFileDirectoryNameString());           
            sb.AppendLine("\n板材:" + pro.Plant);
            sb.AppendLine("\n咬口:" + pro.OffsetY);
            sb.AppendLine("\n颜色:\n" + pro.GetColorString());
            sb.AppendLine("\n线数:" + pro.RulingOrFeatureSize);
            sb.AppendLine("\n网点:" + pro.DotShape);
            sb.AppendLine("\n曲线:" + pro.CalibrationTarget);

            MessageBox.Show(sb.ToString(), "作业信息", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

    }
}
