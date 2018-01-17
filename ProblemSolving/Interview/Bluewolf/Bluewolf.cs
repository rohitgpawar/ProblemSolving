using System;

namespace ProblemSolving.Interview
{
    public class Bluewolf
    {
        public static void BluewolfMain()
        {
            string output = Q1_FindFirstNonRepeatingCharacter("mnonmpsms");
            Q3_CustomSortedArray(new int[5] { 8, 5, 11, 4, 6 });
            Q2_NumberComplement(100);
        }

        static string Q1_FindFirstNonRepeatingCharacter(string s)
        {
            char output = ' ';
            int[] countChar = new int[256];
            foreach (char ch in s)
            {
                countChar[ch]++;
            }

            foreach (char ch in s)
            {
                if (countChar[ch] == 1)
                {
                    output = ch;
                    break;
                }
            }

            return output.ToString();

        }

        static int Q2_NumberComplement(int n)
        {
            int[] binary = new int[1000];
            int i = 0;
            while (n > 0)
            {
                int rem = n % 2;
                if (rem == 0)
                    binary[i] = 1;
                else
                    binary[i] = 0;
                //binary[i] = number % 2;
                n = n / 2;
                i++;
            }
            string temp = "";
            for (int j = i - 1; j >= 0; j--)
            {
                temp += binary[j];
            }

            return Convert.ToInt32(temp, 2);

        }

        static int Q3_CustomSortedArray(int[] a)
        {
            //Stores count of the moves
            int countMoves = 0;
            //Stores start of array location
            int oddPosition = 0;
            //Stores end of array location
            int evenPosition = a.Length - 1;
            while (oddPosition < evenPosition)
            {//Run while we have odd on the left side
                while (a[oddPosition] % 2 == 0 && oddPosition < evenPosition)
                {//increment until we find even values
                    oddPosition++;
                }
                while (a[evenPosition] % 2 == 1 && oddPosition < evenPosition)
                {//decrement until we find odd values
                    evenPosition--;
                }

                if (oddPosition < evenPosition)
                {//we have found odd before even so swap
                    int tempSwap = a[oddPosition];
                    a[oddPosition] = a[evenPosition];
                    a[evenPosition] = tempSwap;
                    //Increment the positions.
                    oddPosition++;
                    evenPosition--;
                    //Increment the moves
                    countMoves++;
                }
            }
            //Return the total moves
            return countMoves;
        }
    }
}
