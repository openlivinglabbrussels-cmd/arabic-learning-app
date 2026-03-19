# تعلم العربية — Learn Arabic

A full-featured **.NET MAUI** mobile application for learning the Arabic language. Available for **Android** and **iOS**, built with C# in Visual Studio 2022.

---

## 📱 Features

### 🔤 Arabic Alphabet
- All **28 Arabic letters** displayed in a scrollable grid
- Each letter shows: Arabic character, letter name, transliteration, and isolated/initial/medial/final forms
- Tap any letter to open a **detail view** with pronunciation guide and example words

### 📖 Vocabulary Lessons
Organized into **7 categories**, each with 10–15 words:
- 🤝 **Greetings & Common Phrases** — Hello, Thank you, How are you?, etc.
- 🔢 **Numbers** — 1–20 and beyond
- 🎨 **Colors** — All primary and common colors
- 🍽️ **Food & Drinks** — Common foods, beverages
- 👨‍👩‍👧‍👦 **Family Members** — Father, mother, siblings, etc.
- 📅 **Days of the Week** — All 7 days plus time expressions
- ⚡ **Common Verbs** — Essential action words

Each word shows: Arabic (RTL, large font), English translation, and transliteration.

### 🃏 Flashcards
- Tappable flip cards — **Arabic on front**, English + transliteration on back
- Navigate with **Next / Previous** buttons
- **Shuffle** deck at any time
- Filter by **vocabulary category**

### 📝 Quiz
- **10 random questions** per session
- Three question types:
  - Arabic → English (What does this mean?)
  - English → Arabic (How do you say this?)
  - Letter identification (What is this letter?)
- **Green/red visual feedback** on correct/incorrect answers
- **Score displayed** at the end with motivational message
- **Quiz history** tracked and displayed

### 📈 Progress Tracking
- Overall progress percentage
- Per-category completion tracking
- Quiz history with scores and dates
- **Persistent** — stored using `Preferences` API (local device storage)
- Reset progress option

### 🏠 Home Screen
- Welcome screen with **Arabic and English title**
- Quick navigation cards to all sections
- Learning tip displayed on screen

---

## 🛠️ Prerequisites

- **Visual Studio 2022** (version 17.8 or later)
- **.NET 9 SDK**
- **.NET MAUI workload** — Install via Visual Studio Installer or:
  ```
  dotnet workload install maui
  ```
- For **Android**: Android SDK (API level 21+), installed via Visual Studio
- For **iOS**: macOS with Xcode 15+ (or a connected Mac for building from Windows)

---

## 🚀 How to Build and Run

### Option 1 — Visual Studio 2022

1. **Clone or download** this repository
2. Open `ArabicLearningApp.sln` in Visual Studio 2022
3. Select your target device/emulator from the debug toolbar:
   - **Android**: Choose an Android emulator or connected device
   - **iOS**: Choose an iOS simulator or connected device
4. Press **F5** or click **Run** to build and deploy

### Option 2 — Command Line (dotnet CLI)

```bash
# Android
dotnet build -f net9.0-android
dotnet run -f net9.0-android

# iOS (requires macOS with Xcode)
dotnet build -f net9.0-ios
dotnet run -f net9.0-ios
```

### Restoring Dependencies

```bash
dotnet restore ArabicLearningApp/ArabicLearningApp.csproj
```

---

## 📁 Project Structure

```
ArabicLearningApp/
├── ArabicLearningApp.sln               # Visual Studio solution
├── ArabicLearningApp/
│   ├── ArabicLearningApp.csproj        # MAUI project file
│   ├── App.xaml / App.xaml.cs          # Application entry point & resources
│   ├── AppShell.xaml / AppShell.xaml.cs # Shell navigation with TabBar
│   ├── MauiProgram.cs                  # DI registration & app configuration
│   │
│   ├── Models/
│   │   ├── ArabicLetter.cs             # Letter data model
│   │   ├── VocabularyItem.cs           # Vocabulary word model
│   │   ├── QuizQuestion.cs             # Quiz question model
│   │   ├── LessonCategory.cs           # Lesson category model
│   │   └── QuizResult.cs               # Quiz result/score model
│   │
│   ├── ViewModels/
│   │   ├── AlphabetViewModel.cs        # Alphabet page logic
│   │   ├── VocabularyViewModel.cs      # Vocabulary browsing logic
│   │   ├── FlashcardViewModel.cs       # Flashcard navigation logic
│   │   ├── QuizViewModel.cs            # Quiz state machine & scoring
│   │   └── ProgressViewModel.cs        # Progress tracking & stats
│   │
│   ├── Views/
│   │   ├── HomePage.xaml/.cs           # Home/welcome screen
│   │   ├── AlphabetPage.xaml/.cs       # 28-letter alphabet grid
│   │   ├── LetterDetailPage.xaml/.cs   # Letter detail view
│   │   ├── VocabularyPage.xaml/.cs     # Category list + word list
│   │   ├── FlashcardPage.xaml/.cs      # Flashcard flip interface
│   │   ├── QuizPage.xaml/.cs           # Multiple choice quiz
│   │   └── ProgressPage.xaml/.cs       # Progress dashboard
│   │
│   ├── Services/
│   │   ├── ArabicDataService.cs        # All Arabic language data (hardcoded)
│   │   └── ProgressService.cs          # Progress persistence via Preferences
│   │
│   ├── Resources/
│   │   ├── Styles/
│   │   │   ├── Colors.xaml             # App color palette
│   │   │   └── Styles.xaml             # Reusable XAML styles
│   │   ├── AppIcon/                    # App icon SVG files
│   │   ├── Splash/                     # Splash screen SVG
│   │   └── Images/                     # Image assets
│   │
│   └── Platforms/
│       ├── Android/                    # Android-specific files
│       └── iOS/                        # iOS-specific files
│
└── README.md
```

---

## 🎨 Design

- **Color Scheme**: Blue/teal gradient (`#1565C0` → `#00796B`) with gold accents (`#F9A825`) — inspired by Arabic calligraphy aesthetics
- **RTL Support**: All Arabic text uses `FlowDirection="RightToLeft"`
- **Typography**: Arabic text rendered at larger font sizes (28–56px) for readability
- **Touch-friendly**: All interactive elements meet minimum 44px touch target guidelines

---

## 🔧 Technologies Used

| Technology | Purpose |
|---|---|
| **.NET MAUI** | Cross-platform mobile UI framework |
| **C# 12** | Programming language |
| **CommunityToolkit.Mvvm** | MVVM pattern (`ObservableObject`, `RelayCommand`) |
| **.NET Preferences API** | Local data persistence |
| **MAUI Shell** | Navigation with TabBar |
| **CollectionView** | Scrollable alphabet grid and vocabulary lists |
| **Dependency Injection** | Service/ViewModel registration via `MauiProgram.cs` |

---

## 📝 Data

All Arabic language data is hardcoded in `Services/ArabicDataService.cs`:
- **28 Arabic letters** with all 4 forms, transliteration, and example words
- **97 vocabulary items** across 7 categories
- **Quiz generation** with randomized questions and answer shuffling
- Accurate **Unicode Arabic text** with proper diacritics (tashkeel)

---

## 🌟 Learning Tips

1. Start with the **Alphabet** — learn to recognize the 28 letters
2. Practice **Vocabulary** by category — work through one category at a time
3. Use **Flashcards** daily to reinforce memory
4. Take the **Quiz** to test your knowledge
5. Check **Progress** to see how far you've come!

---

*يَمنَح العِلمُ الجَنَاح — Knowledge gives wings* ✨
