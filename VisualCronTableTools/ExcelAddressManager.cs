using System;
namespace VisualCronTableTools
{
	public static class ExcelAddressManager
	{
		public static string GetRow(string address)
		{
			string row = "";

			foreach (var c in address)
			{
				if (char.IsNumber(c))
				{
					row += c;
				}
			}

			return row;
		}

		public static string GetColumn(string address)
		{
			string column = "";

			foreach (var c in address)
			{
				if (!(char.IsNumber(c)))
				{
					column += c;
				}
			}
			return column;
		}
	}
}

