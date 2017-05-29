

namespace ProblemSolving
{
    public class UniqueCharInString
    {
        public static bool StringHasUniqueChar(string inputString)
        {
            if (inputString.Length > 128) // If string is Ascii. Ascii charecter set is 128.
                return false;

            //Without using any other DataTypes
            //char[] inputStringChar = inputString.ToCharArray();
            //for (int i = 0; i < inputString.Length; i++)
            //{
            //    char checkUniqueChar = inputStringChar[i];
            //    for (int j = i + 1; j < inputString.Length; j++)
            //    {
            //        if (checkUniqueChar == inputStringChar[j])
            //        {
            //            return false;
            //        }
            //    }
            //}

            //With Other DataTypes
            bool[] charCheck = new bool[128];
            for (int i = 0; i < inputString.Length; i++)
            {
                int charValue = inputString.ToCharArray()[i];
                if(charCheck[charValue])
                 return false; 
                charCheck[charValue] = true;
            }
            return true;
        }
    }
}
