/*
 Maximum number of chocolates to be distributed equally among k students
4
Given n boxes containing some chocolates arranged in a row. There are k number of students. 
The problem is to distribute maximum number of chocolates equally among k students by selecting a consecutive sequence of boxes from the given lot. 
Consider the boxes are arranged in a row with numbers from 1 to n from left to right. 
We have to select a group of boxes which are in consecutive order that could provide maximum number of chocolates equally to all the k students.
An array arr[] is given representing the row arrangement of the boxes and arr[i] represents number of chocolates in that box at position ‘i’.

Examples:

Input : arr[] = {2, 7, 6, 1, 4, 5}, k = 3
Output : 6
The subarray is {7, 6, 1, 4} with sum 18.
Equal distribution of 18 chocolates among
3 students is 6.
Note that the selected boxes are in consecutive order
with indexes {1, 2, 3, 4}
 */
using ProblemSolving;
using System.Collections;

namespace ProblemSolving
{
    public class DistributeChocolateAmongKStudents
    {
        public static void DistributeChocolateAmongKStudentsMain()
        {
            int maxDistribution = GetMaxDistributionAmongstKStudents(new int[6] { 2, 7, 6, 1, 4, 41 }, 3);
        }
        public static int GetMaxDistributionAmongstKStudents(int[] array, int k)
        {
            int sum = 0;
            int maxDistribution = 0;
            Hashtable storedReminders = new Hashtable(); //Store reminder and the position of the reminder
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
                int reminderAfterKDistributions = sum % k;
                if (reminderAfterKDistributions == 0 && (sum / k) > maxDistribution)
                {// all total chocolates can be distributed equally so update maxDistribution
                    maxDistribution = sum / k;
                }
                else if (storedReminders.ContainsKey(reminderAfterKDistributions))
                {// this sum can be equally distributed if we reduce the sum when we got same reminder.
                    int reminderSum = (int)storedReminders[reminderAfterKDistributions];
                    int currentSum = (sum - reminderSum);
                    if ((currentSum / k) > maxDistribution)
                    {//Update Max
                        maxDistribution = currentSum / k;
                    }
                }
                else
                {
                    storedReminders.Add(reminderAfterKDistributions, sum);
                }
            }
            return maxDistribution;
        }
    }
}
