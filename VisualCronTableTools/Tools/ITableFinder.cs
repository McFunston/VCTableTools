using System;
namespace VisualCronTableTools.Tools
{
	public interface ITableFinder
	{
        public delegate bool Matcher(string searchTerm, string itemToSearch);


    }
}

