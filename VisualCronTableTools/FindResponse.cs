using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VisualCronTableTools.Models;

namespace VisualCronTableTools
{
    [Serializable()]
    public class FindResponse: ISerializable
    {
        /* A FindResponse will consist of the following properties
			Success: True if found, False if not
			Message: A string describing the findings ("Two items found")
			Rows: A list of dictionaries with the contents of the rows where the searched value was found ("A9": "Boston", "B9": "Massachusetts" for example)
			Cells: A dictionary of the specifically found cells */

		public FindResponse()
		{
			Rows = new TableListDictionary();
			Addresses = new List<string>();
		}

		public FindResponse(bool success, string message, TableListDictionary rows, List<string> addresses)
		{
			Success = success;
			Message = message;
			Rows = rows;
			Addresses = addresses;
		}
		public bool Success { get; set; }
		public string Message { get; set; }
		public TableListDictionary Rows { get; set; } // TableListDictionary of all rows with found cells
        public List<string> Addresses { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
			info.AddValue("Success", Success);
			info.AddValue("Message", Message);
			info.AddValue("Rows", Rows);
			info.AddValue("Addresses", Addresses);
        }
    }
}

