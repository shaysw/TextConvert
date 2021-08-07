using System;
using System.IO;

namespace TextConvert
{
    public class Hebrew : EnglishQweryConvertibleKeyboardLayout
    {
        private const string _keyboardLayoutMappingsFileName = "hebrew.json";
        public Hebrew() : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KeyboardLayoutMappings", _keyboardLayoutMappingsFileName))
        { }
    }
}
