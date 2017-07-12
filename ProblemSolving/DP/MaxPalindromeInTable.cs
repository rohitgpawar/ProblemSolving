using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class PalindromeInfo
{
    public int palindromeSize;
    public int leftStart;
    public int rightStart;
    public int left;
    public int rgtbtm;
}
class MaxPalindromeInTable
{

    public static void MaxPalindromeInTableMain()
    {
        string[] tokens_n = "3 4".Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        int[][] table = new int[n][];

        string[] table_temp = "8 2 1 9".Split(' ');
        table[0] = Array.ConvertAll(table_temp, Int32.Parse);
        table_temp = "8 1 2 8".Split(' ');
        table[1] = Array.ConvertAll(table_temp, Int32.Parse);
        table_temp = "8 2 1 8".Split(' ');
        table[2] = Array.ConvertAll(table_temp, Int32.Parse);

        int[][] palindromeSize = new int[n][];
        for (int i = 0; i < n; i++)
        {
            palindromeSize[i] = new int[m];
        }

        int MaxSize = 0;
        PalindromeInfo maxPalindrome = new PalindromeInfo();
        maxPalindrome.palindromeSize = 1;
        for (int i = n-1; i >= 0; i--)
        {
            for (int j = m - 1; j >= 0; j--)
            {
                if (maxPalindrome.palindromeSize < (i + 1) * (j + 1))
                {
                    PalindromeInfo palInfo = CountPalindrome(table, palindromeSize, i, j, maxPalindrome.palindromeSize);
                    if (maxPalindrome.palindromeSize < palInfo.palindromeSize)
                    {
                        maxPalindrome = palInfo;
                    }
                }
            }
        }
        Console.WriteLine(maxPalindrome.palindromeSize);
        Console.WriteLine(maxPalindrome.leftStart + " " + maxPalindrome.rightStart + " " + maxPalindrome.left + " " + maxPalindrome.rgtbtm);

    }

    static PalindromeInfo CountPalindrome(int[][] table, int[][] palindromeSize, int left, int rgtbtm, int maxPalindromeSize)
    {
         if (left == 0 && rgtbtm == 0)
        {
            PalindromeInfo palInfo1 = new PalindromeInfo();
            palInfo1.palindromeSize = 1;
            palInfo1.leftStart = 0;
            palInfo1.rightStart = 0;
            palInfo1.left = left;
            palInfo1.rgtbtm = rgtbtm;
            return palInfo1;
        }

        PalindromeInfo palInfo = new PalindromeInfo();
        palInfo.palindromeSize = maxPalindromeSize;
        for (int i = 0; i <= left; i++)
        {
            for (int j = 0; j <= rgtbtm; j++)
            {
                if ((palInfo.palindromeSize < (left - i + 1) * (rgtbtm - j + 1)) && isPalindrome(table, i, j, left, rgtbtm))
                {
                    int size = (left - i + 1) * (rgtbtm - j + 1);
                    if (size > palInfo.palindromeSize)
                    {
                        palInfo.palindromeSize = size;
                        palInfo.leftStart = i;
                        palInfo.rightStart = j;
                        palInfo.left = left;
                        palInfo.rgtbtm = rgtbtm;
                        //return palInfo;
                    }
                }

            }
        }
        return palInfo;
    }

    static bool isPalindrome(int[][] table, int leftStart, int rightStart, int leftMax, int rgtbtmMax)
    {
        int[] digitCount = new int[10];
        int countDigits = 0;
        for (int i = 0; i <= 9; i++)
        {
            digitCount[i] = 0;
        }
        for (int i = leftStart; i <= leftMax; i++)
        {
            for (int j = rightStart; j <= rgtbtmMax; j++)
            {
                digitCount[table[i][j]] = digitCount[table[i][j]] + 1;
                countDigits++;
            }
        }
        bool chkOtherDigitsForEven = false;
        bool nonZeroDigitIsEven = false;
        if (digitCount[0] > 1)
        {
            chkOtherDigitsForEven = true;
        }
        bool zeroEvenOtherDigitOdd = false;
        int oddCount = 0;

        for (int i = 0; i <= 9; i++)
        {
            if (!(digitCount[i] % 2 == 0))
            {
                oddCount++;
                if ((digitCount[0] % 2 == 0) && digitCount[i] > 1)
                {
                    zeroEvenOtherDigitOdd = true;
                }
            }
            else if (chkOtherDigitsForEven && i != 0 && digitCount[i]>1)
            {
                nonZeroDigitIsEven = true;
            }
        }
        return countDigits > 1 && oddCount < 2 && ((!chkOtherDigitsForEven) || (chkOtherDigitsForEven && nonZeroDigitIsEven)|| zeroEvenOtherDigitOdd);
    }
}