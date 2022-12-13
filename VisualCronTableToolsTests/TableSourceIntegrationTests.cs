using System;
using System.IO;
using System.Xml.Serialization;
using VisualCronTableTools;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools.XLS;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class TableSourceIntegrationTests
	{
        [TestMethod]
        public void TestGetWorkSheet()
        {
            //Arrange
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string path = Path.GetFullPath("TestData/Financial Sample.xls");

            //Act
            TableSource xLSTable = new TableSource(path, "Sheet1");

            //Assert
            Assert.IsNotNull(xLSTable);
        }

        [TestMethod]
        public void TestGetXMLFromString()
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
            TableSource tableSource = new TableSource(xmlString);
            TableListDictionary tableListDictionary = tableSource.tableListDictionary;
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
            TableSource tableSource = new TableSource(csvString);
            TableListDictionary tableListDictionary = tableSource.tableListDictionary;

            //Assert
            Assert.IsNotNull(tableListDictionary);
        }

        [TestMethod]
        public void TestTableListDictionary()
        {
            //Arrange
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string path = Path.GetFullPath("TestData/Financial Sample.xls");

            //Act
            TableSource xLSTable = new TableSource(path, "Sheet1");
            TableListDictionary tableListDictionary = xLSTable.tableListDictionary;

            //Assert
            Assert.IsNotNull(tableListDictionary);
        }
    }
}

