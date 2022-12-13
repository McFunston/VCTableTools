using System;
using System.Data;
using ExcelDataReader;
using System.IO;
using VisualCronTableTools.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Collections.Specialized;
using VisualCronTableTools.Tools.XML;

namespace VisualCronTableTools.Tools.XLS
{
	public class TableSource
	{
        public TableListDictionary tableListDictionary { get; set; }

        private string ColumnIndexToColumnLetter(int colIndex)
        {
            int div = colIndex;
            string colLetter = String.Empty;
            int mod = 0;

            while (div > 0)
            {
                mod = (div - 1) % 26;
                colLetter = (char)(65 + mod) + colLetter;
                div = (int)((div - mod) / 26);
            }
            return colLetter;
        }

        public TableSource(string path, string sheetName)
        {
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var dataTable = ReadExcel(path, sheetName);
            tableListDictionary = GetTableListDictionary(dataTable);
        }

        public TableSource(string xmlOrCsv)
        {
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if (xmlOrCsv.StartsWith("<?xml version=")) //If it's xml data
            {
                tableListDictionary = GetTableListDictionary(xmlOrCsv);
            }
            else //If it's coma separated data
            {
                var dataTable = ReadCSVFromString(xmlOrCsv);
                tableListDictionary = GetTableListDictionary(dataTable);                
            }               
            
        }

        private TableListDictionary GetTableListDictionary(DataTable sheet)
        {
            TableListDictionary tableDict = new TableListDictionary();
            List<String> columnLetters = new List<string>();
            List<String> columnNames = new List<string>();

            for (int i = 0; i < sheet.Columns.Count; i++)
            {
                columnLetters.Add(ColumnIndexToColumnLetter(i + 1));
            }

            foreach (var name in sheet.Rows[0].ItemArray)
            {
                columnNames.Add(name.ToString());
            }

            for (int r = 0; r < sheet.Rows.Count; r++)
            {
                Dictionary<string, TableCell> rowDict = new Dictionary<string, TableCell>();
                for (int i = 0; i < columnLetters.Count; i++)
                {
                    TableCell tableCell = new TableCell();
                    tableCell.RowNumber = r + 1;
                    tableCell.ColumnNumber = i + 1;
                    tableCell.ColumnLetter = columnLetters[i];
                    tableCell.ColumnHeader = columnNames[i];
                    tableCell.Value = sheet.Rows[r].ItemArray[i].ToString();
                    rowDict.Add(columnLetters[i], tableCell);
                }
                tableDict.Add(rowDict);
            }
                return tableDict;
        }

        private TableListDictionary GetTableListDictionary(string xml)
        {
            TableListDictionary tableListDictionary = new TableListDictionary();
            FindResponse findResponse = FindResponseDeserializer.Deserialize(xml);
            foreach (var row in findResponse.Rows)
            {
                Dictionary<string, TableCell> newRow = new Dictionary<string, TableCell>();
                foreach (var cell in row)
                {
                    newRow.Add(cell.ColumnLetter, cell);
                }
                tableListDictionary.Add(newRow);
                //newRow.Clear();                
            }
            return tableListDictionary;
        }

        private DataTable ReadCSVFromString(string csvString)
        {            

            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(csvString);
            writer.Flush();
            DataTable dataTable;

            using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
            {
                var results = reader.AsDataSet().Tables[0];
                dataTable = results;
            }

            return dataTable;

        }
               

        private DataTable ReadExcel(string path, string sheetName)
        {
            DataTable dataTable;
            string ext = Path.GetExtension(path);
            if (ext!=".csv")
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    // Auto-detect format, supports:
                    //  - Binary Excel files (2.0-2003 format; *.xls)
                    //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var results = reader.AsDataSet().Tables[sheetName];
                        dataTable = results;
                    }
                }
            }
            else
            {
                using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {

                    using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                    {
                        var results = reader.AsDataSet().Tables[0];
                        dataTable = results;
                    }
                }
            }

            return dataTable;
        }
    }
}

