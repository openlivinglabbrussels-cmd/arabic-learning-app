namespace ArabicLearningApp.Models;

public class QuizResult
{
    public DateTime Date { get; set; }
    public int Score { get; set; }
    public int TotalQuestions { get; set; }
    public string Category { get; set; } = string.Empty;

    public double Percentage => TotalQuestions > 0 ? (double)Score / TotalQuestions * 100 : 0;
    public string DisplayScore => $"{Score}/{TotalQuestions}";
    public string DisplayPercentage => $"{Percentage:F0}%";
}
