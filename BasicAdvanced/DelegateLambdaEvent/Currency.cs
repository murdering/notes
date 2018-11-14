using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateLambdaEvent
{
    public struct Currency
    {
        private readonly uint _Dollars;
        private readonly ushort _Cents;
        private readonly string _CurrenctStr;

        public Currency(uint dollars, ushort cents)
        {
            _Dollars = dollars;
            _Cents = cents;
            _CurrenctStr = string.Empty;
        }

        public Currency(uint dollars, ushort cents, string currencyStr)
        {
            _Dollars = dollars;
            _Cents = cents;
            _CurrenctStr = currencyStr;
        }

        public override string ToString() => $"${_Dollars}.{_Cents,2:00}";

        public static string GetCurrency() => "Dollar";

        public static void ShowCurrency(string countryName)
        {
            var cur = string.Empty;
            if (countryName == "China")
            {
                cur = "RMB";
            }
            else
            {
                cur = "Dollar";
            }
            Console.WriteLine($"country: {countryName}, currency: {cur}");
        }

        public static implicit operator Currency(float value)
        {
            checked
            {
                uint dollars = (uint)value;
                ushort cents = (ushort)((value - dollars) * 100);
                return new Currency(dollars, cents);
            }
        }

        public static implicit operator uint(Currency value) => value._Dollars;
    }
}