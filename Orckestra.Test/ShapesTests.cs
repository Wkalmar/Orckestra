using FluentAssertions;
using System;
using Xunit;

namespace Orckestra.Test
{
    public class ShapesTests
    {
        [Fact]
        public void ValidCircle() 
        {
            var circle = ShapeFactory.CreateShape(" 2 ");
            circle.CalculateArea().Should().BeApproximately(12.56, 0.01);
        }

        [Fact]
        public void ValidSquare_2sides()
        {
            var circle = ShapeFactory.CreateShape(" 2 2");
            circle.CalculateArea().Should().BeApproximately(4, 0.01);
        }

        [Fact]
        public void ValidRectangle_2sides()
        {
            var circle = ShapeFactory.CreateShape("2  4");
            circle.CalculateArea().Should().BeApproximately(8, 0.01);
        }

        [Fact]
        public void ValidTriangle()
        {
            var circle = ShapeFactory.CreateShape("3 4 5");
            circle.CalculateArea().Should().BeApproximately(6, 0.01);
        }

        [Fact]
        public void ValidTriangle_EqualSides()
        {
            var circle = ShapeFactory.CreateShape("5 5 5");
            circle.CalculateArea().Should().BeApproximately(25*Math.Sqrt(3)/4, 0.01);
        }

        [Fact]
        public void ValidSquare_4sides()
        {
            var circle = ShapeFactory.CreateShape(" 2 2 2 2");
            circle.CalculateArea().Should().BeApproximately(4, 0.01);
        }

        [Fact]
        public void ValidRectangle_4sides()
        {
            var circle = ShapeFactory.CreateShape("2  4 2 4");
            circle.CalculateArea().Should().BeApproximately(8, 0.01);
        }

        [Fact]
        public void ValidRectangle_4sides_DifferentOrder()
        {
            var circle = ShapeFactory.CreateShape("2 4 4 2"); //i've decided to make it valid case too
            circle.CalculateArea().Should().BeApproximately(8, 0.01);
        }
    }
}
