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

            Console.WriteLine("\n\n���!");
            Console.WriteLine("��ʱ:"+(DateTime.Now-dt_s));
            Console.WriteLine("�� Ecs ���˳�!");
            while (Console.ReadKey().Key!=ConsoleKey.Escape)
            {

            }
            
           
        }

        private static void _Main()
        {
            PdfDistiller dis = new PdfDistiller();
            dis.FileToPDF(@"D:\����\ps\����.ps","E:\\11.pdf","");
  ;
        }

       
    }
}

                   