using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 综合保障中心.运费
{
    class YunfeiMdd
    {
        public string QuYu { get; set; }
        public string Mdd { get; set; }
        public int LiCheng { get; set; }
        public int XiaoChe { get; set; }
        public int DaChe { get; set; }

        public YunfeiMdd(string quyu,string mdd,int km,int xiaoche,int dache)
        {
            this.QuYu = quyu;
            this.Mdd = mdd;
            this.LiCheng = km;
            this.XiaoChe = xiaoche;
            this.DaChe = dache;
        }
    }
}
