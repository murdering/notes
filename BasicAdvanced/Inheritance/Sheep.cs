using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Inheritance
{
    public class Sheep : Animal
    {
        new public void Eat()
        {
            //WriteLine("Sheep is eatting!");
            base.Eat();
        }

        public override void Shit()
        {
            //WriteLine("Sheep is shitting!");
            base.Shit();
        }
    }
}