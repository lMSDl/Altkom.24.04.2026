using System;
using System.Collections.Generic;
using System.IO;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.UnitTests;

[TestClass]
public class HangmanDisplayTests
{
    [TestMethod]
    public void DrawGallows_WithZeroErrors_WritesYellowStage()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawGallows(0);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "+---+");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGallows_WithOneError_WritesYellowStageWithHead()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawGallows(1);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "O");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGallows_WithFiveErrors_WritesYellowStage()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawGallows(5);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "+---+");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGallows_WithSixErrors_WritesRedStage()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawGallows(6);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "+---+");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGallows_WithErrorsGreaterThanSix_ClampsToSix()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawGallows(10);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "+---+");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGallows_WithNegativeErrors_ClampsToZero()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawGallows(-5);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "+---+");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawMaskedWord_WithNormalWord_WritesWord()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawMaskedWord("H_NG_AN");

        // Assert
        var output = stringWriter.ToString().Trim();
        Assert.AreEqual("H_NG_AN", output);
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawMaskedWord_WithEmptyString_WritesEmptyLine()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawMaskedWord(string.Empty);

        // Assert
        var output = stringWriter.ToString();
        Assert.AreEqual(Environment.NewLine, output);
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }
    [TestMethod]
    public void DrawMaskedWord_WithSingleCharacter_WritesSingleCharacter()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawMaskedWord("X");

        // Assert
        var output = stringWriter.ToString().Trim();
        Assert.AreEqual("X", output);
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGuessedLetters_WithMultipleLetters_WritesOrderedLetters()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var letters = new List<char> { 'z', 'a', 'm', 'b' };

        // Act
        HangmanDisplay.DrawGuessedLetters(letters);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "Used letters: ");
        StringAssert.Contains(output, "a, b, m, z");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGuessedLetters_WithSingleLetter_WritesSingleLetter()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var letters = new List<char> { 'a' };

        // Act
        HangmanDisplay.DrawGuessedLetters(letters);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "Used letters: ");
        StringAssert.Contains(output, "a");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawGuessedLetters_WithEmptyCollection_WritesEmptyList()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var letters = new List<char>();

        // Act
        HangmanDisplay.DrawGuessedLetters(letters);

        // Assert
        var output = stringWriter.ToString();
        StringAssert.Contains(output, "Used letters: ");
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawStatus_WithErrorsAndMaxErrors_WritesCorrectFormat()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawStatus(3, 6);

        // Assert
        var output = stringWriter.ToString().Trim();
        Assert.AreEqual("Errors: 3/6", output);
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawStatus_WithZeroErrors_WritesZeroErrors()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawStatus(0, 6);

        // Assert
        var output = stringWriter.ToString().Trim();
        Assert.AreEqual("Errors: 0/6", output);
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }

    [TestMethod]
    public void DrawStatus_WithErrorsEqualToMaxErrors_WritesMaxErrors()
    {
        // Arrange
        var originalOut = Console.Out;
        var originalColor = Console.ForegroundColor;
        using var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        // Act
        HangmanDisplay.DrawStatus(6, 6);

        // Assert
        var output = stringWriter.ToString().Trim();
        Assert.AreEqual("Errors: 6/6", output);
        Assert.AreEqual(originalColor, Console.ForegroundColor);

        // Cleanup
        Console.SetOut(originalOut);
    }
}
