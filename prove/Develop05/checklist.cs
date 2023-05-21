public class Checklist : Goal
{
    private int _goalNumber;
    private int _currentNumber;

    public Checklist(string title, int goalNumber, string description = "checklist")
        :base(title, description)
        {
            _goalNumber = goalNumber;
        }

    public Checklist(string title, int goalNumber, int points, string description = "checklist")
        :base(title, description, points)
        {
            _goalNumber = goalNumber;
        }

    public int GetCurrentNumber()
    {
        return _currentNumber;
    }

    public void SetCurrentNumber(int number)
    {
        _currentNumber = number;
    }

    public int GetGoalNumber()
    {
        return _goalNumber;
    }
    public override void RecordEvent()
    {
        _currentNumber += 1;
        IsComplete();   
    }

    public override int IsComplete()
    {
        int bonus = GetPoints();
        if (_currentNumber == _goalNumber)
        {
            return (GetPoints() * _currentNumber) + bonus;
        }
        else
        {
            return _currentNumber * GetPoints();
        }
        
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"Checklist | {GetTitle()} | Completed {_currentNumber}/{_goalNumber}");
    }
}