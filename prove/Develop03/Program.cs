using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("1 Nephi", "3", "7");
        string text = @"And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        bool willEndProgram = false;
        bool willContinue = false;

        Scripture scripture = new Scripture(reference, text);
        scripture.CreateWordList();
       
        do
        {
            scripture.DisplayScripture();

            string continueQuestion = "To continue press enter or press Q to quit: ";
            Console.Write(continueQuestion);
            string userinput = Console.ReadLine();

            while (userinput.ToLower() != "q" & willEndProgram == false)
            {
                Console.Clear();
                scripture.HideWords();
                scripture.DisplayScripture();

                Console.Write("If you want to review scripture, press Y: ");
                string userinput1 = Console.ReadLine();
            
                if (userinput1.ToLower() == "y")
                {
                    scripture.CheckScripture();
                } 

                Console.Write(continueQuestion);
                userinput = Console.ReadLine();

            
                willEndProgram = scripture.CheckHiddenWords();
            }

            Console.Write("If you want to start over, press Y: ");
            string userinput2 = Console.ReadLine();

            if (userinput2.ToLower() == "y")
            {
                willEndProgram = false;
                willContinue = true;
                scripture.ResetScripture();
            }
    
            else
            {
                willContinue = false;
            }

        }while (willContinue == true);
    }
}