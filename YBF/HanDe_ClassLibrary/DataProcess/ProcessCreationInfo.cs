using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using HandeJobManager.Common;
using HanDe_ClassLibrary.LogCommon;
 

namespace HanDe_ClassLibrary.PrinergyEvoFile.DataProcess
{
    /// <summary>
    /// 印能捷处理作业记录里面的"ProcessCreationInfo.txt"
    /// </summary>
    class ProcessCreationInfoTxt
    {
        public readonly static string FileFullName="ProcessCreationInfo.txt";

        public FileInfo TxtFileInfo { get; set; }

        ProcessCreationInfoTxt(FileInfo fi)
        {
            if (fi.Exists
                &&fi.Extension==".txt")
            {
                this.TxtFileInfo = fi;
            }
        }

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <returns></returns>
        public List<FileInfo> GetFileList()
        {
            List<FileInfo> fileList = new List<FileInfo>();

            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = this.TxtFileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs);

                string allText = sr.ReadToEnd();
                //释放流
                {
                    sr.Close();
                    fs.Close();
                }
                Regex regex = new Regex("\\\\.+", RegexOptions.IgnoreCase);
                foreach (Match item in regex.Matches(allText))
                {
                    fileList.Add(new FileInfo(item.Value));
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
            return fileList;
        }
    }
}
