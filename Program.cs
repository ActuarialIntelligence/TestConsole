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
            string pallendromeNested = "anaannapaaaaaaaaaap";
            var strCharArray = pallendromeNested.ToCharArray();
            Array.Reverse(strCharArray);
            var reversed = strCharArray.ToString();


            string tmpPallendromeStr = "";
            var length = pallendromeNested.Length;
            var resultsKVPList = new List<KeyValuePair<int, string>>();
            // The substrings can start at each index value along the length
            // and traverse to the end of the length to test a relevant substring.
            for (int i = 0; i < length; i++)
            {
                for(int j = i; j <= length -i ; j++)
                {
                    tmpPallendromeStr = pallendromeNested.Substring(i, j);
                    if (tmpPallendromeStr.Length >= 2)
                    {
                        if (IsPallendrome(tmpPallendromeStr))
                        {
                            resultsKVPList.
                                Add(new KeyValuePair<int, string>
                                (tmpPallendromeStr.Length, tmpPallendromeStr));
                        }
                    }
                }
            }

            var largestPallendromeList = LargestPallendromesList(resultsKVPList);
            foreach (var largestPallendrome in largestPallendromeList)
            {
                Console.WriteLine("Lagrest Pallendrome" + " Length: " + largestPallendrome.Key.ToString() + " Value: " + largestPallendrome.Value.ToString());
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
            var strR = "";
            string reversed = ReversedString(str, ref strR);
            if (str.Equals(reversed))
            {
                return true;
            }
            else { return false; }
        }

        private static string ReversedString(string str, ref string strR)
        {
            var strCharArray = str.ToCharArray();

            var len = strCharArray.Length;
            for (int i = len - 1; i >= 0; i--)
            {
                strR += strCharArray[i].ToString();
            }
            var reversed = strR.ToString();
            return reversed;
        }
    }
}
