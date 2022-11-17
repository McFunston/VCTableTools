using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using VisualCronTableTools.Tools;

namespace VisualCronTableTools.Models
{
    
    public class TableListDictionary: ITableFinder
    {
		// A list of dictionaries where the list represents the rows, the dictionary keys are the column letters (A, B, C, etc.) and the values are the cell values as strings.

        public List<Dictionary<string, TableCell>> ListDictionary { get; set; }

        public delegate bool MatcherDelegate(string searchTerm, string itemToSearch);

        public TableListDictionary()
		{
			ListDictionary = new List<Dictionary<string, TableCell>>();
		}

		public void Add(Dictionary<string, TableCell> row)
		{
			ListDictionary.Add(row);
		}

        public FindResponse FindAll(string searchTerm, string column, MatcherDelegate matcher)
        {
            FindResponse findResponse = new FindResponse();

            foreach (var row in ListDictionary)
            {
                //if (row[column].Value == searchTerm)
                if (matcher(searchTerm, row[column].Value))
                {
                    findResponse.Success = true;
                    List<TableCell> tableCells = row.Values.ToList();

                    findResponse.Rows.Add(tableCells);
                    findResponse.Addresses.Add(row[column].ExcelAddress);
                }
            };
            string message = findResponse.Rows.Count.ToString() + " match(es) found.";
            findResponse.Message = message;
            return findResponse;
        }

        public FindResponse FindFirst(string searchTerm, string column, MatcherDelegate matcher)
        {
            FindResponse findResponse = new FindResponse();

            foreach (var row in ListDictionary)
            {
                //if (row[column].Value == searchTerm)
                if (matcher(searchTerm, row[column].Value)&&findResponse.Success==false)
                {
                    findResponse.Success = true;
                    List<TableCell> tableCells = row.Values.ToList();

                    findResponse.Rows.Add(tableCells);
                    findResponse.Addresses.Add(row[column].ExcelAddress);
                }
            };
            string message = findResponse.Rows.Count.ToString() + " match(es) found.";
            findResponse.Message = message;
            return findResponse;
        }

        public FindResponse FindAllWithout(string searchTerm, string column, string killColumn, MatcherDelegate matcher)
        {
            FindResponse findResponse = new FindResponse();

            foreach (var row in ListDictionary)
            {
                //if (row[column].Value == searchTerm)
                if (matcher(searchTerm, row[column].Value) && row[killColumn].Value=="")
                {
                    findResponse.Success = true;
                    List<TableCell> tableCells = row.Values.ToList();

                    findResponse.Rows.Add(tableCells);
                    findResponse.Addresses.Add(row[column].ExcelAddress);
                }
            };
            string message = findResponse.Rows.Count.ToString() + " match(es) found.";
            findResponse.Message = message;
            return findResponse;
        }

        public FindResponse FindFirstWithout(string searchTerm, string column, string killColumn, MatcherDelegate matcher)
        {
            FindResponse findResponse = new FindResponse();

            foreach (var row in ListDictionary)
            {
                //if (row[column].Value == searchTerm)
                if (matcher(searchTerm, row[column].Value) && row[killColumn].Value == "" && findResponse.Success==false)
                {
                    findResponse.Success = true;
                    List<TableCell> tableCells = row.Values.ToList();

                    findResponse.Rows.Add(tableCells);
                    findResponse.Addresses.Add(row[column].ExcelAddress);
                }
            };
            string message = findResponse.Rows.Count.ToString() + " match(es) found.";
            findResponse.Message = message;
            return findResponse;
        }

        public FindResponse FindAllBoth(string searchTerm1, string column1, string searchTerm2, string column2, MatcherDelegate matcher)
        {
            FindResponse findResponse = new FindResponse();

            foreach (var row in ListDictionary)
            {
                //if (row[column].Value == searchTerm)
                if (matcher(searchTerm1, row[column1].Value) && matcher(searchTerm2, row[column2].Value))
                {
                    findResponse.Success = true;
                    List<TableCell> tableCells = row.Values.ToList();

                    findResponse.Rows.Add(tableCells);
                    findResponse.Addresses.Add(row[column1].ExcelAddress);
                }
            };
            string message = findResponse.Rows.Count.ToString() + " match(es) found.";
            findResponse.Message = message;
            return findResponse;
        }

        public FindResponse FindFirstBoth(string searchTerm1, string column1, string searchTerm2, string column2, MatcherDelegate matcher)
        {
            throw new NotImplementedException();
        }


    }
}

