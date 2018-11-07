#define Community

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Console; // C# 6 新特性

namespace Basics
{
    internal class Program
    {
        private const int j = 20; // 隐式静态
        private const string specialCharator = @" ~!@#$%^&*()";

        private static void Main(string[] args)
        {
            //int j = 10;

            WriteLine("Hello World! {0}", j);

            // 使用关键字
            var @abstract = "abstract";
            WriteLine($"Hello key word! { @abstract}");

            // String
            StringFunction();

            // Enum
            EnumFunction();

            // PreProcess
            PreProcessFunction();

            ///  输出英文一句话中最长的单词
            /// Input: "fun&!! time"
            /// Output: "time"
            var str = getMaxString("I love dogs ahahahaha");
            WriteLine(str);

            ReadLine();
        }

        public static void StringFunction()
        {
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

        public static void PreProcessFunction()
        {
#if Community
#warning "You are getting one Community Wanring"
            WriteLine("this is for Community!");

#else
            WriteLine("this is for NORMAL!");
#error "You are getting one Community Error"
#endif
        }

        public static string getMaxString(string str)
        {
            var tempStr = string.Empty;
            string pattern = @"[^A-Za-z]";
            var strArray = Regex.Split(str, pattern);

            foreach (var item in strArray)
            {
                if (item.Length > tempStr.Length)
                {
                    tempStr = item;
                }
            }

            return tempStr;
        }

        public static string getMax2String(string str)
        {
            List<int> positionList = new List<int>();
            List<string> stringList = new List<string>();
            var tempStr = "";

            //get char position in char array
            var strArray = str.ToCharArray();
            for (int i = 0; i < strArray.Length; i++)
            {
                var tempIndex = specialCharator.IndexOf(strArray[i]);
                if (tempIndex > -1)
                {
                    positionList.Add(i);
                }
            }

            // get string substring by position
            var positionArray = positionList.ToArray();
            for (int i = 0; i < positionArray.Length - 1; i++)
            {
                var item = str.Substring(positionArray[i], positionArray[i + 1] - positionArray[i]);
                stringList.Add(item);
            }

            var lastIndex = positionArray[positionArray.Length - 1];
            stringList.Add(str.Substring(lastIndex, str.Length - lastIndex));

            // get max one
            foreach (var item in stringList)
            {
                if (item.Length > tempStr.Length)
                {
                    tempStr = item;
                }
            }

            return tempStr;
        }
    }

    public enum TimeOfDay
    {
        Morning = 0,
        Afternoon = 1,
        Evening = 2
    }
}