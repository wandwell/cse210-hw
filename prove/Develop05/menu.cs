public class Menu
{
    private List<string> _options = new List<string>
    {
        "1. Create New Goals",
        "2. List Goals",
        "3. Save Goals",
        "4. Delete Goals",
        "5. Record Event",
        "6. Quit"
    };

    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        
        foreach (string option in _options)
        {
            Console.WriteLine(option);
        }
    }

    public void SelectOption(int i, Gamefile file)
    {
        if(i == 0)
        {
            file.CreateGoal();
        }
        else if (i ==1)
        {
            file.ListGoals();
        }
        else if (i == 2)
        {
            file.SaveGamefile();
        }
        else if (i == 3)
        {
            Console.Write("Which goal do you want removed? ");
            string userinput = Console.ReadLine();
            file.DeleteGoal(userinput);
        }
        else if (i == 4)
        {
            Console.Write("Which goal do you want to record an event for? ");
            string userinput = Console.ReadLine();
            file.RecordEvent(userinput);   
        }
    }

}