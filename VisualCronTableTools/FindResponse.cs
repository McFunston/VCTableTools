using System;
using System.Collections.Generic;

namespace VisualCronTableTools
{
	public class FindResponse
	{
		public FindResponse(bool success, string message, Dictionary<string, string> findings)
		{
			Success = success;
			Message = message;
			Findings = findings;
		}
		public bool Success { get; set; }
		public string Message { get; set; }
		public Dictionary<string, string> Findings { get; set; } // Key is location (A2, G41, etc) Value is cell value
	}
}

