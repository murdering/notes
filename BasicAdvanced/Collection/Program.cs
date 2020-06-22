using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Collection
{
    internal class Program
    {
        private static readonly Racer[] defaultRacers = {
                new Racer(1, "Leo", "Dai", "China", 100),
                new Racer(5, "Lang", "Xu", "China", 90),
                new Racer(4, "Alain", "Prost", "France", 40),
                new Racer(2, "Nikki", "Lauda", "Austria", 80),
                new Racer(3, "Michael", "Schumacher", "Germany", 50),
            };

        private static void Main(string[] args)
        {
            // list 排序
            // SortListFunction();

            // Queue<T>
            // QueueFunction();

            // Stack<T>
            // StackFunction();

            // 有序列表`SortedList<TKey, TValue>`
            // SortedListFunction();

            // Set
            // SetFunction();

            // 遍历List并一边删除或添加
            DynamicRemoveInListIterator();

            ReadLine();
        }

        // list 排序
        public static void SortListFunction()
        {
            List<Racer> racers = new List<Racer>();
            racers.AddRange(defaultRacers);

            racers.Sort();

            foreach (var racer in racers)
            {
                WriteLine(racer.ToString());
            }
            WriteLine("#############Using Comparison<T> to sort#############");
            // Comparison<T>
            racers.Sort((r1, r2) => r2.Wins.CompareTo(r1.Wins));
            foreach (var racer in racers)
            {
                WriteLine(racer.ToString());
            }
        }

        // Queue<T>
        public static void QueueFunction()
        {
            WriteLine("#############Using Queue<T>#############");
            var queue = new Queue<Racer>();
            foreach (var racer in defaultRacers)
            {
                queue.Enqueue(racer);
            }

            foreach (var racer in queue)
            {
                WriteLine(racer.ToString());
            }

            while (queue.Count > 0)
            {
                WriteLine(queue.Dequeue().ToString());
            }
        }

        // Stack<T>
        public static void StackFunction()
        {
            WriteLine("#############Using Stack<T>#############");

            var stack = new Stack<Racer>();
            foreach (var racer in defaultRacers)
            {
                stack.Push(racer);
            }

            foreach (var racer in stack)
            {
                WriteLine(racer.ToString());
            }

            while (stack.Count > 0)
            {
                WriteLine(stack.Pop().ToString());
            }
        }

        // 有序列表`SortedList<TKey, TValue>`
        public static void SortedListFunction()
        {
            WriteLine("#############Using SortedList<TKey, TValue>#############");

            var sortedList = new SortedList<int, Racer>();
            foreach (var racer in defaultRacers)
            {
                sortedList.Add(racer.Id, racer);
            }

            foreach (var racer in sortedList)
            {
                WriteLine($"id: {racer.Key}, value: {racer.Value.ToString()}");
            }

            // output keys
            foreach (var id in sortedList.Keys)
            {
                WriteLine(id);
            }

            // key change to use Racer
            var sortedList1 = new SortedList<Racer, Racer>();
            foreach (var racer in defaultRacers)
            {
                sortedList1.Add(racer, racer);
            }

            foreach (var racer in sortedList1)
            {
                WriteLine($"id: {racer.Key.ToString()}, value: {racer.Value.ToString()}");
            }
        }

        // 集
        public static void SetFunction()
        {
            WriteLine("#############Using HashSet#############");

            var hashSet = new HashSet<Racer>();
            var sortedSet = new SortedSet<Racer>();

            foreach (var racer in defaultRacers)
            {
                hashSet.Add(racer);
                sortedSet.Add(racer);
            }

            hashSet.Add(new Racer(1, "Leo", "Dai", "China", 100));
            sortedSet.Add(new Racer(1, "Leo", "Dai", "China", 100));

            foreach (var racer in hashSet)
            {
                WriteLine(racer.ToString());
            }

            WriteLine("#############Using SortedSet#############");

            foreach (var racer in sortedSet)
            {
                WriteLine(racer.ToString());
            }
        }

        /// <summary>
        /// 遍历List并一边删除或添加
        /// </summary>
        public static void DynamicRemoveInListIterator()
        {
            int times = 0;
            var tempRacers = defaultRacers.ToList();

            WriteLine($"Before iteration(count {tempRacers.Count}):");
            tempRacers.ForEach(e => WriteLine(e.ToString()));

            for (var count = tempRacers.Count - 1; count >= 0; count--)
            {
                times++;
                if (tempRacers[count].FirstName == "Nikki")
                {
                    tempRacers.Remove(tempRacers[count]);
                }

                if (tempRacers[count].FirstName == "Lang")
                {
                    tempRacers.Add(new Racer(1, "Lang1", "Dai", "China", 70));
                    tempRacers.Add(new Racer(1, "Lang2", "Dai", "China", 71));
                }
            }

            WriteLine($"After iteration(count {tempRacers.Count}):");
            tempRacers.ForEach(e => WriteLine(e.ToString()));
            WriteLine($"iteration times: [ {times} ]");
        }
    }
}