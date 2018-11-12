using System;
using System.Collections.Generic;
using System.Text;

namespace Array.Class
{
    public class HelloCollection
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "hello";
            yield return "world!";
        }
    }
}