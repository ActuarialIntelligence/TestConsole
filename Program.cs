using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string within which to find longest pallendrome
            string pallendromeNested = "";

            var length = pallendromeNested.Length;
            var resultsKVPList = new List<KeyValuePair<int, string>>();
            // The substrings can start at each index value along the length
            // and traverse to the end of the length to test a relevant substring.
            for (int i = 0; i < length; i++)
            {
                for(int j = i; j < length; j++)
                {
                    pallendromeNested = pallendromeNested.Substring(i, j);
                    if(IsPallendrome(pallendromeNested))
                    {
                            resultsKVPList.
                                Add(new KeyValuePair<int, string>
                                (pallendromeNested.Length, pallendromeNested));
                    }
                }
            }

            var largestPallendromeList = LargestPallendromesList(resultsKVPList);
            foreach (var largestPallendrome in largestPallendromeList)
            {
                Console.WriteLine("Lagrest Pallendrome, length {0} : Pallendrome {1}"
                    ,largestPallendrome.Key,largestPallendrome.Value);
            }
        }

        private  static List<KeyValuePair<int, string>> LargestPallendromesList
            (List<KeyValuePair<int,string>> pallendromeList)
        {
            var pallendromes = new List<KeyValuePair<int,string>>();
            var largestInt = 0;
            foreach(var pallendrome in pallendromeList)
            {
                if(pallendrome.Key > largestInt)
                {
                    largestInt = pallendrome.Key;
                }
            }
            pallendromes = pallendromeList.Where(s=>s.Key == largestInt).ToList();
            return pallendromes;
        }

        private  static bool IsPallendrome(string str)
        {
            var strCharArray = str.ToCharArray();
            Array.Reverse(strCharArray);
            var reversed = strCharArray.ToString();
            if(str.Equals(reversed))
            {
                return true;
            }
            else { return false; }
        }
    }
}
