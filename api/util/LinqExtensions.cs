using System;
using System.Collections.Generic;
using System.Linq;

public static class LinqExtensions
{
    // Ex: collection.TakeLast(5);
    public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int N)
    {
        return source.Skip(Math.Max(0, source.Count() - N));
    }
}