using System;
using System.Collections.Generic;

namespace VisualCronTableTools.Models
{
	public class TableListDictionary
	{
		// A list of dictionaries where the list represents the rows, the dictionary keys are the column letters (A, B, C, etc.) and the values are the cell values as strings.

        public List<Dictionary<string, TableCell>> ListDictionary { get; set; }

        public TableListDictionary()
		{
			ListDictionary = new List<Dictionary<string, TableCell>>();
		}

		public void Add(Dictionary<string, TableCell> row)
		{
			ListDictionary.Add(row);
		}

	}
}

