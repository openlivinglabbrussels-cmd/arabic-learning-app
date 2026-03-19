namespace ArabicLearningApp.Models;

public class ArabicLetter
{
    public int Id { get; set; }
    public string Letter { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string NameArabic { get; set; } = string.Empty;
    public string Transliteration { get; set; } = string.Empty;
    public string IsolatedForm { get; set; } = string.Empty;
    public string InitialForm { get; set; } = string.Empty;
    public string MedialForm { get; set; } = string.Empty;
    public string FinalForm { get; set; } = string.Empty;
    public string Pronunciation { get; set; } = string.Empty;
    public string ExampleWord { get; set; } = string.Empty;
    public string ExampleTranslation { get; set; } = string.Empty;
}
