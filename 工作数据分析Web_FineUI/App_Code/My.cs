using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data;
using 工作数据分析Web_FineUI.App_Code;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
///My 的摘要说明
/// </summary>
public static class My
{
    public static DataSet Dst_zero(DataSet ds)
    {
        foreach (DataTable dt in ds.Tables)
        {
            foreach (DataRow dr in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    string value = dr[dc].ToString();
                    if (value.Trim() == "0")
                    {
                        dr[dc] = "";
                    }
                }
            }
        }
        return ds;
    }

    public static string GetSqlTxt(string mingCheng)
    {
        return MySqlDbHelper.ExecuteScalar("SELECT `SQL语句` FROM  `slbz`.`系统_易捷oracle语句`where 名称='" + mingCheng + "'").ToString();
    }

    public static DataTable GetSqlTxt_Datatable(string mingCheng)
    {
        return OracleHelper.ExecuteDataTable(CommandType.Text, GetSqlTxt(mingCheng), null);
    }

    public static bool 更新成品库存()
    {
        DataTable dt = GetSqlTxt_Datatable("彩盒库存明细");

        //    开始添加到sql中
        List<string> sqlList = new List<string>();

        StringBuilder sb_Insert = new StringBuilder(" INSERT  INTO `slbz`.`二期彩盒库存明细`(");
        foreach (DataColumn dc in dt.Columns)//添加列
        {
            sb_Insert.AppendFormat("`{0}`,", dc.ColumnName);
        }
        sb_Insert.Remove(sb_Insert.Length - 1, 1);
        sb_Insert.AppendLine(")VALUES");
        StringBuilder sb_values = new StringBuilder("(");
        foreach (DataRow dr in dt.Rows)
        {
            sb_values = new StringBuilder("(");
            foreach (DataColumn dc in dt.Columns)
            {
                sb_values.AppendFormat("'{0}',", dr[dc].ToString());
            }
            sb_values.Remove(sb_values.Length - 1, 1);
            sb_values.AppendLine(");");
            sqlList.Add(sb_Insert.ToString() + sb_values.ToString());
        }
        if (sqlList.Count > 0)
        {
            sqlList.Insert(0, "truncate table `slbz`.`二期彩盒库存明细`;");
        }


        return MySqlDbHelper.ExecuteSqlTran(sqlList);
    }

    internal static void DownloadExcel(HttpResponse response, GridView gridView1, string v)
    {
        throw new NotImplementedException();
    }

    public static DataTable Table_deletezero(DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                string value = dr[dc].ToString();
                if (value.Trim() == "0")
                {
                    dr[dc] = "";
                }
            }
        }
        return dt;
    }
    /// <summary>
    /// 删除表格中空的列
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DataTable Table_DeleteEmptyColumn(DataTable dt)
    {
        for (int i = dt.Columns.Count - 1; i >= 0; i--)
        {
            DataColumn dc = dt.Columns[i];
            bool isEmpty = true;
            foreach (DataRow dr in dt.Rows)
            {
                if (!string.IsNullOrWhiteSpace(dr[dc].ToString()))
                {
                    isEmpty = false;
                }
            }
            if (isEmpty)
            {
                dt.Columns.RemoveAt(i);
            }
        }
        return dt;
    }


    public static DataTable CopyDataTable(DataRow[] drs)
    {
        DataTable dt = new DataTable();
        if (drs.Length == 0)
        {
            return dt;
        }
        dt = drs[0].Table.Clone();
        foreach (DataRow dr in drs)
        {
            dt.Rows.Add(dr.ItemArray);
        }
        return dt;
    }


    public static string DataTableToHtml(DataTable dt,string idName)
    {
        StringBuilder sb = new StringBuilder();        
        sb.Append("<table cellspacing='1' cellpadding='1' rules='all' border='1'>");
        if (string.IsNullOrWhiteSpace(idName))
        {
            sb.Append("<tr>");
        }
        else
        {
            sb.Append("<tr><td><b><span>选择</span></b></td>");
        }
        
        
        foreach (DataColumn column in dt.Columns)
        {
            sb.Append("<td><b><span>" + column.ColumnName + "</span></b></td>");
        }
        sb.Append("</tr>");
        int iColsCount = dt.Columns.Count;
        int rowsCount = dt.Rows.Count - 1;
        for (int j = 0; j <= rowsCount; j++)
        {
            if (string.IsNullOrWhiteSpace(idName))
            {
                sb.Append("<tr>");
            }
            else
            {
                sb.Append("<tr><td><input type='checkbox'  id=" + dt.Rows[j][idName] + " ></td>"); 
            }            
           
            for (int k = 0; k <= iColsCount - 1; k++)
            {
                sb.Append("<td>");
                object obj = dt.Rows[j][k];
                if (obj == DBNull.Value)
                {
                    obj = "&nbsp;";//如果是NULL则在HTML里面使用一个空格替换之
                }
                if (obj.ToString() == "")
                {
                    obj = "&nbsp;";
                }
                string strCellContent = obj.ToString().Trim();
                sb.Append("<span>" + strCellContent + "</span>");
                sb.Append("</td>");
            }
            sb.Append("</tr>");
        }
        sb.Append("</table>");
        sb.Append("<br/>");

        return sb.ToString();
    }



    // 在此处添加更多操作并使用 [OperationContract] 标记它们
    #region MD5加密
    /// <summary>  
    /// MD5加密  
    /// </summary>  
    /// <param name="strSource">需要加密的字符串</param>  
    /// <returns>MD5加密后的字符串</returns>  
    [OperationContract]
    public static string Md5Encrypt(string strSource)
    {
        //把字符串放到byte数组中  
        byte[] bytIn = System.Text.Encoding.Default.GetBytes(strSource);
        //建立加密对象的密钥和偏移量          
        byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };//定义偏移量  
        byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };//定义密钥  
        //实例DES加密类  
        DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
        mobjCryptoService.Key = iv;
        mobjCryptoService.IV = key;
        ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
        //实例MemoryStream流加密密文件  
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Write);
        cs.Write(bytIn, 0, bytIn.Length);
        cs.FlushFinalBlock();

        string strOut = System.Convert.ToBase64String(ms.ToArray());
        return strOut;
    }
    #endregion

    #region MD5解密
    /// <summary>  
    /// MD5解密  
    /// </summary>  
    /// <param name="Source">需要解密的字符串</param>  
    /// <returns>MD5解密后的字符串</returns>  
    [OperationContract]
    public static string Md5Decrypt(string Source)
    {
        //将解密字符串转换成字节数组  
        byte[] bytIn = System.Convert.FromBase64String(Source);
        //给出解密的密钥和偏移量，密钥和偏移量必须与加密时的密钥和偏移量相同  
        byte[] iv = { 102, 16, 93, 156, 78, 4, 218, 32 };//定义偏移量  
        byte[] key = { 55, 103, 246, 79, 36, 99, 167, 3 };//定义密钥  
        DESCryptoServiceProvider mobjCryptoService = new DESCryptoServiceProvider();
        mobjCryptoService.Key = iv;
        mobjCryptoService.IV = key;
        //实例流进行解密  
        System.IO.MemoryStream ms = new System.IO.MemoryStream(bytIn, 0, bytIn.Length);
        ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
        CryptoStream cs = new CryptoStream(ms, encrypto, CryptoStreamMode.Read);
        StreamReader strd = new StreamReader(cs, Encoding.Default);
        return strd.ReadToEnd();
    }
    #endregion

}