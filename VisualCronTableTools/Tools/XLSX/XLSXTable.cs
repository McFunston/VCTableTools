using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace VisualCronTableTools.Tools.XLSX
{
	public class XLSXTable: ITableFinder
    {
        /* A Microsoft Office Open XML format table */
        IXLWorksheet Worksheet;

        public XLSXTable(string path, string sheetName, bool loadHeaders = true)
        {
            Worksheet = GetWorksheet(path, sheetName, loadHeaders);
        }

        public FindResponse FindAll(string searchTerm, string column, ITableFinder.Matcher matcher)
        {
            FindResponse findResponse;
            throw new NotImplementedException();
            return findResponse;
        }

        public FindResponse FindAllBoth(string searchTerm1, string column1, string searchTerm2, string column2, ITableFinder.Matcher matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindAllWithout(string searchTerm, string column, string killColumn, ITableFinder.Matcher matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindFirst(string searchTerm, string column, ITableFinder.Matcher matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindFirstBoth(string searchTerm1, string column1, string searchTerm2, string column2, ITableFinder.Matcher matcher)
        {
            throw new NotImplementedException();
        }

        public FindResponse FindFirstWithout(string searchTerm, string column, string killColumn, ITableFinder.Matcher matcher)
        {
            throw new NotImplementedException();
        }

        private IXLWorksheet GetWorksheet(string path, string sheetName, bool loadHeaders = true)
		{
            var workbook = new XLWorkbook(path);
            IXLWorksheet sheet = workbook.Worksheet(sheetName);
            return sheet;
        }
    }
}

