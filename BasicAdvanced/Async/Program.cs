using System;
using System.Threading.Tasks;
using static System.Console;

namespace BasicAdvanced.Async
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 没有异步
            CallerWithoutAsync();

            // 使用异步 -- await
            CallerWithAsync();
            CallerWithAsync2();

            // 使用异步 -- ContinueWith
            CallerWithContinueWith();

            // 按顺序调用多个方法
            CalledWithMultipleAsyncMethod();

            // 使用组合器
            CalledWithMultipleAsyncMethodCombinator();

            // 转换异步模式 --> .Net Core 2.0不支持
            //ConvertAsyncPattern();

            // 捕获不到异常
            DontHandleAsync();

            // 捕获异常 -- use 'await'
            HandleOneErrorAsync();

            // 捕获多个异常 -- 顺序，不会执行第二个异常
            StartTwoTasks();

            // 捕获多个异常 -- 并行，两个异常都会执行，但是只显示第一个异常
            StartTwoTasksParallel();

            // 捕获多个异常 -- 并行，但是显示所有的错误，使用‘Task.Exception.InnerException’
            ShowAggregateException();

            ReadLine();
        }

        // 异步编程基础
        private static string Greeting(string name)
        {
            Task.Delay(3000).Wait();
            return $"Hello, {name}!";
        }

        private static Task<string> GreetingAsync(string name)
        {
            return Task.Run(() =>
            {
                return Greeting(name);
            });
        }

        // 没有异步
        public static void CallerWithoutAsync()
        {
            string result = Greeting("James Bond");

            WriteLine(result);
        }

        // 使用异步 -- await1
        public static async void CallerWithAsync()
        {
            string result = await GreetingAsync("Leo Dai");

            WriteLine(result);
        }

        // 使用异步 -- await2
        public static async void CallerWithAsync2()
        {
            WriteLine(await GreetingAsync("Jason Bourn"));
        }

        // 使用异步 -- ContinueWith
        public static void CallerWithContinueWith()
        {
            Task<string> task = GreetingAsync("Harry Potter");
            WriteLine("before Task.ContinueWith");
            task.ContinueWith(t =>
            {
                string result = t.Result;
                WriteLine(result);
            });
        }

        // 按顺序调用多个方法
        public static async void CalledWithMultipleAsyncMethod()
        {
            string r1 = await GreetingAsync("Hermione Granger");
            WriteLine(r1);

            string r2 = await GreetingAsync("Ron Weasley");
            WriteLine(r2);
        }

        // 使用组合器
        public static async void CalledWithMultipleAsyncMethodCombinator()
        {
            Task<string> t1 = GreetingAsync("Albus Dumbledore");
            Task<string> t2 = GreetingAsync("Severus Snape");
            WriteLine("before Task.WhenAll");
            await Task.WhenAll(t1, t2);
            WriteLine(t1.Result);
            WriteLine(t2.Result);

            WriteLine("using result array");
            var result = await Task.WhenAll(t1, t2);
            WriteLine(result[0]);
            WriteLine(result[1]);
        }

        // 转换异步模式 --> .Net Core 2.0不支持
        private static Func<string, string> greetingInvoker = Greeting;

        private static IAsyncResult BeginGreeting(string name, AsyncCallback asyncCallback, object state)
        {
            return greetingInvoker.BeginInvoke(name, asyncCallback, state);
        }

        private static string EndGreeting(IAsyncResult asyncResult)
        {
            return greetingInvoker.EndInvoke(asyncResult);
        }

        public static async void ConvertAsyncPattern()
        {
            string r = await Task<string>.Factory.FromAsync(BeginGreeting, EndGreeting, "Leo Dai", null);
            WriteLine(r);
        }

        // 异常
        private static async Task ThrowAfter(int ms, string msg)
        {
            await Task.Delay(ms);
            throw new Exception(msg);
        }

        // 捕获不到异常 -- do not use keywords 'await'
        public static void DontHandleAsync()
        {
            try
            {
                ThrowAfter(200, "first");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        // 捕获异常 -- use 'await'
        public static async Task HandleOneErrorAsync()
        {
            try
            {
                await ThrowAfter(200, "first");
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        // 捕获多个异常 -- 顺序，不会执行第二个异常
        public static async Task StartTwoTasks()
        {
            try
            {
                await ThrowAfter(200, "first");
                await ThrowAfter(500, "second");
            }
            catch (Exception e)
            {
                WriteLine("handled" + e.Message);
            }
        }

        // 捕获多个异常 -- 并行，两个异常都会执行，但是只显示第一个异常
        public static async Task StartTwoTasksParallel()
        {
            try
            {
                Task t1 = ThrowAfter(200, "first");
                Task t2 = ThrowAfter(500, "second");
                await Task.WhenAll(t1, t2);
            }
            catch (Exception e)
            {
                WriteLine("handled" + e.Message);
            }
        }

        // 捕获多个异常 -- 并行，但是显示所有的错误，使用‘Task.Exception.InnerException’
        public static async Task ShowAggregateException()
        {
            Task taskResult = null;
            try
            {
                Task t1 = ThrowAfter(200, "first");
                Task t2 = ThrowAfter(500, "second");
                await (taskResult = Task.WhenAll(t1, t2));
            }
            catch (Exception e)
            {
                WriteLine("handled" + e.Message);
                foreach (var ie in taskResult?.Exception?.InnerExceptions)
                {
                    WriteLine($"inner exception: {ie.Message}");
                }
            }
        }
    }
}