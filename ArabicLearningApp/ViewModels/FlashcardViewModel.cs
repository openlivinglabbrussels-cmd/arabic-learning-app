using ArabicLearningApp.Models;
using ArabicLearningApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ArabicLearningApp.ViewModels;

public partial class FlashcardViewModel : ObservableObject
{
    private readonly ArabicDataService _dataService;

    [ObservableProperty]
    private ObservableCollection<VocabularyItem> _flashcards = new();

    [ObservableProperty]
    private VocabularyItem? _currentCard;

    [ObservableProperty]
    private int _currentIndex;

    [ObservableProperty]
    private bool _isShowingFront = true;

    [ObservableProperty]
    private string _selectedCategory = "All";

    [ObservableProperty]
    private ObservableCollection<string> _availableCategories = new();

    [ObservableProperty]
    private string _progressText = "1 / 1";

    public FlashcardViewModel(ArabicDataService dataService)
    {
        _dataService = dataService;
    }

    [RelayCommand]
    public void LoadFlashcards()
    {
        var categories = new List<string> { "All" };
        categories.AddRange(_dataService.GetCategories());
        AvailableCategories = new ObservableCollection<string>(categories);

        LoadCardsForCategory(SelectedCategory);
    }

    private void LoadCardsForCategory(string category)
    {
        var items = category == "All"
            ? _dataService.GetAllVocabulary()
            : _dataService.GetVocabularyByCategory(category);

        var shuffled = items.OrderBy(_ => Guid.NewGuid()).ToList();
        Flashcards = new ObservableCollection<VocabularyItem>(shuffled);
        CurrentIndex = 0;
        IsShowingFront = true;
        UpdateCurrentCard();
    }

    [RelayCommand]
    public void ChangeCategory(string category)
    {
        SelectedCategory = category;
        LoadCardsForCategory(category);
    }

    [RelayCommand]
    public void FlipCard()
    {
        IsShowingFront = !IsShowingFront;
    }

    [RelayCommand]
    public void NextCard()
    {
        if (Flashcards.Count == 0) return;
        CurrentIndex = (CurrentIndex + 1) % Flashcards.Count;
        IsShowingFront = true;
        UpdateCurrentCard();
    }

    [RelayCommand]
    public void PreviousCard()
    {
        if (Flashcards.Count == 0) return;
        CurrentIndex = (CurrentIndex - 1 + Flashcards.Count) % Flashcards.Count;
        IsShowingFront = true;
        UpdateCurrentCard();
    }

    private void UpdateCurrentCard()
    {
        CurrentCard = Flashcards.Count > 0 ? Flashcards[CurrentIndex] : null;
        ProgressText = Flashcards.Count > 0 ? $"{CurrentIndex + 1} / {Flashcards.Count}" : "0 / 0";
    }

    [RelayCommand]
    public void Shuffle()
    {
        LoadCardsForCategory(SelectedCategory);
    }
}
