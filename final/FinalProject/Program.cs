using System;

class Program
{
    static void Main(string[] args)
    {
        Menu main = new Menu();

        main.AddOption("Add Transaction");
        main.AddOption("Spending Tracker");
        main.AddOption("Monthly Budget");
        main.AddOption("Debt Tracker");
        main.AddOption("Assets");
        main.AddOption("Quit");

        TransactionTracker spending = new TransactionTracker();
        spending.LoadTransactions();
        
        DebtTracker debts = new DebtTracker();
        debts.LoadDebts();
        
        Budget budget = new Budget();
        budget.LoadBudget();

        AssetTracker assets = new AssetTracker();
        assets.LoadAssets();

        Console.WriteLine("Welcome to your Personal Finance Tool!");
        Console.WriteLine("");
        int choice = -1;

        do
        { 
            Console.WriteLine("Please Choose from the Following Options:");
            main.DisplayMenu();
            choice = main.SelectOption();
            
            if (choice == 0)
            {
                spending.AddTransaction(assets);
                Console.Clear();
            }

            else if (choice == 1)
            {
                Console.Write("Pick a beginning date: ");
                string userinput = Console.ReadLine();
                DateTime begin = DateTime.Parse(userinput);

                Console.Write("Pick an end date: ");
                userinput = Console.ReadLine();
                DateTime end = DateTime.Parse(userinput);

                spending.SetDates(begin, end);
                spending.DisplaybyDate();
                Console.WriteLine("");
                
                spending.DisplayIncomeData();
                Console.WriteLine("");
                spending.DisplayExpenseData();

                Console.ReadLine();
                Console.Clear();
            }

            else if (choice == 2)
            {
                Menu budgetMenu = new Menu();

                budgetMenu.AddOption("Create Monthly Budget");
                budgetMenu.AddOption("View Monthly Budget");
                budgetMenu.AddOption("Remove Fixed Expense from Budget");
                budgetMenu.AddOption("Return to Main Menu");
                int option = -1;
                do
                {
                    budgetMenu.DisplayMenu();
                    option = budgetMenu.SelectOption();

                    if (option == 0)
                    {
                        Console.Write("What is your projected monthly income? $");
                        string userinput = Console.ReadLine();
                        double income = double.Parse(userinput);
                        budget.SetIncome(income);

                        budget.SortFixedExpenses();
                        budget.AllocatebyPercentage();
                        budget.SetBudgetOutcome();
                    }

                    else if (option == 1)
                    {
                        budget.DisplayBudget();
                        Console.ReadLine();
                    }

                    else if (option ==2)
                    {
                        budget.DisplayFixedExpenses();
                        budget.RemoveFixedExpense();
                    }

                    Console.Clear();

                }while(option != 3);
            }

            else if (choice == 3)
            {
                Menu debtMenu = new Menu();
                debtMenu.AddOption("Add Debt");
                debtMenu.AddOption("Edit Debt");
                debtMenu.AddOption("Set Extra Amount Added Payments");
                debtMenu.AddOption("Add Payment");
                debtMenu.AddOption("Exit to Main Menu");
                int option = -1;
                
                while (option != 4)
                {
                    debts.SetPriorities();
                    debts.CalculateEndDates();

                    debts.DisplayDebts();
                    debtMenu.DisplayMenu();
                    option = debtMenu.SelectOption();

                    if (option == 0)
                    {
                        debts.AddDebt();
                        Console.Clear();
                    }
                    else if (option == 1)
                    {
                        debts.EditDebt();
                        Console.Clear();
                    }
                    else if (option == 2)
                    {
                        debts.SetExtraPayment();
                        Console.Clear();
                    }
                    else if (option ==3)
                    {
                        debts.AddPayment(assets);
                        Console.Clear();
                    }
                }
            }

            else if (choice == 4)
            {
                Menu assetMenu = new Menu();
                assetMenu.AddOption("Add Asset");
                assetMenu.AddOption("Delete Asset");
                assetMenu.AddOption("Return to Main Menu");
                int option = -1;
                do
                {
                    assets.DisplayAssets();
                    assetMenu.DisplayMenu();
                    option = assetMenu.SelectOption();

                    if (option == 0)
                    {
                        assets.AddAsset();
                        Console.Clear();
                    }

                    else if (option == 1)
                    {
                        assets.DeleteAsset();
                        Console.Clear();
                    }

                } while(option != 2);
            }
        }while(choice != 5);

        spending.SaveTransactions();
        budget.SaveBudget();
        debts.SaveDebts();
        assets.SaveAssets();
        
        Console.Clear();
    }
}