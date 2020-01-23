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
    /// 印能捷处理作业记录里面的"-3{customerName-to-device}.out.jtk"
    /// </summary>
    public class PrintingToDeviceOutJtk
    {
        public readonly static string FileRegexName = @"\d+-3{customerName-to-device}.out.jtk";

        public FileInfo PrintingToDeviceFileInfo { get; set; }

        public PrintingToDeviceOutJtk(FileInfo fi)
        {
            if (fi.FullName.IndexOf("-3{customerName-to-device}.out.jtk") > 0
                && fi.Exists)
            {
                this.PrintingToDeviceFileInfo = fi;
            }
        }

        /// <summary>
        /// 获取出版颜色列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetPublishColorList()
        {
            List<string> colorList = new List<string>();

            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = this.PrintingToDeviceFileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs);

                string allText = sr.ReadToEnd();
                //释放流
                {
                    sr.Close();
                    fs.Close();
                }
                Regex regex = new Regex(@"/.*\]/CP \[", RegexOptions.IgnoreCase);
                allText = regex.Match(allText).Value.Replace(@"]/CP [", "");
                //提取颜色
                regex = new Regex(@"/\S+");
                foreach (Match item in regex.Matches(allText))
                {
                    colorList.Add(item.Value.Trim().Trim('/'));
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
