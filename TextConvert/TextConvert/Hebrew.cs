namespace TextConvert
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Hebrew : EnglishQweryConvertibleKeyboardLayout
    {
        private const string _keyboardLayoutMappingsFileName = "hebrew.json";
        public Hebrew() : base(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "KeyboardLayoutMappings", _keyboardLayoutMappingsFileName))
        { }
    }
}
