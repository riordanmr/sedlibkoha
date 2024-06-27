using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintHold
{
    public class Settings
    {
        public Settings() { }

        public string FontFamilyPatron { get; set; } = "Georgia";

        public float FontSizePatron { get; set; } = 18.0F;

        public string FontFamilyOther { get; set; } = "Arial";

        public float FontSizeOther { get; set; } = 12.0F;

        public int UpperLeftX { get; set; } = 15;

        public int UpperLeftY { get; set; } = 15;
    }
}
