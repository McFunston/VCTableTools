using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace VisualCronTableTools.Models
{

    public class TableCell
    {
        [XmlElement(ElementName = "Cell Content")]
        public string Value { get; set; }
        [XmlElement(ElementName = "Column Letter")]
        public string ColumnLetter { get; set; }
        [XmlElement(ElementName = "Column Number")]
        public int ColumnNumber { get; set; }
        [XmlElement(ElementName = "Row Number")]
        public int RowNumber { get; set; }
        [XmlElement(ElementName = "Column Header")]
        public string ColumnHeader { get; set; }
        [XmlElement(ElementName = "Excel Address")]
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

