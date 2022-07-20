using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfShapes.Shapes
{
    public sealed class Triangle: Interfaces.IShape
    {
        public double Side1 { get; private set; }
        public double Side2 { get; private set; }
        public double Side3 { get; private set; }

        internal Triangle GetTriangle(double[] parameters)
        {
            if (parameters == null || parameters.Length != 3)
            {
                throw new ArgumentException(
                    "Parameters are incorrect: a right triangle must have three sides.",
                    "parameters");
            }
            return new Triangle(parameters[0], parameters[1], parameters[2]);
        }

        public double Area
        {
            get
            {
                if (Side1 < 0 || Side2 < 0 || Side3 < 0)
                {
                    throw new ArgumentException("Please, enter only positive values.");
                }
                var p = (Side1 + Side2 + Side3) / 2;
                return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
            }
        }

        public Triangle()
        {
            Side1 = Side2 = Side3 = default(int);
        }

        public Triangle(double side1, double side2, double side3)
        {
            if (side1 <= 0 || side2 <= 0 || side3 <= 0)
            {
                throw new ArgumentException(
                    "Parameters are incorrect: the side of the triangle must be greater than zero.");
            }
            if (!TriangleExists(side1, side2, side3))
            {
                throw new ArgumentException("Parameters are incorrect: triangle with given sides does not exist.");
            }
            Side1 = side1;
            Side2 = side2;
            Side3 = side3;
        }
        private static bool TriangleExists(double side1, double side2, double side3)
        {
            if (side1 + side2 > side3 && side1 + side2 > side3 && side2 + side3 > side1)
            {
                return true;
            }
            return false;
        }
        public bool IsRightTriangle()
        {
            return (Side1 == Math.Sqrt(Math.Pow(Side2, 2) + Math.Pow(Side3, 2))
                || Side2 == Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side3, 2))
                || Side3 == Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side2, 2)));
        }
    }
}
