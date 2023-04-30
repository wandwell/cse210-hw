using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        //default to 1/1

        _top = 1;
        _bottom = 1;
        
    }

    public Fraction(int wholenumber)
    {
        // one parameter for numerator, default denominator to 1; x/1
        _top = wholenumber;
        _bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public void SetBottom (int bottom)
    {
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        return (double)_top / (double)_bottom;
    }
}