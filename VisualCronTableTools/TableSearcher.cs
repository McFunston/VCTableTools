﻿using System;
using DocumentFormat.OpenXml.Spreadsheet;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools;
using VisualCronTableTools.Tools.XLS;
using static VisualCronTableTools.Models.TableListDictionary;

namespace VisualCronTableTools
{
    /// <summary>
    /// Class for searching through tables. This is the class that should be accessed through VisualCron.
    /// </summary>
    public static class TableSearcher
    {
        /// <summary>
        /// Find an exact match in a given column of a given Excel or CSV file.
        /// </summary>
        /// <param name="path">The path of the Excel or CSV file.</param>
        /// <param name="sheetName">The name of the sheet to be searched. Ignored if the file is a CSV file.</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that must be matched exactly to result in a 'hit'.</param>
        /// <returns></returns>
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

