using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace StringAndRegularExpression
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // String
            StringFunction();
            // StringBuilder
            StringBuilderFunction();
            // format
            FormatFunction();
            //自定义字符串格式
            PersonlizationFormatFunction();
            // 正则表达式
            RegularExpressionFunction();
            ReadLine();
        }

        // String
        public static void StringFunction()
        {
            var str = "this is for string builder!";
            for (int i = 'z'; i >= 'a'; i--)
            {
                char oldI = (char)i;
                char newI = (char)(i + 1);
                str = str.Replace(oldI, newI);
            }

            for (int i = 'z'; i >= 'a'; i--)
            {
                char oldI = (char)i;
                char newI = (char)(i + 1);
                str = str.Replace(oldI, newI);
            }

            WriteLine(str);
        }

        // StringBuilder
        public static void StringBuilderFunction()
        {
            var stringBuilder = new StringBuilder("this is for string builder!", 150);
            for (int i = 'z'; i >= 'a'; i--)
            {
                char oldI = (char)i;
                char newI = (char)(i + 1);
                stringBuilder = stringBuilder.Replace(oldI, newI);
            }

            for (int i = 'z'; i >= 'a'; i--)
            {
                char oldI = (char)i;
                char newI = (char)(i + 1);
                stringBuilder = stringBuilder.Replace(oldI, newI);
            }

            WriteLine(stringBuilder);
        }

        // format
        public static void FormatFunction()
        {
            // 转义花括号
            string s = "Hello";
            WriteLine($"{{s}} displays the value {s}");

            // 大写字母`D`表示长日期格式字符串，小写字母`d`表示短日期字符串
            var day = new DateTime(2025, 2, 14);
            WriteLine($"{day:D}");
            WriteLine($"{day:d}");
            WriteLine($"{day:dd-MMM-yyyy}");

            // `n`表示数字格式，`e`表示指数格式，`x`表示16进制，`c`表示货币
            int i = 2477;
            WriteLine($"{ i:n} , {i:e}, {i:x}, {i:c}");

            // #格式说明符是一个数字站位符，如果数字可用，就显示数字；如果数字不可用，不显示数字
            // 0格式说明符是一个零占位符，显示相应数字，如果数字不存在，就显示零
            double d = 3.1415926;
            WriteLine($"{d:###.###}");
            WriteLine($"{d:000.000}");
        }

        // 自定义字符串格式
        public static void PersonlizationFormatFunction()
        {
            var person = new Person { FirstName = "Leo", LastName = "Dai" };
            WriteLine($"ToString(): {person.ToString()}");
            WriteLine($"ToString('F'): {person.ToString("F")}");
            WriteLine($"ToString('L'): {person.ToString("L")}");
            WriteLine($"ToString('A'): {person.ToString("A")}");
            WriteLine($"ToString(null): {person.ToString(null)}");

            WriteLine($": F: {person:F}");
            WriteLine($": L: {person:L}");
            WriteLine($": A: {person:A}");
            //WriteLine($": null: {person:null}");
        }

        // 正则表达式
        public static void RegularExpressionFunction()
        {
            string line = "hey, I just found this amazing URI at "
                + "http:// waht at sdji yes https://www.wrox.com or "
                + "https://www.wrox.com:80";
            string pattern = @"\b(https?)(: //)([. \w]+)(\s:)([\d]{2,4}?) \b";
            var rex = new Regex(pattern);
            var matches = rex.Matches(line);

            foreach (Match match in matches)
            {
                WriteLine($"Match: {match}");
                foreach (Group g in match.Groups)
                {
                    if (g.Success)
                    {
                        WriteLine($"group index: {g.Index}, value: {g.Value}");
                    }
                }
            }
            WriteLine();
        }
    }
}