using sys = System;
using static System.Console;
using Array.Class;

namespace Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //锯齿数组
            JaggedFunction();
            //数组默认排序
            DefaultArraySort();
            //IComparable排序
            ArraySortComparable();
            //IComparer排序
            ArraySortComparer();
            //yield使用
            YieldFunciton();
            ReadLine();
        }

        public static void JaggedFunction()
        {
            int[][] jagged = new int[3][];
            jagged[0] = new int[2] { 1, 2 };
            jagged[1] = new int[6] { 3, 4, 5, 6, 7, 8 };
            jagged[2] = new int[3] { 9, 10, 11 };

            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    WriteLine($"row: {i}, element: {j}, value: {jagged[i][j]}");
                }
            }
        }

        // 数组默认排序
        private static void DefaultArraySort()
        {
            WriteLine("######################Default Array Sort Start#############################");

            string[] names = { "Cristina", "Lady Gaga", "Shakira", "Beyonce" };
            sys.Array.Sort(names);

            foreach (var name in names)
            {
                WriteLine(name);
            }
        }

        // 数组 IComparable 排序
        private static void ArraySortComparable()
        {
            WriteLine("######################Array Sort IComparable Start#############################");
            Person[] persons = {
                new Person{ FirstName = "James", LastName = "Bond"},
                new Person{ FirstName = "Leo", LastName = "Gaga"},
                new Person{ FirstName = "Shakira", LastName = "Ripoll"},
                new Person{ FirstName = "Cristina", LastName = "Own"},
                new Person{ FirstName= "Leo", LastName = "Dai"}
            };
            foreach (var item in persons)
            {
                WriteLine($"First Name: {item.FirstName}, Last Name: {item.LastName}");
            }
            WriteLine("Array Sorted!!!");
            sys.Array.Sort(persons);
            foreach (var item in persons)
            {
                WriteLine($"First Name: {item.FirstName}, Last Name: {item.LastName}");
            }
        }

        // 数组 IComparer 排序
        private static void ArraySortComparer()
        {
            WriteLine("######################Array Sort IComparer Start#############################");
            Person[] persons = {
                new Person{ FirstName = "James", LastName = "Bond"},
                new Person{ FirstName = "Leo", LastName = "Gaga"},
                new Person{ FirstName = "Shakira", LastName = "Ripoll"},
                new Person{ FirstName = "Cristina", LastName = "Own"},
                new Person{ FirstName= "Leo", LastName = "Dai"}
            };
            foreach (var item in persons)
            {
                WriteLine($"First Name: {item.FirstName}, Last Name: {item.LastName}");
            }
            WriteLine("Array Sorted!!!");
            sys.Array.Sort(persons, new PersonComparer(PersonTypeEnum.FirstName));
            foreach (var item in persons)
            {
                WriteLine($"First Name: {item.FirstName}, Last Name: {item.LastName}");
            }
        }

        // yield 使用
        private static void YieldFunciton()
        {
            // hello world
            var helloCollection = new HelloCollection();

            foreach (var item in helloCollection)
            {
                WriteLine(item);
            }

            WriteLine("Music Title!!!!");
            // mustic tile
            var musicTitles = new MusicTitles();
            foreach (var item in musicTitles)
            {
                WriteLine(item);
            }
            WriteLine("Music Title Reverse!!!!");
            foreach (var item in musicTitles.Reverse())
            {
                WriteLine(item);
            }
            WriteLine("Music Title SubTitle!!!!");
            foreach (var item in musicTitles.SubTitle(1, 2))
            {
                WriteLine(item);
            }
        }
    }
}