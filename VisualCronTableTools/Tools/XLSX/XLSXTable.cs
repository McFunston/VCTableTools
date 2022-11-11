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
            List<String> columnLetters = new List<string>();
            int startRow = 1;
            TableListDictionary tableDict = new TableListDictionary();
            List<String> columnNames = new List<string>();

            foreach (var cell in sheet.RangeUsed().FirstRow().CellsUsed())
            {
                columnNames.Add(cell.GetValue<String>());
            }

            foreach (IXLCell cell in sheet.RangeUsed().FirstRow().CellsUsed())
            {
                columnLetters.Add(cell.WorksheetColumn().ColumnLetter());
            }

            for (int r = startRow; r < sheet.RangeUsed().RowCount(); r++)
            {
                Dictionary<string, TableCell> rowDict = new Dictionary<string, TableCell>();
                for (int i = 0; i < columnLetters.Count; i++)
                {
                    TableCell tableCell = new TableCell();
                    tableCell.RowNumber = r;
                    tableCell.ColumnNumber = i + 1;
                    tableCell.ColumnLetter = columnLetters[i];
                    tableCell.ColumnHeader = columnNames[i];
                    tableCell.Value = sheet.Row(r).Cell(i + 1).Value.ToString();
                    //rowDict.Add(columnLetters[i], sheet.Row(r).Cell(i + 1).Value.ToString());
                    rowDict.Add(columnLetters[i], tableCell);
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

