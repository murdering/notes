using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndType
{
    public class TestClass
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public TestClass(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
