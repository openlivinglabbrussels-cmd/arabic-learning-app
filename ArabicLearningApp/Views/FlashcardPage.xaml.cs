using ArabicLearningApp.ViewModels;

namespace ArabicLearningApp.Views;

public partial class FlashcardPage : ContentPage
{
    private readonly FlashcardViewModel _viewModel;
    private bool _isShowingFront = true;

    public FlashcardPage(FlashcardViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadFlashcardsCommand.Execute(null);

        // Populate category picker
        CategoryPicker.ItemsSource = _viewModel.AvailableCategories.ToList();
        CategoryPicker.SelectedIndex = 0;

        UpdateCardDisplay();
    }

    private void UpdateCardDisplay()
    {
        var card = _viewModel.CurrentCard;
        if (card == null) return;

        ArabicWordLabel.Text = card.ArabicWord;
        CardCategoryLabel.Text = card.Category;
        EnglishWordLabel.Text = card.EnglishTranslation;
        TransliterationWordLabel.Text = card.Transliteration;
        BackArabicLabel.Text = card.ArabicWord;
        ProgressLabel.Text = _viewModel.ProgressText;

        // Always start with front
        _isShowingFront = true;
        ShowFront();
    }

    private void ShowFront()
    {
        FrontPanel.IsVisible = true;
        BackPanel.IsVisible = false;
        FlashcardFrame.BackgroundColor = Colors.White;
    }

    private void ShowBack()
    {
        FrontPanel.IsVisible = false;
        BackPanel.IsVisible = true;
        FlashcardFrame.BackgroundColor = Color.FromArgb("#E8F4FD");
    }

    private void OnCardTapped(object sender, EventArgs e)
    {
        _isShowingFront = !_isShowingFront;
        if (_isShowingFront)
            ShowFront();
        else
            ShowBack();
    }

    private void OnFlipClicked(object sender, EventArgs e)
    {
        OnCardTapped(sender, e);
    }

    private void OnNextClicked(object sender, EventArgs e)
    {
        _viewModel.NextCardCommand.Execute(null);
        UpdateCardDisplay();
    }

    private void OnPreviousClicked(object sender, EventArgs e)
    {
        _viewModel.PreviousCardCommand.Execute(null);
        UpdateCardDisplay();
    }

    private void OnShuffleClicked(object sender, EventArgs e)
    {
        _viewModel.ShuffleCommand.Execute(null);
        UpdateCardDisplay();
    }

    private void OnCategoryChanged(object sender, EventArgs e)
    {
        if (CategoryPicker.SelectedItem is string category)
        {
            _viewModel.ChangeCategoryCommand.Execute(category);
            UpdateCardDisplay();
        }
    }
}
