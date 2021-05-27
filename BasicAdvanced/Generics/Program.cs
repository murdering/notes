using Generics.GenericClass;
using Generics.GenericFunction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using static System.Console;

namespace Generics
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*
            // 泛型类
            GenericClassFunction();
            // 泛型方法
            GenericFunctionFunction();
            */
            GenericSimpleClass();

            ReadLine();

        }

        // 泛型类
        public static void GenericClassFunction()
        {
            var dm = new DocumentManager<Document>();
            dm.AddDocument(new Document { Title = "James Bonds", Content = "Handsome!" });
            dm.AddDocument(new Document { Title = "Leo Dai", Content = "Very handsome!" });
            dm.DisplayAllDocument();

            while (dm.IsDocumentAvaliable)
            {
                Document doc = dm.GetDocument();
                WriteLine(doc.Content);
            }
        }

        // 泛型方法
        public static void GenericFunctionFunction()
        {
            var accounts = new List<Account>();
            accounts.Add(new Account("Leo Dai", 400000000000));
            accounts.Add(new Account("James Bond", 30000000000));
            accounts.Add(new Account("Jason Bourne", 2000000000));
            accounts.Add(new Account("Ethan Hunt", 100000000));

            var balance = Algorithms.Accumlate(accounts);
            var balanceInGeneric = Algorithms.Accumlate<Account>(accounts);
            var balanceInDelegate = Algorithms.Accumlate<Account, decimal>(accounts, (account, sum) => sum += account.Balance);
            WriteLine($"The balance is {balance}");
            WriteLine($"The generic balance is {balanceInGeneric}");
            WriteLine($"The generic delegate balance is {balanceInDelegate}");
        }

        public static void GenericSimpleClass()
        {
            var animal = new Duck { Skin = "Yellow"};
            Print(animal);
        }

        private static void Print<T>(SimpleGeneric<T> simpleGeneric)
        { 
            WriteLine(JsonConvert.SerializeObject(simpleGeneric));
        }
    }
}