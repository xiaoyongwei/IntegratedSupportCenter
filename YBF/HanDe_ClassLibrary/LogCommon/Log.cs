using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using HandeJobManager.Common;

namespace HanDe_ClassLibrary.LogCommon
{
    /// <summary>
    /// 日志
    /// </summary>
    public static class Log
    {
        private static readonly string logFile = "Log\\" + DateTime.Now.ToString("yyyyMMdd") + "_Log.xml";

        //public static void WriteLog(string Mess)
        //{
        //    //建立文件夹
        //    if (!Directory.Exists("Log"))
        //    {
        //        Directory.CreateDirectory("Log");
        //    }

        //    XmlDocument xmlDoc = new XmlDocument();//定义XML文档
        //    //建立xml文件
        //    if (!File.Exists(logFile))
        //    {                
        //        XmlDeclaration declaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);//定义声明
        //        xmlDoc.AppendChild(declaration);//添加声明
        //        //添加根节点
        //        XmlElement rootElement = xmlDoc.CreateElement("Errors");
        //        xmlDoc.AppendChild(rootElement);
        //        xmlDoc.Save(logFile);
        //    }

        //    DateTime dt = DateTime.Now;
        //    xmlDoc.Load(logFile);
        //    XmlElement childElement = xmlDoc.CreateElement("event");
        //    childElement.SetAttribute("DateTime", dt.ToString());
        //    childElement.SetAttribute("Description", Mess);
        //    xmlDoc.DocumentElement.AppendChild(childElement);
        //    xmlDoc.Save(logFile);
        //}

        public static void WriteLog(string mess)
        {

            XmlHelper xml = new XmlHelper();

            //建立文件夹
            if (!Directory.Exists("Log"))
            {
                Directory.CreateDirectory("Log");
            }
            //建立xml文件
            if (!File.Exists(logFile))
            {
                xml.CreateXmlDocument(logFile, "Errors", "UTF-8");
            }
            Hashtable ht = new System.Collections.Hashtable();
            ht.Add("Description", mess);
            ht.Add("DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            xml.InsertNode(logFile, "error", true, "Errors", ht, null);
        }

        public static void WriteLog(string mess, Exception ex)
        {

            XmlHelper xml = new XmlHelper();

            //建立文件夹
            if (!Directory.Exists("Log"))
            {
                Directory.CreateDirectory("Log");
            }
            //建立xml文件
            if (!File.Exists(logFile))
            {
                xml.CreateXmlDocument(logFile, "Errors", "UTF-8");
            }
            Hashtable ht = new System.Collections.Hashtable();
            ht.Add("Description", ex.ToString());
            if (string.IsNullOrWhiteSpace(mess))
            {
                ht.Add("Mess", mess + "_");
            }
            ht.Add("DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            xml.InsertNode(logFile, "error", true, "Errors", ht, null);
        }
    }
}
