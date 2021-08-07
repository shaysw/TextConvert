using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.IO;

namespace TextConvert
{
    internal class EnglishQwertyCharsToConvertibleKeyboardLayoutMapping
    {
        private readonly Dictionary<char, char> _englishQwertyCharsToConvertibleKeyboardLayoutDictionary;
        private readonly Dictionary<char, char> _convertibleKeyboardLayoutCharsToEnglishQwertyDictionary;

        public EnglishQwertyCharsToConvertibleKeyboardLayoutMapping(Dictionary<char, char> englishQwertyCharsToConvertibleKeyboardLayoutDictionary)
        {
            _englishQwertyCharsToConvertibleKeyboardLayoutDictionary = englishQwertyCharsToConvertibleKeyboardLayoutDictionary;
            this._convertibleKeyboardLayoutCharsToEnglishQwertyDictionary = ReverseDictionary(englishQwertyCharsToConvertibleKeyboardLayoutDictionary);
        }

        private static Dictionary<char, char> ReverseDictionary(Dictionary<char, char> inputDictionary)
        {
            Dictionary<char, char> reverseDictionary = new Dictionary<char, char>();

            foreach (var inputCharacterMapping in inputDictionary)
            {
                reverseDictionary.Add(inputCharacterMapping.Value, inputCharacterMapping.Key);
            }

            return reverseDictionary;
        }

        internal bool MapFromEnglishQwerty(char englishQwertyChar, out char outputChar)
        {
            return _englishQwertyCharsToConvertibleKeyboardLayoutDictionary.TryGetValue(englishQwertyChar, out outputChar);
        }

        internal bool MapToEnglishQwerty(char convertibleKeyboardLayoutChar, out char englishQwertyChar)
        {
            return _convertibleKeyboardLayoutCharsToEnglishQwertyDictionary.TryGetValue(convertibleKeyboardLayoutChar, out englishQwertyChar);
        }
    }
}