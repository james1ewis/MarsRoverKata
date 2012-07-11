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

        public NavigationCommand Translate(string input)
        {
            TranslateMethodWasCalled = true;
            TranslateMethodParameterValue = input;

            return (TranslateReturnObject == null) ? NavigationCommand.Empty : TranslateReturnObject;
        }

        public NavigationCommand TranslateReturnObject { get; set; }
    }
}
