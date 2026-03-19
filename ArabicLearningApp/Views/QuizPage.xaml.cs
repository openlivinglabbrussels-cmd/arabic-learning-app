using ArabicLearningApp.Models;
using ArabicLearningApp.ViewModels;

namespace ArabicLearningApp.Views;

public partial class QuizPage : ContentPage
{
    private readonly QuizViewModel _viewModel;

    public QuizPage(QuizViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadCategoriesCommand.Execute(null);
        QuizCategoryPicker.ItemsSource = _viewModel.Categories.ToList();
        QuizCategoryPicker.SelectedIndex = 0;
        QuizHistoryView.ItemsSource = _viewModel.QuizHistory;
        ShowState(QuizState.CategorySelection);
    }

    private void ShowState(QuizState state)
    {
        CategorySelectionView.IsVisible = state == QuizState.CategorySelection;
        InProgressView.IsVisible = state == QuizState.InProgress;
        CompletedView.IsVisible = state == QuizState.Completed;
    }

    private void OnStartQuizClicked(object sender, EventArgs e)
    {
        if (QuizCategoryPicker.SelectedItem is string category)
            _viewModel.SelectedCategory = category;
        _viewModel.StartQuizCommand.Execute(null);
        ShowState(QuizState.InProgress);
        DisplayCurrentQuestion();
    }

    private void DisplayCurrentQuestion()
    {
        var question = _viewModel.CurrentQuestion;
        if (question == null) return;

        // Update progress
        double progress = _viewModel.TotalQuestions > 0
            ? (double)_viewModel.CurrentQuestionIndex / _viewModel.TotalQuestions
            : 0;
        QuizProgressBar.Progress = progress;
        QuestionProgressLabel.Text = _viewModel.QuestionProgressText;
        ScoreLabel.Text = $"Score: {_viewModel.ScoreText}";

        // Update question text
        QuestionTypeLabel.Text = question.QuestionType switch
        {
            QuizQuestionType.ArabicToEnglish => "What does this Arabic word mean?",
            QuizQuestionType.EnglishToArabic => "How do you say this in Arabic?",
            QuizQuestionType.LetterName => "What is the name of this letter?",
            _ => "Answer the question:"
        };

        bool isArabicQuestion = question.QuestionType is QuizQuestionType.ArabicToEnglish or QuizQuestionType.LetterName;
        QuestionTextLabel.FontSize = isArabicQuestion ? 44 : 24;
        QuestionTextLabel.FlowDirection = isArabicQuestion ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        QuestionTextLabel.Text = question.QuestionText;

        // Clear previous options
        AnswerOptionsLayout.Children.Clear();

        // Get the outline button style from app resources
        Application.Current?.Resources.TryGetValue("OutlineButton", out var outlineStyleObj);
        var outlineStyle = outlineStyleObj as Style;

        // Build answer buttons
        foreach (var option in question.Options)
        {
            var btn = new Button
            {
                Text = option,
                HorizontalOptions = LayoutOptions.Fill,
                CommandParameter = option,
                CornerRadius = 12,
                Padding = new Thickness(20, 12),
                MinimumHeightRequest = 50,
                BackgroundColor = Colors.Transparent,
                TextColor = Color.FromArgb("#1565C0"),
                BorderColor = Color.FromArgb("#1565C0"),
                BorderWidth = 2,
                FontSize = 16,
            };
            if (outlineStyle != null)
                btn.Style = outlineStyle;

            // For Arabic answers, use RTL
            if (question.QuestionType == QuizQuestionType.EnglishToArabic)
            {
                btn.FlowDirection = FlowDirection.RightToLeft;
                btn.FontSize = 20;
            }

            btn.Clicked += OnAnswerButtonClicked;
            AnswerOptionsLayout.Children.Add(btn);
        }

        // Hide feedback and next button
        FeedbackFrame.IsVisible = false;
        NextButton.IsVisible = false;
        QuizHeaderLabel.Text = $"Question {_viewModel.CurrentQuestionIndex + 1} of {_viewModel.TotalQuestions}";
    }

    private void OnAnswerButtonClicked(object sender, EventArgs e)
    {
        if (_viewModel.HasAnswered) return;
        if (sender is not Button btn) return;

        var answer = btn.CommandParameter as string ?? btn.Text;
        _viewModel.AnswerQuestionCommand.Execute(answer);

        // Visual feedback on buttons
        foreach (var child in AnswerOptionsLayout.Children)
        {
            if (child is Button b)
            {
                var bAnswer = b.CommandParameter as string ?? b.Text;
                if (bAnswer == _viewModel.CurrentQuestion?.CorrectAnswer)
                {
                    b.BackgroundColor = Color.FromArgb("#2E7D32");
                    b.TextColor = Colors.White;
                    b.BorderColor = Color.FromArgb("#2E7D32");
                }
                else if (bAnswer == answer && !_viewModel.IsCorrect)
                {
                    b.BackgroundColor = Color.FromArgb("#C62828");
                    b.TextColor = Colors.White;
                    b.BorderColor = Color.FromArgb("#C62828");
                }
                b.IsEnabled = false;
            }
        }

        // Show feedback
        FeedbackFrame.IsVisible = true;
        FeedbackFrame.BackgroundColor = _viewModel.IsCorrect
            ? Color.FromArgb("#E8F5E9")
            : Color.FromArgb("#FFEBEE");
        FeedbackIcon.Text = _viewModel.IsCorrect ? "✅" : "❌";
        FeedbackLabel.Text = _viewModel.IsCorrect ? "Correct! أَحسَنتَ!" : "Incorrect";
        FeedbackLabel.TextColor = _viewModel.IsCorrect
            ? Color.FromArgb("#2E7D32")
            : Color.FromArgb("#C62828");

        if (!_viewModel.IsCorrect)
            CorrectAnswerLabel.Text = $"Correct answer: {_viewModel.CurrentQuestion?.CorrectAnswer}";
        else
            CorrectAnswerLabel.Text = $"Hint: {_viewModel.CurrentQuestion?.Hint}";

        NextButton.IsVisible = true;
    }

    private void OnNextQuestionClicked(object sender, EventArgs e)
    {
        _viewModel.NextQuestionCommand.Execute(null);

        if (_viewModel.QuizState == QuizState.Completed)
        {
            ShowCompletedView();
        }
        else
        {
            DisplayCurrentQuestion();
        }
    }

    private void ShowCompletedView()
    {
        ShowState(QuizState.Completed);
        FinalScoreLabel.Text = $"{_viewModel.Score}/{_viewModel.TotalQuestions}";
        FinalPercentageLabel.Text = $"{_viewModel.FinalScorePercentage:F0}%";
        ResultMessageLabel.Text = _viewModel.ResultMessage;

        ResultIconLabel.Text = _viewModel.FinalScorePercentage >= 80 ? "🌟" :
                               _viewModel.FinalScorePercentage >= 60 ? "👍" :
                               _viewModel.FinalScorePercentage >= 40 ? "💪" : "✨";
        QuizHeaderLabel.Text = "Quiz Complete!";
    }

    private void OnRestartClicked(object sender, EventArgs e)
    {
        _viewModel.RestartQuizCommand.Execute(null);
        ShowState(QuizState.InProgress);
        DisplayCurrentQuestion();
    }

    private void OnBackToCategoriesClicked(object sender, EventArgs e)
    {
        _viewModel.BackToCategoriesCommand.Execute(null);
        QuizHistoryView.ItemsSource = _viewModel.QuizHistory;
        ShowState(QuizState.CategorySelection);
        QuizHeaderLabel.Text = "Test your Arabic knowledge";
    }
}
