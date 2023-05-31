public class Budget
{
    private double _income;
    private List<Category> _categories = new List<Category>();
    private List<int> _goalPercentages = new List<int>();
    private List<int> _actualPercentages = new List<int>();
    private List<Expense> _fixedExpenses = new List<Expense>();
    private double _outcomeTotal;

    public void AddFixedExpense(Expense expense)
    {
        bool alreadyExists = false;
        foreach (Expense item in _fixedExpenses)
        {
            if (item.GetTitle() == expense.GetTitle())
            {
                alreadyExists = true;
            }
        }

        if (alreadyExists == false)
        {
            _fixedExpenses.Add(expense);
        }
    }

    public void DisplayFixedExpenses()
    {
        foreach (Expense expense in _fixedExpenses)
        {
            expense.DisplayTransaction();
        }
    }

    public void RemoveFixedExpense()
    {
        Console.Write("Which Expense do you want to remove from Budget? ");
        string title = Console.ReadLine();

        foreach(Expense expense in _fixedExpenses)
        {
            if (title == expense.GetTitle())
            {
                _fixedExpenses.Remove(expense);
            }
        }
    }

   public void LoadBudget()
   {
        string[] lines = System.IO.File.ReadAllLines("budget.txt");
        foreach(string line in lines)
        {
            if (line == lines[0])
            {
                _income = double.Parse(line);
            }
            else
            {
                string[] parts = line.Split("|");
                string title = parts[0];
                string type = parts[1];
                string goalPercentageString = parts[2];
                string actualPercentageString = parts[3];
                string goalAmountString = parts[4];
                string fixedExpensesTotalString = parts[5];

                int goalPercentage = int.Parse(goalPercentageString);
                int actualPercentage = int.Parse(actualPercentageString);
                double goalAmount = double.Parse(goalAmountString);
                double fixedExpensesTotal = double.Parse(fixedExpensesTotalString);
                
                Category category = new Category(title, type, goalAmount, fixedExpensesTotal);
                _categories.Add(category);
                _goalPercentages.Add(goalPercentage);
                _actualPercentages.Add(actualPercentage);
            }
        }
   }

   public void SaveBudget(string filename = "budget.txt")
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_income}");
            for (int i = 0; i < _categories.Count(); i++)
            {
                outputFile.WriteLine($"{_categories[i].GetTitle()}|{_categories[i].GetType()}|{_goalPercentages[i]}|{_actualPercentages[i]}|{_categories[i].GetGoal()}|{_categories[i].GetFixedExpenseTotal()}");
            }
        }
    }

   public void SortFixedExpenses()
    {
        foreach(Category category in _categories)
        {
            double amount = 0;
            foreach(Expense expense in _fixedExpenses)
            {
                if (expense.GetCategory() == category.GetTitle())
                {
                    amount += expense.GetAmount();
                }
            }
            category.SetGoal(amount);
            category.SetFixedExpenseTotal(amount);
        }
    }

    public void AllocatebyPercentage()
    {
        for(int i = 0; i < _categories.Count(); i ++)
        {
           double goalByPercentage = _income * _goalPercentages[i] / 100; 

            if (goalByPercentage > _categories[i].GetGoal())
            {
                _categories[i].SetGoal(goalByPercentage);
            }

            double newPercentage = (_categories[i].GetGoal() / _income) * 100;
            newPercentage = Math.Round(newPercentage);
            _actualPercentages[i] = ((int)newPercentage);
        }
    }

    public void SetBudgetOutcome()
    {
        _outcomeTotal = 0;
        foreach (Category category in _categories)
        {
            _outcomeTotal += category.GetGoal();
        }
    }
    public void EditBudget()
    {
        int choice = -1;
        do
        {
            DisplayBudget();
            Console.Write("Which category do you want to edit?(Enter 0 to Exit) ");

            string userinput = Console.ReadLine();
            choice = int.Parse(userinput);

            Console.Write("How much do you want to set aside for {_category[choice]}? ");
            userinput = Console.ReadLine();
            double amount = double.Parse(userinput);

            if (amount <= _categories[choice].GetFixedExpenseTotal())
            {
                _categories[choice].SetGoal(amount);
            }
            else
            {
                Console.WriteLine("Error: Your Fixed Expenses are greater than your budget.");
            }
            
        }while (choice != 0);
    }

    public void DisplayBudget()    
    {
        for(int i = 0; i < _categories.Count(); i ++)
            {
                Console.WriteLine($"{_categories[i].GetTitle()} | ${_categories[i].GetGoal()} | {_actualPercentages[i]}% of Income");
            }
        Console.WriteLine($"Projected Income: {_income} | Current Budget Total: {_outcomeTotal}");
    }           

    public void SetIncome(double income)
    {
        _income = income;
    }
}