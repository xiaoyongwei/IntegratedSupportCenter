using Aspose.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Document doc = new Document("E:\\E069-绿田2805073130-387x367x903-A.pdf");
            Page page = doc.Pages[1];
            Rectangle rec = page.TrimBox;
            Rotation rot = page.Rotate;
        }
    }
}
