using System;
using System.Collections.Generic;
using System.Text;

namespace ClassAndType
{
    struct TestStruct
    {
        public Math MathV { get; set; }
        public int Width;
        public int Height;

        public TestStruct(int width, int height)
        {
            Width = width;
            Height = height;
            MathV = new Math();
        }
    }
}
