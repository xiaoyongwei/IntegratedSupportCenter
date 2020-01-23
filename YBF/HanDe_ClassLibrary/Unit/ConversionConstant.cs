using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Common.Unit
{
    /// <summary>
    /// 各长度单位常量转换
    /// </summary>
    public static class ConversionConstant
    {
        /// <summary>
        /// 每毫米对应多少Pt(点)
        /// </summary>
        public const double MM_PER_PT = 25.4 / 72.0;

        public static double GetSize(double size, ConvertUnit cu, int digits)
        {
            double returnSize = 0;
            switch (cu)
            {
                case ConvertUnit.mm_to_pt:
                    returnSize = Math.Round(size / MM_PER_PT, digits);
                    break;
                case ConvertUnit.pt_to_mm:
                    returnSize = Math.Round(size * MM_PER_PT, digits);
                    break;
                default:
                    break;
            }
            return returnSize;
        }
       
    }

    public enum ConvertUnit
    {
        mm_to_pt,
        pt_to_mm
    }





}
