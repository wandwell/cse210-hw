using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userinput = Console.ReadLine();
        int percentage = int.Parse(userinput);
        int second_digit = percentage % 10;

        string letter = "";
        string sign = "";

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >=  60)
        {
            letter = "D";
        }
        else
        {
            letter ="F";
        }

        if (second_digit < 3 && letter != "F")
        {
            sign = "-";
        }
        else if (second_digit >=7 && letter != "A")
        {
            sign = "+";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your Grade is {letter}{sign}");

        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations! You Passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }
    }
}