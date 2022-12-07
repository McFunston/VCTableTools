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
    }
}

