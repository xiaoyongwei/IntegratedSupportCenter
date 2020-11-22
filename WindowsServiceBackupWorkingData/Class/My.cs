
using System;
using System.Net.NetworkInformation;
using 工作数据分析.Class;
//using excelToTable_NPOI;

namespace 综合保障中心.Comm
{
    public static class My
    {

        public static string macAddress = GetSystemInfo.GetMacAddress();

        public static string computerName = Environment.MachineName;

        

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
