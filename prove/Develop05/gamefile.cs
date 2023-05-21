public class Gamefile
{
    private string _filename;
    private Character _character;
    private List<Goal> _goals = new List<Goal>();
    
    public Gamefile(Character character)
    {
        _character = character;
        _filename = $"{character.GetName()}_Goals.txt";
    }

    public void DeleteGoal(string title)
    {
        int index = -1;
        foreach(Goal goal in _goals)
        {
            if (goal.GetTitle() == title)
            {
                index = _goals.IndexOf(goal);
            }
        }

        if (index >= 0)
        {
            _goals.RemoveAt(index);
        }
    }
    public void ListGoals()
    {
        foreach (Goal goal in _goals)
        {
            goal.DisplayGoal();
        }
        Console.Write(" ");
        Console.ReadLine();
    }

    public void SaveGamefile()
    {
        using (StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach (Goal goal in _goals)
            {
                int index = _goals.IndexOf(goal);
                
                if (goal is Habit)
                    {
                        Habit habit = (Habit)goal;
                        outputFile.WriteLine($"{index}|{habit.GetTitle()}|{habit.GetDescription()}|{habit.GetTotal()}|none|{habit.GetPoints()}");
                    }
                
                else if (goal is Checklist)
                    {
                        Checklist checklist = (Checklist)goal;
                        outputFile.WriteLine($"{index}|{checklist.GetTitle()}|{checklist.GetDescription()}|{checklist.GetGoalNumber()}|{checklist.GetCurrentNumber()}|{checklist.GetPoints()}");
                    }
                
                else
                    {
                        Simple simple = (Simple)goal;
                        outputFile.WriteLine($"{index}|{goal.GetTitle()}|{goal.GetDescription()}|{simple.GetGoalCompleted()}|none|{goal.GetPoints()}");
                    }       
            }
        }
    }

    public void LoadGamefile()
    {
        int score = 0;
        string[] lines = System.IO.File.ReadAllLines(_filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string title = parts[1];
            string description= parts[2];
            string detail_1 = parts[3];
            string detail_2 = parts[4];
            string pointsString = parts[5];
            int points = int.Parse(pointsString);
            if (description == "habit")
            {
                Habit habit = new Habit(title, points, description);
                _goals.Add(habit);
                score += habit.IsComplete();
            }

            else if (description == "checklist")
            {
                int goalnumber = int.Parse(detail_1);
                int currentnumber = int.Parse(detail_2);
                Checklist checklist = new Checklist(title, goalnumber, points, description);
                checklist.SetCurrentNumber(currentnumber);
                _goals.Add(checklist);
                score += checklist.IsComplete();
            }

            else
            {
                Simple goal = new Simple(title, points, description);
                if (detail_1 == "True")
                {
                    goal.SetGoalCompleted(true);
                }
                _goals.Add(goal);
                score += goal.IsComplete();
            }
        _character.SetScore(score);
        }
    }

    public void RecordEvent(string title)
    {
        foreach(Goal goal in _goals)
        {
            if (goal.GetTitle() == title)
            {
                goal.RecordEvent();
                _character.AddPoints(goal.IsComplete());
            }
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("Choose a category:");
        Console.WriteLine("1. Simple");
        Console.WriteLine("2. Checklist");
        Console.WriteLine("3. Habit");
        
        Console.Write("> ");
        string userinput = Console.ReadLine();
        int choice = int.Parse(userinput);

        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Goal Difficulty(from 1 - 3): " );
        userinput = Console.ReadLine();
        int level = int.Parse(userinput);

        if (choice == 1)
            {
                Simple goal = new Simple(title);
                goal.SetPoints(level);
                _goals.Add(goal); 
            }
        else if (choice == 2)
            {
                Console.Write("Number of Times to Complete Goal: ");
                userinput = Console.ReadLine();
                int goalnumber = int.Parse(userinput);

                Checklist goal = new Checklist(title, goalnumber);
                goal.SetPoints(level);
                _goals.Add(goal);
            }
        else
            {
                Habit goal = new Habit(title);
                goal.SetPoints(level);
                _goals.Add(goal);
            }       
    }
}