using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HandeJobManager.Common;
using HandeJobManager.DAL;
using System.Data;

namespace YBF.Class.Comm
{
    [Serializable]
    public static class AppConfig_Local
    {
        public static bool isInit = false;
        /// <summary>
        /// 电脑的mac地址
        /// </summary>
        private static string MacAddress;
        /// <summary>
        /// 已转好的PDF路径
        /// </summary>
        public static string ConversionPdfFolder;
        /// <summary>
        /// 已下单的PDF路径
        /// </summary>
        public static string OrderedPdfFolder;
        /// <summary>
        /// 自动精炼热文件夹路径
        /// </summary>
        public static string RefinePdfHolderFolder;
        /// <summary>
        /// CTP原文件存放路径
        /// </summary>
        public static string CTPYwjFolder;
        /// <summary>
        /// 设计部原文件存放路径
        /// </summary>
        public static List<string> SjbYwjFolder;
        /// <summary>
        /// PDF存档路径
        /// </summary>
        public static List<string> PdfArchiveFolder;
        /// <summary>
        /// Illustrator软件的Dll文件名称
        /// </summary>
        public static string IllustratorDllName;
        /// <summary>
        /// Illustrator软件在注册表中的GUID
        /// </summary>
        public static string IllustratorAppGuid;
        /// <summary>
        /// AI导出PDF的路径
        /// </summary>
        public static string AiToPdfPath;


        public static string GetMacAddress()
        {
            return MacAddress;
        }
        public static string GetConversionPdfFolder()
        {
            return GetPredefinitionString(ConversionPdfFolder.Trim().TrimEnd('\\'));
   
        }

        public static string GetOrderedPdfFolder()
        {
            return GetPredefinitionString(OrderedPdfFolder.Trim().TrimEnd('\\'));
          
        }

        public static string GetRefinePdfHolderFolder()
        {
            return GetPredefinitionString(RefinePdfHolderFolder.Trim().TrimEnd('\\'));
        }

        public static string GetCTPYwjFolder()
        {
            return GetPredefinitionString(CTPYwjFolder.Trim().TrimEnd('\\'));
        }

        public static string GetAiToPdfFolder()
        {
            return GetPredefinitionString(AiToPdfPath.Trim().TrimEnd('\\'));
        }

        public static List<string> GetSjbYwjFolder()
        {
            List<string> list = new List<string>();
            foreach (string item in SjbYwjFolder)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    list.Add(GetPredefinitionString(item.Trim().TrimEnd('\\')));
                }
            }
            return list;
        }
        public static List<string> GetPdfArchiveFolder()
        {
            List<string> list = new List<string>();
            foreach (string item in PdfArchiveFolder)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    list.Add(GetPredefinitionString(item.Trim().TrimEnd('\\')));
                }
            }
            return list;
        }

        /// <summary>
        /// 初始化设置参数
        /// </summary>
        public static void InitAppConfig()
        {
            MacAddress = ComputerComm.GetMacAddress();
            ConversionPdfFolder = "";
            OrderedPdfFolder = "";
            RefinePdfHolderFolder = "";
            CTPYwjFolder = "";
            SjbYwjFolder = new List<string>();
            IllustratorDllName = "";
            IllustratorAppGuid = "";
            PdfArchiveFolder = new List<string>();
            AiToPdfPath = "";

            DataTable dt = SQLiteList.YBF.ExecuteDataTable("SELECT*FROM [设置_本地]WHERE[MacAddress]='" + MacAddress + "'");
            if (dt.Rows.Count == 0)
            {
                InsertInto();
            }
            else
            {
                foreach (DataRow row in dt.Rows)
                {
                    Dictionary<string, string> dic = Comm_Method.GetPredefinitionDic();
                    RefinePdfHolderFolder = row["自动精炼路径"].ToString();
                    CTPYwjFolder = row["CTP原文件路径"].ToString();
                    IllustratorDllName = row["Illustrator_DLL名称"].ToString();
                    IllustratorAppGuid = row["Illustrator_AppGuid"].ToString();
                    SjbYwjFolder = row["设计部文件路径"].ToString().Split('\n').ToList();
                    ConversionPdfFolder = row["已转好PDF"].ToString();
                    OrderedPdfFolder = row["已下单PDF"].ToString();
                    PdfArchiveFolder = row["PDF存档路径"].ToString().Split('\n').ToList();
                    AiToPdfPath = row["AI存PDF路径"].ToString();
                    break;
                }
            }
            isInit = true;
        }

        private static string GetPredefinitionString(string str)
        {
            Dictionary<string, string> dic = Comm_Method.GetPredefinitionDic();
            if (str.Contains('*'))
            {
                foreach (string item in dic.Keys)
                {
                    str = str.Replace(item, dic[item]);
                }
            }
            return str;
        }
        private static string GetListString(List<string> strList)
        {
            string str = "";
            foreach (string item in strList)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    str += (item + "\n");
                }
            }
            return str.Trim();
        }

        public static bool Save()
        {
            string sqlStr = "UPDATE [设置_本地] SET"
     + "[设计部文件路径] = '" + GetListString(SjbYwjFolder) + "'"
     + ",[CTP原文件路径] = '" + CTPYwjFolder.Trim() + "'"
     + ",[自动精炼路径] = '" + RefinePdfHolderFolder.Trim() + "'"
     + ",[已转好PDF] = '" + ConversionPdfFolder.Trim() + "'"
     + ",[已下单PDF] = '" + OrderedPdfFolder.Trim() + "'"
     + ",[PDF存档路径] = '" +GetListString(PdfArchiveFolder) + "'"
     + ",[Illustrator_DLL名称] ='" + IllustratorDllName.Trim() + "'"
     + ",[Illustrator_AppGuid] = '" + IllustratorAppGuid.Trim() + "'"
     + "WHERE [MacAddress] = '" + MacAddress + "';";
            return SQLiteList.YBF.ExecuteSqlTran(new List<string> { sqlStr });

        }

        private static bool InsertInto()
        {
            string sqlStr = string.Format(
                "INSERT INTO [设置_本地]([MacAddress],[设计部文件路径],[CTP原文件路径],[自动精炼路径],[已转好PDF],[已下单PDF],[PDF存档路径],[Illustrator_DLL名称],[Illustrator_AppGuid])VALUES("
                    + "'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}');"
                    , MacAddress
                    , GetListString(SjbYwjFolder)
                    , CTPYwjFolder.Trim()
                    , RefinePdfHolderFolder.Trim()
                    , ConversionPdfFolder.Trim()
                    , OrderedPdfFolder.Trim()
                    , GetListString(PdfArchiveFolder)
                    , IllustratorDllName.Trim()
                    , IllustratorAppGuid.Trim());
            return SQLiteList.YBF.ExecuteSqlTran(new List<string> { sqlStr });
        }
    }
}
