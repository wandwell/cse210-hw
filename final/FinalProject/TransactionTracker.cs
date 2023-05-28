public class TransactionTracker
{
    List<Transaction> _transactions = new List<Transaction>();
    List<Expense> _fixedExpenses = new List<Expense>();
    List<Category> _categories = new List<Category>();
    DateTime _begin;
    DateTime _end;

    public TransactionTracker(string begin, string end)
    {
        _begin = DateTime.Parse(begin);
        _end = DateTime.Parse(end);
    }

    public void AddTransaction()
    {
        Console.Write("Enter 1 for Income and 2 for Expense: ");
        string userinput = Console.ReadLine();
        int i = int.Parse(userinput);

        Console.Write("Category: ");
        string title = Console.ReadLine();

        Console.Write("Date: ");
        string date = Console.ReadLine();

        Console.Write("Amount: ");
        userinput = Console.ReadLine();
        double amount = double.Parse(userinput);

        Category  category = new Category(title, "type");
        if (i == 1)
        {
            Income income = new Income(title, amount, date);
            category = new Category(title, "Income");
            _transactions.Add(income);
        }   
        else
        {
            Expense expense = new Expense(title,amount,date);
            category = new Category(title, "Expense");

            Console.Write("Enter Y if this is a fixed Expense: ");
            userinput = Console.ReadLine();

            if (userinput == "Y")
            {
                expense.SetIsFixed(true);
                _fixedExpenses.Add(expense);
            }
            
            _transactions.Add(expense);
        }

        try
        {
            _categories.IndexOf(category);
        }
        catch
        {
            _categories.Add(category);
        }

    }

    public List<Transaction> SortByDate()
    {
        List<Transaction> sortedList = new List<Transaction>();

        foreach (Transaction transaction in _transactions)
        {
            if (transaction.GetDate() >= _begin && transaction.GetDate() >= _end)
            {
                sortedList.Add(transaction);
            }
        }

        IEnumerable<Transaction> newList =
            from transaction in sortedList
            orderby transaction.GetDate()
            select transaction;

        List<Transaction> sortedByDate = newList.ToList<Transaction>();
        return sortedByDate;
    }

    public void DisplaybyDate()
    {
        foreach (Transaction transaction in SortByDate())
        {
            transaction.DisplayTransaction();
        }
    }

    public void SortByCategory()
    {
        foreach (Transaction transaction in SortByDate())
        {
            foreach (Category category in _categories)
            {
                if (transaction.GetCategory() == category.GetTitle())
                {
                    category.AddTransaction(transaction);
                }
            }
        }
    }

    public void DisplayIncomeData()
    {
        Console.WriteLine("Income: ");
        foreach (Category category in _categories)
        {
            if (category.GetType() == "Income")
            {
                Console.WriteLine($"{category.GetTitle()} | ${category.TotalAmount()}");   
            }
        }
    }

    public void DisplayExpenseData()
    {
        Console.WriteLine("Expense: ");
        foreach (Category category in _categories)
        {
            if (category.GetType() == "Expense")
            {
                Console.WriteLine($"{category.GetTitle()} | ${category.TotalAmount()}");   
            }
        }
    }

}   
