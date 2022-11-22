using System;
using DocumentFormat.OpenXml.Spreadsheet;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools;
using VisualCronTableTools.Tools.XLS;
using static VisualCronTableTools.Models.TableListDictionary;

namespace VisualCronTableTools
{
	public static class TableSearcher
	{
		public static FindResponse FindAllExact(string path, string sheetName, string searchColumn, string searchTerm)
		{
			XLSTable table = new XLSTable(path, sheetName);
			TableListDictionary tableListDictionary = table.tableListDictionary;

			FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEquals);
			return findResponse;

		}

        public static FindResponse FindAllIn(string path, string sheetName, string searchColumn, string searchTerm)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.FindIn);
            return findResponse;

        }

        public static FindResponse FindFirstExact(string path, string sheetName, string searchColumn, string searchTerm)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindFirst(searchTerm, searchColumn, Matcher.findEquals);
            return findResponse;

        }

        public static FindResponse FindFirstIn(string path, string sheetName, string searchColumn, string searchTerm)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindFirst(searchTerm, searchColumn, Matcher.FindIn);
            return findResponse;

        }

        public static FindResponse FindAllExactWithout(string path, string sheetName, string searchColumn, string searchTerm, string killColumn)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAllWithout(searchTerm, searchColumn, killColumn, Matcher.findEquals);
            return findResponse;

        }

        public static FindResponse FindAllInWithout(string path, string sheetName, string searchColumn, string searchTerm, string killColumn)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAllWithout(searchTerm, searchColumn, killColumn, Matcher.FindIn);
            return findResponse;

        }

        public static FindResponse FindFirstExactWithout(string path, string sheetName, string searchColumn, string searchTerm, string killColumn)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindFirstWithout(searchTerm, searchColumn, killColumn, Matcher.findEquals);
            return findResponse;

        }

        public static FindResponse FindFirstInWithout(string path, string sheetName, string searchColumn, string searchTerm, string killColumn)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindFirstWithout(searchTerm, searchColumn, killColumn, Matcher.FindIn);
            return findResponse;

        }

        public static FindResponse FindAllBothExact(string path, string sheetName, string searchColumn1, string searchTerm1, string searchColumn2, string searchTerm2)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAllBoth(searchTerm1, searchColumn1, searchTerm2, searchColumn2, Matcher.findEquals);
            return findResponse;

        }

        public static FindResponse FindFirstBothExact(string path, string sheetName, string searchColumn1, string searchTerm1, string searchColumn2, string searchTerm2)
        {
            XLSTable table = new XLSTable(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindFirstBoth(searchTerm1, searchColumn1, searchTerm2, searchColumn2, Matcher.findEquals);
            return findResponse;

        }


    }
}

