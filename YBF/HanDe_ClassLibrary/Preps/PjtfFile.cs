using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HanDe_ClassLibrary.Common.SizeBox;
using HanDe_ClassLibrary.Common.Unit;
using System.Text.RegularExpressions;
using HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat;
using HandeJobManager.Common;
using HanDe_ClassLibrary.LogCommon;
 

namespace HanDe_ClassLibrary.PrinergyEvoFile.Preps
{
    public class PjtfFile
    {
        public FileInfo PjtfFileInfo { get; set; }

        public PjtfFile(FileInfo fileInfo)
        {
            if (fileInfo.Exists
                && fileInfo.Extension.ToLower() == ".pjtf"
                && fileInfo.Length > 1024)
            {
                this.PjtfFileInfo = fileInfo;
            }
        }

        /// <summary>
        /// 获取第一个PDF文件的版心
        /// </summary>
        /// <returns></returns>
        public CREO_TrimBox_MilliMetre GetFirstPageTrim()
        {
            FileStream fs = null;
            StreamReader sr = null;
            CREO_TrimBox_MilliMetre trimBox = new CREO_TrimBox_MilliMetre
                (new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0));

            try
            {
                FileInfo fileInfo = this.PjtfFileInfo;
                //确定trimBox
                fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                
                string seekString = sr.ReadToEnd();
                //释放流
                {
                    sr.Close();
                    fs.Close();
                }
                Regex regex = new Regex(@"/CPC_PageTrim \[(\d+\.?\d* ){2}\]");
                //找到第一组数据
                Match match = regex.Match(seekString);
                if (match.Success)
                {
                    regex = new Regex(@"\d+\.?\d*");
                    MatchCollection mc = regex.Matches(match.Value);
                    if (mc.Count == 2)
                    {
                        trimBox = new CREO_TrimBox_MilliMetre(
                            new MilliMetre_Unit(Convert.ToDouble(mc[1].Value)*ConversionConstant.MM_PER_PT)
                            , new MilliMetre_Unit(0)
                            , new MilliMetre_Unit(0)
                            , new MilliMetre_Unit(Convert.ToDouble(mc[0].Value) * ConversionConstant.MM_PER_PT)
                                );
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


        /// <summary>
        /// 获取pjtf的印刷纸张大小
        /// </summary>
        /// <returns></returns>
        public CREO_TrimBox_MilliMetre GetPressSheetSize()
        {
            FileStream fs = null;
            StreamReader sr = null;
            CREO_TrimBox_MilliMetre trimBox = new CREO_TrimBox_MilliMetre
                (new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0), new MilliMetre_Unit(0));

            try
            {
                FileInfo fileInfo = this.PjtfFileInfo;
                //确定trimBox
                fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                string seekString = sr.ReadToEnd();
                //释放流
                {
                    sr.Close();
                    fs.Close();
                }
                Regex regex = new Regex(@"/SSiPS \[(\d+\.?\d* ){4}\]");
                //找到表示'印刷纸张大小'的数据,经过测试:这个数据是唯一的,不存在第二个数据
                Match match = regex.Match(seekString);
                if (match.Success)
                {
                    regex = new Regex(@"\d+\.?\d*");
                    MatchCollection mc = regex.Matches(match.Value);
                    if (mc.Count == 4)
                    {
                        trimBox = new CREO_TrimBox_MilliMetre(
                            new MilliMetre_Unit(Convert.ToDouble(mc[3].Value) * ConversionConstant.MM_PER_PT)
                            , new MilliMetre_Unit(0)
                            , new MilliMetre_Unit(0)
                            , new MilliMetre_Unit(Convert.ToDouble(mc[2].Value) * ConversionConstant.MM_PER_PT)
                                );
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

       
    }
}
