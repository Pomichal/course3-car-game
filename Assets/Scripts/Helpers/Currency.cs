using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Helpers
{
    public static class Currency
    {
        private static SortedDictionary<int, string> suffixes = new SortedDictionary<int, string>
        {
            {1000,"K" },
            {1000000, "M" },
            {1000000000, "B" }
        };
        public static string Convert(float amount)
        {
            for (int i = suffixes.Count - 1; i >= 0; i--)
            {
                KeyValuePair<int, string> pair = suffixes.ElementAt(i);
                if (Mathf.Abs(amount) >= pair.Key)
                {
                    return (amount / pair.Key).ToString((amount / pair.Key) % 1 == 0 ? "F0" : "F1") + pair.Value;
                }
            }
            return amount.ToString(amount % 1 == 0 ? "F0" : "F1");
        }
    }
}
