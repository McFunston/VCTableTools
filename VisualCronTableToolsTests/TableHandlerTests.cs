using System;
using VisualCronTableTools;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class TableHandlerTests
	{
        [TestMethod]
        public void TestGetAllData()
        {
            //Arrange
            int expected = 701;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");
                        
            //Act
            var actualXlsx = TableHandler.GetAllData(pathXLSX, "sheet1").Rows.Count;
            var actualXls = TableHandler.GetAllData(pathXLS, "sheet1").Rows.Count;
            var actualCsv = TableHandler.GetAllData(pathCSV, "").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }
    }
}

