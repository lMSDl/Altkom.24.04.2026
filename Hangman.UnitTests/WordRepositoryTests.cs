using System.Text.Json;

namespace Hangman.UnitTests;

[TestClass]
public class WordRepositoryTests
{
    private string CreateTempJsonFile(string content)
    {
        var tempFile = Path.GetTempFileName();
        File.WriteAllText(tempFile, content);
        return tempFile;
    }

    [TestMethod]
    public void Languages_ValidRepository_ReturnsAllLanguages()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog", "cat"]
                },
                "Spanish": {
                    "Animals": ["perro", "gato"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var languages = repository.Languages;

            // Assert
            Assert.HasCount(2, languages);
            CollectionAssert.Contains(languages.ToList(), "English");
            CollectionAssert.Contains(languages.ToList(), "Spanish");
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void Languages_EmptyLanguages_ReturnsEmptyCollection()
    {
        // Arrange
        var json = """
        {
            "languages": {}
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var languages = repository.Languages;

            // Assert
            Assert.HasCount(0, languages);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetCategories_ValidLanguage_ReturnsAllCategories()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog", "cat"],
                    "Colors": ["red", "blue"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var categories = repository.GetCategories("English");

            // Assert
            Assert.HasCount(2, categories);
            CollectionAssert.Contains(categories.ToList(), "Animals");
            CollectionAssert.Contains(categories.ToList(), "Colors");
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetCategories_InvalidLanguage_ReturnsEmptyCollection()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog", "cat"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var categories = repository.GetCategories("French");

            // Assert
            Assert.HasCount(0, categories);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void Constructor_ValidJson_InitializesSuccessfully()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog", "cat", "bird"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            // Act
            var repository = new WordRepository(tempFile);

            // Assert
            Assert.IsNotNull(repository);
            Assert.HasCount(1, repository.Languages);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void Constructor_FileNotFound_ThrowsFileNotFoundException()
    {
        // Arrange
        var nonExistentPath = "nonexistent_file.json";

        // Act & Assert
        try
        {
            _ = new WordRepository(nonExistentPath);
            Assert.Fail("Expected FileNotFoundException was not thrown.");
        }
        catch (FileNotFoundException)
        {
            // Expected exception
        }
    }

    [TestMethod]
    public void Constructor_InvalidJson_ThrowsJsonException()
    {
        // Arrange
        var tempFile = CreateTempJsonFile("{ invalid json }");

        try
        {
            // Act & Assert
            try
            {
                _ = new WordRepository(tempFile);
                Assert.Fail("Expected JsonException was not thrown.");
            }
            catch (JsonException)
            {
                // Expected exception
            }
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void Constructor_MissingLanguagesProperty_ThrowsKeyNotFoundException()
    {
        // Arrange
        var json = """
        {
            "data": {}
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            // Act & Assert
            try
            {
                _ = new WordRepository(tempFile);
                Assert.Fail("Expected KeyNotFoundException was not thrown.");
            }
            catch (KeyNotFoundException)
            {
                // Expected exception
            }
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_NoParameters_ReturnsRandomWord()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog", "cat"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var result = repository.GetRandomWord();

            // Assert
            Assert.IsNotNull(result.word);
            Assert.IsNotNull(result.category);
            Assert.IsNotNull(result.language);
            Assert.IsTrue(result.word == "DOG" || result.word == "CAT");
            Assert.AreEqual("Animals", result.category);
            Assert.AreEqual("English", result.language);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_SpecificLanguage_ReturnsWordFromLanguage()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog"]
                },
                "Spanish": {
                    "Animals": ["perro"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var result = repository.GetRandomWord("Spanish");

            // Assert
            Assert.AreEqual("PERRO", result.word);
            Assert.AreEqual("Animals", result.category);
            Assert.AreEqual("Spanish", result.language);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_SpecificCategory_ReturnsWordFromCategory()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog"],
                    "Colors": ["red"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var result = repository.GetRandomWord(category: "Colors");

            // Assert
            Assert.AreEqual("RED", result.word);
            Assert.AreEqual("Colors", result.category);
            Assert.AreEqual("English", result.language);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_SpecificLanguageAndCategory_ReturnsSpecificWord()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog"]
                },
                "Spanish": {
                    "Colors": ["rojo"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var result = repository.GetRandomWord("Spanish", "Colors");

            // Assert
            Assert.AreEqual("ROJO", result.word);
            Assert.AreEqual("Colors", result.category);
            Assert.AreEqual("Spanish", result.language);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_InvalidLanguage_ThrowsArgumentException()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act & Assert
            try
            {
                repository.GetRandomWord("French");
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.Contains(ex.Message, "Language 'French' not found.");
            }
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_InvalidCategory_ThrowsArgumentException()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act & Assert
            try
            {
                repository.GetRandomWord("English", "Colors");
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException ex)
            {
                Assert.Contains(ex.Message, "Category 'Colors' not found.");
            }
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_WordIsUppercased_ReturnsUppercaseWord()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["lowercase"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var result = repository.GetRandomWord();

            // Assert
            Assert.AreEqual("LOWERCASE", result.word);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void GetRandomWord_MultipleWords_ReturnsOneOfThem()
    {
        // Arrange
        var json = """
        {
            "languages": {
                "English": {
                    "Animals": ["dog", "cat", "bird"]
                }
            }
        }
        """;
        var tempFile = CreateTempJsonFile(json);

        try
        {
            var repository = new WordRepository(tempFile);

            // Act
            var result = repository.GetRandomWord();

            // Assert
            Assert.IsTrue(result.word == "DOG" || result.word == "CAT" || result.word == "BIRD");
            Assert.AreEqual("Animals", result.category);
            Assert.AreEqual("English", result.language);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }
}
