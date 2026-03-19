using ArabicLearningApp.Models;
using ArabicLearningApp.ViewModels;

namespace ArabicLearningApp.Views;

public partial class VocabularyPage : ContentPage
{
    private readonly VocabularyViewModel _viewModel;

    public VocabularyPage(VocabularyViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.LoadCategoriesCommand.Execute(null);
        CategoriesView.ItemsSource = _viewModel.Categories;
    }

    private void OnCategoryTapped(object sender, EventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is LessonCategory category)
        {
            _viewModel.SelectCategoryCommand.Execute(category);
            VocabItemsView.ItemsSource = _viewModel.VocabularyItems;
            PageSubtitle.Text = category.Name;
            CategoriesView.IsVisible = false;
            VocabView.IsVisible = true;
        }
    }

    private void OnBackToCategoriesClicked(object sender, EventArgs e)
    {
        _viewModel.BackToCategoriesCommand.Execute(null);
        CategoriesView.ItemsSource = _viewModel.Categories;
        PageSubtitle.Text = "Choose a category to study";
        CategoriesView.IsVisible = true;
        VocabView.IsVisible = false;
    }

    private void OnMarkDoneClicked(object sender, EventArgs e)
    {
        _viewModel.MarkCategoryDoneCommand.Execute(null);
        CategoriesView.ItemsSource = _viewModel.Categories;
        PageSubtitle.Text = "Choose a category to study";
        CategoriesView.IsVisible = true;
        VocabView.IsVisible = false;
    }
}
