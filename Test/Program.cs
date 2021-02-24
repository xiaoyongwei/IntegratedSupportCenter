
using System;
using System.Data;
using �������ݷ���.Data.DAL.Oracle;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt_s = DateTime.Now;
            _Main();

            Console.WriteLine("\n\n���!");
            Console.WriteLine("��ʱ:"+(DateTime.Now-dt_s));
            Console.WriteLine("�� Ecs ���˳�!");
            while (Console.ReadKey().Key!=ConsoleKey.Escape)
            {

            }
            
           
        }

        private static void _Main()
        {
            try
            {
                DataTable tableLeiji = OracleHelper.ExecuteDataTable(string.Format("select round(sum(case t.ordtyp when 'CB' then round(nvl(t.pacreage,0),4) * t.ACCNUMR  " +
                               "else round(nvl(t.acreage,0),4) * t.ACCNUMR end) ) ƽ��,round(sum(case t.ordtyp when 'CB' then round((t.ctinprice*round(t.pacreage,4) * t.ACCNUMR +" +
                               " nvl(t.dlvamt,0) + nvl(t.annamt,0) ),2)  else round(t.prices * t.accnumr,2) end ) ) ��� from v_bcdx_ct t where t.objtyp='DL' and t.invtyp ='XD' " +
                               "and t.orgcde='KS03' and t.clientid='KS' and t.ordtyp='CL' and to_char(ptdate,'yyyy-MM-dd') >= '{0}-{1}-00'  and to_char(ptdate,'yyyy-MM-dd') <= '{0}-{1}-99'",
                               "2021", "02"));

                string pf = tableLeiji.Rows[0]["ƽ��"].ToString();
                string jine = tableLeiji.Rows[0]["���"].ToString();

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

                   