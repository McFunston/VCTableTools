using System;
namespace VisualCronTableTools.Models
{
	public class TableCell
	{
		public string Value { get; set; }
		public string ColumnLetter { get; set; }
		public int ColumnNumber { get; set; }
		public int RowNumber { get; set; }
		public string ColumnHeader { get; set; }
		public string ExcelAddress { get { return ColumnLetter + RowNumber; } } //A2, B17, etc.                                                                                

        public TableCell()
		{
		}
	}
}

