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
		public static FindResponse FindExact(string path, string sheetName, string searchColumn, string searchTerm)
		{
			TableSource table = new TableSource(path, sheetName);
			TableListDictionary tableListDictionary = table.tableListDictionary;

			FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEquals);
			return findResponse;

		}

        public static FindResponse FindExact(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEquals);
            return findResponse;

        }

        public static FindResponse FindIn(string path, string sheetName, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findIn);
            return findResponse;

        }

        public static FindResponse FindIn(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findIn);
            return findResponse;

        }

        public static FindResponse FindStartsWith(string path, string sheetName, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findStartsWith);
            return findResponse;
        }

        public static FindResponse FindStartsWith(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findStartsWith);
            return findResponse;
        }

        public static FindResponse FindEndsWith(string path, string sheetName, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEndsWith);
            return findResponse;
        }

        public static FindResponse FindEndsWith(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEndsWith);
            return findResponse;
        }
    }
}

