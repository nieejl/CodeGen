using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Extensions
{
    public static class StringExtensions
    {
        public static bool IsMatchWithUnderscore(this string s1, string s2)
        {
            return s1.StartsWith("_") && s1.ToLower().Substring(1) == s2;
        }

        public static bool IsCapitalized(this string s)
        {
            string first = s.Substring(0, 1);
            return first.ToUpper() == first;
        }

        public static string DeCapitalize(this string s)
        {
            if (s == "")
                return s;
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }

        public static string Capitalize(this string s)
        {
            if (s == "")
                return s;
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }
        public static bool IsEqualIgnoreCase(this string s1, string s2)
        {
            return s1.ToLower() == s2.ToLower();
        }

    }
}
