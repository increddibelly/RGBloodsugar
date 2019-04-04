using System.Globalization;

namespace LedScout.Model
{
    public class Color
    {
        public Color(string rgb_hex)
        {
            if (int.TryParse(rgb_hex, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out var color))
            {
                Red =   (color & 0xFF0000) >> 16;
                Green = (color & 0x00FF00) >> 8;
                Blue =  (color & 0x0000FF) >> 0;
            }
        }

        public int Red {get; set;}
        public int Green {get; set;}
        public int Blue {get; set;}
    }
}
