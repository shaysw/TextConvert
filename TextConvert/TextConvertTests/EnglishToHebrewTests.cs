using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextConvert;

namespace TextConvertTests
{
    [TestClass]
    public class EnglishToHebrewTests
    {
        private Hebrew _hebrew = new Hebrew();

        [TestMethod]
        public void TestSingleCharLowerCaseConvert()
        {
            var englishInput = "a";
            var hebrewOutput = "ש";

            Assert.AreEqual(_hebrew.ConvertEnglishQwertyStringToConvertibleKeyboardLayout(englishInput), hebrewOutput);
        }

        [TestMethod]
        public void TestSingleCharUpperCaseConvert()
        {
            var englishInput = "A";
            var hebrewOutput = "ש";

            Assert.AreEqual(_hebrew.ConvertEnglishQwertyStringToConvertibleKeyboardLayout(englishInput), hebrewOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersAllExistingConvert()
        {
            var englishInput = "ABCDEFG";
            var hebrewOutput = "שנבגקכע";

            Assert.AreEqual(_hebrew.ConvertEnglishQwertyStringToConvertibleKeyboardLayout(englishInput), hebrewOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersNotAllExistingConvert()
        {
            var englishInput = "ABCDEFG asd 1223$%^^$";
            var hebrewOutput = "שנבגקכע שדג 1223$%^^$";

            Assert.AreEqual(_hebrew.ConvertEnglishQwertyStringToConvertibleKeyboardLayout(englishInput), hebrewOutput);
        }

        [TestMethod]
        public void TestMultipleWordsWithQuestionMarkConvert()
        {
            var englishInput = "AKUO kl nv vnmc?";
            var hebrewOutput = "שלום לך מה המצב?";

            Assert.AreEqual(_hebrew.ConvertEnglishQwertyStringToConvertibleKeyboardLayout(englishInput), hebrewOutput);
        }
    }
}
