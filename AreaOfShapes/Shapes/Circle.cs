using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfShapes.Shapes
{
	public class Circle : Interfaces.IShape
	{
		private readonly double radius;

		public double Radius => radius;

		public double Area => Math.PI * Math.Pow(Radius, 2);

		public string Type => "Circle";

		public Circle(double radius)
		{
			if (radius <= 0)
			{
				throw new ArgumentException("Radius must be a positive value.", nameof(radius));
			}

			this.radius = radius;
		}

		public static Circle Create(double[] parameters)
		{
			if (parameters == null || parameters.Length != 1 || parameters[0] <= 0)
			{
				throw new ArgumentException("Circle can only be created with one positive radius parameter.", nameof(parameters));
			}

			return new Circle(parameters[0]);
		}
	}
}
