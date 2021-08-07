using Newtonsoft.Json;

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TextConvert
{
    public class EnglishQweryConvertibleKeyboardLayout
    {
        private EnglishQwertyCharsToConvertibleKeyboardLayoutMapping _englishQwertyCharsToConvertibleKeyboardLayoutMapping;

        public EnglishQweryConvertibleKeyboardLayout(string keyboardLayoutMappingsFilePath)
        {
            var KeyboardLayoutMappingsFile = File.ReadAllText(keyboardLayoutMappingsFilePath);
            var englishQwertyCharsToConvertibleKeyboardLayoutDictionary = JsonConvert.DeserializeObject<Dictionary<char, char>>(KeyboardLayoutMappingsFile);
           
            _englishQwertyCharsToConvertibleKeyboardLayoutMapping = new EnglishQwertyCharsToConvertibleKeyboardLayoutMapping(englishQwertyCharsToConvertibleKeyboardLayoutDictionary);
        }


        public string ConvertEnglishQwertyStringToConvertibleKeyboardLayout(string englishQwertyString)
        {
            var convertibleKeyboardLayoutStringBuilder = new StringBuilder();
            englishQwertyString.ToList().ForEach(englishChar => convertibleKeyboardLayoutStringBuilder.Append(_englishQwertyCharsToConvertibleKeyboardLayoutMapping.MapFromEnglishQwerty(char.ToLower(englishChar), out var outputChar) ? outputChar : englishChar));

            return convertibleKeyboardLayoutStringBuilder.ToString();
        }

        public string ConvertConvertibleKeyboardLayoutToEnglishQwertyString(string convertibleKeyboardLayoutString)
        {
            var englishStringBuilder = new StringBuilder();
            convertibleKeyboardLayoutString.ToList().ForEach(convertibleKeyboardLayoutChar => englishStringBuilder.Append(_englishQwertyCharsToConvertibleKeyboardLayoutMapping.MapToEnglishQwerty(char.ToLower(convertibleKeyboardLayoutChar), out var englishChar) ? englishChar : convertibleKeyboardLayoutChar));

            return englishStringBuilder.ToString();
        }
    }
}