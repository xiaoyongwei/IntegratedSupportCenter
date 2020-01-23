using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Job
{
    public class ProcessInfo
    {

        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public string FileName { get; set; }
        public Guid Guid { get; set; }
        public int Number { get; set; }
        public string Plates { get; set; }
    }
}
