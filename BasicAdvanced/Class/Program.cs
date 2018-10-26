using System;
using static System.Console;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            // 属性
            PropertyFunction();
            // params 关键字
            ParamsFunction(1, 2, 3);

            ReadLine();
        }

        public static void PropertyFunction()
        {
            WriteLine($"PI is {Math.GetPi()}");
            WriteLine($"Square of 5 is : {Math.GetSquareOf(5)} ");
            var math = new Math();
            math.Value = 6;
            WriteLine($"Value of Math is : {math.Value}");
            WriteLine($"Square of Math Value is : {math.GetSquare()}");

            // 带参数名字, 默认值, 并且可以乱序
            WriteLine($"Divide of Value 5 with default is : {Math.GetDivid(5)}");
            WriteLine($"Divide of Value 5 with default is : {Math.GetDivid(numerator: 2, denominator: 5)}");
        }

        // params 关键字
        public static void ParamsFunction(params int[] array)
        {
            foreach (var i in array)
            {
                WriteLine($"params item: {i}");
            }
        }
    }
}
