using System;
using System.IO;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools.XLSX;
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
            string path = Path.GetFullPath("TestData/Jobs.xls");

            //Act
            XLSTable xLSTable = new XLSTable(path, "Sheet");

            //Assert
            Assert.IsNotNull(xLSTable);
        }

        [TestMethod]
        public void TestTableListDictionary()
        {
            //Arrange
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            string path = Path.GetFullPath("TestData/Jobs.xls");

            //Act
            XLSTable xLSTable = new XLSTable(path, "Sheet");
            TableListDictionary tableListDictionary = xLSTable.tableListDictionary;

            //Assert
            Assert.IsNotNull(tableListDictionary);
        }
    }
}

