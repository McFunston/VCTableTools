using System;
using System.IO;
using VisualCronTableTools;
using VisualCronTableTools.Models;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class TableSearcherIntegrationTests
	{
        [TestMethod]
        public void TestFindAllExact()
        {
            //Arrange
            int expected = 139;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindAllExact(pathXLSX, "sheet1", "C", "United States of America").Rows.Count;
            var actualXls = TableSearcher.FindAllExact(pathXLS, "sheet1", "C", "United States of America").Rows.Count;
            var actualCsv = TableSearcher.FindAllExact(pathCSV, "", "C", "United States of America").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

    }
}

