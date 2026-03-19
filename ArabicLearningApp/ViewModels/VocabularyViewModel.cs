using ArabicLearningApp.Models;
using ArabicLearningApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace ArabicLearningApp.ViewModels;

public partial class VocabularyViewModel : ObservableObject
{
    private readonly ArabicDataService _dataService;
    private readonly ProgressService _progressService;

    [ObservableProperty]
    private ObservableCollection<LessonCategory> _categories = new();

    [ObservableProperty]
    private ObservableCollection<VocabularyItem> _vocabularyItems = new();

    [ObservableProperty]
    private LessonCategory? _selectedCategory;

    [ObservableProperty]
    private string _currentCategoryTitle = "All Vocabulary";

    [ObservableProperty]
    private bool _isShowingCategories = true;

    public VocabularyViewModel(ArabicDataService dataService, ProgressService progressService)
    {
        _dataService = dataService;
        _progressService = progressService;
    }

    [RelayCommand]
    public void LoadCategories()
    {
        var cats = _dataService.GetLessonCategories();
        var completedIds = _progressService.GetCompletedCategories();
        foreach (var cat in cats)
            cat.IsCompleted = completedIds.Contains(cat.Id);
        Categories = new ObservableCollection<LessonCategory>(cats);
        IsShowingCategories = true;
    }

    [RelayCommand]
    public void SelectCategory(LessonCategory category)
    {
        if (category == null) return;
        SelectedCategory = category;
        CurrentCategoryTitle = category.Name;
        var items = _dataService.GetVocabularyByCategory(category.Id);
        VocabularyItems = new ObservableCollection<VocabularyItem>(items);
        _progressService.IncrementWordsStudied(items.Count);
        IsShowingCategories = false;
    }

    [RelayCommand]
    public void MarkCategoryDone()
    {
        if (SelectedCategory == null) return;
        _progressService.MarkCategoryCompleted(SelectedCategory.Id);
        SelectedCategory.IsCompleted = true;
        // Reload categories to reflect update
        LoadCategories();
        IsShowingCategories = true;
    }

    [RelayCommand]
    public void BackToCategories()
    {
        IsShowingCategories = true;
    }
}
