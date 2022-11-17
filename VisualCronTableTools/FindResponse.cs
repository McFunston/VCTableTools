using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using VisualCronTableTools.Models;

namespace VisualCronTableTools
{
    [Serializable()]
    public class FindResponse
    {
        /* A FindResponse will consist of the following properties
			Success: True if found, False if not
			Message: A string describing the findings ("Two items found")
			Rows: A list of dictionaries with the contents of the rows where the searched value was found ("A9": "Boston", "B9": "Massachusetts" for example)
			Cells: A dictionary of the specifically found cells */

		public FindResponse()
		{
			Rows = new List<List<TableCell>>();
			Addresses = new List<string>();
		}

		public FindResponse(bool success, string message, List<List<TableCell>> rows, List<string> addresses)
		{
			Success = success;
			Message = message;
			Rows = rows;
			Addresses = addresses;
		}
		public bool Success { get; set; }        
        public string Message { get; set; }
        [XmlArrayItem("Row")]
        public List<List<TableCell>> Rows { get; set; }
        [XmlArrayItem("Address")]
        public List<string> Addresses { get; set; }

        public override string ToString()
		{
			string addressesString = string.Join(",", Addresses);
			return addressesString;
		}

    }
}

