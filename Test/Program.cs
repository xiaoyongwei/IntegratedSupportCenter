
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using excelToTable_NPOI;
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
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new ExcelHelper(openFile.FileName).ExcelToDataTable("", true, true);

                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                //��������
                dt.Columns["�ͻ�ʱ��"].ColumnName = "�ͻ�����";
                dt.Columns["�ͻ�"].ColumnName = "�ͻ����";
                dt.Columns["����Ա"].ColumnName = "������";
                DataTable dtGroupBy = dt.AsEnumerable().GroupBy(r => new
                {
                    �ͻ����� = r["�ͻ�����"],
                    �ͻ����� = r["�ͻ�����"],
                    �ͻ���� = r["�ͻ����"],
                    ҵ��Ա = r["ҵ��Ա"],
                    ˾�� = r["˾��"],
                    ������ = r["������"]



                }




                ).Select(
                   g =>
                   {
                       var row = dt.NewRow();

                       row["�ͻ�����"] = g.Key.�ͻ�����;
                       row["�ͻ�����"] = g.Key.�ͻ�����;
                       row["�ͻ����"] = g.Key.�ͻ����;
                       row["ҵ��Ա"] = g.Key.ҵ��Ա;
                       row["˾��"] = g.Key.˾��;
                       row["������"] = g.Key.������;
                       row["���"] = g.Sum(r => (decimal)r["���"]);
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

                   