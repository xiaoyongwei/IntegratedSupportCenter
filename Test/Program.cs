using DBUtility;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt_s = DateTime.Now;
            _Main();


            Console.WriteLine("完成!");
            Console.WriteLine("用时:"+(DateTime.Now-dt_s));
            Console.WriteLine("按 Ecs 键退出!");
            while (Console.ReadKey().Key!=ConsoleKey.Escape)
            {

            }
            
           
        }

        private static void _Main()
        {
        //创建一个PdfDocument类对象并向文档新添加一页
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();

            //创建一个PdfTable对象
            PdfTable table = new PdfTable();
            //设置字体
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial Unicode MS", 9f), true);
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial Unicode MS", 9f), true);

            //创建一个DataTable并写入数据
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("产品类型");
            dataTable.Columns.Add("产品编号");
            dataTable.Columns.Add("采购数额（件）");
            dataTable.Columns.Add("所属月份");

            dataTable.Rows.Add(new string[] { "A", "00101", "35", "7月"});
            dataTable.Rows.Add(new string[] { "B", "00102", "56", "8月"});
            dataTable.Rows.Add(new string[] { "C", "00103", "25", "9月"});

            //填充数据到PDF表格
            table.DataSource = dataTable;
            //显示表头（默认不显示）
            table.Style.ShowHeader = true;
            //在BeginRowLayout事件处理方法中注册自定义事件
            table.BeginRowLayout += Table_BeginRowLayout;

            //将表格绘入PDF并指定位置和大小
            table.Draw(page, new RectangleF(0, 60, 200, 200));

            //保存到文档并预览
            doc.SaveToFile("PDF表格_1.pdf");
            System.Diagnostics.Process.Start("PDF表格_1.pdf");
        }

        private static void Table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            args.MinimalHeight = 10f;
        }
    }
}

                   