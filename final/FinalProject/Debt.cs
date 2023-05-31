public class Debt
{
    private string _title;
    private int _priorityLevel;
    private double _interest;
    private double _initial;
    private double _remaining;
    private double _minimumPayment;
    private double _suggestedPayment;
    private DateTime _projectedEndDate;

    public Debt(string title, double interest, double initial, double payment)
    {
        _title = title;
        _interest = interest;
        _initial = initial;
        _remaining = initial;
        _minimumPayment = payment;
        _suggestedPayment = payment;
    }

    public string GetTitle()
    {
        return _title;
    }
    public void DisplayDebt()
    {
        Console.WriteLine($"{_title} |Interest: {_interest}% |Principle: ${_initial} |Remaining: ${_remaining}");
        Console.WriteLine($"Minimum Payment: ${_minimumPayment} |Suggested Payment: ${_suggestedPayment} |Projected End Date: {_projectedEndDate}");
        Console.WriteLine("");
    }
    public void SetEndDate(DateTime endDate)
    {
        _projectedEndDate = endDate;
    }

    public double GetInterest()
    {
        return _interest;
    }

    public void SetPriorityLvl(int Lvl)
    {
        _priorityLevel = Lvl;
    }

    public int GetPriorityLvl()
    {
        return _priorityLevel;
    }

    public double GetMinimumPayment()
    {
        return _minimumPayment;
    }

    public void SetRemaining(double remaining)
    {
        _remaining = remaining;
    }

    public void SetMinPayment(double amount)
    {
        _minimumPayment = amount;
    }

    public double GetRemaining()
    {
        return _remaining;
    }

    public double GetInitial()
    {
        return _initial;
    }

    public double CalculateInterest(double remaining)
    {
        double monthlyInterest = remaining * _interest/12;     

        return monthlyInterest;
    }

    public void AddPayment(double amount)
    {
        _remaining -= amount;
    }

    public void SetInterest(double interest)
    {
        _interest = interest;
    }

    public void SetInitial(double initial)
    {
        _initial = initial;
    }

    public void SetSuggestedPayment(double amount)
    {
        _suggestedPayment = amount;
    }
}