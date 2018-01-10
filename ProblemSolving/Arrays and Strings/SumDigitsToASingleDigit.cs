using System;

namespace ProblemSolving
{
    //Sum of digits until you return a single digit
    public class SumDigitsToASingleDigit
    {
        public static long GetSum(long n)
        {

            long output = 0;

            if (n > 9)
                output = n % 10 + GetSum(n / 10);
            else
                return n;
            if (output > 9)
            {
                n = output;
                output = GetSum(n);
            }
            return output;

        }

        public static void SumDigitsToASingleDigitMain()
        {
            Console.WriteLine(GetSum(9999999999));
            Console.Read();
        }
    }
}
