using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Journal!");
        Journal journal = new Journal();
        PromptGen prompt = new PromptGen();
        Boolean canContinue = true;

        do
        {
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Delete Entry");
            Console.WriteLine("6. Exit");
            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();
            int menu = int.Parse(input);

            if (menu == 1)
            {
                Entry new_entry = new Entry();
                DateTime dt = DateTime.Now;
                new_entry._date = dt.ToString();
                new_entry._prompt = prompt.ChoosePrompt();
                new_entry.DisplayEntry();
                Console.Write(">");
                new_entry._content = Console.ReadLine();
                journal._entries.Add(new_entry);
            }
            else if (menu == 2)
            {
                journal.DisplayJournal();
            }
            else if (menu == 3)
            {
                Console.Write("What is the filename? ");
                string user_file = Console.ReadLine();

                journal.SaveJournal(user_file);
            }
            else if (menu == 4)
            {
                Console.Write("What is the filename? ");
                string user_file = Console.ReadLine();

                journal.LoadJournal(user_file);
            }
            else if (menu == 5)
            {
                journal.DeleteEntry();
            }
            else
            {
                Console.WriteLine("Thankyou for using My Journal");
                canContinue = false;
            }

        }while(canContinue == true);
    }
}