using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using static System.Console;

namespace SpecialCollection
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // 不可变集合
            ImmutableCollectionFunction();

            ReadLine();
        }

        // 不可变集合
        public static void ImmutableCollectionFunction()
        {
            List<Account> accounts = new List<Account>() {
                new Account("Leo Dai", 10000),
                new Account("Michael Jackson", 9000),
                new Account("James Bond", 8000),
                new Account("Jason Bourn", -1)
            };
            WriteLine("############# ToImmutableList #############");

            var immutableAccounts = accounts.ToImmutableList();
            //foreach (var ac in immutableAccounts)
            //{
            //    WriteLine(ac.ToString());
            //}
            immutableAccounts.ForEach(ac => WriteLine(ac.ToString()));

            WriteLine("############# back to changable #############");
            var builder = immutableAccounts.ToBuilder();
            for (int i = 0; i < builder.Count; i++)
            {
                Account a = builder[i];
                if (a.Amount < 0)
                {
                    builder.Remove(a);
                }
            }

            ImmutableList<Account> overdrawnAccounts = builder.ToImmutable();
            overdrawnAccounts.ForEach(a => WriteLine($"{a.Name}, amount: {a.Amount}"));
        }
    }
}