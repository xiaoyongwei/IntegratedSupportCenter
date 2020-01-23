using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HandeJobManager.DAL;

namespace 综合保障中心.Comm
{
    public static class GaoDai
    {
        public static bool BaoFei(string gdh)
        {
            string sql="UPDATE [稿袋]"+
	            "SET [客户名称] = '',"+
		        ",[产品名称] = '',"+
		        ",[状态] = '报废',"+
		        ",[最后修改人] = '"+User.FullName+"'"+
		        ",[存放位置] = ''"+
		        ",[备注] = ''"+
	            "WHERE [稿袋号] = '"+gdh+";";
            return SQLiteList.GD.ExecuteSqlTran(new List<string>(new string[] { sql }));
        }
    }
}
