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
    }
}
