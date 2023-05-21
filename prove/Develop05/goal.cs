public abstract class Goal
{
    private string _title;
    private string _description;

    int _points;
    
    public Goal(string title, string description)
    {
        _title = title;
        _description = description;
    }

    public Goal(string title, string description, int points)
    {
       _title = title;
        _description = description;
        _points = points; 
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetDescription()
        {
            return _description;
        }

    public void SetPoints(int lvl)
    {
        if (lvl == 1)
        {
            _points = 20;
        }
        else if (lvl ==2)
        {
            _points = 50;
        }
        else
        {
            _points = 100;
        }
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract void RecordEvent();

    public abstract int IsComplete();

    public abstract void DisplayGoal();   
}