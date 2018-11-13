using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateLambdaEvent
{
    public class MathOperations
    {
        private MathOperations()
        {
        }

        public static double MultiplyByTwo(double value) => value * 2;

        public static double Square(double value) => value * value;
    }
}