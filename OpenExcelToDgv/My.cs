using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenExcelToDgv
{
    public static class My
    {

        public static void ShowErrorMessage(string mess)
        {
            MessageBox.Show(mess, "错误!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static double GetYunfei(double area,double km)
        {
            //double yunfei = 0;
            //if (km<=15)
            //{
            //    yunfei = area * 0.07;
            //}
            //else
            //{
            //    yunfei = ((km - 15) * 0.0012 + 0.07) * area;
            //}

            //return yunfei;


            double freight = 0;
            if (km <= 15)
            {
                freight = 0.07 * area;
            }
            else if (16 <= km && km <= 20) { freight = 0.076 * area; }
            else if (21 <= km && km <= 25) { freight = 0.082 * area; }
            else if (26 <= km && km <= 30) { freight = 0.088 * area; }
            else if (31 <= km && km <= 35) { freight = 0.094 * area; }
            else if (36 <= km && km <= 40) { freight = 0.1 * area; }
            else if (41 <= km && km <= 45) { freight = 0.106 * area; }
            else if (46 <= km && km <= 50) { freight = 0.112 * area; }
            else if (51 <= km && km <= 55) { freight = 0.118 * area; }
            else if (56 <= km && km <= 60) { freight = 0.124 * area; }
            else if (61 <= km && km <= 65) { freight = 0.13 * area; }
            else if (66 <= km && km <= 70) { freight = 0.136 * area; }
            else if (71 <= km && km <= 75) { freight = 0.142 * area; }
            else if (76 <= km && km <= 80) { freight = 0.148 * area; }
            else if (81 <= km && km <= 85) { freight = 0.154 * area; }
            else if (86 <= km && km <= 90) { freight = 0.16 * area; }
            else if (91 <= km && km <= 95) { freight = 0.166 * area; }
            else if (96 <= km && km <= 100) { freight = 0.172 * area; }
            else if (101 <= km && km <= 105) { freight = 0.178 * area; }
            else if (106 <= km && km <= 110) { freight = 0.184 * area; }
            else if (111 <= km && km <= 115) { freight = 0.19 * area; }
            else if (116 <= km && km <= 120) { freight = 0.196 * area; }
            else if (121 <= km && km <= 125) { freight = 0.202 * area; }
            else if (126 <= km && km <= 130) { freight = 0.208 * area; }
            else if (131 <= km && km <= 135) { freight = 0.214 * area; }
            else if (136 <= km && km <= 140) { freight = 0.22 * area; }
            else if (141 <= km && km <= 145) { freight = 0.226 * area; }
            else if (146 <= km && km <= 150) { freight = 0.232 * area; }
            else if (151 <= km && km <= 155) { freight = 0.238 * area; }
            else if (156 <= km && km <= 160) { freight = 0.244 * area; }
            else if (161 <= km && km <= 165) { freight = 0.25 * area; }
            else//[(公里数-15)*0.0012+0.07]*平方数
            {
                freight = ((km - 15) * 0.0012 + 0.07) * area;
            }



            return Math.Round(freight, 2);
        }


    }
}
