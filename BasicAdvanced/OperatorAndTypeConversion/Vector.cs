using System;
using System.Collections.Generic;
using System.Text;

namespace OperatorAndTypeConversion
{
    public struct Vector
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Vector vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public static Vector operator +(Vector left, Vector right)
        => new Vector(left.X + right.Y, left.Y + right.Y, left.Z + right.Z);

        public static Vector operator +(int left, Vector right)
        => new Vector((double)left + right.X, (double)left + right.Y, (double)left + right.Z);

        public override string ToString()
        => $"X: {X}, Y: {Y}, Z: {Z}";
    }
}