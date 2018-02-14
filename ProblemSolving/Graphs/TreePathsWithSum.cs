/*
 CTCI Q 4.11 pg 77
 Given a sum return paths of tree having the sum.
 */
using System.Collections;

namespace ProblemSolving
{
    public class TreePathsWithSum
    {
        public static void TreePathsWithSumMain()
        {
            TreeNode root = TreeNode.GenerateBinaryTreeWithDepth(5);
            Hashtable sumTable = new Hashtable();
            int totalPaths = GetTreePathsBySum(root, sumTable, 6, 0);
        }

        public static int GetTreePathsBySum(TreeNode node, Hashtable sumTable, int targetSum, int runningSum)
        {
            if (node == null)
                return 0;
            int totalPaths = 0;
            runningSum += node.val;
            int sum = runningSum - targetSum;
            if(sumTable.ContainsKey(sum))
            {// Path exists from sum
                totalPaths += (int)sumTable[sum];
            }

            if (runningSum == targetSum)
            {//path from root
                totalPaths++;
            }
            //Store runnigSum so it can be used by all the childeren of this node.
            MaintainSumHashtable(sumTable, runningSum, 1);
            totalPaths += GetTreePathsBySum(node.left, sumTable, targetSum, runningSum);
            totalPaths += GetTreePathsBySum(node.right, sumTable, targetSum, runningSum);
            //Remove runningSum as all the childrens of current node are visited so this runningSum can no longer be used.
            MaintainSumHashtable(sumTable, runningSum, -1);
            return totalPaths;
        }

        /// <summary>
        /// Maintains hashtable to store sums which are encountered in the ancestors of the current node.
        /// </summary>
        /// <param name="sumTable"></param>
        /// <param name="runningSum"></param>
        /// <param name="incrementBy"></param>
        public static void MaintainSumHashtable(Hashtable sumTable, int runningSum, int incrementBy)
        {
            if(!sumTable.ContainsKey(runningSum))
            {
                sumTable.Add(runningSum, incrementBy);
                return;
            }

            int currentCount = (int)sumTable[runningSum] + incrementBy;
            if(currentCount ==0)
            {
                sumTable.Remove(runningSum);
            }
            else
            {
                sumTable[runningSum] = currentCount;
            }
        }
    }
}
