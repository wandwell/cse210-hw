public class Menu
{
    private List<string> _options = new List<string>
    {
        "1. Add Transaction",
        "2. View SpendingTracker",
        "3. ViewBudget",
        "4. Add Debt",
        "5. View DebtTracker",
        "6. View Assets",
        "7. Quit"
    };

    public void DisplayMenu()
    {   
        for(int i = 0; i < _options.Count(); i ++)
        {
            Console.WriteLine(_options[i]);
        }
        Console.Write(">");
    }

}