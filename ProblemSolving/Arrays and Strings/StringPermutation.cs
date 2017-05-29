using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    //Given 2 string find if one is permutation of the other.
    public class StringPermutation
    {
        public static bool AreTwoStringsPermutable(string first, string second)
        {
            if (first.Length != second.Length)
                return false;

            int[] charCountCheck = new int[128];
            for (int i=0; i < first.ToCharArray().Length; i++)
            {
                charCountCheck[first.ToCharArray()[i]]++;
            }
            for (int i = 0; i < second.Length; i++)
            {
                charCountCheck[second.ToCharArray()[i]]--;
                if (charCountCheck[second.ToCharArray()[i]] < 0)
                    return false;
            }
            
            return true;
        }

    }
}
