using System;

public class Activity
{
    private string _title;
    private string _description;
    private int _time;

    public void DisplayStartMsg()
    {
        Console.WriteLine($"Welcome to the {_title}.");
        Console.WriteLine("");
        Console.WriteLine(_description);
        Console.WriteLine("");

        Console.Write("How long, in seconds, would you like for your session? ");
        string userinput = Console.ReadLine();
        _time = int.Parse(userinput);

        Console.Clear();
        Console.WriteLine("Get Ready...");

        DateTime current = DateTime.Now;
        DateTime end = current.AddSeconds(3);

        while (current < end)
        {
            DisplaySpinner();
            current = DateTime.Now;
        }

        Console.WriteLine(" ");
    }

    public void DisplayEndMsg()
    {
        Console.WriteLine("Good Job!");
        Console.WriteLine("");
        DateTime current = DateTime.Now;
        DateTime end = current.AddSeconds(3);

        while (current < end)
        {
            DisplaySpinner();
            current = DateTime.Now;
        }

        Console.WriteLine($"You have completed {_time} seconds of the {_title}!");
        current = DateTime.Now;
        end = current.AddSeconds(3);

        while (current < end)
        {
            DisplaySpinner();
            current = DateTime.Now;
        }

        Console.Clear();
    }

    public void DisplaySpinner()
    {
        List<string> animations = new List<string>
        {
            "|",
            "/",
            "-",
            "\\",
            "|",
            "/",
            "-",
            "\\"
        };

        foreach (string animation in animations)
        {
            Console.Write(animation); 
            Thread.Sleep(250);
            Console.Write("\b \b"); 
        }

    }

    public void DisplayCountdown(string prompt)
    {
        Console.Write(prompt + " ... ");

        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            Console.Write("\b \b");
        }
    }

    public int GetTime()
    {
        return _time;
    }

    public string GetTitle()
    {
        return _title;
    }

    public void SetTime(int time)
    {
        _time = time;
    }

    public void SetDescription(string description)
    {
        _description = description;
    }

    public Activity(string title)
    {
        _title = title;
    }
}
