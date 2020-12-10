using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;

namespace 工作数据分析Web_FineUI.App_Code
{
    public static class MySqlDbHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string ConnectionString =
            "Server=sh-cdb-0fqx23nq.sql.tencentcdb.com;Port=62897;Database=slbz;userid=wan_001;password=w12345678;Character Set=utf8;Convert Zero Datetime=True; Allow Zero Datetime=True;connect timeout=1000";
        public static string GetConnectionString()
        {
            return ConnectionString;
        }
        /// <summary>
        //// 获取连接字符串
        //// </summary>
        ////public string GetConnectionString
        ////{
        ////    get { return ConnectionString; }
        ////}
        /// <summary>
        /// 实例化MySql操作类
        /// </summary>
        /// <param name="conn"></param>
        //public MySqlDbHelper(string conn)
        //{
        //    this.ConnectionString = conn;
        //}
        #region ExecuteNonQuery
        /// <summary>
        /// 执行数据库操作(新增、更新或删除)
        /// </summary>
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="cmd">SqlCommand命令</param>
        /// <returns>所受影响的行数</returns>
        public static int ExecuteNonQuery(string commandText)
        {
            int result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                MySqlCommand cmd = new MySqlCommand(commandText);
                MySqlTransaction trans = null;
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <returns>所受影响的行数</returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType)
        {
            int result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                MySqlTransaction trans = null;
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <param name="cmdParms">SQL参数对象</param>
        /// <returns>所受影响的行数</returns>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, params MySqlParameter[] cmdParms)
        {
            int result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                MySqlTransaction trans = null;
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <returns>查询所得的第1行第1列数据</returns>
        public static object ExecuteScalar(string commandText)
        {
            object result = "";
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                MySqlTransaction trans = null;
                MySqlCommand cmd = new MySqlCommand(commandText);
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <returns>查询所得的第1行第1列数据</returns>
        public static object ExecuteScalar(string commandText, CommandType commandType)
        {
            object result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                MySqlTransaction trans = null;
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <param name="cmdParms">SQL参数对象</param>
        /// <returns>查询所得的第1行第1列数据</returns>
        public static object ExecuteScalar(string commandText, CommandType commandType, params MySqlParameter[] cmdParms)
        {
            object result = 0;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                MySqlTransaction trans = null;
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <returns>SqlDataReader对象</returns>
        public static MySqlDataReader ExecuteReader(string commandText)
        {
            MySqlDataReader reader = null;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");

            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlTransaction trans = null;
            MySqlCommand cmd = new MySqlCommand(commandText);
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <returns>SqlDataReader对象</returns>
        public static MySqlDataReader ExecuteReader(string commandText, CommandType commandType)
        {
            MySqlDataReader reader = null;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction trans = null;
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <param name="cmdParms">SQL参数对象</param>
        /// <returns>SqlDataReader对象</returns>
        public static DbDataReader ExecuteReader(string commandText, CommandType commandType, params MySqlParameter[] cmdParms)
        {
            DbDataReader reader = null;
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");

            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction trans = null;
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
        /// <param name="sql">要执行的SQL语句 </param>
        /// <returns> </returns>
        public static DataTable ExecuteDataTable(string sql)
        {
            return ExecuteDataTable(sql, CommandType.Text, null);
        }
        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（2）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <returns> </returns>
        public static DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }
        /// <summary>
        /// SqlDataAdapter的Fill方法执行一个查询，并返回一个DataTable类型结果（3）
        /// </summary>
        /// <param name="sql">要执行的SQL语句 </param>
        /// <param name="commandType">要执行的查询类型（存储过程、SQL文本） </param>
        /// <param name="parameters">参数数组 </param>
        /// <returns> </returns>
        public static DataTable ExecuteDataTable(string sql, CommandType commandType, MySqlParameter[] parameters)
        {
            DataTable data = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.CommandTimeout = 300;
                    command.CommandType = commandType;
                    if (parameters != null)
                    {
                        foreach (MySqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="cmd">SqlCommand对象</param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecuteDataSet(string commandText)
        {
            DataSet ds = new DataSet();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlTransaction trans = null;
            MySqlCommand cmd = new MySqlCommand(commandText);
            cmd.CommandTimeout = 300;
            PrepareCommand(cmd, con, ref trans, false, cmd.CommandType, cmd.CommandText);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecuteDataSet(string commandText, CommandType commandType)
        {
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction trans = null;
            cmd.CommandTimeout = 300;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
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
        /// <param name="ConnectionString">连接字符串</param>
        /// <param name="commandText">执行语句或存储过程名</param>
        /// <param name="commandType">执行类型</param>
        /// <param name="cmdParms">SQL参数对象</param>
        /// <returns>DataSet对象</returns>
        public static DataSet ExecuteDataSet(string commandText, CommandType commandType, params MySqlParameter[] cmdParms)
        {
            if (ConnectionString == null || ConnectionString.Length == 0)
                throw new ArgumentNullException("ConnectionString");
            if (commandText == null || commandText.Length == 0)
                throw new ArgumentNullException("commandText");
            DataSet ds = new DataSet();
            MySqlConnection con = new MySqlConnection(ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction trans = null;
            PrepareCommand(cmd, con, ref trans, false, commandType, commandText, cmdParms);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
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
        /// 通用分页查询方法
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strColumns">查询字段名</param>
        /// <param name="strWhere">where条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <param name="pageSize">每页数据数量</param>
        /// <param name="currentIndex">当前页数</param>
        /// <param name="recordOut">数据总量</param>
        /// <returns>DataTable数据表</returns>
        public static DataTable SelectPaging(string tableName, string strColumns, string strWhere, string strOrder, int pageSize, int currentIndex, out int recordOut)
        {
            DataTable dt = new DataTable();
            recordOut = Convert.ToInt32(ExecuteScalar(
                string.Format("select count(*) from {0} where {1} ", tableName, strWhere), CommandType.Text));
            string pagingTemplate = "select {0} from {1} where {2} order by {3} limit {4} offset {5} ";
            int offsetCount = (currentIndex - 1) * pageSize;
            string commandText = String.Format(pagingTemplate, strColumns, tableName, strWhere, strOrder, pageSize.ToString(), offsetCount.ToString());
            using (MySqlDataReader reader = ExecuteReader(commandText, CommandType.Text))
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
        /// <param name="cmd">Command对象</param>
        /// <param name="conn">Connection对象</param>
        /// <param name="trans">Transcation对象</param>
        /// <param name="useTrans">是否使用事务</param>
        /// <param name="cmdType">SQL字符串执行类型</param>
        /// <param name="cmdText">SQL Text</param>
        /// <param name="cmdParms">MySqlParameters to use in the command</param>
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, ref MySqlTransaction trans, bool useTrans, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParms)
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
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }


        /// <summary>
        /// 执行压缩数据库
        /// </summary>
        /// <returns>压缩数据库</returns>
        public static void ExecuteZip()
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("VACUUM", connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        connection.Close();
                        //throw new Exception(E.Message);
                    }
                }
            }
        }



        #region 事务
        /// <summary>    
        /// 执行SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLString">SQL语句</param>        
        public static bool ExecuteSqlTran(string SQLString)
        {
            List<string> sqllist = new List<string>();
            sqllist.Add(SQLString);
            return ExecuteSqlTran(sqllist);
        }
        /// <summary>    
        /// 执行多条SQL语句，实现数据库事务。    
        /// </summary>    
        /// <param name="SQLStringList">多条SQL语句</param>        
        public static bool ExecuteSqlTran(List<string> SQLStringList)
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
                    //"失败,1秒后重试!"
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
        /// <param name="Sqlstr">sql语句</param>
        /// <returns></returns>
        private static bool ExecuteSqlTran_Ex(List<string> sqlList)
        {
            MySqlConnection conn = null;//连接
            MySqlTransaction tran = null;//事务
            try
            {
                conn = new MySqlConnection(ConnectionString);
                conn.Open();
                tran = conn.BeginTransaction();//先实例SqlTransaction类，使用这个事务使用的是con 这个连接，使用BeginTransaction这个方法来开始执行这个事务
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tran;

                foreach (string item in sqlList)
                {
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