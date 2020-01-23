using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace HandeJobManager.HanDe_ClassLibrary.Corel
{
    public static class CorelDraw
    {
        public static string GetVersion(string FileFullName)
        {
            string extension = Path.GetExtension(FileFullName);
            string returnString = extension;
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(FileFullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //确定查找位置
                int readLength = 1* 1024;//1kb
                //fs.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(fs);
                string seekString = "";
                if (fs.Length < readLength)
                {
                    seekString = sr.ReadToEnd();
                }
                else
                {
                    char[] chars = new char[readLength];
                    sr.ReadBlock(chars, 0, readLength);
                    seekString = new string(chars);
                }
                    
                if (seekString.Contains("CDr9vrsn"))
                {
                    returnString = ".cdr_9";
                }
            }
            catch 
            {
                 returnString = extension+"_未知";
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

