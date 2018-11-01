using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public abstract class Shape
    {
        public Shape(int width, int height, int x, int y)
        {
            Position = new Position { x = x, y = y };
            Size = new Size { Width = width, Height = height };
        }

        public virtual Position Position { get; }
        public Size Size { get; }
    }
}