using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using VisualCronTableTools.Models;

namespace VisualCronTableTools
{
	/// <summary>
	/// The return of any TableSearcher method. This can either be returned as XML within VisualCron in which case it can be searched again, or as a simple list of the cell locations.
	/// </summary>
    public class FindResponse
    {
        /* A FindResponse will consist of the following properties
			Success: True if found, False if not
			Message: A string describing the findings ("Two items found")
			Rows: A list of dictionaries with the contents of the rows where the searched value was found ("A9": "Boston", "B9": "Massachusetts" for example)
			Addresses: A list of the specifically found cells */

		/// <summary>
		/// Basic constructor for FindResponse.
		/// </summary>
        public FindResponse()
		{
            Rows = new List<List<TableCell>>();
			Addresses = new List<string>();
		}

		/// <summary>
		/// A boolean representing the success of the search. True means at least 1 'hit', and False means none.
		/// </summary>
		public bool Success { get; set; }
		/// <summary>
		/// A human readable response message (ie. 'Two instances found')
		/// </summary>
        public string Message { get; set; }
        /// <summary>
        /// A list of dictionaries with the contents of the rows where the searched value was found ("A9": "Boston", "B9": "Massachusetts" for example)
        /// </summary>
        [XmlArrayItem("Row")]
        public List<List<TableCell>> Rows { get; set; }
		/// <summary>
		/// A list of the cell locations in Excel format (eg. "A1", "D3") where the searched value was found.
		/// </summary>
        [XmlArrayItem("Address")]
        public List<string> Addresses { get; set; }

        /// <summary>
        /// Overide for Visualcron to return just a list of the addresses where the searched value was found if 'ToString representation of output' is chosen in Output tab.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
		{
			string addressesString = string.Join(",", Addresses);
			return addressesString;
		}

    }
}

