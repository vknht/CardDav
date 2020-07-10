using System.Collections.Generic;
using System.Linq;

namespace CardDav.Helpers
{
    internal static class DictionaryHelper
    {
        public static void AddValue(IDictionary<string, ISet<string>> dictionary, string propertyName, string value)
        {
            if (dictionary.ContainsKey(propertyName))
            {
                dictionary[propertyName].Add(value);
            }
            else
            {
                dictionary.Add(propertyName, new HashSet<string>() { value });
            }
        }

        public static void RemoveValue(IDictionary<string, ISet<string>> dictionary, string propertyName, string value)
        {
            if (dictionary.ContainsKey(propertyName))
            {
                dictionary[propertyName].Remove(value);
            }
        }

        public static IEnumerable<string> GetValuesOrEmpty(IDictionary<string, ISet<string>> dictionary, string propertyName)
        {
            if (dictionary.TryGetValue(propertyName, out var tmpLst))
            {
                return tmpLst;
            }

            return Enumerable.Empty<string>();
        }
    }
}
