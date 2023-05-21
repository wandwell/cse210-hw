public class Character
{
    private string _name;
    private int _score = 0;

    public Character(string name)
    {
        _name = name;
    }

    public void AddPoints(int points)
    {
        _score += points;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public void DisplayCharacter()
    {
        Console.WriteLine($"{_name} currently has {_score} points!");
    }
}