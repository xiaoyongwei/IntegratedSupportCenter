using DBUtility;
using MySql.Data.MySqlClient;
using 综合保障中心.Comm;

namespace 工作数据分析.Data.DAL
{
    public static class DataBaseList
    {
        public static string IP_财务 = "128.1.50.25";
        //public static string ConnString_财务2019 = "Data Source=" + IP_财务 + ";Initial Catalog=AIS20190130220801;User ID=sa;Password=sql2008;";
        //public static string ConnString_财务 = "Data Source=" + IP_财务 + ";Initial Catalog=AIS20200126172154;User ID=sa;Password=sql2008;";
        public static string ConnString_财务 = "Data Source=" + IP_财务 + "\\senlin;Initial Catalog=AIS202101152033;User ID=sa;Password=sql2012;";

        public static string IP_制版线1800 = "128.1.50.67";
        public static string ConnString_制版线1800 = "Data Source=" + IP_制版线1800 + ";Initial Catalog=cimnc2;User ID=sa;Password=sa;";

        public static string IP_制版线1800F = "128.1.50.96";
        public static string ConnString_制版线1800F = "Data Source=" + IP_制版线1800F + ";Initial Catalog=cimnc;User ID=sa;Password=sa;";

        public static string IP_制版线2200 = "128.1.50.235";
        public static string ConnString_制版线2200 = "Data Source=" + IP_制版线2200 + ";Initial Catalog=cimnc;User ID=sa;Password=sa;";

        public static string IP_制版线2500 = "128.1.127.127";
        public static string ConnString_制版线2500 = "Data Source=" + IP_制版线2500 + "\\JSDCS;Initial Catalog=test1;User ID=sa;Password=83360009;";

        public static SqlHelper sql财务;
        public static SqlHelper sql制版线1800;
        public static SqlHelper sql制版线1800F;
        public static SqlHelper sql制版线2200;
        public static SqlHelper sql制版线2500;

        public static void InitSqlhelper()
        {
            sql财务 = null;
            sql制版线1800 = null;
            sql制版线1800F = null;
            sql制版线2200 = null;
            sql制版线2500 = null;


            if (My.Ping(IP_财务) && SqlHelper.IsConnection(ConnString_财务))
            {
                sql财务 = new SqlHelper(ConnString_财务);
            }
            if (My.Ping(IP_制版线1800) && SqlHelper.IsConnection(ConnString_制版线1800))
            {
                sql制版线1800 = new SqlHelper(ConnString_制版线1800);
            }
            if (My.Ping(IP_制版线1800F) && SqlHelper.IsConnection(ConnString_制版线1800F))
            {
                sql制版线1800F = new SqlHelper(ConnString_制版线1800F);
            }
            if (My.Ping(IP_制版线2200) && SqlHelper.IsConnection(ConnString_制版线2200))
            {
                sql制版线2200 = new SqlHelper(ConnString_制版线2200);
            }
            if (My.Ping(IP_制版线2500) && SqlHelper.IsConnection(ConnString_制版线2500))
            {
                sql制版线2500 = new SqlHelper(ConnString_制版线2500);
            }
        }


    }
}
