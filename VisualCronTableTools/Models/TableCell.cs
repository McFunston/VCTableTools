using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace VisualCronTableTools.Models
{
    /// <summary>
    /// VisualCronTableTools' representation of a 'cell'.
    /// </summary>
    public class TableCell
    {
        public string Value { get; set; }
        public string ColumnLetter { get; set; }
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }
        public string ColumnHeader { get; set; }
        public string ExcelAddress { get { return ColumnLetter + RowNumber; } set { } } //A2, B17, etc.                                                                                

        public TableCell()
		{
		}

		public TableCell(string value, string columnLetter, int columnNumber, int rowNumber, string columnHeader)
		{
			Value = value;
			ColumnLetter = columnLetter;
			ColumnNumber = columnNumber;
			RowNumber = rowNumber;
			ColumnHeader = columnHeader;			
		}
    }
}

