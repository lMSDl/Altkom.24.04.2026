using Hangman;

var repository = new WordRepository();
var engine = new GameEngine(repository);
engine.Run();
