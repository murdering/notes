using System;
using static System.Console; // C# 6 新特性

namespace Basics
{
    class Program
    {
        const int j = 20; // 隐式静态
        static void Main(string[] args)
        {
            //int j = 10;
            WriteLine("Hello World! {0}", j);

            // String
            StringFunction();

            //Enum
            EnumFunction();

            ReadLine();
        }

        public static void StringFunction() {
            //String

            //@
            string filePath1 = "C:\\Windows";
            string filePath2 = @"C:\Windows";

            WriteLine("filePath1: {0} , filePath2: {1}", filePath1, filePath2);

            // string ref
            string s1 = "a string";
            string s2 = s1;

            WriteLine("s1: " + s1);
            WriteLine("s2: " + s2);

            s1 = "new string";

            WriteLine("s1 new: " + s1);
            WriteLine("s2 new: " + s2);

            // $ --> C# 6新特性,允许{}里放变量或者代码表达式
            WriteLine($"s1 $: {s1}");
            WriteLine($"1 == 2 $: { 1 == 2}");
        }

        public static void EnumFunction()
        {
            TimeOfDay time = TimeOfDay.Afternoon;

            WriteLine(time);
            WriteLine((int)time);
            WriteLine(time.ToString());

            TimeOfDay time2 = (TimeOfDay)Enum.Parse(typeof(TimeOfDay), "evening", true); // 第三参数bool为是否忽略大小写 
            WriteLine(time2);
            WriteLine((int)time2);
            WriteLine(time2.ToString());
        }
    }


    public enum TimeOfDay
    {
        Morning = 0,
        Afternoon = 1,
        Evening = 2
    }
}
