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


            Console.WriteLine("���!");
            Console.WriteLine("��ʱ:"+(DateTime.Now-dt_s));
            Console.WriteLine("�� Ecs ���˳�!");
            while (Console.ReadKey().Key!=ConsoleKey.Escape)
            {

            }
            
           
        }

        private static void _Main()
        {
        //����һ��PdfDocument��������ĵ������һҳ
            PdfDocument doc = new PdfDocument();
            PdfPageBase page = doc.Pages.Add();

            //����һ��PdfTable����
            PdfTable table = new PdfTable();
            //��������
            table.Style.DefaultStyle.Font = new PdfTrueTypeFont(new Font("Arial Unicode MS", 9f), true);
            table.Style.HeaderStyle.Font = new PdfTrueTypeFont(new Font("Arial Unicode MS", 9f), true);

            //����һ��DataTable��д������
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("��Ʒ����");
            dataTable.Columns.Add("��Ʒ���");
            dataTable.Columns.Add("�ɹ��������");
            dataTable.Columns.Add("�����·�");

            dataTable.Rows.Add(new string[] { "A", "00101", "35", "7��"});
            dataTable.Rows.Add(new string[] { "B", "00102", "56", "8��"});
            dataTable.Rows.Add(new string[] { "C", "00103", "25", "9��"});

            //������ݵ�PDF���
            table.DataSource = dataTable;
            //��ʾ��ͷ��Ĭ�ϲ���ʾ��
            table.Style.ShowHeader = true;
            //��BeginRowLayout�¼���������ע���Զ����¼�
            table.BeginRowLayout += Table_BeginRowLayout;

            //��������PDF��ָ��λ�úʹ�С
            table.Draw(page, new RectangleF(0, 60, 200, 200));

            //���浽�ĵ���Ԥ��
            doc.SaveToFile("PDF���_1.pdf");
            System.Diagnostics.Process.Start("PDF���_1.pdf");
        }

        private static void Table_BeginRowLayout(object sender, BeginRowLayoutEventArgs args)
        {
            args.MinimalHeight = 10f;
        }
    }
}

                   