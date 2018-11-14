using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DelegateLambdaEvent
{
    public class MathOperations
    {
        private MathOperations()
        {
        }

        public static double MultiplyByTwo(double value) => value * 2;

        public static double Square(double value) => value * value;

        public static void MultipleByTwoMulticast(double value)
        => WriteLine($"MultiplyByTwo result: {value * 2}");

        public static void SquareMulticast(double value)
        => WriteLine($"Square result: {value * value}");
    }
}