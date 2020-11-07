
using System;
using System.Data;
using System.IO;
using System.Linq;
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
            foreach (DataRow dRow in 
                OracleHelper.ExecuteDataTable("SELECT table_name FROM all_tables").Rows)
            {
                Console.WriteLine();
                foreach (DataRow columnName in 
                    OracleHelper.ExecuteDataTable(
                        "SELECT column_name FROM all_tab_columns WHERE table_name='"+dRow[0].ToString()+"'").Rows)
                {
                    //if ("pkcode".Equals(columnName[0].ToString(),StringComparison.OrdinalIgnoreCase))
                    //{
                        File.AppendAllText("D:\\tableNames.txt", 
                            dRow[0].ToString()+"\t"+columnName[0].ToString()+Environment.NewLine);
                        Console.WriteLine(dRow[0].ToString() + "\t" + columnName[0].ToString());
                    //    break;
                    //}
                }
            }
        }


    }
}

                   