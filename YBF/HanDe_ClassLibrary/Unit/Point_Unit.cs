using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Common.Unit
{
    public class Point_Unit:Unit
    {       

        public Point_Unit(double len)
            :base(len)
        {
            
        }

        public MilliMetre_Unit ToMilliMetre()
        {
            return new MilliMetre_Unit(this.Length * ConversionConstant.MM_PER_PT);
        }

    }
}
