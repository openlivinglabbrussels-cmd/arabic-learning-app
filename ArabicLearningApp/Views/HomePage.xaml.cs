namespace ArabicLearningApp.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnAlphabetTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AlphabetPage");
    }

    private async void OnVocabularyTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//VocabularyPage");
    }

    private async void OnFlashcardsTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//FlashcardPage");
    }

    private async void OnQuizTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//QuizPage");
    }

    private async void OnProgressTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ProgressPage");
    }
}
