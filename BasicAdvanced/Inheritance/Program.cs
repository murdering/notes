using System;
using static System.Console;

namespace Inheritance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //多态
            PolymorphismFunction();
            // 派生类的构造函数
            ChildClassFunction();

            ReadLine();
        }

        // 多态
        public static void PolymorphismFunction()
        {
            WriteLine("######################Polymorphism function Start#############################");
            Animal cow1 = new Cow();
            Cow cow2 = new Cow();

            Animal sheep1 = new Sheep();
            Sheep sheep2 = new Sheep();

            cow1.Eat();
            cow1.Shit();
            cow2.Eat();
            cow2.Shit();

            sheep1.Eat();
            sheep1.Shit();
            sheep2.Eat();
            sheep2.Shit();
        }

        // 派生类的构造函数
        public static void ChildClassFunction()
        {
            WriteLine("######################ChildClass function Start#############################");
            var rect = new Rectangle();

            WriteLine(rect.Position.ToString());
            WriteLine(rect.Size.ToString());
        }
    }
}