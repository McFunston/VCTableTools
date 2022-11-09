﻿using System;
namespace VisualCronTableTools.Tools
{
    public static class Matcher
    {
        public static bool FindIn(string searchTerm, string itemToSearch)
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
    }
}
