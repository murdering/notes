using System;
using static System.Console;

namespace DelegateLambdaEvent
{
    internal class Program
    {
        private delegate string getString();

        private delegate double MathOperation(double value);

        private static void Main(string[] args)
        {
            // 委托sample 1 => Currency
            CurrentDelegateFunction();
            // 委托sample2 => MathOperations
            MathOperationsDelegateFunction();

            ReadLine();
        }

        // 委托sample 1 => Currency
        public static void CurrentDelegateFunction()
        {
            int i = 10;
            getString firstStringMethod = i.ToString;
            WriteLine($"firstString Method 1: {firstStringMethod()}");

            var currency = new Currency(10, 33);
            firstStringMethod = currency.ToString;
            WriteLine($"Currency To String: {firstStringMethod.Invoke()}");

            firstStringMethod = Currency.GetCurrency;
            WriteLine($"Curreny.GetCurrency: {firstStringMethod()}");

            Currency currency2 = (float)4.2;
            Currency currency3 = 5;
            firstStringMethod = currency2.ToString;
            WriteLine($"Currency2 To String: {firstStringMethod()}");

            firstStringMethod = currency3.ToString;
            WriteLine($"Curreny.GetCurrency: {firstStringMethod()}");
        }

        // 委托sample2 => MathOperations
        public static void MathOperationsDelegateFunction()
        {
            MathOperation[] operations = { MathOperations.MultiplyByTwo, MathOperations.Square };

            foreach (var operation in operations)
            {
                ProcessAndDisplayNumber(operation, 5);
            }
        }

        private static void ProcessAndDisplayNumber(MathOperation action, double value)
        {
            WriteLine($"MathOperation name: {nameof(action)}, value: {value}, result: {action(value)}");
        }
    }
}