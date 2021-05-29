using System;

namespace TextConvertApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = args[0];
            Console.WriteLine(TextConvert.Hebrew.ConvertEnglishToHebrew(inputString)); 
        }
    }
}
