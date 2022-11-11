using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using VisualCronTableTools.Models;

namespace VisualCronTableTools.Tools.XLSX
{
	public class XLSXTable
    {
        /* A Microsoft Office Open XML format table */
        IXLWorksheet Worksheet;

        public TableListDictionary tableListDictionary { get; set; }

        public XLSXTable(string path, string sheetName)
        {
            Worksheet = GetWorksheet(path, sheetName);
            tableListDictionary = GetTableListDictionary(Worksheet);
        }
        
        private TableListDictionary GetTableListDictionary(IXLWorksheet sheet)
        {
            List<String> columnNames = new List<string>();
            int startRow = 1;
            TableListDictionary tableDict = new TableListDictionary();

            foreach (IXLCell cell in sheet.RangeUsed().FirstRow().CellsUsed())
            {
                columnNames.Add(cell.WorksheetColumn().ColumnLetter());
            }

            for (int r = startRow; r < sheet.RangeUsed().RowCount(); r++)
            {
                Dictionary<string, string> rowDict = new Dictionary<string, string>();
                for (int i = 0; i < columnNames.Count; i++)
                {
                    rowDict.Add(columnNames[i], sheet.Row(r).Cell(i + 1).Value.ToString());
                }
                tableDict.Add(rowDict);
            }
            return tableDict;
        }

        private IXLWorksheet GetWorksheet(string path, string sheetName)
		{
            var workbook = new XLWorkbook(path);
            IXLWorksheet sheet = workbook.Worksheet(sheetName);

            return sheet;
        }

    }
}

