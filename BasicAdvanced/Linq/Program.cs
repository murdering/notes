using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Linq
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 延迟执行
            DeferredExecutionFunction();

            ReadLine();
        }

        // 延迟执行
        public static void DeferredExecutionFunction()
        {
            WriteLine("############# deferred excution #############");
            WriteLine("##### first time #######");
            var names = new List<string>() { "Leo", "Lee", "Jason", "Eddy", "Alex", "Mic", "Apple" };
            var namesL = names.Where(n => n.StartsWith('L'));
            foreach (var name in namesL)
            {
                WriteLine(name);
            }

            names.Add("Lion");
            names.Add("Lim");
            names.Add("Kent");
            names.Add("Hush");
            WriteLine("##### second time #######");

            foreach (var name in namesL)
            {
                WriteLine(name);
            }

            WriteLine("############# using ToList() #############");
            WriteLine("##### first time #######");
            names = new List<string>() { "Leo", "Lee", "Jason", "Eddy", "Alex", "Mic", "Apple" };
            var namesL2 = names.Where(n => n.StartsWith('L')).ToList();
            foreach (var name in namesL2)
            {
                WriteLine(name);
            }

            names.Add("Lion");
            names.Add("Lim");
            names.Add("Kent");
            names.Add("Hush");
            WriteLine("##### second time #######");

            foreach (var name in namesL2)
            {
                WriteLine(name);
            }
        }
    }
}