/*
Stock Buy Sell to Maximize Profit
The cost of a stock on each day is given in an array, find the max profit that you can make by buying and selling in those days. 
For example, if the given array is {100, 180, 260, 310, 40, 535, 695}, the maximum profit can earned by buying on day 0, selling on day 3.
Again buy on day 4 and sell on day 6. If the given array of prices is sorted in decreasing order, then profit cannot be earned at all.
 */

namespace ProblemSolving
{
    public class StockBuySellMaxProfit
    {
        public static void StockBuySellMaxProfitMain()
        {
            int maxProfit = GetMaxProfit(new int[6] { 10, 22, 5, 75, 65, 80 });// { 100, 180, 260, 310, 40, 535, 695 });
        }

        public static int GetMaxProfit(int[] stockPrice)
        {
            int sellPrice = stockPrice.Length-1;
            int totalProfit = 0;
            int localMax = 0;
            for (int i = stockPrice.Length-2; i >= 0; i--)
            {
                if (stockPrice[sellPrice] - stockPrice[i] > localMax)
                {
                    localMax = stockPrice[sellPrice] - stockPrice[i];
                }
                else
                {
                    sellPrice = i;
                    totalProfit += localMax;
                    localMax = 0;
                }
            }

            if(localMax > 0)
                totalProfit += localMax;
            return totalProfit;
        }
    }
}
