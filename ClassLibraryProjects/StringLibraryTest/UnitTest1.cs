using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UtilityLibraries;
using System.Linq;

namespace StringLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartsWithUpper()
        {
            string[] words = { "Alphabet", "Zebra", "ABC", "Αθήνα", "Москва" };

            foreach (var (word, result) in from string word in words
                                           let result = word.StartsWithUpper()
                                           select (word, result))
            {
                Assert.IsTrue(result, $"Expected for '{word}': true; Actual: {result}");
            }
        }

        [TestMethod]
        public void TestDoesNotStartWithUpper()
        {
            // Tests that we expect to return false.
            string[] words = { "alphabet", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                               "1234", ".", ";", " " };
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool result = word.StartsWithUpper();

                Assert.IsFalse(result,
                       String.Format("Expected for '{0}': false; Actual: {1}",
                                     word, result));
            }
        }

        [TestMethod]
        public void DirectCallWithNullOrEmpty()
        {
            // Tests that we expect to return false.
            string[] words = { string.Empty, null };

            foreach (var word in words)
            {
                bool result = StringLibrary.StartsWithUpper(word);
                Assert.IsFalse(result,
                       String.Format("Expected for '{0}': false; Actual: {1}",
                                     word ?? "<null>", result));
            }
        }
    }
}
