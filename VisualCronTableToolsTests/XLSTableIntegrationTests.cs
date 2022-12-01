using System;
using System.IO;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools.XLS;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class XLSTableIntegrationTests
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

