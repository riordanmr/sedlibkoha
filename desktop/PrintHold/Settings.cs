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

        public string FontFamily { get; set; } = "Georgia";

        public float FontSize { get; set; } = 14.0F;

        public int UpperLeftX { get; set; } = 15;

        public int UpperLeftY { get; set; } = 15;
    }
}
