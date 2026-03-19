using ArabicLearningApp.Models;
using ArabicLearningApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ArabicLearningApp.ViewModels;

public partial class ProgressViewModel : ObservableObject
{
    private readonly ProgressService _progressService;
    private readonly ArabicDataService _dataService;

    [ObservableProperty]
    private double _overallProgress;

    [ObservableProperty]
    private string _overallProgressText = "0%";

    [ObservableProperty]
    private int _completedCategories;

    [ObservableProperty]
    private int _totalCategories;

    [ObservableProperty]
    private bool _alphabetViewed;

    [ObservableProperty]
    private int _wordsStudied;

    [ObservableProperty]
    private int _quizzesTaken;

    [ObservableProperty]
    private string _averageScore = "0%";

    [ObservableProperty]
    private ObservableCollection<QuizResult> _recentQuizzes = new();

    [ObservableProperty]
    private ObservableCollection<LessonCategory> _categoryProgress = new();

    public ProgressViewModel(ProgressService progressService, ArabicDataService dataService)
    {
        _progressService = progressService;
        _dataService = dataService;
    }

    [RelayCommand]
    public void LoadProgress()
    {
        var categories = _dataService.GetLessonCategories();
        TotalCategories = categories.Count;
        var completedIds = _progressService.GetCompletedCategories();
        CompletedCategories = completedIds.Count;
        AlphabetViewed = _progressService.HasViewedAlphabet();
        WordsStudied = _progressService.GetTotalWordsStudied();

        foreach (var cat in categories)
            cat.IsCompleted = completedIds.Contains(cat.Id);
        CategoryProgress = new ObservableCollection<LessonCategory>(categories);

        var quizResults = _progressService.GetQuizResults();
        QuizzesTaken = quizResults.Count;
        AverageScore = $"{_progressService.GetAverageQuizScore():F0}%";

        var recent = quizResults.OrderByDescending(r => r.Date).Take(5).ToList();
        RecentQuizzes = new ObservableCollection<QuizResult>(recent);

        var progress = _progressService.GetOverallProgress(TotalCategories, 28);
        OverallProgress = progress / 100.0;
        OverallProgressText = $"{progress:F0}%";
    }

    [RelayCommand]
    public async Task ResetProgress()
    {
        bool confirmed = await Shell.Current.DisplayAlert(
            "Reset Progress",
            "Are you sure you want to reset all progress? This cannot be undone.",
            "Reset",
            "Cancel");

        if (confirmed)
        {
            _progressService.ResetProgress();
            LoadProgress();
        }
    }
}
