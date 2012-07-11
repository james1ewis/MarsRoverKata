using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public class HeadingAdjustment : IHeadingAdjustment
    {
        private readonly Direction _direction;

        public HeadingAdjustment(Direction direction)
        {
            _direction = direction;
        }

        public Direction GetDirectionalAdjustment()
        {
            return _direction;
        }
    }
}
