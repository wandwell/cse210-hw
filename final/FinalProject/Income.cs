public class Income : Transaction
{
    public Income(string category, double amount, string date)
    :base(category, amount, date){}

    public override void DisplayTransaction()
    {
        Console.WriteLine($"{base._category} | {base._date} | {base._amount}");
    }
}
