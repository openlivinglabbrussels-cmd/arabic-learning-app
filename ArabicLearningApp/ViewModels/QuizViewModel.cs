using ArabicLearningApp.Models;
using ArabicLearningApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ArabicLearningApp.ViewModels;

public enum QuizState
{
    CategorySelection,
    InProgress,
    Completed
}

public partial class QuizViewModel : ObservableObject
{
    private readonly ArabicDataService _dataService;
    private readonly ProgressService _progressService;

    [ObservableProperty]
    private QuizState _quizState = QuizState.CategorySelection;

    [ObservableProperty]
    private ObservableCollection<string> _categories = new();

    [ObservableProperty]
    private string _selectedCategory = "All";

    [ObservableProperty]
    private QuizQuestion? _currentQuestion;

    [ObservableProperty]
    private int _currentQuestionIndex;

    [ObservableProperty]
    private int _totalQuestions;

    [ObservableProperty]
    private int _score;

    [ObservableProperty]
    private string? _selectedAnswer;

    [ObservableProperty]
    private bool _hasAnswered;

    [ObservableProperty]
    private bool _isCorrect;

    [ObservableProperty]
    private string _questionProgressText = "1 / 10";

    [ObservableProperty]
    private string _scoreText = "0";

    [ObservableProperty]
    private string _resultMessage = string.Empty;

    [ObservableProperty]
    private double _finalScorePercentage;

    [ObservableProperty]
    private ObservableCollection<QuizResult> _quizHistory = new();

    private List<QuizQuestion> _questions = new();

    public QuizViewModel(ArabicDataService dataService, ProgressService progressService)
    {
        _dataService = dataService;
        _progressService = progressService;
    }

    [RelayCommand]
    public void LoadCategories()
    {
        var cats = new List<string> { "All" };
        cats.AddRange(_dataService.GetCategories());
        Categories = new ObservableCollection<string>(cats);
        LoadQuizHistory();
        QuizState = QuizState.CategorySelection;
    }

    private void LoadQuizHistory()
    {
        var history = _progressService.GetQuizResults()
            .OrderByDescending(r => r.Date)
            .Take(10)
            .ToList();
        QuizHistory = new ObservableCollection<QuizResult>(history);
    }

    [RelayCommand]
    public void StartQuiz()
    {
        _questions = _dataService.GenerateQuizQuestions(SelectedCategory, 10);
        CurrentQuestionIndex = 0;
        Score = 0;
        ScoreText = "0";
        TotalQuestions = _questions.Count;
        HasAnswered = false;
        SelectedAnswer = null;
        QuizState = QuizState.InProgress;
        ShowCurrentQuestion();
    }

    private void ShowCurrentQuestion()
    {
        if (CurrentQuestionIndex < _questions.Count)
        {
            CurrentQuestion = _questions[CurrentQuestionIndex];
            QuestionProgressText = $"{CurrentQuestionIndex + 1} / {TotalQuestions}";
            HasAnswered = false;
            SelectedAnswer = null;
        }
    }

    [RelayCommand]
    public void AnswerQuestion(string answer)
    {
        if (HasAnswered || CurrentQuestion == null) return;

        SelectedAnswer = answer;
        HasAnswered = true;
        IsCorrect = answer == CurrentQuestion.CorrectAnswer;

        if (IsCorrect)
        {
            Score++;
            ScoreText = Score.ToString();
        }
    }

    [RelayCommand]
    public void NextQuestion()
    {
        if (!HasAnswered) return;

        CurrentQuestionIndex++;
        if (CurrentQuestionIndex < _questions.Count)
        {
            ShowCurrentQuestion();
        }
        else
        {
            FinishQuiz();
        }
    }

    private void FinishQuiz()
    {
        FinalScorePercentage = TotalQuestions > 0 ? (double)Score / TotalQuestions * 100 : 0;

        if (FinalScorePercentage >= 80)
            ResultMessage = "Excellent! مُمتَاز 🌟";
        else if (FinalScorePercentage >= 60)
            ResultMessage = "Good job! جَيِّد 👍";
        else if (FinalScorePercentage >= 40)
            ResultMessage = "Keep practicing! استَمِرّ في التَّدرُّب 💪";
        else
            ResultMessage = "Don't give up! لَا تَستَسلِم ✨";

        var result = new QuizResult
        {
            Date = DateTime.Now,
            Score = Score,
            TotalQuestions = TotalQuestions,
            Category = SelectedCategory
        };
        _progressService.SaveQuizResult(result);
        LoadQuizHistory();
        QuizState = QuizState.Completed;
    }

    [RelayCommand]
    public void RestartQuiz()
    {
        StartQuiz();
    }

    [RelayCommand]
    public void BackToCategories()
    {
        QuizState = QuizState.CategorySelection;
    }
}
