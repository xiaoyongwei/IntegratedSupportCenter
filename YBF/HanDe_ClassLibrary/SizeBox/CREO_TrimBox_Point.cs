using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HanDe_ClassLibrary.Common.Unit;

namespace HanDe_ClassLibrary.Common.SizeBox
{
    public class CREO_TrimBox_Point
    {
        public Point_Unit Top { get; set; }
        public Point_Unit Down { get; set; }
        public Point_Unit Left { get; set; }
        public Point_Unit Right { get; set; }

        private Point_Unit width;
        /// <summary>
        /// 宽度
        /// </summary>
        public Point_Unit Width
        {
            get { return width; }
        }

        private Point_Unit high;
        /// <summary>
        /// 高度
        /// </summary>
        public Point_Unit High
        {
            get { return high; }
        }



        public CREO_TrimBox_Point(Point_Unit top, Point_Unit down, Point_Unit left, Point_Unit right)
        {
            this.Top = top;
            this.Down = down;
            this.Left = left;
            this.Right = right;

            this.width = new Point_Unit(Math.Abs(this.Right.Length - this.Left.Length));
            this.high = new Point_Unit(Math.Abs(this.Top.Length - this.Down.Length));


        }

        public string ToString_WxH()
        {
            return this.Width.Length + "x" + this.High.Length;            
        }

        public CREO_TrimBox_MilliMetre ToCREO_TrimBox_MilliMetre()
        {
            return new CREO_TrimBox_MilliMetre(
                new MilliMetre_Unit(this.Top.Length * ConversionConstant.MM_PER_PT),
                    new MilliMetre_Unit(this.Down.Length * ConversionConstant.MM_PER_PT),
                    new MilliMetre_Unit(this.Left.Length * ConversionConstant.MM_PER_PT),
                    new MilliMetre_Unit(this.Right.Length * ConversionConstant.MM_PER_PT)
                    );
                    
        }


    }
}
