using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace ClassAndType
{
    public partial class PartialClass
    {
        partial void PartialFunction()
        {
            WriteLine("this is PartialFunction");
        }
    }
}
