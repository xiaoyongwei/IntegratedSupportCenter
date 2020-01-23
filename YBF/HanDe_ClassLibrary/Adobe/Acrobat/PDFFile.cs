using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace HanDe_ClassLibrary.PrepressFile.Adobe.Acrobat
{
    /// <summary>
    /// 此类提供PDF文件的名称和所在的日期
    /// </summary>
    public class PDFFile
    {
        /// <summary>
        /// PDF文件的名称,包含扩展名,不包括路径名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// PDF文件的全路径名称
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// PDF文件所在的日期
        /// </summary>
        public string Date { get; set; }
        
        /// <summary>
        /// 初始化PDFFile类
        /// </summary>
        /// <param customerName="fileName">PDF文件的全路径</param>
        public PDFFile(string fileName)
        {
            fileName = fileName.Replace('/', '\\');
            FileInfo fileInfo=new FileInfo(fileName);
            this.FullName=fileName;
            this.Name = fileInfo.Name;
            ////确定日期
            //string str = fileInfo.Directory.Parent.FullName;
            //str = str.Substring(str.IndexOf(@"\客户文件\"));
            //string[] objPath = str.Trim('\\').Split('\\');
            //this.Date = objPath[3];
            
        }
    }
}
