using System;
using System.Collections.Generic;

namespace Spoofi.FreudBot.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static string Join(this IEnumerable<string> source, string separator)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (separator == null) throw new ArgumentNullException(nameof(separator));
            return string.Join(separator, source);
        }
    }
}