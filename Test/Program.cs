
using System;
using System.Data;
using 工作数据分析.Data.DAL.Oracle;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt_s = DateTime.Now;
            _Main();

            Console.WriteLine("\n\n完成!");
            Console.WriteLine("用时:"+(DateTime.Now-dt_s));
            Console.WriteLine("按 Ecs 键退出!");
            while (Console.ReadKey().Key!=ConsoleKey.Escape)
            {

            }
            
           
        }

        private static void _Main()
        {
            try
            {
                DataTable tableLeiji = OracleHelper.ExecuteDataTable(string.Format("select round(sum(case t.ordtyp when 'CB' then round(nvl(t.pacreage,0),4) * t.ACCNUMR  " +
                               "else round(nvl(t.acreage,0),4) * t.ACCNUMR end) ) 平方,round(sum(case t.ordtyp when 'CB' then round((t.ctinprice*round(t.pacreage,4) * t.ACCNUMR +" +
                               " nvl(t.dlvamt,0) + nvl(t.annamt,0) ),2)  else round(t.prices * t.accnumr,2) end ) ) 金额 from v_bcdx_ct t where t.objtyp='DL' and t.invtyp ='XD' " +
                               "and t.orgcde='KS03' and t.clientid='KS' and t.ordtyp='CL' and to_char(ptdate,'yyyy-MM-dd') >= '{0}-{1}-00'  and to_char(ptdate,'yyyy-MM-dd') <= '{0}-{1}-99'",
                               "2021", "02"));

                string pf = tableLeiji.Rows[0]["平方"].ToString();
                string jine = tableLeiji.Rows[0]["金额"].ToString();

                Console.WriteLine(pf);
                Console.WriteLine(jine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}

                   