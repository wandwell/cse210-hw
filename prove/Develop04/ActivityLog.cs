using System;

public class Log
{
    private List<Activity> _activities = new List<Activity>();
    private List<DateOnly> _dates = new List<DateOnly>();
    public void AddActivity(Activity activity)
    {
        _activities.Add(activity);
        DateTime current = DateTime.Today;
        DateOnly date = DateOnly.FromDateTime(current);
        _dates.Add(date);
    }

    public void SaveActivityLog(string filename = "mindfulness_log.txt")
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Activity entry in _activities)
            {
                int index = _activities.IndexOf(entry);
                DateOnly date = _dates[index];

                outputFile.WriteLine($"{index} | {entry.GetTitle()} | {entry.GetTime()} | {date}");
            }
        }
    }

    public void LoadActivityLog(string filename = "mindfulness_log.txt")
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string indexString = parts[1];
            string title = parts[1];
            string timeString = parts[2];
            string dateString = parts[3];

            int time = int.Parse(timeString);
            DateOnly date = DateOnly.Parse(dateString);

            Activity activity = new Activity(title);
            activity.SetTime(time);
            _activities.Add(activity);
            _dates.Add(date);
        }
    }

    public void DisplayLog()
    {
        int breathingTotal = 0;
        int reflectingTotal = 0;
        int listingTotal = 0;
        int total = 0;

        Console.WriteLine("Activity Log");
        Console.WriteLine("");

        foreach (Activity entry in _activities)
        {
            int index = _activities.IndexOf(entry);
            DateOnly date = _dates[index];
            string title = entry.GetTitle();
            int time = entry.GetTime();

            Console.WriteLine($"{title} | Time Spent: {time} seconds | Date: {date}");

            if (title == "Breathing Activity")
            {
                breathingTotal += time;
            }
            else if (title == "Reflecting Activity")
            {
                reflectingTotal += time;
            }
            else
            {
                listingTotal += time;
            }
            total += time;
        }
            Console.WriteLine("");

            Console.WriteLine($"Total time spent in Breathing Activity: {breathingTotal}");
            Console.WriteLine($"Total time spent in Reflecting Activity: {reflectingTotal}");
            Console.WriteLine($"Total time spent in Listing Activity: {listingTotal}");
            Console.WriteLine($"Total time spent: {total}");

            Console.WriteLine("");
            Console.Write("Press Enter when you are ready to leave: " );
            Console.ReadLine();
            Console.Clear();
    }
}