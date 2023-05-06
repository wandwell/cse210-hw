using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool GetIsHidden()
    {
        bool isHidden = _isHidden;
        return isHidden;
    }

    public void SetIsHidden(bool isHidden)
    {
        _isHidden = isHidden;
    }

    public void DisplayWord()
    {
        if (_isHidden == false)
        {
            Console.Write(_text + " ");
        }
        else
        {
            Console.Write("___ ");
        }
    }

    public void DisplayAllWords()
    {
        Console.Write(_text + " ");
    }
}
