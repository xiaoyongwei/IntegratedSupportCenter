using Aspose.Pdf;
using System;

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
            Document pdfDoc = new Document("E:\\���˴�ALG-3FP-4838613171-32-301����490X326X427.pdf");
            Console.WriteLine(pdfDoc.Pages[1].TrimBox); 
        }

       
    }
}

                   