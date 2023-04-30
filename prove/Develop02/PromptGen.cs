using System;

public class PromptGen
{
    public List<string> _prompts = new List<string>
    {
        "A miracle that happened today is ...",
        "I am grateful for...",
        "One of my happiest memories is ...",
        "Something great about me is ...",
        "Something amazing I did today is ...",
        "A habit I am trying to develop is ...",
        "Tomorrow I want to ...",
        "Something I have always struggled with is ...",
        "Something I have always excelled at is ...",
        "My top 5 favorite things to do are ...",
        "If I could change one thing about today, I would ...",
        "The strongest emotion I felt today is ...",
        "Something that scared me today is",
        "Today I realized that I am ...",
        "Something I think about all the time is ...",
        "Something I am worried about is ...",
        "Something I am excited about is ...",
    };
    
    public string ChoosePrompt()
    {
        Random rand = new Random();

        int index = rand.Next(_prompts.Count);
        string prompt = _prompts[index];

        return prompt;
    }
}