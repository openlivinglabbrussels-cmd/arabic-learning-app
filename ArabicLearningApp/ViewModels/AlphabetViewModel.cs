using ArabicLearningApp.Models;
using ArabicLearningApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ArabicLearningApp.ViewModels;

public partial class AlphabetViewModel : ObservableObject
{
    private readonly ArabicDataService _dataService;
    private readonly ProgressService _progressService;

    [ObservableProperty]
    private ObservableCollection<ArabicLetter> _letters = new();

    [ObservableProperty]
    private ArabicLetter? _selectedLetter;

    [ObservableProperty]
    private bool _isLoading;

    public AlphabetViewModel(ArabicDataService dataService, ProgressService progressService)
    {
        _dataService = dataService;
        _progressService = progressService;
    }

    [RelayCommand]
    public void LoadLetters()
    {
        IsLoading = true;
        var letterList = _dataService.GetAllLetters();
        Letters = new ObservableCollection<ArabicLetter>(letterList);
        _progressService.MarkAlphabetViewed();
        IsLoading = false;
    }

    [RelayCommand]
    public async Task SelectLetter(ArabicLetter letter)
    {
        if (letter == null) return;
        SelectedLetter = letter;
        await Shell.Current.GoToAsync($"LetterDetailPage?letterId={letter.Id}");
    }
}
