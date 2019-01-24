using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGenerator.Extensions
{
    public static class ListExtensions
    {
        public static List<T> RemoveDuplicates<T>(this List<T> items) where T : class
        {
            return new HashSet<T>(items).ToList();
        }

        public static bool IsEqualTo<T>(this List<T> items, List<T> other) where T : class
        {
            if (items.Count != other.Count)
                return false;

            for (int i = 0; i < items.Count; i++)
            {
                if (!items[i].Equals( other[i] ))
                    return false;
            }
            return true;
        }

    }
}
