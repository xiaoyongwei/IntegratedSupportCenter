using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HandeJobManager.DAL
{
   public static class SQLiteList
    {
       /// <summary>
       /// 开单 数据库
       /// </summary>
       public static SQLiteDbHelper GD;
       /// <summary>
       /// 作业备份数据库
       /// </summary>
       public static SQLiteDbHelper BackupProcess;

       /// <summary>
       /// 原纸仓库 数据库
       /// </summary>
       public static SQLiteDbHelper YZ;
      
    }
}
