using System;

public class BreathingActivity : Activity
{
    private string _breathin = "Breath in";
    private string _breathout = "Now breath Out";

    public string GetPrompt(int i)
    {
        if (i % 2 == 0)
        {
            return _breathin;
        }
        else
        {
            return _breathout;
        }
    }

    public BreathingActivity(string title)
        : base (title)
        {
            SetDescription("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        }

}