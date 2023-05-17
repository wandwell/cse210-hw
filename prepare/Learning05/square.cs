public class Square : Shape
{
    private double _side;

    public Square(string color, double side)
        :base(color)
        {
            _side = side;
        }

    public override double getArea()
    {
        return _side * _side;
    }
}