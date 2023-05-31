public class Asset
{
    private string _title;
    private double _amount;

    public Asset (string title, double amount)
    {
        _title = title;
        _amount = amount;
    }

    public void DisplayAsset()
    {
        Console.WriteLine($"{_title} | ${_amount}");
        Console.WriteLine("");
    }

    public string GetTitle()
    {
        return _title;
    }

    public double GetAmount()
    {
        return _amount;
    }

    public void AddMoney(double amount)
    {
        _amount += amount;
    }

    public void WithdrawMoney(double amount)
    {
        _amount -= amount;
    }

    
}