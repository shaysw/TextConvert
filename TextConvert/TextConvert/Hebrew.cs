namespace TextConvert
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Hebrew : EnglishQweryConvertibleKeyboardLayout
    {
        private static readonly Dictionary<char, char> EnglishCharsToHebrewChars = new()
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

        public Hebrew() : base(EnglishCharsToHebrewChars)
        { }
    }
}
