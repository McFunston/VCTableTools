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
            var actualXlsx = TableSearcher.FindAllIn(pathXLSX, "sheet1", "C", "United").Rows.Count;
            var actualXls = TableSearcher.FindAllIn(pathXLS, "sheet1", "C", "United").Rows.Count;
            var actualCsv = TableSearcher.FindAllIn(pathCSV, "", "C", "United").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindFirstExact()
        {
            //Arrange
            int expected = 348; //Row number of first instance of United Arab Emirates
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindFirstExact(pathXLSX, "sheet1", "C", "United Arab Emirates").Rows[0][0].RowNumber;
            var actualXls = TableSearcher.FindFirstExact(pathXLS, "sheet1", "C", "United Arab Emirates").Rows[0][0].RowNumber;
            var actualCsv = TableSearcher.FindFirstExact(pathCSV, "", "C", "United Arab Emirates").Rows[0][0].RowNumber;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindFirstIn()
        {
            //Arrange
            int expected = 17; //Row number of first instance of United States of America
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindFirstIn(pathXLSX, "sheet1", "C", "United").Rows[0][0].RowNumber;
            var actualXls = TableSearcher.FindFirstIn(pathXLS, "sheet1", "C", "United").Rows[0][0].RowNumber;
            var actualCsv = TableSearcher.FindFirstIn(pathCSV, "", "C", "United").Rows[0][0].RowNumber;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindAllExactWithout()
        {
            //Arrange
            int expected = 12; //The number of rows that have Canada in Column C and an empty column J
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindAllExactWithout(pathXLSX, "sheet1", "C", "Canada", "J").Rows.Count;
            var actualXls = TableSearcher.FindAllExactWithout(pathXLS, "sheet1", "C", "Canada", "J").Rows.Count;
            var actualCsv = TableSearcher.FindAllExactWithout(pathCSV, "", "C", "Canada", "J").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindAllInWithout()
        {
            //Arrange
            int expected = 2; //The number of rows that have .5 in Column I and an empty column J
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindAllInWithout(pathXLSX, "sheet1", "I", ".5", "J").Rows.Count;
            var actualXls = TableSearcher.FindAllInWithout(pathXLS, "sheet1", "I", ".5", "J").Rows.Count;
            var actualCsv = TableSearcher.FindAllInWithout(pathCSV, "", "I", ".5", "J").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindFirstExactWithout()
        {
            //Arrange
            string expected = "Carretera"; //The value in Column D in the first row where Column C is Mexico and Column J is empty
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindFirstExactWithout(pathXLSX, "sheet1", "C", "Mexico", "J").Rows[0][3].Value;
            var actualXls = TableSearcher.FindFirstExactWithout(pathXLS, "sheet1", "C", "Mexico", "J").Rows[0][3].Value;
            var actualCsv = TableSearcher.FindFirstExactWithout(pathCSV, "", "C", "Mexico", "J").Rows[0][3].Value;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindFirstInWithout()
        {
            //Arrange
            string expected = "Canada"; //The value in Column C where Column K has .5 in it column J is empty
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindFirstInWithout(pathXLSX, "sheet1", "K", ".5", "J").Rows[0][2].Value;
            var actualXls = TableSearcher.FindFirstInWithout(pathXLS, "sheet1", "K", ".5", "J").Rows[0][2].Value;
            var actualCsv = TableSearcher.FindFirstInWithout(pathCSV, "", "K", ".5", "J").Rows[0][2].Value;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

        [TestMethod]
        public void TestFindAllBothExact()
        {
            //Arrange
            int expected = 42; //The number of rows that have Canada in Column C and Paseo in Column D
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLSX = Path.GetFullPath("TestData/Financial Sample.xlsx");
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");

            //Act
            var actualXlsx = TableSearcher.FindAllBothExact(pathXLSX, "sheet1", "C", "Canada", "D", "Paseo").Rows.Count;
            var actualXls = TableSearcher.FindAllBothExact(pathXLS, "sheet1", "C", "Canada", "D", "Paseo").Rows.Count;
            var actualCsv = TableSearcher.FindAllBothExact(pathCSV, "", "C", "Canada", "D", "Paseo").Rows.Count;

            //Assert
            Assert.AreEqual(expected, actualXlsx);
            Assert.AreEqual(expected, actualXls);
            Assert.AreEqual(expected, actualCsv);
        }

    }
}

