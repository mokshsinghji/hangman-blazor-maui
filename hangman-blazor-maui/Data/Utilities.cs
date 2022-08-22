using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman_blazor_maui.Data
{
    public static class Utilities
    {
        public static IList<int> AllIndexOf(this string text, string str, StringComparison comparisonType)
        {
            IList<int> allIndexOf = new List<int>();
            int index = text.IndexOf(str, comparisonType);
            while (index != -1)
            {
                allIndexOf.Add(index);
                index = text.IndexOf(str, index + 1, comparisonType);
            }
            return allIndexOf;
        }
    }
}
