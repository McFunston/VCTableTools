using VisualCronTableTools.Models;

namespace VisualCronTableToolsTests;

[TestClass]
public class TableListDictionaryTests
{
    public Dictionary<string, TableCell> MakeSampleRow()
    {        
        Dictionary<string, TableCell> row1 = new Dictionary<string, TableCell>();
        TableCell tableCell1 = new TableCell();
        TableCell tableCell2 = new TableCell();

        tableCell1.ColumnHeader = "City";
        tableCell1.ColumnLetter = "A";
        tableCell1.RowNumber = 2;
        tableCell1.ColumnNumber = 1;
        tableCell1.Value = "Ottawa";

        tableCell2.ColumnHeader = "Population";
        tableCell2.ColumnLetter = "B";
        tableCell2.RowNumber = 2;
        tableCell2.ColumnNumber = 2;
        tableCell2.Value = "994837";

        row1.Add("A", tableCell1);
        row1.Add("B", tableCell2);
        return row1;
    }

    [TestMethod]
    public void TestAdd()
    {
        //Arrange
        TableListDictionary tableListDictionary = new TableListDictionary();
        Dictionary<string, TableCell> row;
        TableCell tableCell1 = new TableCell();
        row = MakeSampleRow();

        //Act
        tableListDictionary.Add(row);

        //Assert
        Assert.IsTrue(tableListDictionary.ListDictionary[0]["A"].Value == "Ottawa");
    }
}

