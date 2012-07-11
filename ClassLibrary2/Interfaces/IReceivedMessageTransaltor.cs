using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    public interface IReceivedMessageTranslator
    {
        RoverInput Translate(string input);
    }
}
