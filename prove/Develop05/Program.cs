using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Gamify!");
        Console.Write("What is the name of your character? ");
        string userinput = Console.ReadLine();

        Character character = new Character(userinput);
        Gamefile file = new Gamefile(character);

        try 
        {
            file.LoadGamefile();
        }
        catch(FileNotFoundException)
        {
            file.SaveGamefile();
        }

        Menu menu = new Menu();
        int choice = -1;

        do
        { 
            Console.Clear();

            character.DisplayCharacter();
            Console.WriteLine("");
            
            menu.DisplayMenu();

            Console.Write("Select Menu Option: ");
            userinput = Console.ReadLine();
            choice = int.Parse(userinput) - 1;
            Console.Clear();

            menu.SelectOption(choice, file);
            Console.Clear();
            
        }while (choice != 5);

        file.SaveGamefile();
    }
}