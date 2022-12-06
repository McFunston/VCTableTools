using System;
using VisualCronTableTools.Tools.XLS;

namespace VisualCronTableTools
{
	public static class TableHandler
	{
		public static FindResponse GetAllData(string path, string sheet)
		{
			TableSource tableSource = new TableSource(path, sheet);
			FindResponse findResponse = tableSource.tableListDictionary.ReturnAll();
			return findResponse;
		}

	}
}

