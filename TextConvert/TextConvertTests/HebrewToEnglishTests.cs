using Microsoft.VisualStudio.TestTools.UnitTesting;

using TextConvert;

namespace TextConvertTests
{
    [TestClass]
    public class HebrewToEnglishTests
    {
        private Hebrew _hebrew = new Hebrew();

        [TestMethod]
        public void TestSingleCharLowerCaseConvert()
        {
            var hebrewInput = "ש";
            var englishOutput = "a";

            Assert.AreEqual(_hebrew.ConvertConvertibleKeyboardLayoutToEnglishQwertyString(hebrewInput), englishOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersAllExistingConvert()
        {
            var hebrewInput = "שנבגקכע";
            var englishOutput = "abcdefg";

            Assert.AreEqual(_hebrew.ConvertConvertibleKeyboardLayoutToEnglishQwertyString(hebrewInput), englishOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersNotAllExistingConvert()
        {
            var hebrewInput = "שנבגקכע שדג 1223$%^^$";
            var englishOutput = "abcdefg asd 1223$%^^$";

            Assert.AreEqual(_hebrew.ConvertConvertibleKeyboardLayoutToEnglishQwertyString(hebrewInput), englishOutput);
        }

        [TestMethod]
        public void TestMultipleWordsWithQuestionMarkConvert()
        {
            var hebrewInput = "שלום לך מה המצב?";
            var englishOutput = "akuo kl nv vnmc?";

            Assert.AreEqual(_hebrew.ConvertConvertibleKeyboardLayoutToEnglishQwertyString(hebrewInput), englishOutput);
        }
    }
}
