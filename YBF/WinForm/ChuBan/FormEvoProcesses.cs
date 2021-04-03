using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using YBF.HanDe_ClassLibrary.PrinergyEvo;
using HanDe_ToolBox_Form.HanDe_ClassLibrary.PrinergyEvo;
using System.Xml;
using YBF.Class.Comm;
using HanDe_ClassLibrary.LogCommon;

namespace YBF.WinForm.ChuBan
{
    public partial class FormEvoProcesses : Form
    {
        public FormEvoProcesses()
        {
            InitializeComponent();
        }

        private void FormEvoProcesses_Load(object sender, EventArgs e)
        {
            //关闭多余的窗体
            foreach (Form f in this.ParentForm.MdiChildren)
            {
                if (f.Name == this.Name && f.Handle != this.Handle)
                {
                    f.Dispose();
                }
            }


            //***显示印能捷EVo的出版记录
            DataTable dt_evo = GetEvoProcesses();
            if (dt_evo.Rows.Count > 0)
            {
                dgvEvoProcess.DataSource = dt_evo;
                dgvEvoProcess.Sort(dgvEvoProcess.Columns["提交时间"], ListSortDirection.Descending);
                dgvEvoProcess.Columns["文件名"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvEvoProcess.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvEvoProcess.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //***显示PrintConsole工作站文件记录
            DataTable dt_pc = GetPrintConsoleTif();

            if (dt_pc.Rows.Count > 0)
            {
                dgvTifFile.DataSource = dt_pc;
                dgvTifFile.Sort(dgvTifFile.Columns["完成时间"], ListSortDirection.Descending);
                dgvTifFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvTifFile.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            ////确定分割线的位置
            //int dgvEvoRowCount = dgvEvoProcess.RowCount;
            //int dgvTifRowCount = dgvTifFile.RowCount;

            //if (dgvEvoRowCount == 0 || dgvTifRowCount == 0)
            //{
            //    dgvEvoRowCount++;
            //    dgvTifRowCount++;
            //    this.splitContainer1.SplitterDistance =
            //    Convert.ToInt32((1.0 * dgvEvoRowCount / (dgvEvoRowCount + dgvTifRowCount/4)
            //    * this.splitContainer1.Height));
            //}
            //else
            //{
            //    this.splitContainer1.SplitterDistance =
            //    Convert.ToInt32((1.0 * dgvEvoRowCount / (dgvEvoRowCount + dgvTifRowCount/4)
            //    * this.splitContainer1.Height));
            //}
        }

        private void tsmiTongji_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dic_evo = new Dictionary<string, int>();
            foreach (DataGridViewRow row in dgvEvoProcess.SelectedRows)
            {
                string bancai = row.Cells["板材"].Value.ToString();
                int shuliang = Convert.ToInt16(row.Cells["数量"].Value);
                if (dic_evo.ContainsKey(bancai))
                {
                    dic_evo[bancai] += shuliang;
                }
                else
                {
                    dic_evo.Add(bancai, shuliang);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string item in dic_evo.Keys)
            {
                sb.AppendFormat("{0}:{1}张{2}", item, dic_evo[item], Environment.NewLine);
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "印能捷出版记录");
            }
        }



        private void tsmiTifTongji_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dic_evo = new Dictionary<string, int>();
            foreach (DataGridViewRow row in dgvTifFile.SelectedRows)
            {
                string bancai = row.Cells["版材"].Value.ToString();
                if (dic_evo.ContainsKey(bancai))
                {
                    dic_evo[bancai]++;
                }
                else
                {
                    dic_evo.Add(bancai, 1);
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string item in dic_evo.Keys)
            {
                sb.AppendFormat("{0}:{1}张{2}", item, dic_evo[item], Environment.NewLine);
            }
            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "工作站Tif文件记录");
            }
        }


        private DataTable GetEvoProcesses()
        {


            //C:\Program Files (x86)\Kodak\Prinergy Evo 6.1.3.0\historical_data\processes
            //-3{printing-to-hires-file}.out.jtk
            // \\EvoServer\historical_data\processes
            // /CPC_OutputDestination (\\\\192.168.110.33\\PCHotFolders\\1180x1460)
            // /CPC_OutputDestination (\\\\192.168.110.33\\PCHotFolders\\785x1040)
            // /CPC_OutputDestination (//192.168.110.33/PCHotFolders/1180x1460)
            // /CPC_OutputDestination (//192.168.110.33/PCHotFolders/785x1040)
            // done

            DataTable dt_evo = new DataTable();
            try
            {
                //***获取印能捷出版记录
                string[] OutputDestinations ={"\\\\192.168.110.33\\PCHotFolders\\1180x1460",
                                        "\\\\192.168.110.33\\PCHotFolders\\785x1040",
                                        "//192.168.110.33/PCHotFolders/1180x1460",
                                        "//192.168.110.33/PCHotFolders/785x1040"};
                List<EvoPrintingToDeviceProcessInfo> evoInfoList = new List<EvoPrintingToDeviceProcessInfo>();
                foreach (string file in Directory.EnumerateFiles
                    (@"\\192.168.110.32\historical_data\processes",
                    "*-3{printing-to-hires-file}.out.jtk", SearchOption.AllDirectories))
                {
                    EvoPrintingToDeviceProcessInfo evoInfo = new EvoPrintingToDeviceProcessInfo(file, "");
                    if (!evoInfo.IsNull && OutputDestinations.Contains(evoInfo.CPC_OutputDestination))
                    {
                        evoInfoList.Add(evoInfo);
                    }
                }
                //按从晚到早的时间排序
                for (int i = 0; i < evoInfoList.Count - 1; i++)
                {
                    for (int j = i + 1; j <= evoInfoList.Count - 1; j++)
                    {
                        if (evoInfoList[i].SubmissionDate < evoInfoList[j].SubmissionDate)
                        {
                            EvoPrintingToDeviceProcessInfo tempExcel = evoInfoList[i];
                            evoInfoList[i] = evoInfoList[j];
                            evoInfoList[j] = tempExcel;
                        }
                    }
                }
                //***显示印能捷出版记录           
                dt_evo.Columns.Add("提交时间");
                dt_evo.Columns.Add("文件名");
                dt_evo.Columns.Add("板材");
                dt_evo.Columns.Add("颜色");
                dt_evo.Columns.Add("数量");
                dt_evo.Columns.Add("咬口");
                dt_evo.Columns.Add("结束时间");

                foreach (EvoPrintingToDeviceProcessInfo item in evoInfoList)
                {
                    DataRow dr = dt_evo.NewRow();
                    dr["提交时间"] = item.SubmissionDate.ToString("yyyy-MM-dd HH:mm:ss");
                    string filesStr = "";
                    foreach (string file in item.FileFullNameList)
                    {
                        filesStr += (Path.GetFileNameWithoutExtension(file) + Environment.NewLine);
                    }
                    dr["文件名"] = filesStr.Trim();
                    dr["板材"] = item.Plant;
                    string colorsStr = "";
                    foreach (string color in item.ColorList)
                    {
                        colorsStr += (color + ",");
                    }
                    dr["颜色"] = colorsStr.TrimEnd(',');
                    dr["数量"] = item.ColorNumber;
                    dr["咬口"] = item.OffsetY;
                    dr["结束时间"] = item.CompletionTime;
                    dt_evo.Rows.Add(dr);
                }

            }
            catch (Exception ex)
            {
                Comm_Method.ShowErrorMessage(ex.Message);
                Log.WriteLog("读取印能捷Evo记录时出错：", ex);
            }
            return dt_evo;
        }




        /// <summary>
        /// PrintConsole出版情况
        /// </summary>
        /// <param name="eNode">节点对象</param>
        private DataTable GetPrintConsoleTif()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("文件名");
            dt.Columns.Add("版材");
            dt.Columns.Add("完成时间");
            XmlReader reader = null;
            FileStream fs = null;
            try
            {
                Directory.CreateDirectory("Temp");
                File.Copy(@"\\192.168.110.33\Kodak\PrintConsole5\\ProcessedQueue.xml", "Temp\\ProcessedQueue.xml", true);
                string fileName = "Temp\\ProcessedQueue.xml";

                //设置读取xml文档的方式
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;
                settings.IgnoreWhitespace = true;
                settings.ConformanceLevel = ConformanceLevel.Document;

                //读取
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                reader = XmlReader.Create(fs, settings);

                //循环读取
                while (reader.Read())
                {
                    //判断是否是节点并且 名称是否是"ExposureStatusInfo"
                    if (reader.NodeType == XmlNodeType.Element
                        && reader.Name == "ExposureStatusInfo")
                    {
                        DataRow dr = dt.NewRow();
                        reader.ReadToFollowing("ExposureName");
                        dr["文件名"] = reader.ReadString();
                        reader.ReadToFollowing("ExposureStatus");
                        if (reader.ReadString() == "Successful")
                        {
                            reader.ReadToFollowing("EndTime");
                            //string dtstr = reader.ReadString();
                            //string dt_end = Convert.ToDateTime(dtstr).ToString("yyyy-MM-dd HH:mm:ss");
                            dr["完成时间"] = Convert.ToDateTime(reader.ReadString()).ToString("yyyy-MM-dd HH:mm:ss");
                            reader.ReadToFollowing("MediaSizeName");
                            dr["版材"] = reader.ReadString();
                            dt.Rows.Add(dr);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Comm_Method.ShowErrorMessage(ex.Message);
                Log.WriteLog("读取PrintConsole记录时出错：", ex);
            }
            finally
            {

                if (reader != null && reader.ReadState != ReadState.Closed)
                {
                    reader.Close();
                }
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
            return dt;
        }

    }
}
