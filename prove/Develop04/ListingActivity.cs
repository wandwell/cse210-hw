using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    private List<string> _responses = new List<string>();

    public string getPrompt()
    {
        Random rand = new Random();
        int index = rand.Next(_prompts.Count());

        string prompt = _prompts[index];
        return prompt;
    }

    public void StoreResponse(string response)
    {
        _responses.Add(response);
    }

    public void GetResponseCount()
    {
        int responseCount = _responses.Count();
        Console.WriteLine("");
        Console.WriteLine($"You have listed {responseCount} items!");
        Console.WriteLine("");
    }

    public ListingActivity(string title) 
        : base (title)
        {
            SetDescription("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        }
}