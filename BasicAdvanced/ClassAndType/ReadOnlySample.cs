using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndType
{
    public class ReadOnlySample
    {
        static ReadOnlySample()
        {
            StartTime = DateTime.Now;
        }

        public ReadOnlySample(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public const int DayOfWeek = 1;
        public static readonly DateTime StartTime;
        public readonly string FirstName = "default";
        public string LastName { get; }
        public string FullName => $"{FirstName}, {LastName}";
        // C# 6实现自动只读属性
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
