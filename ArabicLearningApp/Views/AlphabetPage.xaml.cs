using ArabicLearningApp.Models;
using ArabicLearningApp.ViewModels;

namespace ArabicLearningApp.Views;

public partial class AlphabetPage : ContentPage
{
    private readonly AlphabetViewModel _viewModel;

    public AlphabetPage(AlphabetViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadLettersCommand.Execute(null);
        LettersCollection.ItemsSource = _viewModel.Letters;
    }

    private async void OnLetterTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is ArabicLetter letter)
        {
            await _viewModel.SelectLetterCommand.ExecuteAsync(letter);
        }
    }
}
