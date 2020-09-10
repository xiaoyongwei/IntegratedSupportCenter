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

            Console.WriteLine("\n\n完成!");
            Console.WriteLine("用时:"+(DateTime.Now-dt_s));
            Console.WriteLine("按 Ecs 键退出!");
            while (Console.ReadKey().Key!=ConsoleKey.Escape)
            {

            }
            
           
        }

        private static void _Main()
        {
            Document pdfDoc = new Document("E:\\爱仕达ALG-3FP-4838613171-32-301外箱490X326X427.pdf");
            Console.WriteLine(pdfDoc.Pages[1].TrimBox); 
        }

       
    }
}

                   