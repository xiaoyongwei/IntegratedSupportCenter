using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HanDe_ClassLibrary.Common.Unit;
using HandeJobManager.HanDe_ClassLibrary.Adobe.Acrobat;

namespace HanDe_ClassLibrary.Common.SizeBox
{
    public class CREO_TrimBox_MilliMetre
    {
        public PdfSizeBox TrimBox_Type { get; set; }
        
        private MilliMetre_Unit top;

        public MilliMetre_Unit Top
        {
            get { return top; }
        }
        private MilliMetre_Unit down;

        public MilliMetre_Unit Down
        {
            get { return down; }
        }
        private MilliMetre_Unit left;

        public MilliMetre_Unit Left
        {
            get { return left; }
        }
        private MilliMetre_Unit right;

        public MilliMetre_Unit Right
        {
            get { return right; }
        }

        private MilliMetre_Unit width;
        /// <summary>
        /// 宽度
        /// </summary>
        public MilliMetre_Unit Width
        {
            get { return width; }
        }

        private MilliMetre_Unit high;
        /// <summary>
        /// 高度
        /// </summary>
        public MilliMetre_Unit High
        {
            get { return high; }
        }



        public CREO_TrimBox_MilliMetre(MilliMetre_Unit top, MilliMetre_Unit down, MilliMetre_Unit left, MilliMetre_Unit right)
        {
            this.top = top;
            this.down = down;
            this.left = left;
            this.right = right;

            this.width = new MilliMetre_Unit(Math.Abs(this.Right.Length - this.Left.Length));
            this.high = new MilliMetre_Unit(Math.Abs(this.Top.Length - this.Down.Length));


        }

        public string ToString_WxH()
        {
            return this.Width.Length + "x" + this.High.Length;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param customerName="digits">要精确到的位数</param>
        /// <returns></returns>
        public string ToString_WxH(int digits)
        {
            return Math.Round(this.Width.Length, digits) + "x" + Math.Round(this.High.Length, digits);        
        }


        public CREO_TrimBox_Point ToCREO_TrimBox_Point()
        {
            return new CREO_TrimBox_Point(
                new Point_Unit(this.Top.Length / ConversionConstant.MM_PER_PT),
                    new Point_Unit(this.Down.Length / ConversionConstant.MM_PER_PT),
                    new Point_Unit(this.Left.Length / ConversionConstant.MM_PER_PT),
                    new Point_Unit(this.Right.Length / ConversionConstant.MM_PER_PT)
                    );

        }

    }
}
