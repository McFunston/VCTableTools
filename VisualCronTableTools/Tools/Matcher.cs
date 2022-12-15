using System;
namespace VisualCronTableTools.Tools
{
    internal static class Matcher
    {
        /* Used as the matcher delegate in TableListDictionary */
        internal static bool findIn(string searchTerm, string itemToSearch)
        {
            return itemToSearch.Contains(searchTerm);
        }

        internal static bool findEquals(string searchTerm, string itemToSearch)
        {
            return itemToSearch.Equals(searchTerm);
        }

        internal static bool findStartsWith(string searchTerm, string itemToSearch)
        {
            return itemToSearch.StartsWith(searchTerm);
        }

        internal static bool findEndsWith(string searchTerm, string itemToSearch)
        {
            return itemToSearch.EndsWith(searchTerm);
        }
    }
}

