using System;
using System.Runtime.Serialization;

namespace VisualCronTableTools.Models
{
	public class TableCell: ISerializable
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

		public TableCell(string value, string columnLetter, int columnNumber, int rowNumber, string columnHeader)
		{
			Value = value;
			ColumnLetter = columnLetter;
			ColumnNumber = columnNumber;
			RowNumber = rowNumber;
			ColumnHeader = columnHeader;			
		}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", Value);
			info.AddValue("ColumnLetter", ColumnLetter);
			info.AddValue("ColumnNumber", ColumnNumber);
			info.AddValue("RowNumber", RowNumber);
			info.AddValue("ExcelAddress", ExcelAddress);
        }
    }
}

