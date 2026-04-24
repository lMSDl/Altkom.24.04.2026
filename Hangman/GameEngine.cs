namespace Hangman;

public class GameEngine
{
    private readonly WordRepository _repository;

    public GameEngine(WordRepository repository)
    {
        _repository = repository;
    }

    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool playAgain = true;

        while (playAgain)
        {
            var (language, category) = ChooseLanguageAndCategory();
            var (word, chosenCategory, chosenLanguage) = _repository.GetRandomWord(language, category);
            var state = new GameState(word, chosenCategory, chosenLanguage);

            PlayRound(state);

            Console.WriteLine();
            Console.Write("Play again? (y/n): ");
            playAgain = Console.ReadLine()?.Trim().ToLower() == "y";
        }

        Console.WriteLine("\nThanks for playing! Goodbye.");
    }

    private (string? language, string? category) ChooseLanguageAndCategory()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== HANGMAN ===");
        Console.ResetColor();

        Console.WriteLine("\nChoose a language:");
        Console.WriteLine("  0. Random");
        var languages = _repository.Languages.ToList();
        for (int i = 0; i < languages.Count; i++)
            Console.WriteLine($"  {i + 1}. {languages[i]}");

        Console.Write("\nYour choice: ");
        var langInput = Console.ReadLine()?.Trim();
        string? selectedLanguage = null;
        if (int.TryParse(langInput, out int langChoice) && langChoice >= 1 && langChoice <= languages.Count)
            selectedLanguage = languages[langChoice - 1];

        var categories = selectedLanguage is not null
            ? _repository.GetCategories(selectedLanguage).ToList()
            : [];

        if (categories.Count == 0)
            return (selectedLanguage, null);

        Console.WriteLine("\nChoose a category:");
        Console.WriteLine("  0. Random");
        for (int i = 0; i < categories.Count; i++)
            Console.WriteLine($"  {i + 1}. {categories[i]}");

        Console.Write("\nYour choice: ");
        var catInput = Console.ReadLine()?.Trim();
        string? selectedCategory = null;
        if (int.TryParse(catInput, out int catChoice) && catChoice >= 1 && catChoice <= categories.Count)
            selectedCategory = categories[catChoice - 1];

        return (selectedLanguage, selectedCategory);
    }

    private void PlayRound(GameState state)
    {
        while (!state.IsOver)
        {
            Render(state);

            Console.Write("\nGuess a letter: ");
            var input = Console.ReadLine()?.Trim().ToUpper();

            if (string.IsNullOrEmpty(input) || input.Length != 1 || !char.IsLetter(input[0]))
            {
                ShowMessage("Please enter a single letter.", ConsoleColor.DarkYellow);
                continue;
            }

            var result = state.Guess(input[0]);

            switch (result)
            {
                case GuessResult.Correct:
                    ShowMessage("Correct!", ConsoleColor.Green);
                    break;
                case GuessResult.Wrong:
                    ShowMessage($"Wrong! '{input[0]}' is not in the word.", ConsoleColor.Red);
                    break;
                case GuessResult.AlreadyGuessed:
                    ShowMessage($"You already guessed '{input[0]}'.", ConsoleColor.DarkYellow);
                    break;
            }

            System.Threading.Thread.Sleep(600);
        }

        Render(state);

        Console.WriteLine();
        if (state.IsWon)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"🎉 You won! The word was: {state.Word}");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"💀 You lost! The word was: {state.Word}");
        }
        Console.ResetColor();
    }

    private void Render(GameState state)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== HANGMAN ===");
        Console.ResetColor();
        Console.WriteLine($"Language: {state.Language} | Category: {state.Category}");
        Console.WriteLine();

        HangmanDisplay.DrawGallows(state.ErrorCount);
        Console.WriteLine();
        HangmanDisplay.DrawMaskedWord(state.MaskedWord);
        Console.WriteLine();
        HangmanDisplay.DrawGuessedLetters(state.GuessedLetters);
        HangmanDisplay.DrawStatus(state.ErrorCount, state.MaxErrors);
    }

    private static void ShowMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
