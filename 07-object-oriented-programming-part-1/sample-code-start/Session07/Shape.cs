using System;
using Xunit;

namespace Session07
{
	public abstract class Shape
	{
		public abstract double Area();
	}

	public class Circle : Shape
	{
		private readonly double _radius;

		public Circle(double radius)
		{
			_radius = radius;
		}

		public override double Area()
		{
			return Math.PI * _radius;
		}
	}

	public class Rectangle : Shape
	{
		public double Width { get; set; }
		public double Height { get; set; }

		public Rectangle(double width, double height)
		{
			Width = width;
			Height = height;
		}

		public override double Area()
		{
			return Width * Height;
		}
	}

	public class Square : Rectangle
	{
		public Square(double side) : base(side, side)
		{}
	}

	public class UhOh
	{
		[Fact(Skip = "Unpleasant surprise")]
		public void OhDear()
		{
			var square = new Square(5);

			Assert.Equal(5 * 5, square.Area());

			square.Width = 4;

			Assert.Equal(4 * 4, square.Area());
		}
	}
}
