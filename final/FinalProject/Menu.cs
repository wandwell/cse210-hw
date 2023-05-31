public class Menu
{
    private List<string> _options = new List<string>();

    public void DisplayMenu()
    {   
        for(int i = 0; i < _options.Count(); i ++)
        {
            Console.WriteLine($"{i + 1 }: {_options[i]}");
        }
    }

    public void AddOption(string option)
    {
        _options.Add(option);
    }    

    public int SelectOption()
    {
        Console.Write("> ");

        string userinput = Console.ReadLine();
        int choice = int.Parse(userinput) - 1;

        Console.Clear();
        return choice;
    }
}