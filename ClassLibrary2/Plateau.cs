using System;
using System.Linq;

namespace ClassLibrary2
{
    public class Plateau : IPlateau
    {
        public int UpperX { get; set; }
        public int UpperY { get; set; }
        public int LowerX { get; set; }
        public int LowerY { get; set; }

        public static IPlateau Parse(string bounds)
        {
            if (string.IsNullOrEmpty(bounds))
                throw new InvalidOperationException("plateau can only parse valid input strings");

            var boundsArray = bounds.Split(' ');

            if (boundsArray.Count() != 2)
                throw new InvalidOperationException("plateau can only parse valid input strings");

            int x;
            int y;

            if (!int.TryParse(boundsArray[0], out x))
                throw new InvalidOperationException("plateau can only parse valid input strings");
            if (!int.TryParse(boundsArray[1], out y))
                throw new InvalidOperationException("plateau can only parse valid input strings");

            return new Plateau { UpperX = x, UpperY = y, LowerX = 0, LowerY = 0 };
        }
    }
}
