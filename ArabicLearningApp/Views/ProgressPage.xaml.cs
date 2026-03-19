using ArabicLearningApp.ViewModels;

namespace ArabicLearningApp.Views;

public partial class ProgressPage : ContentPage
{
    private readonly ProgressViewModel _viewModel;

    public ProgressPage(ProgressViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadProgressCommand.Execute(null);
        UpdateUI();
    }

    private void UpdateUI()
    {
        OverallProgressBar.Progress = _viewModel.OverallProgress;
        OverallProgressText.Text = _viewModel.OverallProgressText;
        CompletedCatsLabel.Text = $"{_viewModel.CompletedCategories}/{_viewModel.TotalCategories}";
        AlphabetLabel.Text = _viewModel.AlphabetViewed ? "✅" : "—";
        QuizzesTakenLabel.Text = _viewModel.QuizzesTaken.ToString();
        AvgScoreLabel.Text = _viewModel.AverageScore;
        CategoryProgressView.ItemsSource = _viewModel.CategoryProgress;
        RecentQuizzesView.ItemsSource = _viewModel.RecentQuizzes;
    }

    private async void OnResetClicked(object sender, EventArgs e)
    {
        await _viewModel.ResetProgressCommand.ExecuteAsync(null);
        UpdateUI();
    }
}
