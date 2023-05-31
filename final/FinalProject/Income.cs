public class Income : Transaction
{
    public Income(string title, string category, double amount, string date)
    :base(title, category, amount, date){}

    public override void DisplayTransaction()
    {
        Console.WriteLine($"{base._title} | {base._category} | {base._date} | {base._amount}");
    }
}
