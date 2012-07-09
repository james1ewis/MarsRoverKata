using System;
using System.Linq;

namespace ClassLibrary2
{
    public enum HeadingEnum
    {
        North,
        East,
        South,
        West,
        Unknown
    }

    public class Heading
    {
        public HeadingEnum HeadingEnum { get; private set; }

        public Heading(HeadingEnum headingEnum)
        {
            HeadingEnum = headingEnum;
        }

        public override string ToString()
        {
            switch (HeadingEnum)
            {
                case HeadingEnum.North:
                    return "N";
                case HeadingEnum.East:
                    return "E";
                case HeadingEnum.South:
                    return "S";
                case HeadingEnum.West:
                    return "W";
                default: return string.Empty;
            }
        }

        public static Heading Parse(string headingString)
        {
            var validHeadings = new string[] { "N", "E", "S", "W" };

            if (string.IsNullOrEmpty(headingString) || !validHeadings.Contains(headingString))
                throw new InvalidOperationException("rover only accepts valid heading information on initialization");

            switch (headingString)
            {
                case "N":
                    return new Heading(HeadingEnum.North);
                case "E":
                    return new Heading(HeadingEnum.East);
                case "S":
                    return new Heading(HeadingEnum.South);
                case "W":
                    return new Heading(HeadingEnum.West);
                default: return new Heading(HeadingEnum.Unknown);
            }
        }
    }
}
