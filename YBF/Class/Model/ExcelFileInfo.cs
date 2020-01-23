using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace YBF.Class.Model
{
    class ExcelFileInfo
    {
        public string FileFullName { get; set; }
        public DateTime CreateTime { get; set; }

        public ExcelFileInfo(string fileFullName)
        {
            this.FileFullName = fileFullName;
            this.CreateTime = File.GetCreationTime(this.FileFullName);
        }

        
    }
}
