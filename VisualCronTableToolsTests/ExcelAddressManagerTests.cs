using System;
using VisualCronTableTools;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class ExcelAddressManagerTests
	{
		[TestMethod]
		public void TestGetRow()
		{
			//Arrange
			string address = "CA155";
			string expected = "155";

			//Act
			string actual = ExcelAddressManager.GetRow(address);

			//Assert
			Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGetColumn()
        {
            //Arrange
            string address = "CA155";
            string expected = "CA";

            //Act
            string actual = ExcelAddressManager.GetColumn(address);

            //Assert
            Assert.AreEqual(expected, actual);

        }

    }
}

