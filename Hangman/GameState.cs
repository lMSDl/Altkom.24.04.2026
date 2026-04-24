namespace Hangman;

public class GameState
{
    public string Word { get; }
    public string Category { get; }
    public string Language { get; }
    public HashSet<char> GuessedLetters { get; } = new();
    public int MaxErrors { get; } = 6;
    public int ErrorCount { get; private set; }

    public bool IsWon => Word.All(c => GuessedLetters.Contains(c));
    public bool IsLost => ErrorCount >= MaxErrors;
    public bool IsOver => IsWon || IsLost;

    public string MaskedWord => new(Word.Select(c => GuessedLetters.Contains(c) ? c : '_').ToArray());

    public GameState(string word, string category, string language)
    {
        Word = word.ToUpper();
        Category = category;
        Language = language;
    }

    public GuessResult Guess(char letter)
    {
        letter = char.ToUpper(letter);

        if (GuessedLetters.Contains(letter))
            return GuessResult.AlreadyGuessed;

        GuessedLetters.Add(letter);

        if (Word.Contains(letter))
            return GuessResult.Correct;

        ErrorCount++;
        return GuessResult.Wrong;
    }
}

public enum GuessResult
{
    Correct,
    Wrong,
    AlreadyGuessed
}
