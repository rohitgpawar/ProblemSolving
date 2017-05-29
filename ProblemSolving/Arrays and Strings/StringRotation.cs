/*
 Assume you have a method isSubString. Given 2 strings s1,s2 find if s1 is rotation of s2.
 */
namespace ProblemSolving
{
    public class StringRotation
    {

        //OptimalSolution
        public static bool isStringRotation(string inputString1, string inputString2)
        {
            if(inputString2.Length == inputString1.Length || inputString2.Length > 0)
            {
                string twiceString1 = inputString1 + inputString1;
                return twiceString1.Contains(inputString2);
            }
            return false;
        }
        //public static bool isStringRotation(string inputString1, string inputString2)
        //{
        //    int index = inputString2.Length / 2;
        //    if (inputString1.Contains(inputString2.Substring(0, index)))
        //    {
        //        while (index < inputString2.Length - 1 && inputString1.Contains(inputString2.Substring(0, index + 1)))
        //        {
        //            index++;
        //        }
        //        string correctedString = inputString2.Substring(index,inputString2.Length - index) +inputString2.Substring(0, index);
        //        if (correctedString == inputString1)
        //            return true;
        //    }
        //    else if(inputString1.Contains(inputString2.Substring(index,inputString2.Length-index)))
        //    {
        //        while (index > 0 && inputString1.Contains(inputString2.Substring(index-1, inputString2.Length-index)))
        //        {
        //            index--;
        //        }
        //        string correctedString = inputString2.Substring(index, inputString2.Length-index) + inputString2.Substring(0, index);
        //        if (correctedString == inputString1)
        //            return true;
        //    }
        //    //else
        //        return false;
        //}
    }
}
