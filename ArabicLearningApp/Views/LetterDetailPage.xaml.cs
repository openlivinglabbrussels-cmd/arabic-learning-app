using ArabicLearningApp.Services;

namespace ArabicLearningApp.Views;

[QueryProperty(nameof(LetterId), "letterId")]
public partial class LetterDetailPage : ContentPage
{
    private readonly ArabicDataService _dataService;
    private int _letterId;

    public int LetterId
    {
        get => _letterId;
        set
        {
            _letterId = value;
            LoadLetter(value);
        }
    }

    public LetterDetailPage(ArabicDataService dataService)
    {
        InitializeComponent();
        _dataService = dataService;
    }

    private void LoadLetter(int id)
    {
        var letter = _dataService.GetLetterById(id);
        if (letter == null) return;

        BigLetterLabel.Text = letter.Letter;
        LetterNameLabel.Text = $"{letter.Name} — {letter.NameArabic}";
        ArabicNameLabel.Text = letter.NameArabic;
        TransliterationLabel.Text = letter.Transliteration;
        IsolatedLabel.Text = letter.IsolatedForm;
        InitialLabel.Text = letter.InitialForm;
        MedialLabel.Text = letter.MedialForm;
        FinalLabel.Text = letter.FinalForm;
        PronunciationLabel.Text = letter.Pronunciation;
        ExampleWordLabel.Text = letter.ExampleWord;
        ExampleTranslationLabel.Text = letter.ExampleTranslation;
        Title = $"{letter.Name} ({letter.Letter})";
    }
}
