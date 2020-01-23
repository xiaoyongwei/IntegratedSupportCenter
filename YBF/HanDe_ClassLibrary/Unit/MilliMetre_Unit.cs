using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Common.Unit
{
    public class MilliMetre_Unit:Unit
    {
        
        public MilliMetre_Unit(double len)
            : base(len)
        {
            
        }

        public Point_Unit ToPoint()
        {
            return new Point_Unit(this.Length / ConversionConstant.MM_PER_PT);
        }
    }
}
