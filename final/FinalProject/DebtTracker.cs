public class DebtTracker
{
    private List<Debt> _debts = new List<Debt>();
    private double _totalMinimum;
    private double _extraPayment;
    private List<DateTime> _endDates = new List<DateTime>();
    
    public void TotalMinimumPayments()
    {
        double total = 0;
        foreach(Debt debt in _debts)
        {
            total += debt.GetMinimumPayment();
        }
    }
    public void AddDebt()
    {
        Console.Write("What is the name of the debt? ");
        string title = Console.ReadLine();
        
        Console.Write("What is the interest rate? ");
        string userinput = Console.ReadLine();
        double interest = double.Parse(userinput);

        Console.Write("What is the amount owed? ");
        userinput = Console.ReadLine();
        double initial = double.Parse(userinput);

        Console.Write("What is the minimum monthly payment? $");
        userinput = Console.ReadLine();
        double payment = double.Parse(userinput);

        Debt debt = new Debt(title, interest, initial, payment);
        _debts.Add(debt);
    }

    public void EditDebt()
    {
        DisplayDebts();

        Console.Write("What is the name of the debt you want to edit? ");
        string title = Console.ReadLine();

        foreach(Debt debt in _debts)
        {
            if (debt.GetTitle() == title)
            {
                Console.Write("What is the interest rate? ");
                string userinput = Console.ReadLine();
                double interest = double.Parse(userinput);

                Console.Write("What is the amount owed? ");
                userinput = Console.ReadLine();
                double initial = double.Parse(userinput);

                Console.Write("What is the minimum monthly payment? $");
                userinput = Console.ReadLine();
                double payment = double.Parse(userinput);

                debt.SetInitial(initial);
                debt.SetInterest(interest);
                debt.SetMinPayment(payment);
            }
            
        }
    }

    public void SetPriorities()
    {
        IEnumerable<Debt> sortedList =
        from debt in _debts
        orderby debt.GetInterest()
        descending
        select debt;

        _debts = sortedList.ToList<Debt>();

        for (int i = 0; i < _debts.Count(); i ++)
        {
            _debts[i].SetPriorityLvl(i + 1);

            if (_debts[i].GetPriorityLvl() == 1)
            {
                _debts[i].SetSuggestedPayment(_debts[i].GetMinimumPayment() + _extraPayment);
            }
        }
    }

    public void CalculateEndDates()
    {
        int totalMonths = 0;
        double leftoverAmount = 0;

        for (int i = 0 ; i < _debts.Count(); i ++)
        {
            double remaining = _debts[i].GetRemaining();
            double interestAmount = 0;
            int months = 0;

            while (remaining > 0)
            {
                if(months < totalMonths)
                {
                    interestAmount = _debts[i].CalculateInterest(remaining);
                    remaining -= _debts[i].GetMinimumPayment();
                }
                else if(months == totalMonths)
                {
                    interestAmount = _debts[i].CalculateInterest(remaining);
                    remaining -= _debts[i].GetMinimumPayment() - leftoverAmount;
                }
                else if (months > totalMonths)
                {
                    interestAmount = _debts[i].CalculateInterest(remaining);
                    remaining -= _debts[i].GetMinimumPayment() - _extraPayment;
                }

                months ++;
            }

                leftoverAmount = 0 - remaining;

            if(months > totalMonths)
            {
                totalMonths = months;
            }
        
            DateTime current = DateTime.Now;
            _debts[i].SetEndDate(current.AddMonths(months));
        }
    }

    public void DisplayDebts()
    {
        TotalMinimumPayments();

        Console.WriteLine($"Total Minimum Payment: ${_totalMinimum}");
        Console.WriteLine($"Current Extra set for Payments: ${_extraPayment}");
        Console.WriteLine("");

        foreach(Debt debt in _debts)
        {
            debt.DisplayDebt();
        }
    }

    public void AddPayment(AssetTracker assets)
    {
        DisplayDebts();
        
        Console.Write("Which debt do you want to add a payment to? ");
        string title = Console.ReadLine();

        Console.Write("Amount of Payment: $");
        string userinput = Console.ReadLine();
        double payment = double.Parse(userinput);

        Console.Write("Date of Payment: ");
        userinput = Console.ReadLine();
        DateTime date = DateTime.Parse(userinput);

        foreach (Debt debt in _debts)
        {
            if (title == debt.GetTitle())
            {
                debt.AddPayment(payment);
            }
        }

        try
        {
        assets.WithdrawMoney(payment);
        }
        finally
        {

        }
    }
    
   public void LoadDebts()
   {
        string[] lines = System.IO.File.ReadAllLines("debts.txt");
        foreach(string line in lines)
        {
            if (line == lines[0])
            {
                _extraPayment = double.Parse(line);
            }
            else
            {
                string[] parts = line.Split("|");
                string title = parts[0];
                string interestString = parts[1];
                string initialString = parts[2];   
                string remainingString = parts[3];         
                string minimumPaymentString = parts[4];

                double interest = double.Parse(interestString);
                double initial = double.Parse(initialString);
                double remaining = double.Parse(remainingString);
                double minimum = double.Parse(minimumPaymentString);

                Debt debt = new Debt(title, interest, initial, minimum);
                debt.SetRemaining(remaining);
                _debts.Add(debt);
            }
        }
    }
   
   public void SaveDebts(string filename = "debts.txt")
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine($"{_extraPayment}");

            for (int i = 0; i < _debts.Count(); i++)
            {
                outputFile.WriteLine($"{_debts[i].GetTitle()}|{_debts[i].GetInterest().ToString()}|{_debts[i].GetInitial().ToString()}|{_debts[i].GetRemaining().ToString()}|{_debts[i].GetMinimumPayment().ToString()}");
            }
        }
    }

    public void SetExtraPayment()
    {
        Console.Write("Amount: $");
        string userinput = Console.ReadLine();
        _extraPayment = double.Parse(userinput);
    }
}