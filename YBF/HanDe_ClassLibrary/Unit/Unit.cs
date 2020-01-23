using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HanDe_ClassLibrary.Common.Unit
{
    public class Unit
    {
        public double Length { get; set; }

        public Unit(double len)
        {
            this.Length = len;
        }
    }
}
