using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VisualCronTableTools.Tools;

namespace VisualCronTableTools.Models
{
    [Serializable()]
    public class TableListDictionary: ITableFinder, ISerializable
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
                    findResponse.Rows.Add(row);
                    findResponse.Addresses.Add(row[column].ExcelAddress);
                }
            };
            string message = findResponse.Rows.ListDictionary.Count.ToString() + " match(es) found.";
            findResponse.Message = message;
            return findResponse;
        }

        public FindResponse FindFirst(string searchTerm, string column, MatcherDelegate matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindAllWithout(string searchTerm, string column, string killColumn, MatcherDelegate matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindFirstWithout(string searchTerm, string column, string killColumn, MatcherDelegate matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindAllBoth(string searchTerm1, string column1, string searchTerm2, string column2, MatcherDelegate matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindFirstBoth(string searchTerm1, string column1, string searchTerm2, string column2, MatcherDelegate matcher)
        {
            throw new NotImplementedException();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ListDictionary", ListDictionary);
        }
    }
}

