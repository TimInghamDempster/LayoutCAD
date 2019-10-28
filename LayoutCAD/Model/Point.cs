using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LayoutCAD.Model
{
    public struct Point
    {
        public float X { get; set; }
        public float Y { get; set; }
        public static Point Zero => new Point { X = 0, Y = 0 };

        public static Point operator -(Point a, Point b)
            => a + (-b);
        public static Point operator -(Point a)
            => new Point { X = -a.X, Y = -a.Y };
        public static Point operator +(Point a, Point b)
            => new Point { X = a.X + b.X, Y = a.Y + b.Y };
        public static Point operator +(Point p, float s)
            => new Point { X = p.X + s, Y = p.Y + s };
        public static Point operator -(Point p, float s)
            => p + (-s);
        public static Point operator *(Point p, float s)
            => new Point { X = p.X * s, Y = p.Y * s };

        // Never overlaod * for a vector class, there's way
        // too many ways to multiply vectors and it isn't obvious
        // which one is implemented
        public static Point ComponentWiseMul(Point a, Point b)
            => new Point { X = a.X * b.X, Y = a.Y * b.Y };
        public static Point ComponentWiseDiv(Point a, Point b)
            => new Point { X = a.X / b.X, Y = a.Y / b.Y };

        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }
    }
}
