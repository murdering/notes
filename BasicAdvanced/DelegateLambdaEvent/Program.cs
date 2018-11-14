using System;
using static System.Console;
using DelegateLambdaEvent.Event;

namespace DelegateLambdaEvent
{
    internal class Program
    {
        private delegate string getString();

        private delegate string getStringWithOneParam(string str);

        private delegate double MathOperation(double value);

        private static void Main(string[] args)
        {
            // 委托sample 1 => Currency
            CurrentDelegateFunction();
            // 委托sample2 => MathOperations
            MathOperationsDelegateFunction();
            // 委托sample3 ==> Action<T>和Func<T>
            ActionFuncDelegateFunction();
            // 委托sample 4 ==> 多播委托
            MulticastDelegateFunction();
            // lambda表达式
            LambdaFunction();
            // 事件
            EventFunction();

            ReadLine();
        }

        #region 委托sample1 => Currency

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

        #endregion 委托sample1 => Currency

        #region 委托sample2 => MathOperations

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

        #endregion 委托sample2 => MathOperations

        #region 委托sample3 ==> Action<T>和Func<T>

        public static void ActionFuncDelegateFunction()
        {
            // using Func<T>
            Func<double, double>[] operations = { MathOperations.MultiplyByTwo, MathOperations.Square };

            foreach (var operation in operations)
            {
                ProcessAndDisplayNumber(operation, 5);
            }
            // using Act<T>
            Action<string> action = Currency.ShowCurrency;
            action("China");
        }

        // Func
        private static void ProcessAndDisplayNumber(Func<double, double> action, double value)
        {
            WriteLine($"MathOperation name: {nameof(action)}, value: {value}, result: {action(value)}");
        }

        // Action
        private static void GetCurrenctAction(Action<string> action, string name)
        {
            action(name);
        }

        #endregion 委托sample3 ==> Action<T>和Func<T>

        #region 委托sample 4 ==> 多播委托

        public static void MulticastDelegateFunction()
        {
            Action<double> operations = MathOperations.MultipleByTwoMulticast;
            operations += MathOperations.SquareMulticast;

            ProcessAndDisplayNumber(operations, 10);
            ProcessAndDisplayNumber(operations, 15);
            ProcessAndDisplayNumber(operations, 30);
        }

        private static void ProcessAndDisplayNumber(Action<double> action, double value)
        {
            WriteLine($"The input value is: {value}");
            action(value);
        }

        #endregion 委托sample 4 ==> 多播委托

        #region lambda表达式

        public static void LambdaFunction()
        {
            // lambda Func<T>, 闭包
            string mid = ", middle part,";
            Func<string, string> func = param =>
            {
                param += mid;
                param += " and this was added to this string.";
                return param;
            };

            WriteLine($"lambda Func<T> sample: {func("Leo Dai")}");

            // lambda delegate
            getStringWithOneParam getString = param =>
            {
                param += mid;
                param += " and this was added to this string.";
                return param;
            };

            WriteLine($"lambda delegate sample: {func("James Bond")}");

            // lamda action with multiple params
            Action<string, string, string> action = (param1, param2, param3) =>
            {
                WriteLine(param1 + ", " + param2 + ", " + param3 + ".");
            };
            action("I love this city", "Leo Dai", "In CD");
        }

        #endregion lambda表达式

        #region 事件

        public static void EventFunction()
        {
            var carDealer = new CarDealer();
            var leo = new CarConsumer("Leo");
            carDealer.NewCarInfo += leo.NewCarIsHere;

            carDealer.NewCar("Haval 6");

            var james = new CarConsumer("James");
            carDealer.NewCarInfo += james.NewCarIsHere;

            carDealer.NewCar("Audi A4L");

            carDealer.NewCarInfo -= james.NewCarIsHere;

            carDealer.NewCar("Range Rover Discovery 4");
        }

        #endregion 事件
    }
}