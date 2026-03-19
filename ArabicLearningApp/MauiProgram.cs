using ArabicLearningApp.Services;
using ArabicLearningApp.ViewModels;
using ArabicLearningApp.Views;
using Microsoft.Extensions.Logging;

namespace ArabicLearningApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register Services
        builder.Services.AddSingleton<ArabicDataService>();
        builder.Services.AddSingleton<ProgressService>();

        // Register ViewModels
        builder.Services.AddTransient<AlphabetViewModel>();
        builder.Services.AddTransient<VocabularyViewModel>();
        builder.Services.AddTransient<FlashcardViewModel>();
        builder.Services.AddTransient<QuizViewModel>();
        builder.Services.AddTransient<ProgressViewModel>();

        // Register Views
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<AlphabetPage>();
        builder.Services.AddTransient<LetterDetailPage>();
        builder.Services.AddTransient<VocabularyPage>();
        builder.Services.AddTransient<FlashcardPage>();
        builder.Services.AddTransient<QuizPage>();
        builder.Services.AddTransient<ProgressPage>();

        // Register Shell
        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<App>();

        return builder.Build();
    }
}
