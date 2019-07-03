using DirectX.DesignPatterns.Builder.Models;
using System;

namespace DirectX.DesignPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();

            var yahaB = new YaHahaBuilder();
            var actor = director.CreateActor(yahaB);

            Console.WriteLine(actor.Name);
            Console.WriteLine(actor.Eye);
            Console.WriteLine(actor.Gender);

            var monsterB = new MonstorBuilder();
            var actor2 = director.CreateActor(monsterB);

            Console.WriteLine(actor2.Name);
            Console.WriteLine(actor2.Eye);
            Console.WriteLine(actor2.Gender);

            Console.ReadLine();
        }
    }
}
