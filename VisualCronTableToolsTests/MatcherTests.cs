using System;
using VisualCronTableTools.Tools;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class MatcherTests
	{
        [TestMethod]
        public void TestFindIn()
        {
            //Arrange
            string searchTerm = "To-";
            string itemToSearchTrue = "From here To- there";
            string itemToSearchFalse = "From here to there";

            //Act
            bool expectedTrue = Matcher.FindIn(searchTerm, itemToSearchTrue);
            bool expectedFalse = Matcher.FindIn(searchTerm, itemToSearchFalse);

            //Assert
            Assert.IsTrue(expectedTrue);
            Assert.IsFalse(expectedFalse);
        }

        [TestMethod]
        public void TestFindEquals()
        {
            //Arrange
            string searchTerm = "42";
            string itemToSearchTrue = "42";
            string itemToSearchFalse = "421";

            //Act
            bool expectedTrue = Matcher.findEquals(searchTerm, itemToSearchTrue);
            bool expectedFalse = Matcher.findEquals(searchTerm, itemToSearchFalse);

            //Assert
            Assert.IsTrue(expectedTrue);
            Assert.IsFalse(expectedFalse);
        }

        [TestMethod]
        public void TestStartsWith()
        {
            //Arrange
            string searchTerm = "42";
            string itemToSearchTrue = "42554654";
            string itemToSearchFalse = "-42554654";

            //Act
            bool expectedTrue = Matcher.findStartsWith(searchTerm, itemToSearchTrue);
            bool expectedFalse = Matcher.findStartsWith(searchTerm, itemToSearchFalse);

            //Assert
            Assert.IsTrue(expectedTrue);
            Assert.IsFalse(expectedFalse);
        }

        [TestMethod]
        public void TestEndsWith()
        {
            //Arrange
            string searchTerm = "42";
            string itemToSearchTrue = "425546542";
            string itemToSearchFalse = "42554654 2";

            //Act
            bool expectedTrue = Matcher.findEndsWith(searchTerm, itemToSearchTrue);
            bool expectedFalse = Matcher.findEndsWith(searchTerm, itemToSearchFalse);

            //Assert
            Assert.IsTrue(expectedTrue);
            Assert.IsFalse(expectedFalse);
        }
    }
}

