public class Expense : Transaction
{
    private bool _isFixed = false;

    public Expense(string category, double amount, string date)
    :base(category, amount, date){}

    public void SetIsFixed(bool isFixed)
    {
        _isFixed = isFixed;
    }

    public override void DisplayTransaction()
    {
        string isFixedString = "No";

        if (_isFixed == true)
        {
            isFixedString = "Yes";
        }
        Console.WriteLine($"{base._category} | {base._date} | {base._amount} | Fixed: {isFixedString}");
    }

}