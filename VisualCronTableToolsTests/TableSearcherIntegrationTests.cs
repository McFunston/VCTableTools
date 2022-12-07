using System;
using System.IO;
using System.Xml.Serialization;
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
        public void TestGetFromXML()
        {
            //Arrange
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathXLS = Path.GetFullPath("TestData/Financial Sample.xls");
            FindResponse findResponse = TableSearcher.FindExact(pathXLS, "sheet1", "E", "None");
            XmlSerializer serializer = new XmlSerializer(typeof(FindResponse));
            StringWriter stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, findResponse);
            string xmlString = stringWriter.ToString();
            string expected = "2014";

            //Act
            TableListDictionary tableListDictionary = new TableListDictionary(xmlString);
            var keys = tableListDictionary.ListDictionary[52].Keys;
            string actual = tableListDictionary.ListDictionary[52]["Q"].Value;

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestGetFromCSVString()
        {
            //Arrange
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string pathCSV = Path.GetFullPath("TestData/Financial Sample.csv");
            string csvString = File.ReadAllText(pathCSV);

            //Act
            TableListDictionary tableListDictionary = new TableListDictionary(csvString);

            //Assert
            Assert.IsNotNull(tableListDictionary);
        }

    }
}

