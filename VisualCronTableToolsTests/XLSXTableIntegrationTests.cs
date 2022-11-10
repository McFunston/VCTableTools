using System;
using System.IO;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools.XLSX;

namespace VisualCronTableToolsTests
{
    [TestClass]
    public class XLSXTableIntegrationTests
	{
        [TestMethod]        
        public void TestGetWorkSheet()
        {
            //Arrange
            string path = Path.GetFullPath("TestData/Jobs.xlsx");

            //Act
            XLSXTable xLSXTable = new XLSXTable(path, "Sheet");

            //Assert
            Assert.IsNotNull(xLSXTable);
        }

        [TestMethod]
        public void TestTableListDictionary()
        {
            //Arrange
            string path = Path.GetFullPath("TestData/Jobs.xlsx");

            //Act
            XLSXTable xLSXTable = new XLSXTable(path, "Sheet");
            TableListDictionary tableListDictionary = xLSXTable.tableListDictionary;

            //Assert
            Assert.IsNotNull(tableListDictionary);
        }

    }
}

