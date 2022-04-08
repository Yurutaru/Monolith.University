using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.University.Core.Extensions
{
    internal static class EnumExtensions
    {
        public static T? ToEnumOrNull<T>(this string? source)
            where T : struct, Enum
        {
            if (!Enum.TryParse<T>(source, out var value))
                return null;

            return value;
        }

        public static T ToEnum<T>(this string? source)
            where T : struct, Enum
        {
            if (string.IsNullOrWhiteSpace(source))
                return Enum.Parse<T>("0");

            return (T)Enum.Parse(typeof(T), source.ToString(), true);
        }
    }
}
