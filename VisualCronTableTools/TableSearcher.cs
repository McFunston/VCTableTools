using System;
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
        /// Find any exact matches in a given column of a given Excel or CSV file.
        /// </summary>
        /// <param name="path">The path of the Excel or CSV file.</param>
        /// <param name="sheetName">The name of the sheet to be searched. Ignored if the file is a CSV file.</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that must be matched exactly to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindExact(string path, string sheetName, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEquals);
            return findResponse;

        }
        /// <summary>
        /// Find any exact matches in a given column of a given FindResponse Output returned within VisualCron as XML.
        /// </summary>
        /// <param name="tableString">The Output from a previous search returned as an XML representation (for example {TASK(efa38047-151d-4bca-92b9-5a140e21184b|StdOut)})</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that must be matched exactly to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindExact(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEquals);
            return findResponse;

        }
        /// <summary>
        /// Find any partial matches in a given column of a given Excel or CSV file (For example 'shing' in 'Washington'.
        /// </summary>
        /// <param name="path">The path of the Excel or CSV file.</param>
        /// <param name="sheetName">The name of the sheet to be searched. Ignored if the file is a CSV file.</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that may be matched in any part to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindIn(string path, string sheetName, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findIn);
            return findResponse;

        }
        /// <summary>
        /// Find any partial matches in a given column of a FindResponse Output returned within VisualCron as XML.
        /// </summary>
        /// <param name="tableString">The Output from a previous search returned as an XML representation (for example {TASK(efa38047-151d-4bca-92b9-5a140e21184b|StdOut)})</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that may be matched in any part to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindIn(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findIn);
            return findResponse;

        }
        /// <summary>
        /// Find any partial matches where the cell value begins with the search term in a given column of a given Excel or CSV file (For example 'Wash' in 'Washington'.
        /// </summary>
        /// <param name="path">The path of the Excel or CSV file.</param>
        /// <param name="sheetName">The name of the sheet to be searched. Ignored if the file is a CSV file.</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that must be matched at the beginning of the cell value to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindStartsWith(string path, string sheetName, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findStartsWith);
            return findResponse;
        }
        /// <summary>
        /// Find any partial matches where the cell value begins with the search term in a given column of a FindResponse Output returned within VisualCron as XML
        /// </summary>
        /// <param name="tableString">The Output from a previous search returned as an XML representation (for example {TASK(efa38047-151d-4bca-92b9-5a140e21184b|StdOut)})</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that must be matched at the beginning of the cell value to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindStartsWith(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findStartsWith);
            return findResponse;
        }
        /// <summary>
        /// Find any partial matches where the cell value ends with the search term in a given column of a given Excel or CSV file (For example 'ton' in 'Washington'.
        /// </summary>
        /// <param name="path">The path of the Excel or CSV file.</param>
        /// <param name="sheetName">The name of the sheet to be searched. Ignored if the file is a CSV file.</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that must be matched at the end of the cell value to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindEndsWith(string path, string sheetName, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(path, sheetName);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEndsWith);
            return findResponse;
        }
        /// <summary>
        /// Find any partial matches where the cell value ends with the search term in a given column of a FindResponse Output returned within VisualCron as XML
        /// </summary>
        /// <param name="tableString">The Output from a previous search returned as an XML representation (for example {TASK(efa38047-151d-4bca-92b9-5a140e21184b|StdOut)})</param>
        /// <param name="searchColumn">The column letter to be searched.</param>
        /// <param name="searchTerm">A string that must be matched at the end of the cell value to result in a 'hit'.</param>
        /// <returns>FindResponse</returns>
        public static FindResponse FindEndsWith(string tableString, string searchColumn, string searchTerm)
        {
            TableSource table = new TableSource(tableString);
            TableListDictionary tableListDictionary = table.tableListDictionary;

            FindResponse findResponse = tableListDictionary.FindAll(searchTerm, searchColumn, Matcher.findEndsWith);
            return findResponse;
        }
    }
}

