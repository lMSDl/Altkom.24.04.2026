namespace Hangman;

public static class HangmanDisplay
{
    private static readonly string[] Stages =
    [
        """
          +---+
          |   |
              |
              |
              |
              |
        =========
        """,
        """
          +---+
          |   |
          O   |
              |
              |
              |
        =========
        """,
        """
          +---+
          |   |
          O   |
          |   |
              |
              |
        =========
        """,
        """
          +---+
          |   |
          O   |
         /|   |
              |
              |
        =========
        """,
        """
          +---+
          |   |
          O   |
         /|\  |
              |
              |
        =========
        """,
        """
          +---+
          |   |
          O   |
         /|\  |
         /    |
              |
        =========
        """,
        """
          +---+
          |   |
          O   |
         /|\  |
         / \  |
              |
        =========
        """
    ];

    public static void DrawGallows(int errors)
    {
        Console.ForegroundColor = errors >= 6 ? ConsoleColor.Red : ConsoleColor.Yellow;
        Console.WriteLine(Stages[Math.Clamp(errors, 0, 6)]);
        Console.ResetColor();
    }

    public static void DrawMaskedWord(string maskedWord)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(string.Join(' ', maskedWord));
        Console.ResetColor();
    }

    public static void DrawGuessedLetters(IEnumerable<char> guessedLetters)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Used letters: ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(string.Join(", ", guessedLetters.OrderBy(c => c)));
        Console.ResetColor();
    }

    public static void DrawStatus(int errors, int maxErrors)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"Errors: {errors}/{maxErrors}");
        Console.ResetColor();
    }
}
