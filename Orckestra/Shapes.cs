using System;
using System.Collections.Generic;
using System.Linq;

namespace Orckestra
{
    public interface IShape
    {
        string ShapeType { get; }
        //since I don't really care about nubmer of digits
        // after decimal separator
        // I've decided to stick with double instead of decimal
        double CalculateArea();
    }

    internal class Circle : IShape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }
        
        public string ShapeType => "Circle";

        public double CalculateArea()
        {
            return Math.Pow(_radius, 2) * Math.PI;
        }
    }

    internal class Triangle : IShape
    {
        private readonly double _side0;
        private readonly double _side1;
        private readonly double _side2;

        public Triangle(double side0, double side1, double side2)
        {
            ValidateSides(side0, side1, side2);
            _side0 = side0;
            _side1 = side1;
            _side2 = side2;
        }

        private void ValidateSides(double side0, double side1, double side2)
        {
            var sides = new List<double> { side0, side1, side2 };
            var maxSide = sides.Max();
            var sumOfSmallerSides = sides.Sum() - maxSide;
            if (maxSide >= sumOfSmallerSides)
            {
                throw new ArgumentException("Invalid parameters for triangle. Bigger side cannot be larger than sum of two other sides");
            }
        }

        public string ShapeType => "Triangle";

        public double CalculateArea()
        {
            var halfPerimeter = (_side0 + _side1 + _side2) / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - _side0) * (halfPerimeter - _side1) * (halfPerimeter - _side2));
        }
    }

    internal class Square : IShape
    {
        private readonly double _side;

        public Square(double side)
        {
            _side = side;
        }
        
        public string ShapeType => "Square";

        public double CalculateArea()
        {
            return Math.Pow(_side, 2);
        }
    }

    internal class Rectangle : IShape
    {
        private readonly double _width;
        private readonly double _height;

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }
        
        public string ShapeType => "Rectangle";

        public double CalculateArea()
        {
            return _width * _height;
        }
    }

    public static class ShapeFactory
    {
        private const int MinSidesSupported = 1;
        private const int MaxSidesSupported = 4;
        
        public static IShape CreateShape(string input)
        {
            // RemoveEmptyEntries to eliminate multiple whitespaces
            var unparsedSides = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (unparsedSides.Length < MinSidesSupported || unparsedSides.Length > MaxSidesSupported)
            {
                throw new ArgumentException("Unsupported shape. Suppoted only circle, triangle, rectangle, square");
            }
            var parsedSides = ParseSides(unparsedSides);
            switch (parsedSides.Length)
            {
                case 1:
                    return new Circle(parsedSides[0]);
                case 2:
                    if (parsedSides[0] == parsedSides[1])
                    {
                        return new Square(parsedSides[0]);
                    }
                    else 
                    {
                        return new Rectangle(parsedSides[0], parsedSides[1]);
                    }
                case 3:
                    return new Triangle(parsedSides[0], parsedSides[1], parsedSides[2]);
                case 4: 
                    var differentSides = parsedSides.Distinct().ToList();
                    if (differentSides.Count() == 1)
                    {
                        return new Square(differentSides[0]);
                    }
                    else if (differentSides.Count() == 2)
                    {
                        return new Rectangle(differentSides[0], differentSides[1]);
                    }
                    else 
                    {
                        throw new ArgumentException("Although this shape has 4 sides it's neither a square, nor a rectangle");
                    }
                default:
                    //this one is not really reachable but better safe than sorry :)
                    throw new ArgumentException("Invalid input"); 
            }
                
        }

        private static double[] ParseSides(string[] unparsedSides)
        {
            var parsedSides = new double[unparsedSides.Length];
            for (var i = 0; i < unparsedSides.Length; i++)
            {
                //I could use Parse which throws an exception
                //But I prefer to throw an exception with nice custom message
                var parsed = double.TryParse(unparsedSides[i], out var number);
                if (!parsed)
                {
                    throw new ArgumentException($"Failed to parse input string. Invalid value {unparsedSides[i]}");
                }
                parsedSides[i] = number;
            }
            return parsedSides;
        }
    }
}
