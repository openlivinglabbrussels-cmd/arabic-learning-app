namespace ArabicLearningApp.Models;

public class VocabularyItem
{
    public int Id { get; set; }
    public string ArabicWord { get; set; } = string.Empty;
    public string EnglishTranslation { get; set; } = string.Empty;
    public string Transliteration { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ExampleSentence { get; set; } = string.Empty;
    public string ExampleSentenceTranslation { get; set; } = string.Empty;
}
