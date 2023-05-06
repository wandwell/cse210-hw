using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private string _text;
   
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _text = text;
    }
    
    public void DisplayScripture()
    {
        _reference.DisplayReference();

        foreach (Word word in _words)
        {
            word.DisplayWord();
        }
        
        Console.WriteLine("");
    }
    public void CreateWordList()
    {
        string[] parts = _text.Split(" ");

        foreach (string part in parts)
        {
            Word new_word = new Word(part);
            _words.Add(new_word);
        }
    }

    public void HideWords()
    {
        Random rand = new Random();
        bool isHidden = true;
        int index = -1;

        do
        {
            index = rand.Next(_words.Count);
            isHidden = _words[index].GetIsHidden();
        }while(isHidden == true);

        isHidden = true;
        _words[index].SetIsHidden(isHidden);
    }

    public bool CheckHiddenWords()
    {
        bool willEndProgram = true;
        foreach (Word word in _words)
        {
            bool isHidden = word.GetIsHidden();

            if (isHidden == false)
            {
                willEndProgram = false;
            }
        }
        return willEndProgram;
    }

    public void CheckScripture()
    {
        _reference.DisplayReference();

        foreach (Word word in _words)
        {
            word.DisplayAllWords();
        }

        Console.WriteLine("");
    }

    public void ResetScripture()
    {
        foreach (Word word in _words)
        {
            bool isHidden = false;
            word.SetIsHidden(isHidden);
        }
    }

}

