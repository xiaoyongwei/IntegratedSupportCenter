
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using excelToTable_NPOI;
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
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new ExcelHelper(openFile.FileName).ExcelToDataTable("", true, true);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                //更改列名
                dt.Columns["送货时间"].ColumnName = "送货日期";
                dt.Columns["客户"].ColumnName = "客户简称";
                dt.Columns["开单员"].ColumnName = "操作人";
                DataTable dtGroupBy = dt.AsEnumerable().GroupBy(r => new
                {
                    送货日期 = r["送货日期"],
                    送货单号 = r["送货单号"],
                    客户简称 = r["客户简称"],
                    业务员 = r["业务员"],
                    司机 = r["司机"],
                    操作人 = r["操作人"]



                }




                ).Select(
                   g =>
                   {
                       var row = dt.NewRow();

                       row["送货日期"] = g.Key.送货日期;
                       row["送货单号"] = g.Key.送货单号;
                       row["客户简称"] = g.Key.客户简称;
                       row["业务员"] = g.Key.业务员;
                       row["司机"] = g.Key.司机;
                       row["操作人"] = g.Key.操作人;
                       row["金额"] = g.Sum(r => (decimal)r["金额"]);
                       return row;
                   }).CopyToDataTable();






                foreach (DataColumn column in dtGroupBy.Columns)
                {
                    Console.Write(column.ColumnName + '\t');
                }
                Console.WriteLine();

                foreach (DataRow row1 in dtGroupBy.Rows)
                {
                    foreach (DataColumn column in dtGroupBy.Columns)
                    {
                        Console.Write(row1[column].ToString() + '\t');
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}

                   