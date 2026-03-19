using ArabicLearningApp.Models;

namespace ArabicLearningApp.Services;

public class ArabicDataService
{
    private static readonly List<ArabicLetter> _letters = new()
    {
        new ArabicLetter { Id = 1, Letter = "أ", Name = "Alef", NameArabic = "أَلِف", Transliteration = "a / ā", IsolatedForm = "ا", InitialForm = "ا", MedialForm = "ـا", FinalForm = "ـا", Pronunciation = "Like 'a' in 'apple' or 'ah'", ExampleWord = "أَسَد", ExampleTranslation = "Lion" },
        new ArabicLetter { Id = 2, Letter = "ب", Name = "Ba", NameArabic = "بَاء", Transliteration = "b", IsolatedForm = "ب", InitialForm = "بـ", MedialForm = "ـبـ", FinalForm = "ـب", Pronunciation = "Like 'b' in 'book'", ExampleWord = "بَيت", ExampleTranslation = "House" },
        new ArabicLetter { Id = 3, Letter = "ت", Name = "Ta", NameArabic = "تَاء", Transliteration = "t", IsolatedForm = "ت", InitialForm = "تـ", MedialForm = "ـتـ", FinalForm = "ـت", Pronunciation = "Like 't' in 'tea'", ExampleWord = "تُفَّاحة", ExampleTranslation = "Apple" },
        new ArabicLetter { Id = 4, Letter = "ث", Name = "Tha", NameArabic = "ثَاء", Transliteration = "th", IsolatedForm = "ث", InitialForm = "ثـ", MedialForm = "ـثـ", FinalForm = "ـث", Pronunciation = "Like 'th' in 'think'", ExampleWord = "ثَعلَب", ExampleTranslation = "Fox" },
        new ArabicLetter { Id = 5, Letter = "ج", Name = "Jim", NameArabic = "جِيم", Transliteration = "j", IsolatedForm = "ج", InitialForm = "جـ", MedialForm = "ـجـ", FinalForm = "ـج", Pronunciation = "Like 'j' in 'jar'", ExampleWord = "جَمَل", ExampleTranslation = "Camel" },
        new ArabicLetter { Id = 6, Letter = "ح", Name = "Ha", NameArabic = "حَاء", Transliteration = "ḥ", IsolatedForm = "ح", InitialForm = "حـ", MedialForm = "ـحـ", FinalForm = "ـح", Pronunciation = "A breathy 'h' from the throat", ExampleWord = "حِصَان", ExampleTranslation = "Horse" },
        new ArabicLetter { Id = 7, Letter = "خ", Name = "Kha", NameArabic = "خَاء", Transliteration = "kh", IsolatedForm = "خ", InitialForm = "خـ", MedialForm = "ـخـ", FinalForm = "ـخ", Pronunciation = "Like 'ch' in Scottish 'loch'", ExampleWord = "خُبز", ExampleTranslation = "Bread" },
        new ArabicLetter { Id = 8, Letter = "د", Name = "Dal", NameArabic = "دَال", Transliteration = "d", IsolatedForm = "د", InitialForm = "د", MedialForm = "ـد", FinalForm = "ـد", Pronunciation = "Like 'd' in 'door'", ExampleWord = "دَرَاجة", ExampleTranslation = "Bicycle" },
        new ArabicLetter { Id = 9, Letter = "ذ", Name = "Dhal", NameArabic = "ذَال", Transliteration = "dh", IsolatedForm = "ذ", InitialForm = "ذ", MedialForm = "ـذ", FinalForm = "ـذ", Pronunciation = "Like 'th' in 'this'", ExampleWord = "ذِئب", ExampleTranslation = "Wolf" },
        new ArabicLetter { Id = 10, Letter = "ر", Name = "Ra", NameArabic = "رَاء", Transliteration = "r", IsolatedForm = "ر", InitialForm = "ر", MedialForm = "ـر", FinalForm = "ـر", Pronunciation = "Rolled 'r', like Spanish 'r'", ExampleWord = "رُمَّان", ExampleTranslation = "Pomegranate" },
        new ArabicLetter { Id = 11, Letter = "ز", Name = "Zay", NameArabic = "زَاي", Transliteration = "z", IsolatedForm = "ز", InitialForm = "ز", MedialForm = "ـز", FinalForm = "ـز", Pronunciation = "Like 'z' in 'zebra'", ExampleWord = "زَهرَة", ExampleTranslation = "Flower" },
        new ArabicLetter { Id = 12, Letter = "س", Name = "Sin", NameArabic = "سِين", Transliteration = "s", IsolatedForm = "س", InitialForm = "سـ", MedialForm = "ـسـ", FinalForm = "ـس", Pronunciation = "Like 's' in 'sun'", ExampleWord = "سَمَكة", ExampleTranslation = "Fish" },
        new ArabicLetter { Id = 13, Letter = "ش", Name = "Shin", NameArabic = "شِين", Transliteration = "sh", IsolatedForm = "ش", InitialForm = "شـ", MedialForm = "ـشـ", FinalForm = "ـش", Pronunciation = "Like 'sh' in 'ship'", ExampleWord = "شَمس", ExampleTranslation = "Sun" },
        new ArabicLetter { Id = 14, Letter = "ص", Name = "Sad", NameArabic = "صَاد", Transliteration = "ṣ", IsolatedForm = "ص", InitialForm = "صـ", MedialForm = "ـصـ", FinalForm = "ـص", Pronunciation = "Emphatic 's', heavier than regular 's'", ExampleWord = "صَابُون", ExampleTranslation = "Soap" },
        new ArabicLetter { Id = 15, Letter = "ض", Name = "Dad", NameArabic = "ضَاد", Transliteration = "ḍ", IsolatedForm = "ض", InitialForm = "ضـ", MedialForm = "ـضـ", FinalForm = "ـض", Pronunciation = "Emphatic 'd', unique to Arabic", ExampleWord = "ضِفدَع", ExampleTranslation = "Frog" },
        new ArabicLetter { Id = 16, Letter = "ط", Name = "Ta", NameArabic = "طَاء", Transliteration = "ṭ", IsolatedForm = "ط", InitialForm = "طـ", MedialForm = "ـطـ", FinalForm = "ـط", Pronunciation = "Emphatic 't'", ExampleWord = "طَاوِلة", ExampleTranslation = "Table" },
        new ArabicLetter { Id = 17, Letter = "ظ", Name = "Dha", NameArabic = "ظَاء", Transliteration = "ẓ", IsolatedForm = "ظ", InitialForm = "ظـ", MedialForm = "ـظـ", FinalForm = "ـظ", Pronunciation = "Emphatic 'dh'", ExampleWord = "ظَرف", ExampleTranslation = "Envelope" },
        new ArabicLetter { Id = 18, Letter = "ع", Name = "Ayn", NameArabic = "عَين", Transliteration = "'", IsolatedForm = "ع", InitialForm = "عـ", MedialForm = "ـعـ", FinalForm = "ـع", Pronunciation = "A unique guttural sound, constriction of the throat", ExampleWord = "عَين", ExampleTranslation = "Eye" },
        new ArabicLetter { Id = 19, Letter = "غ", Name = "Ghayn", NameArabic = "غَين", Transliteration = "gh", IsolatedForm = "غ", InitialForm = "غـ", MedialForm = "ـغـ", FinalForm = "ـغ", Pronunciation = "Like 'r' in French 'Paris'", ExampleWord = "غُرفة", ExampleTranslation = "Room" },
        new ArabicLetter { Id = 20, Letter = "ف", Name = "Fa", NameArabic = "فَاء", Transliteration = "f", IsolatedForm = "ف", InitialForm = "فـ", MedialForm = "ـفـ", FinalForm = "ـف", Pronunciation = "Like 'f' in 'fan'", ExampleWord = "فِيل", ExampleTranslation = "Elephant" },
        new ArabicLetter { Id = 21, Letter = "ق", Name = "Qaf", NameArabic = "قَاف", Transliteration = "q", IsolatedForm = "ق", InitialForm = "قـ", MedialForm = "ـقـ", FinalForm = "ـق", Pronunciation = "Like 'k' but from the back of the throat", ExampleWord = "قَمَر", ExampleTranslation = "Moon" },
        new ArabicLetter { Id = 22, Letter = "ك", Name = "Kaf", NameArabic = "كَاف", Transliteration = "k", IsolatedForm = "ك", InitialForm = "كـ", MedialForm = "ـكـ", FinalForm = "ـك", Pronunciation = "Like 'k' in 'king'", ExampleWord = "كِتَاب", ExampleTranslation = "Book" },
        new ArabicLetter { Id = 23, Letter = "ل", Name = "Lam", NameArabic = "لَام", Transliteration = "l", IsolatedForm = "ل", InitialForm = "لـ", MedialForm = "ـلـ", FinalForm = "ـل", Pronunciation = "Like 'l' in 'lamp'", ExampleWord = "لَيمُون", ExampleTranslation = "Lemon" },
        new ArabicLetter { Id = 24, Letter = "م", Name = "Mim", NameArabic = "مِيم", Transliteration = "m", IsolatedForm = "م", InitialForm = "مـ", MedialForm = "ـمـ", FinalForm = "ـم", Pronunciation = "Like 'm' in 'moon'", ExampleWord = "مَاء", ExampleTranslation = "Water" },
        new ArabicLetter { Id = 25, Letter = "ن", Name = "Nun", NameArabic = "نُون", Transliteration = "n", IsolatedForm = "ن", InitialForm = "نـ", MedialForm = "ـنـ", FinalForm = "ـن", Pronunciation = "Like 'n' in 'noon'", ExampleWord = "نَجمَة", ExampleTranslation = "Star" },
        new ArabicLetter { Id = 26, Letter = "ه", Name = "Ha", NameArabic = "هَاء", Transliteration = "h", IsolatedForm = "ه", InitialForm = "هـ", MedialForm = "ـهـ", FinalForm = "ـه", Pronunciation = "Like 'h' in 'hat'", ExampleWord = "هَلَال", ExampleTranslation = "Crescent" },
        new ArabicLetter { Id = 27, Letter = "و", Name = "Waw", NameArabic = "وَاو", Transliteration = "w / ū", IsolatedForm = "و", InitialForm = "و", MedialForm = "ـو", FinalForm = "ـو", Pronunciation = "Like 'w' in 'water' or 'oo' in 'moon'", ExampleWord = "وَرد", ExampleTranslation = "Roses" },
        new ArabicLetter { Id = 28, Letter = "ي", Name = "Ya", NameArabic = "يَاء", Transliteration = "y / ī", IsolatedForm = "ي", InitialForm = "يـ", MedialForm = "ـيـ", FinalForm = "ـي", Pronunciation = "Like 'y' in 'yes' or 'ee' in 'see'", ExampleWord = "يَد", ExampleTranslation = "Hand" },
    };

    private static readonly List<VocabularyItem> _vocabulary = new()
    {
        // Greetings & Common Phrases
        new VocabularyItem { Id = 1, ArabicWord = "مَرحَبًا", EnglishTranslation = "Hello", Transliteration = "Marhaban", Category = "Greetings" },
        new VocabularyItem { Id = 2, ArabicWord = "السَّلَامُ عَلَيكُم", EnglishTranslation = "Peace be upon you", Transliteration = "As-salāmu ʿalaykum", Category = "Greetings" },
        new VocabularyItem { Id = 3, ArabicWord = "وَعَلَيكُمُ السَّلَام", EnglishTranslation = "And upon you be peace", Transliteration = "Wa ʿalaykumu s-salām", Category = "Greetings" },
        new VocabularyItem { Id = 4, ArabicWord = "صَبَاحُ الخَير", EnglishTranslation = "Good morning", Transliteration = "Ṣabāḥu l-khayr", Category = "Greetings" },
        new VocabularyItem { Id = 5, ArabicWord = "مَسَاءُ الخَير", EnglishTranslation = "Good evening", Transliteration = "Masāʾu l-khayr", Category = "Greetings" },
        new VocabularyItem { Id = 6, ArabicWord = "مَعَ السَّلَامَة", EnglishTranslation = "Goodbye", Transliteration = "Maʿa s-salāmah", Category = "Greetings" },
        new VocabularyItem { Id = 7, ArabicWord = "شُكرًا", EnglishTranslation = "Thank you", Transliteration = "Shukran", Category = "Greetings" },
        new VocabularyItem { Id = 8, ArabicWord = "عَفوًا", EnglishTranslation = "You're welcome / Excuse me", Transliteration = "ʿAfwan", Category = "Greetings" },
        new VocabularyItem { Id = 9, ArabicWord = "مِن فَضلِك", EnglishTranslation = "Please", Transliteration = "Min faḍlak", Category = "Greetings" },
        new VocabularyItem { Id = 10, ArabicWord = "آسِف", EnglishTranslation = "Sorry", Transliteration = "Āsif", Category = "Greetings" },
        new VocabularyItem { Id = 11, ArabicWord = "كَيفَ حَالُك؟", EnglishTranslation = "How are you?", Transliteration = "Kayfa ḥāluk?", Category = "Greetings" },
        new VocabularyItem { Id = 12, ArabicWord = "بِخَير، شُكرًا", EnglishTranslation = "Fine, thank you", Transliteration = "Bi-khayr, shukran", Category = "Greetings" },
        new VocabularyItem { Id = 13, ArabicWord = "نَعَم", EnglishTranslation = "Yes", Transliteration = "Naʿam", Category = "Greetings" },
        new VocabularyItem { Id = 14, ArabicWord = "لَا", EnglishTranslation = "No", Transliteration = "Lā", Category = "Greetings" },
        new VocabularyItem { Id = 15, ArabicWord = "مَا اسمُك؟", EnglishTranslation = "What is your name?", Transliteration = "Mā ismuk?", Category = "Greetings" },

        // Numbers
        new VocabularyItem { Id = 16, ArabicWord = "وَاحِد", EnglishTranslation = "One (1)", Transliteration = "Wāḥid", Category = "Numbers" },
        new VocabularyItem { Id = 17, ArabicWord = "اثنَان", EnglishTranslation = "Two (2)", Transliteration = "Ithnan", Category = "Numbers" },
        new VocabularyItem { Id = 18, ArabicWord = "ثَلَاثَة", EnglishTranslation = "Three (3)", Transliteration = "Thalāthah", Category = "Numbers" },
        new VocabularyItem { Id = 19, ArabicWord = "أَربَعَة", EnglishTranslation = "Four (4)", Transliteration = "ʾArbaʿah", Category = "Numbers" },
        new VocabularyItem { Id = 20, ArabicWord = "خَمسَة", EnglishTranslation = "Five (5)", Transliteration = "Khamsah", Category = "Numbers" },
        new VocabularyItem { Id = 21, ArabicWord = "سِتَّة", EnglishTranslation = "Six (6)", Transliteration = "Sittah", Category = "Numbers" },
        new VocabularyItem { Id = 22, ArabicWord = "سَبعَة", EnglishTranslation = "Seven (7)", Transliteration = "Sabʿah", Category = "Numbers" },
        new VocabularyItem { Id = 23, ArabicWord = "ثَمَانِيَة", EnglishTranslation = "Eight (8)", Transliteration = "Thamāniyah", Category = "Numbers" },
        new VocabularyItem { Id = 24, ArabicWord = "تِسعَة", EnglishTranslation = "Nine (9)", Transliteration = "Tisʿah", Category = "Numbers" },
        new VocabularyItem { Id = 25, ArabicWord = "عَشَرَة", EnglishTranslation = "Ten (10)", Transliteration = "ʿAsharah", Category = "Numbers" },
        new VocabularyItem { Id = 26, ArabicWord = "أَحَد عَشَر", EnglishTranslation = "Eleven (11)", Transliteration = "ʾAḥad ʿashar", Category = "Numbers" },
        new VocabularyItem { Id = 27, ArabicWord = "اثنَا عَشَر", EnglishTranslation = "Twelve (12)", Transliteration = "Ithnā ʿashar", Category = "Numbers" },
        new VocabularyItem { Id = 28, ArabicWord = "ثَلَاثَةَ عَشَر", EnglishTranslation = "Thirteen (13)", Transliteration = "Thalāthata ʿashar", Category = "Numbers" },
        new VocabularyItem { Id = 29, ArabicWord = "عِشرُون", EnglishTranslation = "Twenty (20)", Transliteration = "ʿIshrūn", Category = "Numbers" },
        new VocabularyItem { Id = 30, ArabicWord = "مِئَة", EnglishTranslation = "One hundred (100)", Transliteration = "Miʾah", Category = "Numbers" },

        // Colors
        new VocabularyItem { Id = 31, ArabicWord = "أَحمَر", EnglishTranslation = "Red", Transliteration = "ʾAḥmar", Category = "Colors" },
        new VocabularyItem { Id = 32, ArabicWord = "أَزرَق", EnglishTranslation = "Blue", Transliteration = "ʾAzraq", Category = "Colors" },
        new VocabularyItem { Id = 33, ArabicWord = "أَخضَر", EnglishTranslation = "Green", Transliteration = "ʾAkḥḍar", Category = "Colors" },
        new VocabularyItem { Id = 34, ArabicWord = "أَصفَر", EnglishTranslation = "Yellow", Transliteration = "ʾAṣfar", Category = "Colors" },
        new VocabularyItem { Id = 35, ArabicWord = "أَبيَض", EnglishTranslation = "White", Transliteration = "ʾAbyaḍ", Category = "Colors" },
        new VocabularyItem { Id = 36, ArabicWord = "أَسوَد", EnglishTranslation = "Black", Transliteration = "ʾAswad", Category = "Colors" },
        new VocabularyItem { Id = 37, ArabicWord = "بُرتُقَالِي", EnglishTranslation = "Orange", Transliteration = "Burtuqālī", Category = "Colors" },
        new VocabularyItem { Id = 38, ArabicWord = "بَنَفسَجِي", EnglishTranslation = "Purple", Transliteration = "Banafsajī", Category = "Colors" },
        new VocabularyItem { Id = 39, ArabicWord = "وَردِي", EnglishTranslation = "Pink", Transliteration = "Wardī", Category = "Colors" },
        new VocabularyItem { Id = 40, ArabicWord = "بُنِّي", EnglishTranslation = "Brown", Transliteration = "Bunnī", Category = "Colors" },
        new VocabularyItem { Id = 41, ArabicWord = "رَمَادِي", EnglishTranslation = "Gray", Transliteration = "Ramādī", Category = "Colors" },
        new VocabularyItem { Id = 42, ArabicWord = "ذَهَبِي", EnglishTranslation = "Golden", Transliteration = "Dhahabī", Category = "Colors" },

        // Food & Drinks
        new VocabularyItem { Id = 43, ArabicWord = "مَاء", EnglishTranslation = "Water", Transliteration = "Māʾ", Category = "Food & Drinks" },
        new VocabularyItem { Id = 44, ArabicWord = "خُبز", EnglishTranslation = "Bread", Transliteration = "Khubz", Category = "Food & Drinks" },
        new VocabularyItem { Id = 45, ArabicWord = "أُرُز", EnglishTranslation = "Rice", Transliteration = "ʾUruz", Category = "Food & Drinks" },
        new VocabularyItem { Id = 46, ArabicWord = "لَحم", EnglishTranslation = "Meat", Transliteration = "Laḥm", Category = "Food & Drinks" },
        new VocabularyItem { Id = 47, ArabicWord = "سَمَك", EnglishTranslation = "Fish", Transliteration = "Samak", Category = "Food & Drinks" },
        new VocabularyItem { Id = 48, ArabicWord = "دَجَاج", EnglishTranslation = "Chicken", Transliteration = "Dajāj", Category = "Food & Drinks" },
        new VocabularyItem { Id = 49, ArabicWord = "تُفَّاحَة", EnglishTranslation = "Apple", Transliteration = "Tuffāḥah", Category = "Food & Drinks" },
        new VocabularyItem { Id = 50, ArabicWord = "مَوز", EnglishTranslation = "Banana", Transliteration = "Mawz", Category = "Food & Drinks" },
        new VocabularyItem { Id = 51, ArabicWord = "شَاي", EnglishTranslation = "Tea", Transliteration = "Shāy", Category = "Food & Drinks" },
        new VocabularyItem { Id = 52, ArabicWord = "قَهوَة", EnglishTranslation = "Coffee", Transliteration = "Qahwah", Category = "Food & Drinks" },
        new VocabularyItem { Id = 53, ArabicWord = "حَلِيب", EnglishTranslation = "Milk", Transliteration = "Ḥalīb", Category = "Food & Drinks" },
        new VocabularyItem { Id = 54, ArabicWord = "عَصِير", EnglishTranslation = "Juice", Transliteration = "ʿAṣīr", Category = "Food & Drinks" },
        new VocabularyItem { Id = 55, ArabicWord = "طَعَام", EnglishTranslation = "Food", Transliteration = "Ṭaʿām", Category = "Food & Drinks" },
        new VocabularyItem { Id = 56, ArabicWord = "سُكَّر", EnglishTranslation = "Sugar", Transliteration = "Sukkar", Category = "Food & Drinks" },
        new VocabularyItem { Id = 57, ArabicWord = "مِلح", EnglishTranslation = "Salt", Transliteration = "Milḥ", Category = "Food & Drinks" },

        // Family Members
        new VocabularyItem { Id = 58, ArabicWord = "أَب", EnglishTranslation = "Father", Transliteration = "ʾAb", Category = "Family" },
        new VocabularyItem { Id = 59, ArabicWord = "أُم", EnglishTranslation = "Mother", Transliteration = "ʾUm", Category = "Family" },
        new VocabularyItem { Id = 60, ArabicWord = "أَخ", EnglishTranslation = "Brother", Transliteration = "ʾAkh", Category = "Family" },
        new VocabularyItem { Id = 61, ArabicWord = "أُخت", EnglishTranslation = "Sister", Transliteration = "ʾUkht", Category = "Family" },
        new VocabularyItem { Id = 62, ArabicWord = "جَدّ", EnglishTranslation = "Grandfather", Transliteration = "Jadd", Category = "Family" },
        new VocabularyItem { Id = 63, ArabicWord = "جَدَّة", EnglishTranslation = "Grandmother", Transliteration = "Jaddah", Category = "Family" },
        new VocabularyItem { Id = 64, ArabicWord = "اِبن", EnglishTranslation = "Son", Transliteration = "Ibn", Category = "Family" },
        new VocabularyItem { Id = 65, ArabicWord = "بِنت", EnglishTranslation = "Daughter", Transliteration = "Bint", Category = "Family" },
        new VocabularyItem { Id = 66, ArabicWord = "زَوج", EnglishTranslation = "Husband", Transliteration = "Zawj", Category = "Family" },
        new VocabularyItem { Id = 67, ArabicWord = "زَوجَة", EnglishTranslation = "Wife", Transliteration = "Zawjah", Category = "Family" },
        new VocabularyItem { Id = 68, ArabicWord = "عَمّ", EnglishTranslation = "Uncle (paternal)", Transliteration = "ʿAmm", Category = "Family" },
        new VocabularyItem { Id = 69, ArabicWord = "عَمَّة", EnglishTranslation = "Aunt (paternal)", Transliteration = "ʿAmmah", Category = "Family" },
        new VocabularyItem { Id = 70, ArabicWord = "أُسرَة", EnglishTranslation = "Family", Transliteration = "ʾUsrah", Category = "Family" },

        // Days of the Week
        new VocabularyItem { Id = 71, ArabicWord = "الأَحَد", EnglishTranslation = "Sunday", Transliteration = "Al-ʾAḥad", Category = "Days" },
        new VocabularyItem { Id = 72, ArabicWord = "الاثنَين", EnglishTranslation = "Monday", Transliteration = "Al-Ithnayn", Category = "Days" },
        new VocabularyItem { Id = 73, ArabicWord = "الثُّلَاثَاء", EnglishTranslation = "Tuesday", Transliteration = "Ath-Thulāthāʾ", Category = "Days" },
        new VocabularyItem { Id = 74, ArabicWord = "الأَربِعَاء", EnglishTranslation = "Wednesday", Transliteration = "Al-ʾArbiʿāʾ", Category = "Days" },
        new VocabularyItem { Id = 75, ArabicWord = "الخَمِيس", EnglishTranslation = "Thursday", Transliteration = "Al-Khamīs", Category = "Days" },
        new VocabularyItem { Id = 76, ArabicWord = "الجُمُعَة", EnglishTranslation = "Friday", Transliteration = "Al-Jumuʿah", Category = "Days" },
        new VocabularyItem { Id = 77, ArabicWord = "السَّبت", EnglishTranslation = "Saturday", Transliteration = "As-Sabt", Category = "Days" },
        new VocabularyItem { Id = 78, ArabicWord = "يَوم", EnglishTranslation = "Day", Transliteration = "Yawm", Category = "Days" },
        new VocabularyItem { Id = 79, ArabicWord = "أُسبُوع", EnglishTranslation = "Week", Transliteration = "ʾUsbūʿ", Category = "Days" },
        new VocabularyItem { Id = 80, ArabicWord = "اليَوم", EnglishTranslation = "Today", Transliteration = "Al-Yawm", Category = "Days" },
        new VocabularyItem { Id = 81, ArabicWord = "أَمس", EnglishTranslation = "Yesterday", Transliteration = "ʾAms", Category = "Days" },
        new VocabularyItem { Id = 82, ArabicWord = "غَدًا", EnglishTranslation = "Tomorrow", Transliteration = "Ghadan", Category = "Days" },

        // Common Verbs
        new VocabularyItem { Id = 83, ArabicWord = "ذَهَبَ", EnglishTranslation = "To go", Transliteration = "Dhahaba", Category = "Verbs" },
        new VocabularyItem { Id = 84, ArabicWord = "جَاءَ", EnglishTranslation = "To come", Transliteration = "Jāʾa", Category = "Verbs" },
        new VocabularyItem { Id = 85, ArabicWord = "أَكَلَ", EnglishTranslation = "To eat", Transliteration = "ʾAkala", Category = "Verbs" },
        new VocabularyItem { Id = 86, ArabicWord = "شَرِبَ", EnglishTranslation = "To drink", Transliteration = "Shariba", Category = "Verbs" },
        new VocabularyItem { Id = 87, ArabicWord = "نَامَ", EnglishTranslation = "To sleep", Transliteration = "Nāma", Category = "Verbs" },
        new VocabularyItem { Id = 88, ArabicWord = "قَرَأَ", EnglishTranslation = "To read", Transliteration = "Qaraʾa", Category = "Verbs" },
        new VocabularyItem { Id = 89, ArabicWord = "كَتَبَ", EnglishTranslation = "To write", Transliteration = "Kataba", Category = "Verbs" },
        new VocabularyItem { Id = 90, ArabicWord = "تَكَلَّمَ", EnglishTranslation = "To speak", Transliteration = "Takallama", Category = "Verbs" },
        new VocabularyItem { Id = 91, ArabicWord = "سَمِعَ", EnglishTranslation = "To hear/listen", Transliteration = "Samiʿa", Category = "Verbs" },
        new VocabularyItem { Id = 92, ArabicWord = "رَأَى", EnglishTranslation = "To see", Transliteration = "Raʾā", Category = "Verbs" },
        new VocabularyItem { Id = 93, ArabicWord = "أَحَبَّ", EnglishTranslation = "To love/like", Transliteration = "ʾAḥabba", Category = "Verbs" },
        new VocabularyItem { Id = 94, ArabicWord = "عَرَفَ", EnglishTranslation = "To know", Transliteration = "ʿArafa", Category = "Verbs" },
        new VocabularyItem { Id = 95, ArabicWord = "فَهِمَ", EnglishTranslation = "To understand", Transliteration = "Fahima", Category = "Verbs" },
        new VocabularyItem { Id = 96, ArabicWord = "عَمِلَ", EnglishTranslation = "To work", Transliteration = "ʿAmila", Category = "Verbs" },
        new VocabularyItem { Id = 97, ArabicWord = "دَرَسَ", EnglishTranslation = "To study", Transliteration = "Darasa", Category = "Verbs" },
    };

    public List<ArabicLetter> GetAllLetters() => _letters;

    public ArabicLetter? GetLetterById(int id) =>
        _letters.FirstOrDefault(l => l.Id == id);

    public List<VocabularyItem> GetAllVocabulary() => _vocabulary;

    public List<VocabularyItem> GetVocabularyByCategory(string category) =>
        _vocabulary.Where(v => v.Category == category).ToList();

    public List<string> GetCategories() =>
        _vocabulary.Select(v => v.Category).Distinct().ToList();

    public List<LessonCategory> GetLessonCategories()
    {
        var categories = new List<LessonCategory>
        {
            new() { Id = "Greetings", Name = "Greetings & Phrases", ArabicName = "تَحِيَّات وعِبَارات", Icon = "🤝", Description = "Common greetings and everyday phrases", TotalItems = GetVocabularyByCategory("Greetings").Count },
            new() { Id = "Numbers", Name = "Numbers", ArabicName = "أَرقَام", Icon = "🔢", Description = "Arabic numerals and counting", TotalItems = GetVocabularyByCategory("Numbers").Count },
            new() { Id = "Colors", Name = "Colors", ArabicName = "أَلوَان", Icon = "🎨", Description = "Names of colors in Arabic", TotalItems = GetVocabularyByCategory("Colors").Count },
            new() { Id = "Food & Drinks", Name = "Food & Drinks", ArabicName = "طَعَام وشَرَاب", Icon = "🍽️", Description = "Common food and drink vocabulary", TotalItems = GetVocabularyByCategory("Food & Drinks").Count },
            new() { Id = "Family", Name = "Family Members", ArabicName = "أَفرَاد العَائِلَة", Icon = "👨‍👩‍👧‍👦", Description = "Family relationship words", TotalItems = GetVocabularyByCategory("Family").Count },
            new() { Id = "Days", Name = "Days of the Week", ArabicName = "أَيَّام الأُسبُوع", Icon = "📅", Description = "Days, weeks, and time expressions", TotalItems = GetVocabularyByCategory("Days").Count },
            new() { Id = "Verbs", Name = "Common Verbs", ArabicName = "أَفعَال شَائِعَة", Icon = "⚡", Description = "Essential action words", TotalItems = GetVocabularyByCategory("Verbs").Count },
        };
        return categories;
    }

    public List<QuizQuestion> GenerateQuizQuestions(string category = "All", int count = 10)
    {
        var random = new Random();
        var allQuestions = new List<QuizQuestion>();

        // ArabicToEnglish questions from vocabulary
        var vocabItems = category == "All"
            ? _vocabulary
            : _vocabulary.Where(v => v.Category == category).ToList();

        if (vocabItems.Count < 4)
            vocabItems = _vocabulary;

        foreach (var item in vocabItems)
        {
            var wrongAnswers = _vocabulary
                .Where(v => v.EnglishTranslation != item.EnglishTranslation)
                .OrderBy(_ => random.Next())
                .Take(3)
                .Select(v => v.EnglishTranslation)
                .ToList();

            var options = wrongAnswers.Append(item.EnglishTranslation)
                .OrderBy(_ => random.Next())
                .ToList();

            allQuestions.Add(new QuizQuestion
            {
                Id = allQuestions.Count + 1,
                QuestionType = QuizQuestionType.ArabicToEnglish,
                QuestionText = item.ArabicWord,
                CorrectAnswer = item.EnglishTranslation,
                Options = options,
                Hint = item.Transliteration
            });
        }

        // EnglishToArabic questions
        foreach (var item in vocabItems)
        {
            var wrongAnswers = _vocabulary
                .Where(v => v.ArabicWord != item.ArabicWord)
                .OrderBy(_ => random.Next())
                .Take(3)
                .Select(v => v.ArabicWord)
                .ToList();

            var options = wrongAnswers.Append(item.ArabicWord)
                .OrderBy(_ => random.Next())
                .ToList();

            allQuestions.Add(new QuizQuestion
            {
                Id = allQuestions.Count + 1,
                QuestionType = QuizQuestionType.EnglishToArabic,
                QuestionText = item.EnglishTranslation,
                CorrectAnswer = item.ArabicWord,
                Options = options,
                Hint = item.Transliteration
            });
        }

        // Letter name questions
        foreach (var letter in _letters)
        {
            var wrongAnswers = _letters
                .Where(l => l.Name != letter.Name)
                .OrderBy(_ => random.Next())
                .Take(3)
                .Select(l => l.Name)
                .ToList();

            var options = wrongAnswers.Append(letter.Name)
                .OrderBy(_ => random.Next())
                .ToList();

            allQuestions.Add(new QuizQuestion
            {
                Id = allQuestions.Count + 1,
                QuestionType = QuizQuestionType.LetterName,
                QuestionText = letter.Letter,
                CorrectAnswer = letter.Name,
                Options = options,
                Hint = letter.Transliteration
            });
        }

        return allQuestions
            .OrderBy(_ => random.Next())
            .Take(count)
            .ToList();
    }
}
