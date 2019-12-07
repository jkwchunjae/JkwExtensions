using System;
using System.Collections.Generic;
using System.Linq;

namespace JkwExtensions
{
    public static class EnumExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static IEnumerable<T> GetValues<T>(this Type type)
        {
            return Enum.GetValues(type).Cast<T>();
        }
    }
}
