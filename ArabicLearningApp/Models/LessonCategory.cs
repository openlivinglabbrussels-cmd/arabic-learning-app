namespace ArabicLearningApp.Models;

public class LessonCategory
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ArabicName { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int TotalItems { get; set; }
    public bool IsCompleted { get; set; }
}
