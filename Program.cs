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
            string pallendromeNested = "anaannapaaaaaaaaaappngtymmytgnp";
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
                if(i==30)
                    {

                }

                for(int j = i; j <= length; j++)
                {
                    //Console.WriteLine(i.ToString() + " "+ j.ToString());
                    tmpPallendromeStr = pallendromeNested.Substring(i, j-i);
                    //Console.WriteLine(tmpPallendromeStr);
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
                Console.WriteLine("Lagrest Pallendrome" + " Length: " 
                    + largestPallendrome.Key.ToString() + " Value: " + largestPallendrome.Value.ToString());
            }
        }
        /// <summary>
        /// Add largest palindrome value/s to list
        /// this is because thaere can be two or more of the 
        /// same largest length
        /// </summary>
        /// <param name="pallendromeList">Largest palindrome/s added to this list</param>
        /// <returns></returns>
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
        /// <summary>
        /// Check to see if the string passed is a pallendrome
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
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
        /// <summary>
        /// I could do this with a simple reverse string
        /// However at previous posting i.e. MS they required me to be able
        /// to do things from scratch as much as possible.
        /// For this reason I have included this block
        /// </summary>
        /// <param name="str"> String to reverse </param>
        /// <param name="strR">Reversed String </param>
        /// <returns></returns>
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
