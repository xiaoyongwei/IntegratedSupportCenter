using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using YBF.Class.Comm;

namespace HandeJobManager.DAL
{
    /// <summary>
    /// 本类为SQLite数据库帮助静态类,使用时只需直接调用即可,无需实例化
    /// </summary>
    public class SQLiteDbHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private string ConnectionString;
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public string GetConnectionString
        {
            get { return ConnectionString; }
        }
        ///// <summary>
        ///// 实例化SQLite操作类(1)
        ///// </summary>
        //public SQLiteDbHelper()
        //{
        //    this.ConnectionString = @"Data Source=" + Application.StartupPath + "\\Data\\HandeDb.db;Version=3;Password=wqEm,584&1;";
        //}
        ///// <summary>
        ///// 实例化SQLite操作类(2)
        ///// </summary>
        ///// <param customerName="dbFileFullName">数据库文件所在位置</param>
        //public SQLiteDbHelper(FileInfo dbFileInfo)
        //{
        //    this.ConnectionString = @"Data Source=" + dbFileInfo.FullName + ";Version=3;Password=wqEm,584&1;";
        //}
        /// <summary>
        /// 实例化SQLite操作类(3)
        /// </summary>
        /// <param customerName="conn">连接</param>
        public SQLiteDbHelper(string conn)
        {
            this.ConnectionString = conn;
        }
        #region ExecuteNonQuery
        /// <summary>
        /// 执行数据库操作(新增、更新或删除)
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="cmd">SqlCommand命令</param>
        /// <returns>所受影响的行数</returns>
        public int ExecuteNonQuery(string commandText)
        {
            int result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString, true))
            {
                SQLiteCommand cmd = new SQLiteCommand(commandText);
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// 执行数据库操作(新增、更新或删除)
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <returns>所受影响的行数</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            int result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString, true))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// 执行数据库操作(新增、更新或删除)
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <param customerName="cmdParms">SQL参数对象</param>
        /// <returns>所受影响的行数</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            int result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString, true))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行数据库操作(新增、更新或删除)同时返回执行后查询所得的第1行第1列数据
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="cmd">SqlCommand对象</param>
        /// <returns>查询所得的第1行第1列数据</returns>
        public object ExecuteScalar(string commandText)
        {
            object result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString, true))
            {
                SQLiteTransaction trans = null;
                SQLiteCommand cmd = new SQLiteCommand(commandText);
                PrepareCommand(cmd, con, ref trans, true, cmd.CommandType, cmd.CommandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// 执行数据库操作(新增、更新或删除)同时返回执行后查询所得的第1行第1列数据
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <returns>查询所得的第1行第1列数据</returns>
        public object ExecuteScalar(string commandText, CommandType commandType)
        {
            object result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString, true))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// 执行数据库操作(新增、更新或删除)同时返回执行后查询所得的第1行第1列数据
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <param customerName="cmdParms">SQL参数对象</param>
        /// <returns>查询所得的第1行第1列数据</returns>
        public object ExecuteScalar(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            object result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SQLiteCommand cmd = new SQLiteCommand();
            using (SQLiteConnection con = new SQLiteConnection(ConnectionString, true))
            {
                SQLiteTransaction trans = null;
                PrepareCommand(cmd, con, ref trans, true, commandType, commandText);
                try
                {
                    result = cmd.ExecuteScalar();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return result;
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 执行数据库查询，返回SqlDataReader对象
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="cmd">SqlCommand对象</param>
        /// <returns>SqlDataReader对象</returns>
        public SQLiteDataReader ExecuteReader(string commandText)
        {
            SQLiteDataReader reader = null;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");

            SQLiteConnection con = new SQLiteConnection(ConnectionString, true);
            SQLiteTransaction trans = null;
            SQLiteCommand cmd = new SQLiteCommand(commandText);
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        /// <summary>
        /// 执行数据库查询，返回SqlDataReader对象
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <returns>SqlDataReader对象</returns>
        public SQLiteDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            SQLiteDataReader reader = null;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SQLiteConnection con = new SQLiteConnection(ConnectionString, true);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }

        /// <summary>
        /// 执行数据库查询，返回SqlDataReader对象
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <param customerName="cmdParms">SQL参数对象</param>
        /// <returns>SqlDataReader对象</returns>
        public DbDataReader ExecuteReader(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            DbDataReader reader = null;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            SQLiteConnection con = new SQLiteConnection(ConnectionString, true);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
            try
            {
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reader;
        }
        #endregion

        #region ExecuteDataTable

        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（1）
        /// </summary>
        /// <param customerName="sql">要执行的SQL语句 </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }
        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（2）
        /// </summary>
        /// <param customerName="sql">要执行的SQL语句 </param>
        /// <param customerName="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }
        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（3）
        /// </summary>
        /// <param customerName="sql">要执行的SQL语句 </param>
        /// <param customerName="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param customerName="parameters">参数数组 </param>
        /// <returns> </returns>
        public DataTable ExecuteDataTable(string sql, CommandType commandType, SQLiteParameter[] parameters)
        {
            DataTable data = new DataTable();
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString, true))
            {
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (SQLiteParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    adapter.Fill(data);
                }
            }
            return data;
        }

        #endregion



        #region ExecuteDataSet
        /// <summary>
        /// 执行数据库查询，返回DataSet对象
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="cmd">SqlCommand对象</param>
        /// <returns>DataSet对象</returns>
        public DataSet ExecuteDataSet(string commandText)
        {
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(ConnectionString, true);
            SQLiteTransaction trans = null;
            SQLiteCommand cmd = new SQLiteCommand(commandText);
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd.Connection != null)
                {
                    if (cmd.Connection.State == ConnectionState.Open)
                    {
                        cmd.Connection.Close();
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行数据库查询，返回DataSet对象
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <returns>DataSet对象</returns>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(ConnectionString, true);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ds;
        }

        /// <summary>
        /// 执行数据库查询，返回DataSet对象
        /// </summary>
        /// <param customerName="ConnectionString">连接字符串</param>
        /// <param customerName="commandText">执行语句或存储过程名</param>
        /// <param customerName="commandType">执行类型</param>
        /// <param customerName="cmdParms">SQL参数对象</param>
        /// <returns>DataSet对象</returns>
        public DataSet ExecuteDataSet(string commandText, CommandType commandType, params SQLiteParameter[] cmdParms)
        {
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            SQLiteConnection con = new SQLiteConnection(ConnectionString, true);
            SQLiteCommand cmd = new SQLiteCommand();
            SQLiteTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
            try
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return ds;
        }
        #endregion

        /// <summary>
        /// 通用分页查询方法(1)
        /// </summary>
        /// <param customerName="tableName">表名</param>
        /// <param customerName="strColumns">查询字段名</param>
        /// <param customerName="strWhere">where条件</param>
        /// <param customerName="strOrder">排序条件</param>
        /// <param customerName="pageSize">每页数据数量</param>
        /// <param customerName="currentIndex">当前页数</param>
        /// <returns>DataTable数据表</returns>
        public DataTable SelectPaging(string tableName, string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex)
        {
            pageSize = pageSize < 0 ? 0 : pageSize;
            DataTable dt = new DataTable();
            string pagingTemplate = "select {0} from {1} where {2} order by {3} limit {4} offset {5} ";
            int offsetCount = (currentIndex - 1) * pageSize;
            string commandText = String.Format(pagingTemplate, strColumns, tableName, strWhere, strOrder, pageSize.ToString(), offsetCount.ToString());
            using (SQLiteDataReader reader = ExecuteReader(commandText, CommandType.Text))
            {
                if (reader != null)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>
        /// 通用分页查询方法(2)
        /// </summary>
        /// <param customerName="tableName">表名</param>
        /// <param customerName="strColumns">查询字段名</param>
        /// <param customerName="strWhere">where条件</param>
        /// <param customerName="strOrder">排序条件</param>
        /// <param customerName="pageSize">每页数据数量</param>
        /// <param customerName="currentIndex">当前页数</param>
        /// <param customerName="recordOut">数据总量</param>
        /// <returns>DataTable数据表</returns>
        public DataTable SelectPaging(string tableName, string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordOut)
        {
            DataTable dt = new DataTable();
            recordOut = Convert.ToInt32(ExecuteScalar(
                string.Format("select count(*) from {0} where {1} ", tableName, strWhere), CommandType.Text));
            string pagingTemplate = "select {0} from {1} where {2} order by {3} limit {4} offset {5} ";
            int offsetCount = (currentIndex - 1) * pageSize;
            string commandText = String.Format(pagingTemplate, strColumns, tableName, strWhere, strOrder, pageSize.ToString(), offsetCount.ToString());
            using (SQLiteDataReader reader = ExecuteReader(commandText, CommandType.Text))
            {
                if (reader != null)
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        /// <summary>
        /// 预处理Command对象,数据库链接,事务,需要执行的对象,参数等的初始化
        /// </summary>
        /// <param customerName="cmd">Command对象</param>
        /// <param customerName="conn">Connection对象</param>
        /// <param customerName="trans">Transcation对象</param>
        /// <param customerName="useTrans">是否使用事务</param>
        /// <param customerName="cmdType">SQL字符串执行类型</param>
        /// <param customerName="cmdText">SQL Text</param>
        /// <param customerName="cmdParms">SQLiteParameters to use in the command</param>
        private void PrepareCommand(SQLiteCommand cmd, SQLiteConnection conn, ref SQLiteTransaction trans, bool useTrans, CommandType cmdType, string cmdText, params SQLiteParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (useTrans)
            {
                trans = conn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = trans;
            }


            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SQLiteParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }


        /// <summary>
        /// 执行压缩数据库
        /// </summary>
        /// <returns>压缩数据库</returns>
        public void ExecuteZip()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionString, true))
            {
                using (SQLiteCommand cmd = new SQLiteCommand("VACUUM", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Data.SQLite.SQLiteException E)
                    {
                        connection.Close();
                        Comm_Method.ShowErrorMessage(E.Message);
                        //throw new Exception(E.Message);
                    }
                }
            }
        }



        #region 事务
        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param customerName="SQLStringList">多条SQL语句</param>        
        public bool ExecuteSqlTran(List<string> SQLStringList)
        {
            if (SQLStringList.Count <= 0)
            {
                return false;
            }
            int num = 0;
            while (!ExecuteSqlTran_Ex(SQLStringList))
            {
                if (num++ < 12)
                {
                    //"失败,300毫秒后重试!"
                    Thread.Sleep(300);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 执行事务，返回True或False
        /// </summary>
        /// <param customerName="Sqlstr">sql语句</param>
        /// <returns></returns>
        private bool ExecuteSqlTran_Ex(List<string> sqlList)
        {
            SQLiteConnection conn = null;//连接
            SQLiteTransaction tran = null;//事务
            try
            {
                conn = new SQLiteConnection(ConnectionString, true);
                conn.Open();
                tran = conn.BeginTransaction();//先实例SqlTransaction类，使用这个事务使用的是con 这个连接，使用BeginTransaction这个方法来开始执行这个事务
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                foreach (string item in sqlList)
                {
                    if (string.IsNullOrWhiteSpace(item))
                    {
                        continue;
                    }
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();

                }
                tran.Commit();
                return true;
            }
            catch
            {
                if (tran != null) tran.Rollback();
                return false;
            }
            finally
            {
                if (conn != null) conn.Dispose();
                if (tran != null) tran.Dispose();
            }

        }
        #endregion
    }
}
