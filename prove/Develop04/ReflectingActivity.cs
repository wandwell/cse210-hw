using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public void DisplayReflectionPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count);

        Console.WriteLine("Consider the Following Prompt: ");
        Console.WriteLine("");
        Console.WriteLine($"---{_prompts[index]}---");
        Console.WriteLine("");

        Console.Write("When you are Ready, press Enter");
        Console.ReadLine();
        Console.WriteLine("");
        
        DisplayCountdown("Now ponder on the following questions as they relate to this experience: ");
        Console.Clear();
    }

    public void DisplayQuestion()
    {
        Random rand = new Random();
        int index = rand.Next(_questions.Count);

        Console.Write(_questions[index] + " ");

        DateTime spinner = DateTime.Now;
        DateTime endSpinner = spinner.AddSeconds(7);

        while (spinner < endSpinner)
        {
            DisplaySpinner();
            spinner = DateTime.Now;
        }

        Console.WriteLine("");
        Console.WriteLine("");
    }

    public ReflectingActivity(string title)
    :base(title)
    {
        SetDescription( "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    }
}