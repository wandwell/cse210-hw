using System;

class Program
{
    static void Main(string[] args)
    {
        string response = "no";

        do
        {
            //for parts 1 & 2 where user chooses the Magic Number
            //Console.Write("What is the Magic Number? ");
            //string response = Console.ReadLine();
            //int magic = int.Parse(response);

            //For part 3 where computer chooses random number
            Random randomGenerator = new Random();
            int magic = randomGenerator.Next(1,101);
            
            int guess = -1;
            int number = 0;

            do
            {
                Console.Write("What is your guess? ");
                string userinput = Console.ReadLine();
                guess = int.Parse(userinput);
                number ++;

                if (guess > magic)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < magic)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("You Guessed it!");
                    Console.WriteLine($"You made {number} guesses!");
                }

            } while (guess != magic);

            Console.Write("Do you want to play again? ");

            response = Console.ReadLine();
        } while (response.ToLower() == "yes");

        Console.WriteLine("Thankyou for playing!");
    }
}