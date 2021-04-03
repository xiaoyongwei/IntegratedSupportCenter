
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
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
			string text = "";
			int num = 0;
			TextBox1.Text = "";
			TextBox2.Text = "";
			TextBox3.Text = "";
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				string text2 = "";
				text2 = Conversions.ToString(item["signature"]);
				switch (num)
				{
					case 0:
						TextBox1.Text = text2;
						break;
					case 1:
						TextBox2.Text = text2;
						break;
					case 3:
						TextBox3.Text = text2;
						break;
				}
				num = checked(num + 1);
			}
		}


    }
}

                   