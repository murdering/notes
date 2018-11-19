using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialCollection
{
    public class Account
    {
        public Account(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }

        public string Name { get; }
        public decimal Amount { get; }

        public override string ToString() => $"Name: {Name}, Amount: {Amount}";
    }
}