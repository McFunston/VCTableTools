using System;
using ClosedXML.Excel;
using System.Collections.Generic;
using static VisualCronTableTools.Models.TableListDictionary;

namespace VisualCronTableTools.Tools
{
	public interface ITableFinder
	{
        //public delegate bool Matcher(string searchTerm, string itemToSearch);

        FindResponse FindAll(string searchTerm, string column, MatcherDelegate matcher); //Find all where the cell in "column" matches searchTerm
        FindResponse FindFirst(string searchTerm, string column, MatcherDelegate matcher); //Same as FindAll but returns the first row found
        FindResponse FindAllWithout(string searchTerm, string column, string killColumn, MatcherDelegate matcher); //Find all where the cell in "column" matches searchTerm but the killColumn is empty
        FindResponse FindFirstWithout(string searchTerm, string column, string killColumn, MatcherDelegate matcher);
        FindResponse FindAllBoth(string searchTerm1, string column1, string searchTerm2, string column2, MatcherDelegate matcher); //FindAll but with two columns to be matched
        FindResponse FindFirstBoth(string searchTerm1, string column1, string searchTerm2, string column2, MatcherDelegate matcher);
    }
}

