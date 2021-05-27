using System;
using System.Collections.Generic;
using System.Text;

namespace Generics.GenericClass
{
    public class SimpleGeneric<T>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Animal 
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }

    public class Duck : SimpleGeneric<Animal>
    { 
        public string Skin { get; set; }
    }
}
