/***
 *Find the Missing Number
 *You are given a list of n-1 integers and these integers are in the range of 1 to n. 
 *There are no duplicates in list. One of the integers is missing in the list. 
 *Write an efficient code to find the missing integer. 
 */
namespace ProblemSolving
{
    public class FindMissingNumber
    {
        public static void FindMissingNumberMain()
        {
            int missingNumber = GetMissingNumber(new int[4] { 1, 2, 3, 5 });
            missingNumber = GetMissingNumber_Approach_XOR(new int[4] { 1, 2, 3, 5 });
        }

        public static int GetMissingNumber(int[] array)
        {
            //Total sum of n numbers is n*(n+1)/2
            int totalSum = (array.Length + 1) * (array.Length + 2) / 2;
            for(int i = 0; i< array.Length; i++)
            {
                totalSum -= array[i];
            }

            return totalSum;

        }

        public static int GetMissingNumber_Approach_XOR(int[] array)
        {

            int X1 = array[0];
            int X2 = 1;
            for (int i = 1; i < array.Length; i++)
            {
                X1 = X1 ^ array[i];
            }
            //X1 => 1^2^3^5
            for(int i=2;i<=array.Length+1;i++)
            {
                X2 = X2 ^ i;
            }
            //X2 => 1^2^3^4^5

            //X1^X2 => (1^1 =0, 2^2 =0, 3^3 =0 5^5 =0) + 4
            return X1 ^ X2;

        }
    }
}
