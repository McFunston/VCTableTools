using System;
using System.IO;
using System.Xml.Serialization;
using VisualCronTableTools;
using VisualCronTableTools.Models;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class TableSearcherTests
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
            var actualXlsx = TableSearcher.FindExact(pathXLSX, "sheet1", "C", "United States of America").Rows.Count;
            var actualXls = TableSearcher.FindExact(pathXLS, "sheet1", "C", "United States of America").Rows.Count;
            var actualCsv = TableSearcher.FindExact(pathCSV, "", "C", "United States of America").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindAllIn()
        {
            //Arrange
            int expected = 140;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindIn(pathXLSX, "sheet1", "C", "United").Rows.Count;
            var actualXls = TableSearcher.FindIn(pathXLS, "sheet1", "C", "United").Rows.Count;
            var actualCsv = TableSearcher.FindIn(pathCSV, "", "C", "United").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindStartsWith()
        {
            //Arrange
            int expected = 105;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindStartsWith(pathXLSX, "sheet1", "P", "Dec").Rows.Count;
            var actualXls = TableSearcher.FindStartsWith(pathXLS, "sheet1", "P", "Dec").Rows.Count;
            var actualCsv = TableSearcher.FindStartsWith(pathCSV, "", "P", "Dec").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindEndsWith()
        {
            //Arrange
            int expected = 139;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindEndsWith(pathXLSX, "sheet1", "C", "America").Rows.Count;
            var actualXls = TableSearcher.FindEndsWith(pathXLS, "sheet1", "C", "America").Rows.Count;
            var actualCsv = TableSearcher.FindEndsWith(pathCSV, "", "C", "America").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

    }
}

