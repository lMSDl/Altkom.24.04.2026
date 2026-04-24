using Hangman;

namespace Hangman.UnitTests;

[TestClass]
public class GameStateTests
{
    [TestMethod]
    public void Constructor_WithValidParameters_SetsPropertiesCorrectly()
    {
        // Arrange
        var word = "test";
        var category = "Category";
        var language = "English";

        // Act
        var gameState = new GameState(word, category, language);

        // Assert
        Assert.AreEqual("TEST", gameState.Word);
        Assert.AreEqual(category, gameState.Category);
        Assert.AreEqual(language, gameState.Language);
        Assert.IsNotNull(gameState.GuessedLetters);
        Assert.IsEmpty(gameState.GuessedLetters);
        Assert.AreEqual(6, gameState.MaxErrors);
        Assert.AreEqual(0, gameState.ErrorCount);
    }

    [TestMethod]
    public void Constructor_WithLowercaseWord_ConvertsToUppercase()
    {
        // Arrange
        var word = "hangman";
        var category = "Game";
        var language = "English";

        // Act
        var gameState = new GameState(word, category, language);

        // Assert
        Assert.AreEqual("HANGMAN", gameState.Word);
    }

    [TestMethod]
    public void Constructor_WithMixedCaseWord_ConvertsToUppercase()
    {
        // Arrange
        var word = "HaNgMaN";
        var category = "Game";
        var language = "English";

        // Act
        var gameState = new GameState(word, category, language);

        // Assert
        Assert.AreEqual("HANGMAN", gameState.Word);
    }

    [TestMethod]
    public void IsWon_WhenNoLettersGuessed_ReturnsFalse()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        var result = gameState.IsWon;

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsWon_WhenSomeLettersGuessed_ReturnsFalse()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");
        gameState.GuessedLetters.Add('T');

        // Act
        var result = gameState.IsWon;

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsWon_WhenAllLettersGuessed_ReturnsTrue()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");
        gameState.GuessedLetters.Add('T');
        gameState.GuessedLetters.Add('E');
        gameState.GuessedLetters.Add('S');

        // Act
        var result = gameState.IsWon;

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsWon_WhenAllLettersGuessedWithExtras_ReturnsTrue()
    {
        // Arrange
        var gameState = new GameState("CAT", "Category", "English");
        gameState.GuessedLetters.Add('C');
        gameState.GuessedLetters.Add('A');
        gameState.GuessedLetters.Add('T');
        gameState.GuessedLetters.Add('X');
        gameState.GuessedLetters.Add('Y');

        // Act
        var result = gameState.IsWon;

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsWon_WithEmptyWord_ReturnsTrue()
    {
        // Arrange
        var gameState = new GameState("", "Category", "English");

        // Act
        var result = gameState.IsWon;

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsLost_WhenErrorCountIsZero_ReturnsFalse()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        var result = gameState.IsLost;

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsLost_WhenErrorCountBelowMax_ReturnsFalse()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");
        gameState.Guess('X');
        gameState.Guess('Y');
        gameState.Guess('Z');

        // Act
        var result = gameState.IsLost;

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsLost_WhenErrorCountEqualsMax_ReturnsTrue()
    {
        // Arrange
        var gameState = new GameState("A", "Category", "English");
        gameState.Guess('X');
        gameState.Guess('Y');
        gameState.Guess('Z');
        gameState.Guess('B');
        gameState.Guess('C');
        gameState.Guess('D');

        // Act
        var result = gameState.IsLost;

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsOver_WhenNotWonAndNotLost_ReturnsFalse()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");
        gameState.GuessedLetters.Add('T');

        // Act
        var result = gameState.IsOver;

        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsOver_WhenWon_ReturnsTrue()
    {
        // Arrange
        var gameState = new GameState("CAT", "Category", "English");
        gameState.GuessedLetters.Add('C');
        gameState.GuessedLetters.Add('A');
        gameState.GuessedLetters.Add('T');

        // Act
        var result = gameState.IsOver;

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsOver_WhenLost_ReturnsTrue()
    {
        // Arrange
        var gameState = new GameState("A", "Category", "English");
        gameState.Guess('X');
        gameState.Guess('Y');
        gameState.Guess('Z');
        gameState.Guess('B');
        gameState.Guess('C');
        gameState.Guess('D');

        // Act
        var result = gameState.IsOver;

        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void MaskedWord_WhenNoLettersGuessed_ReturnsAllUnderscores()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        var result = gameState.MaskedWord;

        // Assert
        Assert.AreEqual("____", result);
    }

    [TestMethod]
    public void MaskedWord_WhenSomeLettersGuessed_ReturnsMixedResult()
    {
        // Arrange
        var gameState = new GameState("HANGMAN", "Category", "English");
        gameState.GuessedLetters.Add('A');
        gameState.GuessedLetters.Add('N');

        // Act
        var result = gameState.MaskedWord;

        // Assert
        Assert.AreEqual("_AN__AN", result);
    }

    [TestMethod]
    public void MaskedWord_WhenAllLettersGuessed_ReturnsFullWord()
    {
        // Arrange
        var gameState = new GameState("CAT", "Category", "English");
        gameState.GuessedLetters.Add('C');
        gameState.GuessedLetters.Add('A');
        gameState.GuessedLetters.Add('T');

        // Act
        var result = gameState.MaskedWord;

        // Assert
        Assert.AreEqual("CAT", result);
    }

    [TestMethod]
    public void MaskedWord_WithEmptyWord_ReturnsEmptyString()
    {
        // Arrange
        var gameState = new GameState("", "Category", "English");

        // Act
        var result = gameState.MaskedWord;

        // Assert
        Assert.AreEqual("", result);
    }

    [TestMethod]
    public void MaskedWord_WithSingleLetter_ReturnsCorrectMask()
    {
        // Arrange
        var gameState = new GameState("A", "Category", "English");

        // Act
        var result = gameState.MaskedWord;

        // Assert
        Assert.AreEqual("_", result);
    }

    [TestMethod]
    public void MaskedWord_WithRepeatingLetters_ShowsAllOccurrences()
    {
        // Arrange
        var gameState = new GameState("BOOK", "Category", "English");
        gameState.GuessedLetters.Add('O');

        // Act
        var result = gameState.MaskedWord;

        // Assert
        Assert.AreEqual("_OO_", result);
    }

    [TestMethod]
    public void Guess_WithCorrectUppercaseLetter_ReturnsCorrect()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        var result = gameState.Guess('T');

        // Assert
        Assert.AreEqual(GuessResult.Correct, result);
        Assert.Contains('T', gameState.GuessedLetters);
        Assert.AreEqual(0, gameState.ErrorCount);
    }

    [TestMethod]
    public void Guess_WithCorrectLowercaseLetter_ReturnsCorrectAndConvertsToUppercase()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        var result = gameState.Guess('t');

        // Assert
        Assert.AreEqual(GuessResult.Correct, result);
        Assert.Contains('T', gameState.GuessedLetters);
        Assert.DoesNotContain('t', gameState.GuessedLetters);
        Assert.AreEqual(0, gameState.ErrorCount);
    }

    [TestMethod]
    public void Guess_WithWrongUppercaseLetter_ReturnsWrongAndIncrementsErrorCount()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        var result = gameState.Guess('X');

        // Assert
        Assert.AreEqual(GuessResult.Wrong, result);
        Assert.Contains('X', gameState.GuessedLetters);
        Assert.AreEqual(1, gameState.ErrorCount);
    }

    [TestMethod]
    public void Guess_WithWrongLowercaseLetter_ReturnsWrongAndConvertsToUppercase()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        var result = gameState.Guess('x');

        // Assert
        Assert.AreEqual(GuessResult.Wrong, result);
        Assert.Contains('X', gameState.GuessedLetters);
        Assert.DoesNotContain('x', gameState.GuessedLetters);
        Assert.AreEqual(1, gameState.ErrorCount);
    }

    [TestMethod]
    public void Guess_WithAlreadyGuessedCorrectLetter_ReturnsAlreadyGuessed()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");
        gameState.Guess('T');

        // Act
        var result = gameState.Guess('T');

        // Assert
        Assert.AreEqual(GuessResult.AlreadyGuessed, result);
        Assert.HasCount(1, gameState.GuessedLetters);
        Assert.AreEqual(0, gameState.ErrorCount);
    }

    [TestMethod]
    public void Guess_WithAlreadyGuessedWrongLetter_ReturnsAlreadyGuessed()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");
        gameState.Guess('X');
        var initialErrorCount = gameState.ErrorCount;

        // Act
        var result = gameState.Guess('X');

        // Assert
        Assert.AreEqual(GuessResult.AlreadyGuessed, result);
        Assert.HasCount(1, gameState.GuessedLetters);
        Assert.AreEqual(initialErrorCount, gameState.ErrorCount);
    }

    [TestMethod]
    public void Guess_WithAlreadyGuessedLetterInDifferentCase_ReturnsAlreadyGuessed()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");
        gameState.Guess('T');

        // Act
        var result = gameState.Guess('t');

        // Assert
        Assert.AreEqual(GuessResult.AlreadyGuessed, result);
        Assert.HasCount(1, gameState.GuessedLetters);
        Assert.AreEqual(0, gameState.ErrorCount);
    }

    [TestMethod]
    public void Guess_MultipleWrongGuesses_IncrementsErrorCountEachTime()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        gameState.Guess('X');
        gameState.Guess('Y');
        var result = gameState.Guess('Z');

        // Assert
        Assert.AreEqual(GuessResult.Wrong, result);
        Assert.AreEqual(3, gameState.ErrorCount);
        Assert.HasCount(3, gameState.GuessedLetters);
    }

    [TestMethod]
    public void Guess_MultipleCorrectGuesses_DoesNotIncrementErrorCount()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        gameState.Guess('T');
        gameState.Guess('E');
        var result = gameState.Guess('S');

        // Assert
        Assert.AreEqual(GuessResult.Correct, result);
        Assert.AreEqual(0, gameState.ErrorCount);
        Assert.HasCount(3, gameState.GuessedLetters);
    }

    [TestMethod]
    public void Guess_MixedCorrectAndWrongGuesses_TracksErrorCountCorrectly()
    {
        // Arrange
        var gameState = new GameState("TEST", "Category", "English");

        // Act
        gameState.Guess('T'); // Correct
        gameState.Guess('X'); // Wrong
        gameState.Guess('E'); // Correct
        var result = gameState.Guess('Y'); // Wrong

        // Assert
        Assert.AreEqual(GuessResult.Wrong, result);
        Assert.AreEqual(2, gameState.ErrorCount);
        Assert.HasCount(4, gameState.GuessedLetters);
    }
}
