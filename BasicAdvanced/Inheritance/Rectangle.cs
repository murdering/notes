using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Rectangle : Shape
    {
        public Rectangle() : base(width: 0, height: 0, x: 0, y: 0)
        {
        }

        public Rectangle(int width, int height, int x, int y) : base(width: width, height: height, x: x, y: y)
        {
        }

        public override Position Position { get; }
        new public Size Size { get; }
    }
}