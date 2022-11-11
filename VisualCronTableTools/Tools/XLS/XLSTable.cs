using System;
using System.Data;
using ExcelDataReader;
using System.IO;
using VisualCronTableTools.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using ClosedXML.Excel;

namespace VisualCronTableTools.Tools.XLS
{
	public class XLSTable
	{
        public TableListDictionary tableListDictionary { get; set; }

        public XLSTable(string path, string sheetName)
        {
            //System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var dataTable = ReadExcel(path, sheetName);

        }

        private TableListDictionary GetTableListDictionary(DataTable sheet)
        {

        }

        private DataTable ReadExcel(string path, string sheetName)
        {
            DataTable dataTable;
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
            return dataTable;
        }
    }
}

