using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using VisualCronTableTools;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools;

namespace VisualCronTableToolsTests;

[TestClass]
public class TableListDictionaryTests
{
    public Dictionary<string, TableCell> MakeSampleRow()
    {        
        Dictionary<string, TableCell> row1 = new Dictionary<string, TableCell>();
        TableCell tableCell1 = new TableCell("Ottawa", "A", 1, 2, "City");
        TableCell tableCell2 = new TableCell("994837", "B", 2, 2, "Population");
        TableCell tableCell3 = new TableCell("City", "C", 3, 2, "Municipality Type");

        row1.Add("A", tableCell1);
        row1.Add("B", tableCell2);
        row1.Add("C", tableCell3);
        return row1;
    }

    public Dictionary<string, TableCell> MakeSampleRow2()
    {
        Dictionary<string, TableCell> row1 = new Dictionary<string, TableCell>();
        TableCell tableCell1 = new TableCell("Toronto", "A", 1, 3, "City");
        TableCell tableCell2 = new TableCell("2930000", "B", 2, 3, "Population");
        TableCell tableCell3 = new TableCell("City", "C", 3, 3, "Municipality Type");

        row1.Add("A", tableCell1);
        row1.Add("B", tableCell2);
        row1.Add("C", tableCell3);
        return row1;
    }

    public Dictionary<string, TableCell> MakeSampleRow3()
    {
        Dictionary<string, TableCell> row1 = new Dictionary<string, TableCell>();
        TableCell tableCell1 = new TableCell("Lanark", "A", 1, 4, "City");
        TableCell tableCell2 = new TableCell("800", "B", 2, 4, "Population");
        TableCell tableCell3 = new TableCell("Village", "C", 3, 4, "Municipality Type");

        row1.Add("A", tableCell1);
        row1.Add("B", tableCell2);
        row1.Add("C", tableCell3);
        return row1;
    }

    public Dictionary<string, TableCell> MakeSampleRow4()
    {
        Dictionary<string, TableCell> row1 = new Dictionary<string, TableCell>();
        TableCell tableCell1 = new TableCell("Perth", "A", 1, 5, "City");
        TableCell tableCell2 = new TableCell("5930", "B", 2, 5, "Population");
        TableCell tableCell3 = new TableCell("", "C", 3, 5, "Municipality Type");

        row1.Add("A", tableCell1);
        row1.Add("B", tableCell2);
        row1.Add("C", tableCell3);
        return row1;
    }

    public Dictionary<string, TableCell> MakeSampleRow5()
    {
        Dictionary<string, TableCell> row1 = new Dictionary<string, TableCell>();
        TableCell tableCell1 = new TableCell("Carleton Place", "A", 1, 6, "City");
        TableCell tableCell2 = new TableCell("5930", "B", 2, 6, "Population");
        TableCell tableCell3 = new TableCell("", "C", 3, 6, "Municipality Type");

        row1.Add("A", tableCell1);
        row1.Add("B", tableCell2);
        row1.Add("C", tableCell3);
        return row1;
    }

    public TableListDictionary MakeSampleTableListDictionary()
    {
        TableListDictionary tableListDictionary = new TableListDictionary();

        tableListDictionary.Add(MakeSampleRow());
        tableListDictionary.Add(MakeSampleRow2());
        tableListDictionary.Add(MakeSampleRow3());
        tableListDictionary.Add(MakeSampleRow4());
        tableListDictionary.Add(MakeSampleRow5());

        return tableListDictionary;
    }

    [TestMethod]
    public void TestAdd()
    {
        //Arrange
        TableListDictionary tableListDictionary = new TableListDictionary();
        Dictionary<string, TableCell> row = MakeSampleRow(); 
        //TableCell tableCell1 = new TableCell();        

        //Act
        tableListDictionary.Add(row);

        //Assert
        Assert.IsTrue(tableListDictionary.ListDictionary[0]["A"].Value == "Ottawa");
    }

    [TestMethod]
    public void TestFindAll()
    {
        //Arrange
        TableListDictionary tableListDictionary=MakeSampleTableListDictionary();

        //Act
        var findResult = tableListDictionary.FindAll("City", "C", Matcher.findEquals);

        //Assert
        Assert.IsTrue(findResult.Success = true);
        
    }

    [TestMethod]
    public void TestFindFirst()
    {
        //Arrange
        TableListDictionary tableListDictionary = MakeSampleTableListDictionary();
        string expected = "C2";
        int expectedCount = 1;

        //Act
        var findResult = tableListDictionary.FindFirst("City", "C", Matcher.findEquals);
        string actual = findResult.Addresses[0];
        int actualCount = findResult.Addresses.Count();

        //Assert
        Assert.AreEqual(actual, expected);
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void FindAllWithout()
    {
        //Arrange
        TableListDictionary tableListDictionary = MakeSampleTableListDictionary();
        string expected = "B5";
        int expectedCount = 2;

        //Act
        var findResult = tableListDictionary.FindAllWithout("5930", "B", "C", Matcher.findEquals);
        string actual = findResult.Addresses[0];
        int actualCount = findResult.Addresses.Count();

        //Assert
        Assert.AreEqual(actual, expected);
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void FindFirstWithout()
    {
        //Arrange
        TableListDictionary tableListDictionary = MakeSampleTableListDictionary();
        string expected = "B5";
        int expectedCount = 1;

        //Act
        var findResult = tableListDictionary.FindFirstWithout("5930", "B", "C", Matcher.findEquals);
        string actual = findResult.Addresses[0];
        int actualCount = findResult.Addresses.Count();

        //Assert
        Assert.AreEqual(actual, expected);
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void TestSerialize()
    {
        //Arrange
        MemoryStream mem = new MemoryStream();
        XmlSerializer serializer = new XmlSerializer(typeof(FindResponse));        
        TableListDictionary tableListDictionary = MakeSampleTableListDictionary();
        FindResponse findResponse = tableListDictionary.FindAll("City", "C", Matcher.findEquals);
        
        //Act
        try
        {
            serializer.Serialize(mem, findResponse);            
        }
        catch (Exception ex)
        {
            Assert.Fail(ex.Message);
        }
    }

    [TestMethod]
    public void TestTableCellToString()
    {
        //Arrange
        TableListDictionary tableListDictionary = MakeSampleTableListDictionary();

        //Act
        var findResult = tableListDictionary.FindAll("City", "C", Matcher.findEquals);

        //Assert
        Assert.AreEqual(findResult.ToString(), "C2,C3");
    }
}

