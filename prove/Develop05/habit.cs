public class Habit : Goal
{
    private int _total;

    public Habit(string title, string description = "habit")
        :base (title, description)
        {

        }
    
    public Habit(string title, int points, string description = "habit")
        :base (title, description, points)
        {

        }

    public override void RecordEvent()
    {
        _total += 1; 
        IsComplete(); 
    }

    public int GetTotal()
    {
        return _total;
    }

    public override int IsComplete()
    {
        return _total * GetPoints(); 
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Habit | {GetTitle()} | Times completed {_total}");
    }

}