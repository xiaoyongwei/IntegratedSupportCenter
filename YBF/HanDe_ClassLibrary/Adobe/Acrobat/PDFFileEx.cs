using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

using HandeJobManager.Common;
using HanDe_ClassLibrary.LogCommon;

namespace HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat
{
    /// <summary>
    /// Pdf文件类的扩展类
    /// </summary>
    public class PDFFileEx : PDFFile
    {
        /// <summary>
        /// PDF文件的TrimBox
        /// </summary>
        public string TrimBox { get; set; }

        public PDFFileEx(string fileName)
            : base(fileName)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                FileInfo fileInfo = new FileInfo(fileName);
                //确定trimBox
                fs = fileInfo.OpenRead();
                //确定查找位置
                Int32 readLength = 2*1024 * 1024;//读取2MB
                if (fs.Length > readLength)
                {
                    fs.Seek(-readLength, SeekOrigin.End);
                }

                sr = new StreamReader(fs);

                string seekString = sr.ReadToEnd();
                Regex regex = new Regex(@"CREO_TrimBox\[(-?\d+\.?\d*) (-?\d+\.?\d*) (\d+\.?\d*) (\d+\.?\d*)\]");
                MatchCollection matchs = regex.Matches(seekString);
                //如果没有做版心,则赋值为零
                if (matchs.Count > 0)
                {
                    seekString = matchs[matchs.Count - 1].ToString();

                    GetTrimBox(seekString);
                }
                else
                {
                    
                    char[] chars = new char[readLength];
                    fs.Seek(0, SeekOrigin.Begin);
                    sr = new StreamReader(fs);
                    sr.ReadBlock(chars, 0, readLength);
                    seekString = new string(chars);
                    regex = new Regex(@"CREO_TrimBox\[(-?\d+\.?\d*) (-?\d+\.?\d*) (\d+\.?\d*) (\d+\.?\d*)\]");
                    seekString = regex.Match(seekString).Value;
                    GetTrimBox(seekString);
                }
                if (this.TrimBox==null)
                {
                    this.TrimBox = "0x0";
                }
            }
            catch (Exception ex)
            {
               Log.WriteLog(ex.ToString());
                this.TrimBox = "0x0";
            }
            finally
            {
                if (sr != null)
                {
                    sr.Dispose();
                }
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }


        private void GetTrimBox(string seekString)
        {
            Regex regex = new Regex(@"(-?\d+\.?\d*)");
            MatchCollection matchs = regex.Matches(seekString);
            double x1 = Math.Round(Convert.ToDouble(matchs[0].Value) * Constant.MM_PER_PT, 4);
            double y1 = Math.Round(Convert.ToDouble(matchs[1].Value) * Constant.MM_PER_PT, 4);
            double x2 = Math.Round(Convert.ToDouble(matchs[2].Value) * Constant.MM_PER_PT, 4);
            double y2 = Math.Round(Convert.ToDouble(matchs[3].Value) * Constant.MM_PER_PT, 4);
            this.TrimBox = (x2 - x1).ToString() + "x" + (y2 - y1).ToString();
        }
    }
}
