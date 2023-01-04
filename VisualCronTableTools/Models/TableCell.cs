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
        /// <summary>
        /// The contents of the cell as a string.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// The column letter of the cell as if it were an Excel file (A,B,C etc.)
        /// </summary>
        public string ColumnLetter { get; set; }
        /// <summary>
        /// The 1-based index of the column of the cell.
        /// </summary>
        public int ColumnNumber { get; set; }
        /// <summary>
        /// The 1-based index of the row of the cell.
        /// </summary>
        public int RowNumber { get; set; }
        /// <summary>
        /// The column header (if applicable) for the cell. If the file does not have column headers this should be ignored as it will simply take the first row value and turn it into a 'column header'.
        /// </summary>
        public string ColumnHeader { get; set; }
        /// <summary>
        /// The Excel Address of the cell (ie. 'A5')
        /// </summary>
        public string ExcelAddress { get { return ColumnLetter + RowNumber; } set { } } //A2, B17, etc.                                                                                

        internal TableCell()
		{
		}

		internal TableCell(string value, string columnLetter, int columnNumber, int rowNumber, string columnHeader)
		{
			Value = value;
			ColumnLetter = columnLetter;
			ColumnNumber = columnNumber;
			RowNumber = rowNumber;
			ColumnHeader = columnHeader;			
		}
    }
}

