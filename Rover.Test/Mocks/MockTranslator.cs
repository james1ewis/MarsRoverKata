using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary2;

namespace Rover.Test
{
    internal class MockTranslator : IReceivedMessageTranslator
    {
        public bool TranslateMethodWasCalled { get; private set; }
        public string TranslateMethodParameterValue { get; private set; }

        public MockTranslator()
        {
            TranslateMethodWasCalled = false;
            TranslateMethodParameterValue = string.Empty;
        }

        public RoverInput Translate(string input)
        {
            TranslateMethodWasCalled = true;
            TranslateMethodParameterValue = input;

            return (TranslateReturnObject == null) ? RoverInput.Empty : TranslateReturnObject;
        }

        public RoverInput TranslateReturnObject { get; set; }
    }
}
