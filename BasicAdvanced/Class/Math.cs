using System;
using System.Collections.Generic;
using System.Text;

namespace Class
{
    class Math
    {
        public int Value { get; set; }

        // C# 6 新特性，提供lambda给一个语句的方法
        public int GetSquare() => Value * Value;

        public static int GetSquareOf(int x) => x * x;

        public static double GetPi() => 3.1415926;

        // 参数可以提供默认值
        public static float GetDivid(int denominator, int numerator = 1) => denominator / numerator;
    }
}
