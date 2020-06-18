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
            SpeechSynthesizer ssh = new SpeechSynthesizer();
             for (int i = 0; i < 100; i++)
            {
                ssh.SpeakAsync(i.ToString());
            }
            
            Console.ReadKey();
        }
    }
}
