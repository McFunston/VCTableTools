using VisualCronTableTools.Models;

namespace VisualCronTableToolsTests;

[TestClass]
public class TableListDictionaryTests
{
    [TestMethod]
    public void TestAdd()
    {
        //Arrange
        TableListDictionary tableListDictionary = new TableListDictionary();
        Dictionary<string, string> row = new Dictionary<string, string>();
        row.Add("A", "Ottawa");
        row.Add("B", "Toronto");

        //Act
        tableListDictionary.Add(row);

        //Assert
        Assert.IsTrue(tableListDictionary.ListDictionary[0]["A"] == "Ottawa");
    }
}

