using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextConvertTests
{
    [TestClass]
    public class HebrewToEnglisTests
    {
        [TestMethod]
        public void TestSingleCharLowerCaseConvert()
        {
            var hebrewInput = "ש";
            var englishOutput = "a";

            Assert.AreEqual(TextConvert.Hebrew.ConvertHebrewToEnglish(hebrewInput), englishOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersAllExistingConvert()
        {
            var hebrewInput = "שנבגקכע";
            var englishOutput = "abcdefg";

            Assert.AreEqual(TextConvert.Hebrew.ConvertHebrewToEnglish(hebrewInput), englishOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersNotAllExistingConvert()
        {
            var hebrewInput = "שנבגקכע שדג 1223$%^^$";
            var englishOutput = "abcdefg asd 1223$%^^$";

            Assert.AreEqual(TextConvert.Hebrew.ConvertHebrewToEnglish(hebrewInput), englishOutput);
        }

        [TestMethod]
        public void TestMultipleWordsWithQuestionMarkConvert()
        {
            var hebrewInput = "שלום לך מה המצב?";
            var englishOutput = "akuo kl nv vnmc?";

            Assert.AreEqual(TextConvert.Hebrew.ConvertHebrewToEnglish(hebrewInput), englishOutput);
        }
    }
}
