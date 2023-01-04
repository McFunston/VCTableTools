using System;
using VisualCronTableTools.Tools.XLS;

namespace VisualCronTableTools
{
	/// <summary>
	/// A class for bypassing VisualCron's Excel Tasks (So that for example, you can grab all of the data from an Excel file).
	/// </summary>
	public static class TableHandler
	{
		/// <summary>
		/// Gets all of the data from a sheet in an Excel or CSV file
		/// </summary>
		/// <param name="path">Path to the Excel or CSV file.</param>
		/// <param name="sheet">The 'Sheet' in the Excel file to be returned. Ignored if the file is CSV.</param>
		/// <returns>A FindResponse of all of the data in the file.</returns>
		public static FindResponse GetAllData(string path, string sheet)
		{
			TableSource tableSource = new TableSource(path, sheet);
			FindResponse findResponse = tableSource.tableListDictionary.ReturnAll();
			return findResponse;
		}

	}
}

