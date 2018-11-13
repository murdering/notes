using System;
using static System.Console;

namespace OperatorAndTypeConversion
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 重载 + 运算符
            var v1 = new Vector(1, 1, 1);
            var v2 = new Vector(2, 2, 2);
            var v3 = v1 + v2;

            WriteLine($"v1: {v1}");
            WriteLine($"v2: {v2}");
            WriteLine($"v3: {v3}");
            WriteLine($"v4: {2 + v3}");
            ReadLine();
        }
    }
}