
using System;
using System.Linq;

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
            string a = "456654564";
            string b = "5665444";
            Console.WriteLine(a);
            Console.WriteLine(b);

           
            Console.WriteLine();
            Console.WriteLine("相似度:" + Math.Round((100.0 * a.ToCharArray().Intersect(b).Count() / a.ToCharArray().Union(b).Count()), 3) + "%");

        }


    }
}

                   