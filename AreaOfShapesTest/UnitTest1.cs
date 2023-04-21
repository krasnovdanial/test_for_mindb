using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaOfShapes;
using AreaOfShapes.Shapes;

namespace AreaOfShapesTest
{
	[TestFixture]
	public class UnitTest1
	{
		[Test]
		public void Circle_CreatedWithPositiveRadius_ReturnsCorrectRadius()
		{
			double radius = 5;

			Circle circle = new Circle(radius);

			Assert.AreEqual(radius, circle.Radius);
		}

		[Test]
		public void Circle_CreatedWithNegativeRadius_ThrowsArgumentException()
		{
			double radius = -5;

			Assert.Throws<ArgumentException>(() => new Circle(radius), "Radius must be a positive value.");
		}

		[Test]
		public void Circle_CreateWithOnePositiveRadiusParameter_ReturnsCircleWithDefinedRadius()
		{
			double[] parameters = new double[] { 10 };

			Circle circle = Circle.Create(parameters);

			Assert.AreEqual(parameters[0], circle.Radius);
		}

		[Test]
		public void Circle_CreateWithMultipleParameters_ThrowsArgumentException()
		{
			double[] parameters = new double[] { 10, 20 };

			Assert.Throws<ArgumentException>(() => Circle.Create(parameters), "Circle can only be created with one positive radius parameter.");
		}

		[Test]
		public void Circle_CreateWithNegativeRadiusParameter_ThrowsArgumentException()
		{
			double[] parameters = new double[] { -10 };
			
			Assert.Throws<ArgumentException>(() => Circle.Create(parameters), "Circle can only be created with one positive radius parameter.");
		}

		[Test]
		public void Circle_CreateWithZeroRadiusParameter_ThrowsArgumentException()
		{
			double[] parameters = new double[] { 0 };

			Assert.Throws<ArgumentException>(() => Circle.Create(parameters), "Circle can only be created with one positive radius parameter.");
		}

		[Test]
		public void Area_CircleCreatedWithPositiveRadius_ReturnsCorrectArea()
		{
			double radius = 5;
			Circle circle = new Circle(radius);

			double area = circle.Area;

			Assert.AreEqual(Math.PI * Math.Pow(radius, 2), area);
		}
	}
	[Test]
	public void Triangle_CreatedWithPositiveSides_ReturnsCorrectSides()
	{
		double side1 = 3;
		double side2 = 4;
		double side3 = 5;
	
		Triangle triangle = new Triangle(side1, side2, side3);

		Assert.AreEqual(side1, triangle.Side1);
		Assert.AreEqual(side2, triangle.Side2);
		Assert.AreEqual(side3, triangle.Side3);
	}

	[Test]
	public void Triangle_CreatedWithNegativeSides_ThrowsArgumentException()
	{
		double side1 = -3;
		double side2 = -4;
		double side3 = -5;

		Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3), "Value of the " + nameof(side1) + " parameter must be a positive number.");
	}

	[Test]
	public void Triangle_CreatedWithZeroSide_ThrowsArgumentException()
	{
		double side1 = 0;
		double side2 = 4;
		double side3 = 5;

		Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3), "Value of the " + nameof(side1) + " parameter must be a positive number.");
	}

	[Test]
	public void Triangle_CreatedWithSidesThatDoNotFormTriangle_ThrowsArgumentException()
	{
		double side1 = 3;
		double side2 = 4;
		double side3 = 10;

		Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3), "Triangle with given sides does not exist.");
	}

	[Test]
	public void Area_TriangleCreatedWithPositiveSides_ReturnsCorrectArea()
	{
		double side1 = 3;
		double side2 = 4;
		double side3 = 5;
		Triangle triangle = new Triangle(side1, side2, side3);

		double area = triangle.Area;

		Assert.AreEqual(6, area);
	}

	[Test]
	public void IsRightTriangle_TriangleWithSides_345_ReturnsTrue()
	{
		double side1 = 3;
		double side2 = 4;
		double side3 = 5;
		Triangle triangle = new Triangle(side1, side2, side3);

		bool result = triangle.IsRightTriangle();

		Assert.IsTrue(result);
	}

	[Test]
	public void IsRightTriangle_TriangleWithSides_536_ReturnsFalse()
	{
		double side1 = 5;
		double side2 = 3;
		double side3 = 6;
		Triangle triangle = new Triangle(side1, side2, side3);

		bool result = triangle.IsRightTriangle();

		Assert.IsFalse(result);
	}
}
}
