using System;

using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    
    public void SaveJournal(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine($"{entry._date} | {entry._prompt} | {entry._content}");
                }
        }
    }

    public void LoadJournal(string filename)
    {
        string[] lines = System.IO.File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split("|");

            string date = parts[0];
            string prompt = parts[1];
            string content = parts[2];

            Entry entry = new Entry();
            entry._date = date;
            entry._prompt = prompt;
            entry._content = content;
            _entries.Add(entry);
        }
    }

    public void DisplayJournal()
    {
        Console.WriteLine("My Journal:");
        Console.WriteLine("");
        foreach (Entry entry in _entries)
        {
            int index = _entries.IndexOf(entry);
            Console.WriteLine($"Entry Index: {index + 1}");
            Console.WriteLine($"{entry._date}");
            Console.WriteLine($"{entry._prompt}");
            Console.WriteLine($"{entry._content}");
            Console.WriteLine("");
        }  
    }

    public void DeleteEntry()
    {
        Console.Write("What is the index of the Entry you wish to delete?(enter 0 to cancel)");
        string input = Console.ReadLine();
        int i = int.Parse(input);

        _entries.RemoveAt(i - 1);
    }
}