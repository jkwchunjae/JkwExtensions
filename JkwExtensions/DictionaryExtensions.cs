using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JkwExtensions
{
    public static class DictionaryExtensions
    {
        public static DefaultDictionary<TKey, TValue> ToDefaultDictionary<TKey, TValue>(this Dictionary<TKey, TValue> dict)
        {
            var defaultDict = new DefaultDictionary<TKey, TValue>(dict);
            return defaultDict;
        }

        public static DefaultDictionary<TKey, TValue> ToDefaultDictionary<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue defaultValue)
        {
            var defaultDict = new DefaultDictionary<TKey, TValue>(dict, defaultValue);
            return defaultDict;
        }
    }
}
