public class Budget
{
    private double _income;
    private List<Category> _categories = new List<Category>();
    private List<int> _goalPercentages = new List<int>();
    private List<int> _actualPercentages = new List<int>();
    private List<Expense> _fixedExpenses = new List<Expense>();
    private double _outcomeTotal;
    private DateTime _begin;
    private DateTime _end;

    public void AddFixedExpense(Expense expense)
    {
        _fixedExpenses.Add(expense);
    }

   public void CreateCategories()
   {
        string[] lines = System.IO.File.ReadAllLines("budget.txt");
        foreach(string line in lines)
        {
            string[] parts = line.Split("|");
            string title = parts[0];
            string percent = parts[1];
            int percentage = int.Parse(percent);
            
            Category category = new Category(title, "Expense");
            _categories.Add(category);
            _goalPercentages.Add(percentage);
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
           Category category = _categories[i];
           double goalByPercentage = _income * (_goalPercentages[i] / 100); 

            if (goalByPercentage >= category.GetGoal())
            {
                category.SetGoal(goalByPercentage);
            }

            double newPercentage = category.GetGoal() / _income;
            newPercentage = Math.Round(newPercentage);
            _actualPercentages.Add((int)newPercentage);
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
            for(int i = 0; i < _categories.Count(); i ++)
            {
                Console.WriteLine($"{i + 1}: {_categories[i]} | ${_categories[i].GetGoal()} | {_actualPercentages[i]}");
            }
            Console.WriteLine($"Projected Income: {_income} | Current Budget Total: {_outcomeTotal}");
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
}