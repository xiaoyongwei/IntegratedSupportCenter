using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace YBF.HanDe_ClassLibrary.PrinergyEvo
{
    public static class EvoProcess
    {
        public static string GetCPC_OutputDestination(string fileFullName)
        {
            string CPC_OutputDestinatio = "";
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                sr = new StreamReader(fs);
                string AllText = sr.ReadToEnd();
                sr.Dispose();
                fs.Dispose();
                Match match = Regex.Match(AllText, @"/CPC_OutputDestination \(.*\)");
                if (match != null)
                {
                    string str = match.Value;
                    CPC_OutputDestinatio = str.Remove(str.Length - 1)
                    .Replace("/CPC_OutputDestination (", "").Trim();
                }
            }
            catch
            {
                CPC_OutputDestinatio = "";
            }
            finally
            {
                if (sr!=null)
                {
                    sr.Dispose();
                }
                if (fs!=null)
                {
                    fs.Dispose();
                }
            }
            return CPC_OutputDestinatio;
        }
    }
}
