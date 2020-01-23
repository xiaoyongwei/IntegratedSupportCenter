using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using HanDe_ClassLibrary.Common.SizeBox;
using HanDe_ClassLibrary.Common.Unit;
 
using HandeJobManager.HanDe_ClassLibrary.Adobe.Acrobat;
using HandeJobManager.Common;
using HanDe_ClassLibrary.LogCommon;


namespace HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat
{
    public class Acrobat8
    {
        /// <summary>
        /// Acrobat的文件实例
        /// </summary>
        public FileInfo AcrobatFileInfo { get; set; }
        /// <summary>
        /// 初始化一个Acrobat8实例
        /// </summary>
        /// <param customerName="fileInfo">用于初始化属性AcrobatFileInfo的文件实例</param>
        public Acrobat8(FileInfo fileInfo)
        {
            if (fileInfo.Exists
                &&fileInfo.Extension.ToLower()==".pdf")
            {
                this.AcrobatFileInfo = fileInfo;
            }
        }

        /// <summary>
        /// 返回'CREO_TrimBox ',如果文件没有做版心则返回'MediaBox'的尺寸
        /// 如果读取过程出错则返回null.
        /// </summary>
        /// <returns></returns>
        public CREO_TrimBox_MilliMetre GetCREO_TrimBox()
        {
            FileStream fs = null;
            StreamReader sr = null;
            CREO_TrimBox_MilliMetre trimBox = new CREO_TrimBox_MilliMetre
                (new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0));

            try
            {
                FileInfo fileInfo = this.AcrobatFileInfo;
                //确定trimBox
                fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //确定查找位置
                Int32 readLength =3* 1024 * 1024;//读取3072KB(3MB)
                if (fs.Length > readLength)
                {
                    fs.Seek(-readLength, SeekOrigin.End);
                }

                sr = new StreamReader(fs);

                string seekString = sr.ReadToEnd();
                Regex regex = new Regex(@"CREO_TrimBox\[(-?\d+\.?\d*) (-?\d+\.?\d*) (\d+\.?\d*) (\d+\.?\d*)\]");
                MatchCollection matchs = regex.Matches(seekString);
                //找到版心的最后一组数据
                if (matchs.Count > 0)
                {
                    seekString = matchs[matchs.Count - 1].ToString();
                    trimBox = GetTrimBox(seekString);
                    if (trimBox!=null)
                    {
                        trimBox.TrimBox_Type = PdfSizeBox.CREO_TrimBox;
                    }
                    
                }
                else
                {
                    char[] chars = new char[readLength];
                    fs.Seek(0, SeekOrigin.Begin);
                    sr = new StreamReader(fs);
                    sr.Read(chars, 0, readLength);
                    //sr.ReadBlock(chars, 0, readLength);
                    seekString = new string(chars);
                    regex = new Regex(@"CREO_TrimBox\[(-?\d+\.?\d*) (-?\d+\.?\d*) (\d+\.?\d*) (\d+\.?\d*)\]");
                    seekString = regex.Match(seekString).Value;
                    trimBox = GetTrimBox(seekString);
                    if (trimBox!=null)
                    {
                        trimBox.TrimBox_Type = PdfSizeBox.CREO_TrimBox;
                    }
                }
                if (trimBox == null
                    || trimBox.Width.Length == 0
                    || trimBox.High.Length == 0)
                {
                    char[] chars = new char[readLength];
                    fs.Seek(0, SeekOrigin.Begin);
                    sr = new StreamReader(fs);
                    sr.ReadBlock(chars, 0, readLength);
                    seekString = new string(chars);
                    regex = new Regex(@"MediaBox\[(-?\d+\.?\d*) (-?\d+\.?\d*) (\d+\.?\d*) (\d+\.?\d*)\]");
                    seekString = regex.Match(seekString).Value;
                    trimBox = GetTrimBox(seekString);
                    if (trimBox != null)
                    {
                        trimBox.TrimBox_Type = PdfSizeBox.MediaBox;
                    }
                    if (trimBox.Width.Length==0
                        ||trimBox.High.Length==0)
                    {
                        trimBox = null;
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
            return trimBox;
        }

        private CREO_TrimBox_MilliMetre GetTrimBox(string seekString)
        {
            try
            {
                CREO_TrimBox_MilliMetre trimBox = new CREO_TrimBox_MilliMetre
                    (new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0));

                Regex regex = new Regex(@"(-?\d+\.?\d*)");
                MatchCollection matchs = regex.Matches(seekString);
                double x1 = Math.Round(Convert.ToDouble(matchs[0].Value) * ConversionConstant.MM_PER_PT, 4);
                double y1 = Math.Round(Convert.ToDouble(matchs[1].Value) * ConversionConstant.MM_PER_PT, 4);
                double x2 = Math.Round(Convert.ToDouble(matchs[2].Value) * ConversionConstant.MM_PER_PT, 4);
                double y2 = Math.Round(Convert.ToDouble(matchs[3].Value) * ConversionConstant.MM_PER_PT, 4);
                trimBox = new CREO_TrimBox_MilliMetre
                    (new MilliMetre_Unit(y2), new MilliMetre_Unit(y1), new MilliMetre_Unit(x1), new MilliMetre_Unit(x2));
                return trimBox;
            }
            catch
            {
                return null;
            }
            
        }
    }
}
