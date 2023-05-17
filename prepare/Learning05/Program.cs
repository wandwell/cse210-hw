using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("red", 3);
        shapes.Add(square);

        Rectangle rect = new Rectangle("yellow", 9, 2);
        shapes.Add(rect);

        Circle circle = new Circle("blue", 7);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.getColor();
            double area = shape.getArea();

            Console.WriteLine($"Color: {color}; Area: {area}");
        }
    }
}