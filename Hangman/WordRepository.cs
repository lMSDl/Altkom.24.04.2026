using System.Text.Json;

namespace Hangman;

public class WordRepository
{
    private readonly Dictionary<string, Dictionary<string, List<string>>> _languages;
    private readonly Random _random = new();

    public IReadOnlyCollection<string> Languages => _languages.Keys.ToList();

    public IReadOnlyCollection<string> GetCategories(string language) =>
        _languages.TryGetValue(language, out var cats) ? cats.Keys.ToList() : [];

    public WordRepository(string configPath = "words.json")
    {
        var json = File.ReadAllText(configPath);
        var doc = JsonDocument.Parse(json);

        _languages = doc.RootElement
            .GetProperty("languages")
            .EnumerateObject()
            .ToDictionary(
                lang => lang.Name,
                lang => lang.Value.EnumerateObject().ToDictionary(
                    cat => cat.Name,
                    cat => cat.Value.EnumerateArray()
                                   .Select(e => e.GetString()!)
                                   .ToList()
                )
            );
    }

    public (string word, string category, string language) GetRandomWord(
        string? language = null, string? category = null)
    {
        var lang = language ?? _languages.Keys.ElementAt(_random.Next(_languages.Count));

        if (!_languages.TryGetValue(lang, out var categories))
            throw new ArgumentException($"Language '{language}' not found.");

        var cat = category ?? categories.Keys.ElementAt(_random.Next(categories.Count));

        if (!categories.TryGetValue(cat, out var words))
            throw new ArgumentException($"Category '{category}' not found.");

        return (words[_random.Next(words.Count)].ToUpper(), cat, lang);
    }
}
