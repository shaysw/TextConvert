using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextConvertTests
{
    [TestClass]
    public class HebrewTests
    {
        [TestMethod]
        public void TestSingleCharLowerCaseConvert()
        {
            var englishInput = "a";
            var hebrewOutput = "ש";

            Assert.AreEqual(TextConvert.Hebrew.ConvertEnglishToHebrew(englishInput), hebrewOutput);
        }

        [TestMethod]
        public void TestSingleCharUpperCaseConvert()
        {
            var englishInput = "A";
            var hebrewOutput = "ש";

            Assert.AreEqual(TextConvert.Hebrew.ConvertEnglishToHebrew(englishInput), hebrewOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersAllExistingConvert()
        {
            var englishInput = "ABCDEFG";
            var hebrewOutput = "שנבגקכע";

            Assert.AreEqual(TextConvert.Hebrew.ConvertEnglishToHebrew(englishInput), hebrewOutput);
        }

        [TestMethod]
        public void TestMultipleCharactersNotAllExistingConvert()
        {
            var englishInput = "ABCDEFG asd 1223$%^^$";
            var hebrewOutput = "שנבגקכע שדג 1223$%^^$";

            Assert.AreEqual(TextConvert.Hebrew.ConvertEnglishToHebrew(englishInput), hebrewOutput);
        }
    }
}
