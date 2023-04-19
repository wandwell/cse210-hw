using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int user_number = -1;

        Console.WriteLine("Enter a list of numbers; Type 0 when finished.");

        do
        {
            Console.Write("Enter a number: ");
            string user_input = Console.ReadLine();
            user_number = int.Parse(user_input);
            
            if (user_number != 0)
            {
                numbers.Add(user_number);
            }

        } while (user_number != 0);

        numbers.Reverse();
        int sum = 0;
        int max = numbers[0];
        int min = numbers[0];
        
        foreach (int number in numbers)
        {
            sum += number;

            if (number > max)
            {
                max = number;
            }

            if (number < min && number > 0)
            {
                min = number;
            }

        }

        float avg = ((float)sum) / numbers.Count;

        Console.WriteLine($"The Sum is {sum}.");
        Console.WriteLine($"The Average is {avg}");
        Console.WriteLine($"The Max is {max}");
        Console.WriteLine($"The smallest positive number is {min}");
    }
}