using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Rule
{
    [Serializable]
    public class PrintToDeviceRule
    {
        public List<PathAndFileNameRule> PathAndFileNameList { get; set; }

        public List<PlantInfo> PlantList { get; set; }

        public List<string> ColorList { get; set; }

        public int Line { get; set; }

        public float Bite { get; set; }

    }
}
