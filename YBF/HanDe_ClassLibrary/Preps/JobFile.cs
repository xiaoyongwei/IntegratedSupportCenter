using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat;
using HandeJobManager.Common;
using HanDe_ClassLibrary.Common.Unit;
using HanDe_ClassLibrary.LogCommon;
 

namespace HanDe_ClassLibrary.PrinergyEvoFile.Preps
{
    /// <summary>
    /// 此类提供了job文件的读取,包括连接的pdf和可能需要印刷的颜色
    /// </summary>
    public  class JobFile
    {


        /// <summary>
        /// pdf文件的绝对路径
        /// </summary>
        public string PdfFullPath { get; set; }

        /// <summary>
        /// pdf文件的绝对路径
        /// </summary>
        public string PdfFullPath_0 { get; set; }

        /// <summary>
        /// 出血
        /// </summary>
        private readonly string bleed = Math.Round(20 / ConversionConstant.MM_PER_PT, 5).ToString();
        /// <summary>
        /// 模板名称
        /// </summary>
        public string TplName { get; set; }
        /// <summary>
        /// 帖名
        /// </summary>
        public string Sign { get; set; }
        ///// <summary>
        ///// 水平偏移量
        ///// </summary>
        //public double HorShift { get; set; }
        ///// <summary>
        ///// 垂直偏移量
        ///// </summary>
        //public double VerShift { get; set; }
        /// <summary>
        /// job文件绝对路径
        /// </summary>
        public string JobFileFullPath { get; set; }

        /// <summary>
        /// 实例化一个JobFile对象
        /// </summary>
        /// <param customerName="pdfFullPath">pdf文件的绝对路径</param>
        /// <param customerName="tplName">模板名称</param>
        /// <param customerName="sign">帖名</param>
        public JobFile(string pdfFullPath, string tplName, string sign)
        {
            this.PdfFullPath_0 = pdfFullPath;
            //pdf文件绝对路径---@"//" + Environment.MachineName + "/" +
            this.PdfFullPath = Uri.EscapeDataString(pdfFullPath).Replace("%5C", @"/");
            //模板名称
            this.TplName = tplName;
            // 帖名
            this.Sign = sign;
            //job文件绝对路径
            this.JobFileFullPath = Path.GetDirectoryName(Path.GetDirectoryName(pdfFullPath)) + "\\out\\" + Path.GetFileNameWithoutExtension(pdfFullPath) + ".job";
            ////水平偏移量
            //this.HorShift = horShift;
            ////垂直偏移量
            //this.VerShift = verShift;
        }

        /// <summary>
        /// 生成job文件
        /// </summary>
        /// <returns></returns>
        public bool MakeJob()
        {
            try
            {
                string jobCon = "%!PS\r\n% This: Job Map File: 【job文件绝对路径】\r\n%%FileEncoding: 134217984\r\n%%Creator: Preps 5.3.2   Windows Win32\r\n%SSiPrepsVer: 1\r\n%SSiJobFileRef: 6 'file:【PDF文件绝对路径】' 6 1012682840 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 1012682840\r\n%SSiJobFileRef: -1 'Blank Page' 0 0 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 -1\r\n%SSiJobFileRef: -2 'LW/CT Single' 0 0 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 -1\r\n%SSiJobFileRef: -3 'LW/CT Reader Left' 0 0 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 -1\r\n%SSiJobFileRef: -4 'LW/CT Reader Right' 0 0 0 0.00000 0.00000 0.00000 0.00000 0.00000 0.00000 1.00000 0 -1\r\n%SSiJobPage: 6 1 0 0 1.00000 1.00000 3 0.00000 0.00000 '' 1 -1 1\r\n%SSiLaySpecs: 0 0 0.00000 0.00000 '' 0.00000 0.00000 0.00000 0.00000 1.00000 1.00000 【出血】 0 '' '' '' 4 1 1 '' 0\r\n%SSiSigUsed: '出版模板:【模板名称】' '【帖名】' 0 0 '' '' '' 10.00000 '' '' '' '' '' 0 0\r\n%SSiJobDelivery: 1 1 1 1 0\r\n%SSiWindowSize: 1 0 0 200 800 4271986 \r\n%SSiWindowSize: 2 230 0 200 800 4271986 \r\n%SSiWindowSize: 3 460 0 200 800 4271986 \r\n%SSiJobColor: 'Composite' 150.00000 45.00000 -1 0.00000 0.00000 0.00000 0.00000 0 0 0.00000 0.00000 0.00000 0.00000 150.00000 45.00000\r\n%SSiJobColor: 'Process Cyan' 150.00000 105.00000 -1 0.00000 0.00000 0.00000 0.00000 1 2 1.00000 0.00000 0.00000 0.00000 150.00000 105.00000\r\n%SSiJobColor: 'Process Magenta' 150.00000 75.00000 -1 0.00000 0.00000 0.00000 0.00000 2 2 0.00000 0.00000 0.00000 0.00000 150.00000 75.00000\r\n%SSiJobColor: 'Process Yellow' 150.00000 90.00000 -1 0.00000 0.00000 0.00000 0.00000 3 2 0.00000 0.00000 0.00000 0.00000 150.00000 90.00000\r\n%SSiJobColor: 'Process Black' 150.00000 45.00000 -1 0.00000 0.00000 0.00000 0.00000 4 2 0.00000 0.00000 0.00000 1.00000 150.00000 45.00000\r\n";
                jobCon = jobCon.Replace("【job文件绝对路径】", this.JobFileFullPath);
                jobCon = jobCon.Replace("【PDF文件绝对路径】", this.PdfFullPath);
                jobCon = jobCon.Replace("【出血】", this.bleed);
                jobCon = jobCon.Replace("【模板名称】", this.TplName);
                jobCon = jobCon.Replace("【帖名】", this.Sign);

                //创建目录
                if (!Directory.Exists(Path.GetDirectoryName(JobFileFullPath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(JobFileFullPath));
                }
                File.WriteAllText(this.JobFileFullPath, jobCon);
            }
            catch (Exception ex)
            {
                Log.WriteLog("",ex);
                return false;
            }
            return true;
        }


        public FileInfo JobFileInfo { get; set; }

        /// <summary>
        /// 初始化一个JobFile实例
        /// </summary>
        /// <param customerName="fileInfo"></param>
        public JobFile(FileInfo fileInfo)
        {
            if (fileInfo.Exists
                && fileInfo.Extension.ToLower() == ".job"
                && fileInfo.Length < 10 * 1024 * 1024)
            {
                this.JobFileInfo = fileInfo;
            }
        }

        /// <summary>
        /// 获取job里面的pdf文件列表
        /// </summary>
        /// <returns></returns>
        public List<Acrobat8> GetPdfList()
        {
            FileStream fs = null;
            StreamReader sr = null;
            List<Acrobat8> acrobat8List = new List<Acrobat8>();

            try
            {
                fs = new FileStream(this.JobFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs);

                string allText = sr.ReadToEnd();
                //释放流
                {
                    sr.Close();
                    fs.Close();
                }

                Regex regex = new Regex("//.*.pdf",RegexOptions.IgnoreCase);
                foreach (Match item in regex.Matches(allText))
                {
                    string temp =Uri.UnescapeDataString( item.Value);
                    acrobat8List.Add(new Acrobat8(new FileInfo(temp)));
                }

            }
            catch (Exception ex)
            {
               Log.WriteLog(ex.ToString());
                
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                } 
            }
            return acrobat8List;
        }


        /// <summary>
        /// 获取job里面的颜色列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetColorList()
        {
            FileStream fs = null;
            StreamReader sr = null;
            List<string> colorList = new List<string>();

            try
            {
                fs = new FileStream(this.JobFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs);

                string allText = sr.ReadToEnd();
                //释放流
                {
                    sr.Close();
                    fs.Close();
                }

                Regex regex = new Regex("%SSiJobColor: '.*'");
                foreach (Match item in regex.Matches(allText))
                {
                    if (item.Value == @"%SSiJobColor: 'Composite'")
                    {
                        continue;
                    }
                    Regex reg = new Regex("'.*'");
                    string temp = reg.Match(item.Value).Value.Trim('\'');
                    if (colorList.IndexOf(temp) < 0)
                    {
                        colorList.Add(temp);
                    }
                }

            }
            catch (Exception ex)
            {
               Log.WriteLog(ex.ToString());

            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return colorList;
        }
    }
}
