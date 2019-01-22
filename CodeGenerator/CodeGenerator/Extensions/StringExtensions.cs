using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Extensions
{
    static class StringExtensions
    {
        public static bool IsMatchWithUnderscore(this string s1, string s2)
        {
            return s1.StartsWith("_") && s1.ToLower().EndsWith(s2);
        }

        public static bool IsEqualIgnoreCase(this string s1, string s2)
        {
            return s1.ToLower() == s2.ToLower();
        }
    }
}
