using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Inheritance
{
    public class Cow : Animal
    {
        public void Eat()
        {
            WriteLine("Cow is eatting!");
        }

        public override void Shit()
        {
            WriteLine("Cow is shitting!");
        }
    }
}