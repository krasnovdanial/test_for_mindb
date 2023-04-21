using AreaOfShapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaOfShapes.Shapes
{
	public class Shape : IShape
	{
		private readonly IShape shape;

		public double Area => shape.Area;
		public string Type => shape.Type;

		public Shape(IShape figure)
		{
			shape = figure;
		}
	}
}
