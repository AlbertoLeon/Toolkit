using System;
using System.Collections.Generic;
using System.Linq;

namespace Tokiota.Toolkit.XCutting.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryExtensions
    {
        
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, TValue defaultValue = default(TValue))
        {
            TValue value;
            
            return dictionary.TryGetValue(key, out value)
                ? value
                : defaultValue;
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
        {
            var value = default(TValue);
            if (!dictionary.TryGetValue(key, out value))
            {
                lock (dictionary)
                {
                    if (!dictionary.TryGetValue(key, out value))
                    {
                        value = valueFactory(key);
                        dictionary[key] = value;
                    }
                }
            }

            return value;
        }

        public static void SetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = value;
            }
            else
            {
                dict.Add(key, value);
            }
        }

        public static void RemoveAll<TKey, TValue>(this Dictionary<TKey, TValue> dict,
            Func<KeyValuePair<TKey, TValue>, bool> condition)
        {
            var toRemove = dict.Where(condition)
                .Select(item => item.Key)
                .ToList();

            foreach (var key in toRemove)
            {
                dict.Remove(key);
            }
        }

    }
}