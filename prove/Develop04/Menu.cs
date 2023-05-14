using System;

public class Menu
{
    private List<string> _titles = new List<string>
    {
        "Breathing Activity",
        "Reflecting Activity",
        "Listing Activity",
        "View Activity Log",
        "Quit"
    };

    public void DisplayMenu()
    {
        Console.WriteLine("Menu Options: ");
        int option = 0;

        foreach (string activity in _titles)
        {
            option += 1;
            Console.WriteLine($"{option}. {activity}");
        }
    }

    public string SelectOption()
    {
        Console.Write("Select an option from the Menu: ");
        string userinput = Console.ReadLine();
        int index = int.Parse(userinput) - 1;

        string title = _titles[index];
        Console.Clear();
        return title;
    }
}