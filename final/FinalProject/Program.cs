using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        TransactionTracker spending = new TransactionTracker();
        DebtTracker debts = new DebtTracker();

        Console.WriteLine("Welcome to your Personal Finance Tool!");

        Console.WriteLine("Please Choose from the Following Options:");
        menu.DisplayMenu();

        string userinput = Console.ReadLine();
        int choice = int.Parse(userinput) - 1;

        if (choice == 0)
        {
            spending.AddTransaction();
        }

        else if (choice == 1)
        {
            Console.Write("Pick a beginning date: ");
            userinput = Console.ReadLine();
            DateTime begin = DateTime.Parse(userinput);

            Console.Write("Pick an end date: ");
            userinput = Console.ReadLine();
            DateTime end = DateTime.Parse(userinput);

            spending.SetDates(begin, end);
            spending.DisplaybyDate();
            Console.WriteLine("");
            spending.DisplayIncomeData();
            spending.DisplayExpenseData();
        }




    }
}