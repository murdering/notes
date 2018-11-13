using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateLambdaEvent
{
    public struct Currency
    {
        private readonly uint Dollars;
        private readonly ushort Cents;

        public Currency(uint dollars, ushort cents)
        {
            Dollars = dollars;
            Cents = cents;
        }

        public override string ToString() => $"${Dollars}.{Cents,2:00}";

        public static string GetCurrency() => "Dollar";

        public static implicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }

        public static implicit operator uint(Currency value) => value.Dollars;
    }
}