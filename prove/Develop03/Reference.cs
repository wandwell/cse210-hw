using System;

public class Reference
{
    private string _book;
    private string _chapter;
    private string _begverse;
    private string _endverse;

    public Reference(string book, string chapter, string begverse)
    {
        _book = book;
        _chapter = chapter;
        _begverse = begverse;
        _endverse = "N/A";
    }

    public Reference(string book, string chapter, string begverse, string endverse)
    {
        _book = book;
        _chapter = chapter;
        _begverse = begverse;
        _endverse = endverse;
    }

    public void DisplayReference()
    {   
        if (_endverse == "N/A")
        {
            Console.WriteLine($"{_book} {_chapter}:{_begverse}");
        }
        else
        {
            Console.WriteLine($"{_book} {_chapter}:{_begverse}-{_endverse}");
        }
    }
}