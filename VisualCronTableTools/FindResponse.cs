using System;
using System.Collections.Generic;

namespace VisualCronTableTools
{
	public class FindResponse
	{
        /* A FindResponse will consist of the following properties
			Success: True if found, False if not
			Message: A string describing the findings ("Two items found")
			Findings: A list of dictionaries with the contents of the rows where the searched value was found ("A9": "Boston", "B9": "Massachusetts" for example) */

		public FindResponse(bool success, string message, List<Dictionary<string, string>> findings)
		{
			Success = success;
			Message = message;
			Findings = findings;
		}
		public bool Success { get; set; }
		public string Message { get; set; }
		public List<Dictionary<string, string>> Findings { get; set; } // Key is location (A2, G41, etc) Value is cell value 
	}
}

