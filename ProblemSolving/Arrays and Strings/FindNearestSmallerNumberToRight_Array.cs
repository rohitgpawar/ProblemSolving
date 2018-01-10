using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolving
{
    class FindNearestSmallerNumberToRight_Array
    {
        public static void findNearestSmallToRight(int[] array)
        {
            int[] outputArray = new int[array.Length];
            Stack<int> smallestNumberStack = new Stack<int>();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                while (smallestNumberStack.Count() > 0 && smallestNumberStack.Peek() > array[i])
                {// Bigger number to right remove it.
                    smallestNumberStack.Pop();
                }
                if (smallestNumberStack.Count() == 0)
                {//No Smaller number to right
                    outputArray[i] = array[i];
                }
                else
                {//Smaller number to right found
                    outputArray[i] = array[i]-smallestNumberStack.Peek();
                }

                smallestNumberStack.Push(array[i]);

            }
        }

        //For Quicker Loans Test
        static void finalPrice(int[] prices)
        {
            List<int> nonDiscountedIndices = new List<int>();
            Stack<int> nearestDiscountPrice = new Stack<int>();
            int finalPrice = 0;
            for (int i = prices.Length - 1; i >= 0; i--)
            {
                while (nearestDiscountPrice.Count() > 0 && nearestDiscountPrice.Peek() > prices[i])
                {//Bigger Price so remove it
                    nearestDiscountPrice.Pop();
                }
                if (nearestDiscountPrice.Count() == 0)
                {// No Discount price / no smaller price towards right
                    nonDiscountedIndices.Add(i);
                    finalPrice += prices[i];
                }
                else
                {// Discount price found
                    finalPrice += prices[i] - nearestDiscountPrice.Peek();
                }
                nearestDiscountPrice.Push(prices[i]);
            }
            Console.WriteLine(finalPrice);
            string discountedIndex = string.Empty;
            foreach (int nonDiscountIndex in nonDiscountedIndices.OrderBy(index => index))
            {
                if (string.IsNullOrEmpty(discountedIndex))
                {
                    discountedIndex = nonDiscountIndex.ToString();
                }
                else
                    discountedIndex = discountedIndex + ' ' + nonDiscountIndex.ToString();
            }
            Console.WriteLine(discountedIndex);
        }

        public static void FindNearestSmallerNumberToRight_ArrayMain()
        {
            int[] testArray = new int[8]{ 1,3,5,7,11,13,11,5};
            //findNearestSmallToRight(testArray);
            finalPrice(testArray);

        }
    }
}
