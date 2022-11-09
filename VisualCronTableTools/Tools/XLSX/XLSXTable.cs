using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace VisualCronTableTools.Tools.XLSX
{
	public class XLSXTable
	{
        /* A Microsoft Office Open XML format table */
        IXLWorksheet Worksheet;

        public XLSXTable(string path, string sheetName, bool loadHeaders = true)
        {
            Worksheet = GetWorksheet(path, sheetName, loadHeaders);
        }

		private IXLWorksheet GetWorksheet(string path, string sheetName, bool loadHeaders = true)
		{
            var workbook = new XLWorkbook(path);
            IXLWorksheet sheet = workbook.Worksheet(sheetName);
            return sheet;
        }
    }
}

