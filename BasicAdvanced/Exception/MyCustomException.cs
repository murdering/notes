using System;
using System.Collections.Generic;
using System.Text;

namespace BasicAdvanced.ExceptionSample
{
    internal class MyCustomException : Exception
    {
        public int ErrorCode { get; set; }

        public MyCustomException(string msg) : base(msg)
        {
        }
    }
}