using ACRODISTXLib;
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
            PdfDistiller dis = new PdfDistiller();
            dis.FileToPDF(@"D:\桌面\ps\测试.ps","E:\\11.pdf","");
  ;
        }

       
    }
}

                   