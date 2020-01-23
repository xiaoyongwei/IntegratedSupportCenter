using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace HandeJobManager.HanDe_ClassLibrary.Adobe
{
    public static class PostScriptFile
    {
        public static string GetLanguageLevel(string fileFullName)
        {
            string extension=Path.GetExtension(fileFullName);
            string returnString = extension;
             FileStream fs = null;
            StreamReader sr = null;

            try{

            fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    //确定查找位置
                    int readLength = 1 * 1024 * 1024;                   
                    //fs.Seek(0, SeekOrigin.Begin);
                    sr = new StreamReader(fs);
                    string seekString = "";
                    if (fs.Length<readLength)
                    {
                        seekString = sr.ReadToEnd();
                    }
                    else
                    {
                        char[] chars = new char[readLength];
                        sr.ReadBlock(chars, 0, readLength);
                        seekString = new string(chars);
                    }
                    
                    Regex regex = new Regex(@"%%LanguageLevel: \d");
                    MatchCollection matchs = regex.Matches(seekString);
                    //找到版心的最后一组数据
                    if (matchs.Count > 0)
                    {
                        string ai = new Regex(@"\d").Match(matchs[0].Value).Value;
                        returnString = extension + "(语言" + ai + ")";
                    }
                    else
                    {
                        returnString = extension + "(没有)";
                    }
                }

            
            catch 
            {
                returnString = extension + "(错误)";
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
                if (sr != null)
                {
                    sr.Dispose();
                }
            }
            return returnString;
        }
    }
}
