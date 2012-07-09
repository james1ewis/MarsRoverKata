using System;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class Position
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            var toStringBuilder = new StringBuilder();
            toStringBuilder.Append(X.ToString());
            toStringBuilder.Append(" ");
            toStringBuilder.Append(Y.ToString());

            return toStringBuilder.ToString();
        }

        public static Position Empty { get { return new Position(0, 0); } }

        public static Position Parse(string position)
        {
            if (string.IsNullOrEmpty(position))
                throw new InvalidOperationException("position can only parse valid input strings");

            var positionArray = position.Split(' ');

            if (positionArray.Count() != 2)
                throw new InvalidOperationException("position can only parse valid input strings");

            int x;
            int y;

            if (!int.TryParse(positionArray[0], out x))
                throw new InvalidOperationException("position can only parse valid input strings");
            if (!int.TryParse(positionArray[1], out y))
                throw new InvalidOperationException("position can only parse valid input strings");

            return new Position(x, y);
        }
    }
}
