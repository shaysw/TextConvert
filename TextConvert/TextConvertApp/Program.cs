using System;

using TextConvert;

namespace TextConvertApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hebrew = new Hebrew();
            var inputString = args[0];

            Console.WriteLine(hebrew.ConvertEnglishQwertyStringToConvertibleKeyboardLayout(inputString)); 
        }
    }
}
