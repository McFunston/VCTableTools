using System;
namespace VisualCronTableTools
{
	/// <summary>
	/// A class for extracting either row numbers or column letters from Excel addresses.
	/// </summary>
	public static class ExcelAddressManager
	{
		/// <summary>
		/// Extracts the row number from an Excel address.
		/// </summary>
		/// <param name="address">A string representation of an Excel address (ie. A21)</param>
		/// <returns>The row number as a string.</returns>
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
        /// <summary>
        /// Extracts the column letter from an Excel address.
        /// </summary>
        /// <param name="address">A string representation of an Excel address (ie. A21)</param>
        /// <returns>The column letter.</returns>
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

