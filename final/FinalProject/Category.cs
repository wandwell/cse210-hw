public class Category
{
    private string _title;
    private string _type;
    private double _goal;
    private double _fixedExpensesTotal;
    List<Transaction> _transactions = new List<Transaction>();

    public Category(string title, string type)
    {
        _title = title;
        _type = type;
    }
    public Category(string title, string type, double goal, double fixedExpensesTotal)
    {
        _title = title;
        _type = type;
        _goal = goal;
        _fixedExpensesTotal = fixedExpensesTotal;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetType()
    {
        return _type;
    }

    public void SetGoal(double goal)
    {
        _goal = goal;
    }

    public double GetGoal()
    {
        return _goal;
    }

    public double GetFixedExpenseTotal()
    {
        return _fixedExpensesTotal;
    }

    public void SetFixedExpenseTotal(double total)
    {
        _fixedExpensesTotal = total;
    }

    public double TotalAmount()
    {
        double total = 0;
        foreach (Transaction transaction in _transactions)
        {
            total += transaction.GetAmount();
        }
        return total;
    }

    public double TimeLimitedAmount(DateTime begin, DateTime end)
    {
        double total = 0;
        foreach(Transaction transaction in _transactions)
        {
            if (transaction.GetDate() >= begin && transaction.GetDate() <= end)
            {
                total += transaction.GetAmount();
            }
        }
        return total;
    }

    public void AddTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }
}