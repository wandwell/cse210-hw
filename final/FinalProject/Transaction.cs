public abstract class Transaction
{
    protected string _category;
    protected double _amount;
    protected DateTime _date;

    public Transaction(string category, double amount, string date)
    {
        _category = category;
        _amount = amount;
        _date = DateTime.Parse(date);
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public string GetCategory()
    {
        return _category;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public abstract void DisplayTransaction();
}