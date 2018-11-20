using System;
using static System.Console;

namespace BasicAdvanced.ExceptionSample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 异常初试
            //FirstExceptionFunction();
            // 异常过滤器
            //ExceptionFilterFunction();
            //重新抛出异常
            RethrowExceptionFunction();

            ReadLine();
        }

        // 异常初试
        public static void FirstExceptionFunction()
        {
            while (true)
            {
                try
                {
                    string input = string.Empty;
                    WriteLine("pls input a number between 0 and 5, or just hit enter to exit.");

                    input = ReadLine();

                    if (string.IsNullOrEmpty(input)) break;

                    int num = Convert.ToInt32(input);

                    if (num < 0 || num > 5) throw new IndexOutOfRangeException($"You typed in {input}");

                    WriteLine($"The number you inputted is: {num}");
                }
                catch (IndexOutOfRangeException ex)
                {
                    WriteLine($"Number should be between 0 and 5, {ex.Message}");
                }
                catch (Exception ex)
                {
                    WriteLine($"An exception was thrown, {ex.Message}");
                }
                finally
                {
                    WriteLine("Thank you! \n");
                }
            }
        }

        // 异常过滤器
        public static void ExceptionFilterFunction()
        {
            while (true)
            {
                try
                {
                    string input = string.Empty;
                    WriteLine("pls input the error code.");

                    input = ReadLine();

                    if (string.IsNullOrEmpty(input)) break;

                    int errorcode = Convert.ToInt32(input);

                    throw new MyCustomException($"{input} MyCustomException") { ErrorCode = errorcode };
                }
                catch (MyCustomException ex) when (ex.ErrorCode == 405)
                {
                    WriteLine($"MyCustomException is thrown, {ex.Message}");
                }
                catch (Exception ex)
                {
                    WriteLine($"An exception was thrown, {ex.Message}");
                }
                finally
                {
                    WriteLine("Thank you! \n");
                }
            }
        }

        // 重新抛出异常
        public static void RethrowExceptionFunction()
        {
            var actions = new Action[] {
                HandleAndThrowAgain,
                HandleAndThrowWithInnerException,
                HandleAndRethrow,
                HandleAndFilter
            };

            foreach (var action in actions)
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                    WriteLine(ex.StackTrace);
                    if (ex.InnerException != null)
                    {
                        WriteLine($"inner exception: {ex.InnerException.Message}");
                        WriteLine($"inner exception stack trace: {ex.InnerException.StackTrace}");
                    }
                }
            }
        }

        private static void ThrowAnException(string msg)
        {
            throw new MyCustomException(msg);
        }

        private static void HandleAndThrowAgain()
        {
            try
            {
                ThrowAnException("test 1");
            }
            catch (Exception ex)
            {
                WriteLine($"log exception {ex.Message} and throw again");
                throw ex;
            }
        }

        private static void HandleAndThrowWithInnerException()
        {
            try
            {
                ThrowAnException("test 2");
            }
            catch (Exception ex)
            {
                WriteLine($"log exception {ex.Message} and throw again");
                throw new AnotherCustomException("throw with inner exception", ex);
            }
        }

        private static void HandleAndRethrow()
        {
            try
            {
                ThrowAnException("test 3");
            }
            catch (Exception ex)
            {
                WriteLine($"log exception {ex.Message} and throw again");
                throw;
            }
        }

        private static void HandleAndFilter()
        {
            try
            {
                ThrowAnException("test 4");
            }
            catch (Exception ex) when (Filter(ex))
            {
                WriteLine($"block will be never called!");
            }
        }

        private static bool Filter(Exception ex)
        {
            WriteLine($"just log {ex.Message}");
            return false;
        }
    }
}