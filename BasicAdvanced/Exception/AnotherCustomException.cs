using System;
using System.Collections.Generic;
using System.Text;

namespace BasicAdvanced.ExceptionSample
{
    internal class AnotherCustomException : Exception
    {
        public AnotherCustomException(string msg, Exception innerException) : base(msg, innerException)
        {
        }
    }
}