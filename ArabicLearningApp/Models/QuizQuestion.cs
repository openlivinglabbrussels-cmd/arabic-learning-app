namespace ArabicLearningApp.Models;

public enum QuizQuestionType
{
    ArabicToEnglish,
    EnglishToArabic,
    LetterName
}

public class QuizQuestion
{
    public int Id { get; set; }
    public QuizQuestionType QuestionType { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string CorrectAnswer { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();
    public string Hint { get; set; } = string.Empty;
}
