public class Simple : Goal
{
    private DateOnly _event;
    private bool _goalCompleted;
    public Simple(string title, string description = "simple")
        : base(title, description)
        {
            _goalCompleted = false;
        }

    public Simple(string title, int points, string description = "simple")
        : base(title, description, points)
        {
            _goalCompleted = false;
        }
    public void SetGoalCompleted(bool completed)
    {
        _goalCompleted = completed;
    }

    public bool GetGoalCompleted()
    {
        return _goalCompleted;
    }
    public override void RecordEvent()
    {
        _goalCompleted = true;
        IsComplete(); 
    }

    public override int IsComplete()
    {
        if (_goalCompleted == true)
        {
            return GetPoints();
        }
        else
        {
            return 0;
        }
    }

    public override void DisplayGoal()
    {
        if (_goalCompleted == true)
            {
                Console.WriteLine($"Simple | {GetTitle()} | Completed");
            }
        else
        {
            Console.WriteLine($"Simple | {GetTitle()} | Not Completed");
        }
    }
}