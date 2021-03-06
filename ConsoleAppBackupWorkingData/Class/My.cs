﻿using excelToTable_NPOI;
using System;
using System.Data;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using 工作数据分析.Class;
//using excelToTable_NPOI;

namespace 综合保障中心.Comm
{
    public static class My
    {

        public static string macAddress = GetSystemInfo.GetMacAddress();

        public static string computerName = Environment.MachineName;

        /// <summary>
        /// 显示错误弹窗
        /// </summary>
        /// <param name="mess"></param>
        public static void ShowErrorMessage(string mess)
        {
            MessageBox.Show(mess, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="mess"></param>
        public static void ShowMessage(string mess)
        {
            MessageBox.Show(mess, "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
        }


        public static bool ExceptToExcel(string fileFullName, DataTable table)
        {
            return new ExcelHelper(fileFullName).DataTableToExcel(table, null, true) > 0;
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

        public static bool Ping(string ip)
        {
            return (new Ping().Send(ip).Status == IPStatus.Success);
            //bool online = false; //是否在线
            //Ping ping = new Ping();
            //PingReply pingReply = ping.Send(ip);
            //if (pingReply.Status == IPStatus.Success)
            //{
            //    online = true;
            //}

            //return online;
        }


        

        public static void InsertMysqlBackupLog(string logtxt)
        {
            string sql = string.Format("INSERT INTO `slbz`.`备份日志`(`时间`,`Mac地址`,`计算机名称`,`描述`)	VALUES('{0}','{1}','{2}','{3}');"
                , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), My.macAddress, My.computerName, logtxt);
            MySqlDbHelper.ExecuteSqlTran(sql);
        }

    }
}
