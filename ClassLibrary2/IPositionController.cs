﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public interface IPositionController
    {
        void ProgressPosition();
        void AdjustHeading(IHeadingAdjustment navCommand);
        int CurrentX { get; }
        int CurrentY { get; }
        void SetBounds(IPlateau plateau);
    }
}
