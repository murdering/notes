using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.GenericFunction
{
    public static class Algorithms
    {
        public static decimal Accumlate(IEnumerable<Account> source)
        {
            decimal sum = 0;
            foreach (var account in source)
            {
                sum += account.Balance;
            }
            return sum;
        }

        public static decimal Accumlate<TAccount>(IEnumerable<TAccount> source) where TAccount : IAccount
        {
            decimal sum = 0;
            foreach (var account in source)
            {
                sum += account.Balance;
            }

            return sum;
        }

        public static T2 Accumlate<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> action) where T1 : IAccount
        {
            T2 sum = default(T2);

            foreach (var account in source)
            {
                sum = action(account, sum);
            }

            return sum;
        }
    }
}