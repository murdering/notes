using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Inheritance
{
    public class Animal
    {
        public void Eat()
        {
            WriteLine("Animal is eatting!");
        }

        public virtual void Shit()
        {
            WriteLine("Animal is shitting!");
        }
    }
}