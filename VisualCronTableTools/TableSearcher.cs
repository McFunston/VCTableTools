using System;
using VisualCronTableTools.Models;
using VisualCronTableTools.Tools.XLS;

namespace VisualCronTableTools
{
	public static class TableSearcher
	{
		public FindResponse FindAllExact(string path, string sheetName, string searchColumn, string searchTerm)
		{
			XLSTable table = new XLSTable(path, sheetName);
			TableListDictionary tableListDictionary = table.tableListDictionary;


		}
	}
}

