using ArabicLearningApp.Views;

namespace ArabicLearningApp;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute("LetterDetailPage", typeof(LetterDetailPage));
    }
}
