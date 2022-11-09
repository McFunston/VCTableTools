using System;
using ClosedXML.Excel;
using System.Collections.Generic;

namespace VisualCronTableTools.Tools
{
	public interface ITableFinder
	{
        public delegate bool Matcher(string searchTerm, string itemToSearch);

        public FindResponse FindAll(string searchTerm, string column, Matcher matcher); //Find all where the cell in "column" matches searchTerm
        public FindResponse FindFirst(string searchTerm, string column, Matcher matcher); //Same as FindAll but returns the first row found
        public FindResponse FindAllWithout(string searchTerm, string column, string killColumn, Matcher matcher); //Find all where the cell in "column" matches searchTerm but the killColumn is empty
        public FindResponse FindFirstWithout(string searchTerm, string column, string killColumn, Matcher matcher);
        public FindResponse FindAllBoth(string searchTerm1, string column1, string searchTerm2, string column2, Matcher matcher); //FindAll but with two columns to be matched
        public FindResponse FindFirstBoth(string searchTerm1, string column1, string searchTerm2, string column2, Matcher matcher);
    }
}

