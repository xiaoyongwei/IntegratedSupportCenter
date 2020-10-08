using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using excelToTable_NPOI;
using YBF.Properties;
using System.Management;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Reflection;

namespace YBF.Class.Comm
{
    //常用的通用类
    public static class Comm_Method
    {
        /// <summary>
        /// Illustrator文件列表
        /// </summary>
        public static List<string> AiFileList = new List<string>();
        public static DataTable Table_Excel = new DataTable();
        private static DateTime LastTime_Excel = DateTime.MinValue;
        public static List<string> PdfFileList = new List<string>();
        public static void Init_Tabel_Excel()
        {
            string ExcelFile = "D:\\资料\\出版记录表.xlsx";
            // string ExcelFile = "E:\\SOFTWARE\\CTP输出记录表000.xlsx";
            DateTime ExcelFileLastTime = File.GetLastWriteTime(ExcelFile);
            if (ExcelFileLastTime > LastTime_Excel)
            {
                Table_Excel = new ExcelHelper(ExcelFile)
                .ExcelToDataTable(null, true, true);
                LastTime_Excel = ExcelFileLastTime;
            }
        }
        public static void Init_PdfFileList()
        {
            PdfFileList.Clear();
            string[] OldFilePaths = { @"\\EvoServer\JobData\PDF\已下单PDF" };
            StringBuilder sb_error = new StringBuilder();
            foreach (string path in OldFilePaths)
            {
                if (Comm_Method.IsConnectPath(path))
                {
                    PdfFileList.AddRange(Directory.GetFiles(path, "*.pdf", System.IO.SearchOption.AllDirectories));
                }
                else
                {
                    sb_error.AppendLine(path);
                }
                
            }
            //PdfFileList.AddRange(Directory.GetFiles(@"\\128.1.30.144\JobData\pdf\已下单PDF", "*.pdf",SearchOption.AllDirectories));
            if (sb_error.Length>0)
            {
                sb_error.AppendLine("以上路径找不到。");
                ShowErrorMessage(sb_error.ToString());
            }
        }


        /// <summary>
        /// 显示错误弹窗
        /// </summary>
        /// <param name="mess"></param>
        public static void ShowErrorMessage(string mess)
        {
            MessageBox.Show(mess, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //根据excle的路径把第一个sheel中的内容放入datatable
        public static DataTable ReadExcelToTable(string path)//excel存放的路径
        {
            try
            {

                //连接字符串
                string connstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; // Office 07及以上版本 不能出现多余的空格 而且分号注意
                //string connstring = Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=NO;IMEX=1';"; //Office 07以下版本 
                using (OleDbConnection conn = new OleDbConnection(connstring))
                {
                    conn.Open();
                    DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
                    string firstSheetName = sheetsName.Rows[0][2].ToString(); //得到第一个sheet的名字
                    string sql = string.Format("SELECT * FROM [{0}]", firstSheetName); //查询字符串
                    //string sql = string.Format("SELECT * FROM [{0}] WHERE [日期] is not null", firstSheetName); //查询字符串

                    OleDbDataAdapter ada = new OleDbDataAdapter(sql, connstring);
                    DataSet set = new DataSet();
                    ada.Fill(set);
                    set.Tables[0].TableName = Path.GetFileNameWithoutExtension(path);
                    return set.Tables[0];
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static DataTable GetPublishDataTableFromExcelFile(string excelFileFullName)
        {
            DataTable dt = new ExcelHelper(excelFileFullName).ExcelToDataTable(null, false, true); ;
            
            //if (dt == null || dt.Rows.Count == 0)
            //{
            //    FileSystem.DeleteFile(excelFileFullName);
            //    return dt;
            //}
            //****删除空白行******
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                bool isEmptyRow = true;
                foreach (DataColumn dc in dt.Columns)
                {
                    object obj = dt.Rows[i][dc];
                    if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
                    {
                        isEmptyRow = false; break;
                    }
                }
                if (isEmptyRow)
                {
                    dt.Rows.RemoveAt(i);
                }
                else
                {
                    //***删除有“打印人”、“印版房”、“打印日期”的列，基本是最后一列了

                    string rowText = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        rowText += dt.Rows[i][dc];
                    }
                    if (rowText.Contains("打印人")
                        && rowText.Contains("打印日期"))
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
            }
            //删除第一列和最后一列，因为是空白的
            dt.Columns.RemoveAt(0);
            dt.Columns.RemoveAt(dt.Columns.Count - 1);

            ////****删除空白列******
            //for (int i = dt.Columns.Count-1; i >= 0; i--)
            //{
            //    bool isEmptyColumn = true;
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        object obj = dr[i];
            //        if (obj != null && !string.IsNullOrWhiteSpace(obj.ToString()))
            //        {
            //            isEmptyColumn = false; break;
            //        }
            //    }
            //    if (isEmptyColumn)
            //    {
            //        dt.Columns.RemoveAt(i);
            //    }
            //}



            //dt.Rows.RemoveAt(0);//删除首行
            //dt.Columns.RemoveAt(0);//删除首列
            //dt.Columns.RemoveAt(dt.Columns.Count - 1);//删除末列
            //for (int i = 0; i < 2; i++)//删除最后2行
            //{
            //    dt.Rows.RemoveAt(dt.Rows.Count - 1);
            //}
            //设置列名
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                object obj = dt.Rows[0][i];
                if (string.IsNullOrWhiteSpace(obj.ToString()))
                {
                    dt.Columns[i].ColumnName = "色数2";
                }
                else
                {
                    dt.Columns[i].ColumnName = obj.ToString();
                }
                if (dt.Columns[i].ColumnName == "色数")
                {
                    dt.Columns[i].ColumnName = "色数1";
                }
            }
            ////将列名改为小写字母
            //foreach (DataColumn col in dt.Columns)
            //{
            //    col.ColumnName = PinYinConverter.GetFirst(col.ColumnName).ToLower();
            //}
            //删除首行（就是把列名的那行删除了）
            dt.Rows.RemoveAt(0);

            return dt;
        }


        /// <summary>
        /// 读取Excel中数据
        /// </summary>
        /// <param name="strExcelPath"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetExcelTableByOleDB(string strExcelPath, string tableName)
        {
            try
            {
                DataTable dtExcel = new DataTable();
                //数据表
                DataSet ds = new DataSet();
                //获取文件扩展名
                string strExtension = System.IO.Path.GetExtension(strExcelPath);
                string strFileName = System.IO.Path.GetFileName(strExcelPath);
                //Excel的连接
                OleDbConnection objConn = null;
                switch (strExtension)
                {
                    case ".xls":
                        objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"");
                        break;
                    case ".xlsx":
                        objConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;\"");
                        break;
                    default:
                        objConn = null;
                        break;
                }
                if (objConn == null)
                {
                    return null;
                }
                objConn.Open();
                //获取Excel中所有Sheet表的信息
                //System.Data.DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                //获取Excel的第一个Sheet表名
                // string tableName1 = schemaTable.Rows[0][2].ToString().Trim();
                string strSql = "select * from [$" + tableName + "]";
                //获取Excel指定Sheet表中的信息
                OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
                myData.Fill(ds, tableName);//填充数据
                objConn.Close();
                //dtExcel即为excel文件中指定表中存储的信息
                dtExcel = ds.Tables[tableName];
                return dtExcel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }


        }

        #region 全角转换半角以及半角转换为全角
        /// <summary>
        /// 转全角的函数(SBC case)
        ///<para>全角空格为12288，半角空格为32</para>
        ///<para>其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248</para>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSBC(string input)
        {
            // 半角转全角：
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 32)
                {
                    array[i] = (char)12288;
                    continue;
                }
                if (array[i] < 127)
                {
                    array[i] = (char)(array[i] + 65248);
                }
            }
            return new string(array);
        }

        /// <summary>
        ///转半角的函数(DBC case)
        ///<para>全角空格为12288，半角空格为32</para>
        ///<para>其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248</para>
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToDBC(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 12288)
                {
                    array[i] = (char)32;
                    continue;
                }
                if (array[i] > 65280 && array[i] < 65375)
                {
                    array[i] = (char)(array[i] - 65248);
                }
            }
            return new string(array);
        }
        #endregion



        /// <summary>
        /// 获取进程的命令行参数
        /// </summary>
        /// <param name="processName">进程名(包含'.exe')</param>
        /// <returns></returns>
        public static List<string> GetCommandLines(string processName)
        {
            List<string> results = new List<string>();

            string wmiQuery = string.Format("select CommandLine from Win32_Process where Name='{0}'", processName);

            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
            {

                using (ManagementObjectCollection retObjectCollection = searcher.Get())
                {

                    foreach (ManagementObject retObject in retObjectCollection)
                    {

                        results.Add((string)retObject["CommandLine"]);

                    }

                }

            }
            return results;
        }

        /// <summary>  
        /// 执行DOS命令，返回DOS命令的输出  
        /// </summary>  
        /// <param name="dosCommand">dos命令</param>  
        /// <returns>返回DOS命令的输出</returns>  
        public static string ExecuteCom(string command, bool isReturn)
        {
            Process p = new Process();
            string strOuput = "";
            try
            {
                //设置要启动的应用程序
                p.StartInfo.FileName = "cmd.exe";
                //是否使用操作系统shell启动
                p.StartInfo.UseShellExecute = false;
                // 接受来自调用程序的输入信息
                p.StartInfo.RedirectStandardInput = true;
                //输出信息
                p.StartInfo.RedirectStandardOutput = true;
                // 输出错误
                p.StartInfo.RedirectStandardError = true;
                //不显示程序窗口
                p.StartInfo.CreateNoWindow = true;
                //启动程序
                p.Start();

                //向cmd窗口发送输入信息
                p.StandardInput.WriteLine(command + "&exit");

                //是否需要返回信息
                if (!isReturn)
                {
                    return "";
                }

                p.StandardInput.AutoFlush = true;

                //获取输出信息
                strOuput = p.StandardOutput.ReadToEnd();

                //等待程序执行完退出进程
                p.WaitForExit();
            }
            finally
            {
                p.Close();
            }

            return strOuput;
        }

        /// <summary>
        /// 判断路径是否能连接到
        /// </summary>
        /// <param name="path">需要连接的路径</param>
        /// <returns>true表示能连接到,false表示不能连接到</returns>
        public static bool IsConnectPath(string path)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    return false;
                }
                if (path.IndexOf("\\\\") == 0)
                {
                    string ipRoot = path.Substring(2, path.IndexOf('\\', 2) - 2);
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(ipRoot);
                    if (pingReply.Status == IPStatus.Success)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (File.Exists(path) || Directory.Exists(path))
                {
                    return true;
                }
                else if (path.IndexOf("http",StringComparison.OrdinalIgnoreCase) == 0)
                {
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// 获取单元格的值，或默认值
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string GetCellDefault(DataGridViewCell cell)
        {
            string sssss = cell.OwningColumn.Name;
            string ss = cell.ValueType.Name;
            string value = "";
            switch (cell.ValueType.Name)
            {
                case "Boolean":
                    bool bll = cell.Value == null;
                    value = ((cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString())) ? "0" : (Convert.ToBoolean(cell.Value) ? "1" : "0"));
                    break;
                case "String":
                    value = cell.Value == null ? "" : cell.Value.ToString();
                    break;
                case "Int32":
                case "Int16":
                case "Int64":
                case "Double":
                    value = cell.Value == null ? "0" : cell.Value.ToString();
                    break;
                default:
                    value = cell.Value == null ? "" : cell.Value.ToString();
                    break;
            }

            return value;
        }

        /// <summary>
        /// 预定义字符串
        /// </summary>
        public enum Predefinition
        {
            年,
            月,
            日,
            时,
            分,
            秒,
            随机数字,
            随机字母大写,
            随机字母小写
        }
        /// <summary>
        /// 获取预定义的字典对象
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetPredefinitionDic()
        {
            Dictionary<string, string> dic_Pre = new Dictionary<string, string>();
            DateTime dTime = DateTime.Now;
            dic_Pre.Add("*年1*", dTime.ToString("yyyy"));
            dic_Pre.Add("*年2*", dTime.ToString("yy"));
            dic_Pre.Add("*月1*", dTime.ToString("%M"));
            dic_Pre.Add("*月2*", dTime.ToString("MM"));
            dic_Pre.Add("*日1*", dTime.ToString("%d"));
            dic_Pre.Add("*日2*", dTime.ToString("dd"));
            dic_Pre.Add("*时1*", dTime.ToString("%H"));
            dic_Pre.Add("*时2*", dTime.ToString("HH"));
            dic_Pre.Add("*分1*", dTime.ToString("%m"));
            dic_Pre.Add("*分2*", dTime.ToString("mm"));
            dic_Pre.Add("*秒1*", dTime.ToString("%s"));
            dic_Pre.Add("*秒2*", dTime.ToString("ss"));
            //dic_Pre.Add("*随机数字*", new Random().Next(9).ToString());
            //dic_Pre.Add("*随机字母大写*", (char)(new Random().Next(64,90)));
            //dic_Pre.Add("*随机字母小写*", dTime.ToString("ss"));


            return dic_Pre;
        }
        public static string GetCustoString(string str)
        {
            if (str.Contains('*'))
            {
                Dictionary<string, string> dic_Pre = GetPredefinitionDic();
                foreach (string key in dic_Pre.Keys)
                {
                    str = str.Replace(key, dic_Pre[key]);
                }
            }
            return str;
        }

        public static bool AiToPDF(string fileFullName)
        {
            bool returnBool = false;
            if (Path.GetExtension(fileFullName).IndexOf
                (".ai",StringComparison.OrdinalIgnoreCase)==-1)
            {
                return false;
            }
            //空间名+类名
            string spaceName = Path.GetFileNameWithoutExtension(AppConfig_Local.IllustratorDllName) + ".ApplicationClass";

            //加载程序集(dll文件地址)，使用Assembly类   
            Assembly assembly = Assembly.LoadFile(AppConfig_Local.IllustratorDllName);

            //获取类型，参数（名称空间+类）   
            Type type = assembly.GetType(spaceName);

            //创建该对象的实例，object类型，参数（名称空间+类）   
            object instance = assembly.CreateInstance(spaceName);

            //方法名称
            string strMethod = "DoJavaScript";
            // 获取方法信息
            // 注意获取重载方法，需要指定参数类型
            MethodInfo method = type.GetMethod(strMethod);
            object[] parameters = new object[] 
                { Resources.AutoSavePdf.Replace("*文件名*",fileFullName.Replace('\\', '/'))
                    .Replace("*AI导出PDF目录*",AppConfig_Local.GetAiToPdfFolder().Replace('\\', '/'))
                    , null, null };
            // 调用方法，有参数
            method.Invoke(instance, parameters);
            returnBool = Comm_Method.IsConnectPath(AppConfig_Local.GetAiToPdfFolder() + "\\" + Path.GetFileNameWithoutExtension(fileFullName) + ".pdf");
            if (returnBool)
            {
                FileSystem.MoveFile(fileFullName, Path.GetDirectoryName(fileFullName)+"\\ok\\"+Path.GetFileName(fileFullName)
               , UIOption.AllDialogs, UICancelOption.DoNothing);
                //if (Path.GetExtension(destinationFileName).LastIndexOf(".ai", StringComparison.OrdinalIgnoreCase) > -1)
                //{
                //    Comm_Method.AiFileList.Add(destinationFileName);
                //}
            }
            return returnBool;
        }

        /// <summary>
        /// 用于比较两个字符串的相似度
        /// </summary>
        /// <param name="a">字符串1</param>
        /// <param name="b">字符串2</param>
        /// <returns>返回一个[0,1]之间的数值</returns>
        public static double Similarity(string a, string b)
        {
           return Math.Round((100.0 * a.ToCharArray().Intersect(b).Count() / a.ToCharArray().Union(b).Count()), 3);
        }
    }
}
