using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.GenericFunction
{
    public class Account : IAccount
    {
        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public override string Name { get; }
        public override decimal Balance { get; }
    }
}