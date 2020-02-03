using System;

namespace Orckestra
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter shape dimensions. Press q to quit");
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    if (string.Equals("q", input, StringComparison.OrdinalIgnoreCase))
                    {
                        break;
                    }
                    var shape = ShapeFactory.CreateShape(input);
                    Console.WriteLine($"Shape type: {shape.ShapeType}, Area: {shape.CalculateArea()}");
                }
                catch (ArgumentException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
