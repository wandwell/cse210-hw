public class TransactionTracker
{
    List<Transaction> _transactions = new List<Transaction>();
    List<Expense> _fixedExpenses = new List<Expense>();
    List<Category> _categories = new List<Category>();
    DateTime _begin;
    DateTime _end;

    public void AddCategory(Category category, Transaction transaction)
    {
        bool doesExist = false;

        if (_categories.Count() == 0)
            {
                category.AddTransaction(transaction);
                _categories.Add(category);
                doesExist = true;
            }

        for(int j = 0; j < _categories.Count(); j ++)
        {   
            if (_categories[j].GetTitle() == category.GetTitle())
            {
                _categories[j].AddTransaction(transaction);
                doesExist =true;
            }
        }

        if (doesExist == false)
        {
            category.AddTransaction(transaction);
            _categories.Add(category);
        }
        
    }
    public void AddTransaction(Transaction transaction)
    {
        Category category = new Category("title", "type");

        if (transaction is Income)
        {
            Income income = (Income)transaction;
            category = new Category(income.GetTitle(), "Income");

            AddCategory(category, income);
            _transactions.Add(income);

        }   
        else
        {
            Expense expense = (Expense)transaction;
            category = new Category(expense.GetTitle(), "Expense");
           
            AddCategory(category, expense);
            _transactions.Add(expense);
        }   
    }

    public void AddTransaction(AssetTracker assets)
    {
        Console.Write("Enter 1 for Income and 2 for Expense: ");
        string userinput = Console.ReadLine();
        int i = int.Parse(userinput);

        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Category: ");
        string categoryString = Console.ReadLine();

        Console.Write("Date: ");
        string date = Console.ReadLine();

        Console.Write("Amount: $");
        userinput = Console.ReadLine();
        double amount = double.Parse(userinput);

        Category  category = new Category(title, "type");
        if (i == 1)
        {
            Income income = new Income(title, categoryString, amount, date);
            category = new Category(title, "Income");

            AddCategory(category, income);
            _transactions.Add(income);
            assets.AddMoney(amount);
        }   
        else
        {
            Expense expense = new Expense(title, categoryString, amount, date);
            category = new Category(title, "Expense");
            assets.WithdrawMoney(amount);
            
            Console.Write("Enter Y if this is a fixed Expense: ");
            userinput = Console.ReadLine();

            if (userinput == "Y")
            {
                expense.SetIsFixed(true);
                _fixedExpenses.Add(expense);
            }
            
            AddCategory(category,expense);
            _transactions.Add(expense);
        }   
    }

    public List<Transaction> SortByDate()
    {
        List<Transaction> sortedList = new List<Transaction>();

        foreach (Transaction transaction in _transactions)
        {
            if (transaction.GetDate() >= _begin && transaction.GetDate() <= _end)
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

    public void DisplayIncomeData()
    {
        double total = 0;

        foreach (Transaction transaction in _transactions)
        {
            if(transaction is Income && transaction.GetDate() >= _begin && transaction.GetDate() <= _end)
            {
                total += transaction.GetAmount();
            }
        }

        Console.WriteLine($"Income: ${total}");
        
        foreach (Category category in _categories)
        {
            if (category.GetType() == "Income")
            {
                Console.WriteLine($"{category.GetTitle()} | ${category.TimeLimitedAmount(_begin, _end)}");   
            }
        }
    }

    public void DisplayExpenseData()
    {
        double total = 0;

        foreach (Transaction transaction in _transactions)
        {
            if(transaction is Expense  && transaction.GetDate() >= _begin && transaction.GetDate() <= _end)
            {
                total += transaction.GetAmount();
            }
        }

        Console.WriteLine($"Expense: ${total}");

        foreach (Category category in _categories)
        {
            if (category.GetType() == "Expense")
            {
                Console.WriteLine($"{category.GetTitle()} | ${category.TimeLimitedAmount(_begin, _end)}");   
            }
        }
    }
    public void SetDates(DateTime begin, DateTime end)
    {
        _begin = begin;
        _end = end;
    }

    public void LoadTransactions()
   {
        string[] lines = System.IO.File.ReadAllLines("transactions.txt");
        foreach(string line in lines)
        {
            string[] parts = line.Split("|");
            string title = parts[0];
            string category = parts[1];
            string amountString = parts[2];
            string date = parts[3];
            string isFixedString = parts[4];

            double amount = double.Parse(amountString);

            if (isFixedString != "-")
            {
                bool isFixed = bool.Parse(isFixedString);

                Expense expense = new Expense(title, category, amount, date);
                expense.SetIsFixed(isFixed);
                AddTransaction(expense);
            }
            else
            {
                Income income = new Income(title,category, amount, date);
                AddTransaction(income);
            }
        }
    }
   

   public void SaveTransactions(string filename = "transactions.txt")
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            for (int i = 0; i < _transactions.Count(); i++)
            {
                if(_transactions[i] is Expense)
                {
                    Expense expense = (Expense)_transactions[i];
                    outputFile.WriteLine($"{expense.GetTitle()}|{expense.GetCategory()}|{expense.GetAmount()}|{expense.GetDate().ToString()}|{expense.GetIsFixed()}");   
                }
                else
                {
                    outputFile.WriteLine($"{_transactions[i].GetTitle()}|{_transactions[i].GetCategory()}|{_transactions[i].GetAmount()}|{_transactions[i].GetDate().ToString()}|-");   
                }
            }
        }
    }

}   
