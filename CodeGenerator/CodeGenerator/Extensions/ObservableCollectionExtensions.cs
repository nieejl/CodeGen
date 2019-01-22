using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CodeGenerator.Extensions
{
    static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> AsObservableCollection<T>(this IEnumerable<T> items) where T : class
        {
            var observable = new ObservableCollection<T>();
            foreach (T item in items)
            {
                observable.Add(item);
            }
            return observable;
        }
    }
}
