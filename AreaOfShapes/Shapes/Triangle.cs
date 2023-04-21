using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfShapes.Shapes
{
    public sealed class Triangle : Interfaces.IShape
{
    private const int DefaultSide = 0;
    
    public double Side1 { get; private set; }
    public double Side2 { get; private set; }
    public double Side3 { get; private set; }

    public Triangle() : this(DefaultSide, DefaultSide, DefaultSide) { }

    public Triangle(double side1, double side2, double side3)
    {
        CheckIfPositiveValue(side1, nameof(side1));
        CheckIfPositiveValue(side2, nameof(side2));
        CheckIfPositiveValue(side3, nameof(side3));
        CheckIfTriangleExists(side1, side2, side3);
        
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double Area
    {
        get
        {
            CheckIfPositiveValue(Side1, nameof(Side1));
            CheckIfPositiveValue(Side2, nameof(Side2));
            CheckIfPositiveValue(Side3, nameof(Side3));

            var p = (Side1 + Side2 + Side3) / 2;
            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }
    }

        public string Type => "Triangle";

		public bool IsRightTriangle()
    {
        return (Side1 == Math.Sqrt(Math.Pow(Side2, 2) + Math.Pow(Side3, 2))
                 || Side2 == Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side3, 2))
                 || Side3 == Math.Sqrt(Math.Pow(Side1, 2) + Math.Pow(Side2, 2)));
    }

    private static void CheckIfPositiveValue(double value, string name)
    {
        if (value <= 0 || double.IsNaN(value) || double.IsInfinity(value))
        {
            throw new ArgumentException("Value of the " + name + " parameter must be a positive number.");
        }
    }

    private static void CheckIfTriangleExists(double side1, double side2, double side3)
    {
        if (!(side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1))
        {
            throw new ArgumentException("Triangle with given sides does not exist.");
        }
    }
}
}
