using System;
namespace VisualCronTableTools.Tools
{
    public static class Matcher
    {
        /* Used as the matcher delegate in TableListDictionary */
        public static bool findIn(string searchTerm, string itemToSearch)
        {
            return itemToSearch.Contains(searchTerm);
        }

        public static bool findEquals(string searchTerm, string itemToSearch)
        {
            return itemToSearch.Equals(searchTerm);
        }

        public static bool findStartsWith(string searchTerm, string itemToSearch)
        {
            return itemToSearch.StartsWith(searchTerm);
        }

        public static bool findEndsWith(string searchTerm, string itemToSearch)
        {
            return itemToSearch.EndsWith(searchTerm);
        }
    }
}

