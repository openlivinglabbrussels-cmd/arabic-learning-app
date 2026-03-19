using ArabicLearningApp.Models;
using System.Text.Json;

namespace ArabicLearningApp.Services;

public class ProgressService
{
    private const string CompletedCategoriesKey = "completed_categories";
    private const string QuizResultsKey = "quiz_results";
    private const string AlphabetViewedKey = "alphabet_viewed";
    private const string TotalWordsStudiedKey = "total_words_studied";

    public void MarkCategoryCompleted(string categoryId)
    {
        var completed = GetCompletedCategories();
        if (!completed.Contains(categoryId))
        {
            completed.Add(categoryId);
            Preferences.Set(CompletedCategoriesKey, string.Join(",", completed));
        }
    }

    public List<string> GetCompletedCategories()
    {
        var stored = Preferences.Get(CompletedCategoriesKey, string.Empty);
        if (string.IsNullOrEmpty(stored))
            return new List<string>();
        return stored.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public bool IsCategoryCompleted(string categoryId)
    {
        return GetCompletedCategories().Contains(categoryId);
    }

    public void SaveQuizResult(QuizResult result)
    {
        var results = GetQuizResults();
        results.Add(result);
        // Keep only last 50 results
        if (results.Count > 50)
            results = results.Skip(results.Count - 50).ToList();
        var json = JsonSerializer.Serialize(results);
        Preferences.Set(QuizResultsKey, json);
    }

    public List<QuizResult> GetQuizResults()
    {
        var json = Preferences.Get(QuizResultsKey, string.Empty);
        if (string.IsNullOrEmpty(json))
            return new List<QuizResult>();
        try
        {
            return JsonSerializer.Deserialize<List<QuizResult>>(json) ?? new List<QuizResult>();
        }
        catch
        {
            return new List<QuizResult>();
        }
    }

    public void MarkAlphabetViewed()
    {
        Preferences.Set(AlphabetViewedKey, true);
    }

    public bool HasViewedAlphabet()
    {
        return Preferences.Get(AlphabetViewedKey, false);
    }

    public void IncrementWordsStudied(int count = 1)
    {
        var current = Preferences.Get(TotalWordsStudiedKey, 0);
        Preferences.Set(TotalWordsStudiedKey, current + count);
    }

    public int GetTotalWordsStudied()
    {
        return Preferences.Get(TotalWordsStudiedKey, 0);
    }

    public double GetOverallProgress(int totalCategories, int totalLetters)
    {
        var completedCategories = GetCompletedCategories().Count;
        var alphabetDone = HasViewedAlphabet() ? 1 : 0;
        var quizzesTaken = GetQuizResults().Count;

        // Weight: categories 50%, alphabet 20%, quizzes 30%
        double categoryProgress = totalCategories > 0 ? (double)completedCategories / totalCategories * 0.5 : 0;
        double alphabetProgress = alphabetDone * 0.2;
        double quizProgress = Math.Min(quizzesTaken / 10.0, 1.0) * 0.3;

        return (categoryProgress + alphabetProgress + quizProgress) * 100;
    }

    public double GetAverageQuizScore()
    {
        var results = GetQuizResults();
        if (results.Count == 0) return 0;
        return results.Average(r => r.Percentage);
    }

    public void ResetProgress()
    {
        Preferences.Remove(CompletedCategoriesKey);
        Preferences.Remove(QuizResultsKey);
        Preferences.Remove(AlphabetViewedKey);
        Preferences.Remove(TotalWordsStudiedKey);
    }
}
