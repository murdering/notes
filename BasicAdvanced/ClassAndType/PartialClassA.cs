using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndType
{
    public partial class PartialClass
    {
        public void MethodOne()
        {
            PartialFunction();
        }

        partial void PartialFunction();
    }
}
