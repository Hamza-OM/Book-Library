using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Utilities
{
    public static class StringUtils
    {
        public static string TruncateText(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (text.Length <= maxLength)
                return text;

            return text.Substring(0, maxLength) + "...";
        }
    }
} 