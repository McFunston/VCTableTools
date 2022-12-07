﻿using System;
namespace VisualCronTableTools.Tools
{
    public static class Matcher
    {
        /* Used as the matcher delegate in TableListDictionary */
        public static bool findIn(string searchTerm, string itemToSearch)
        {
            bool found = false;

            if (itemToSearch.Contains(searchTerm))
            {
                found = true;
            }

            return found;
        }

        public static bool findEquals(string searchTerm, string itemToSearch)
        {
            bool found = false;

            if (itemToSearch.Equals(searchTerm))
            {
                found = true;
            }
            return found;
        }

        public static bool findStartsWith(string searchTerm, string itemToSearch)
        {
            bool found = false;

            if (itemToSearch.StartsWith(searchTerm))
            {
                found = true;
            }
            return found;
        }

        public static bool findEndsWith(string searchTerm, string itemToSearch)
        {
            bool found = false;

            if (itemToSearch.EndsWith(searchTerm))
            {
                found = true;
            }
            return found;
        }
    }
}

