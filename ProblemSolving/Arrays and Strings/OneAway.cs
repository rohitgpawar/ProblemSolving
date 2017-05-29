/*
 Three types of edit can be performed on string. insert / replace / remove.
 Given 2 strings check if they are one(or zero) edit away.
 */
/*
 THIS IS SOLUTION IS NOT CORRECT.
   *   MAY 2 DIFFERENT FUNCTIONS FOR REPLACE HANDLING AND FOR INSERT/DELETE HANDLING.
   *   FOR INSERT/DELETE. FIND LARGER AND SMALLER STRINGS.
       USE WHILE LOOP AND DECIDE WHEN TO INCREMENT THE SMALLER STRING. USE 2 VARIABLES TO INCREMENT POSITION IN BOTH STRINGS.
 */
namespace ProblemSolving
{
    public class OneAway
    {
        public static bool isOneEditAway(string firstString, string secondString)
        {
            int lengthDifference = firstString.Length - secondString.Length;
            bool isInsertOrDelete = false,isReplace = false,isDelete=false;
            int j = 0;
            if (lengthDifference > 1 || lengthDifference < -1)
                return false;
            else if (lengthDifference != -1)
                isInsertOrDelete = true;
            else
            {//Swap set largerString as FirstString.
                string temp = firstString;
                firstString = secondString;
                secondString = temp;
            }
            for (int i =0; i < firstString.Length; i++)
            {
                if (j >= secondString.Length)
                { break; }
                if (firstString[i] != secondString[j])
                {
                    
                    if (isDelete || isReplace)
                    {// InsertOrDelete + Replace || SecondReplace
                        return false;
                    }
                    else if (isInsertOrDelete && lengthDifference !=0)
                    {
                        isDelete = true;
                    }
                    else
                    {
                        isReplace = true;
                        j++;
                    }
                }
                else
                { j++; }
            }
            return true;
        }
    }
}
