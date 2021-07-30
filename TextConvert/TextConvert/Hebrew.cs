namespace TextConvert
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hebrew
    {
        private static readonly Dictionary<char, char> EnglishCharsToHebrewChars = new Dictionary<char, char>
        {
            { 'q', '/' },
            { 'w', '\'' },
            { 'e', 'ק' },
            { 'r', 'ר' },
            { 't', 'א' },
            { 'y', 'ט' },
            { 'u', 'ו' },
            { 'i', 'ן' },
            { 'o', 'ם' },
            { 'p', 'פ' },
            { '[', ']' },
            { ']', '[' },
            { '\\', '\\'},
            { 'a', 'ש' },
            { 's', 'ד' },
            { 'd', 'ג' },
            { 'f', 'כ' },
            { 'g', 'ע' },
            { 'h', 'י' },
            { 'j', 'ח' },
            { 'k', 'ל' },
            { 'l', 'ך' },
            { ';', 'ף' },
            { '\'', ',' },
            { 'z', 'ז'},
            { 'x', 'ס' },
            { 'c', 'ב' },
            { 'v', 'ה' },
            { 'b', 'נ' },
            { 'n', 'מ' },
            { 'm', 'צ' },
            { ',', 'ת' },
            { '.', 'ץ' },
            { '/', '.' },

            // TODO: what about shifts?
        };
        private static readonly Dictionary<char, char> HebrewCharsToEnglishChars = ReverseDictionary(EnglishCharsToHebrewChars);

        public static Dictionary<char, char> ReverseDictionary(Dictionary<char, char> inputDictionary)
        {
            Dictionary<char, char> reverseDictionary = new Dictionary<char, char>();

            foreach (var inputCharacterMapping in inputDictionary)
            {
                reverseDictionary.Add(inputCharacterMapping.Value, inputCharacterMapping.Key);
            }

            return reverseDictionary;
        }

        public static string ConvertEnglishToHebrew(string englishString)
        {
            var hebrewStringBuilder = new StringBuilder();
            englishString.ToList().ForEach(englishChar => hebrewStringBuilder.Append(EnglishCharsToHebrewChars.TryGetValue(char.ToLower(englishChar), out var hebrewChar) ? hebrewChar : englishChar));

            return hebrewStringBuilder.ToString();
        }

        public static string ConvertHebrewToEnglish(string hebrewString)
        {
            var englishStringBuilder = new StringBuilder();
            hebrewString.ToList().ForEach(hebrewChar => englishStringBuilder.Append(HebrewCharsToEnglishChars.TryGetValue(char.ToLower(hebrewChar), out var englishChar) ? englishChar : hebrewChar));

            return englishStringBuilder.ToString();
        }
    }
}
