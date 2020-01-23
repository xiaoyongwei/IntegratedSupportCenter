using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HanDe_ClassLibrary.Common.Process
{
    public class ProcessCommon
    {
         public static void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/n,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi); 
        }

         public static void OpenFile(String fileFullName)
         {
             if (File.Exists(fileFullName))
             {
                 System.Diagnostics.Process.Start(fileFullName);
             }
         }
    }
}
