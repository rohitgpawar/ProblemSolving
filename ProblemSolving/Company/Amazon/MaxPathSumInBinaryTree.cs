/*
 Maximum Path Sum in a Binary Tree

Given a binary tree, find the maximum path sum. The path may start and end at any node in the tree.

Example:

Input: Root of below tree
       1
      / \
     2   3
Output: 6

See below diagram for another example.
1+2+3

https://www.geeksforgeeks.org/find-maximum-path-sum-in-a-binary-tree/
 */
using System;

namespace ProblemSolving
{
    public class MaxPathSumInBinaryTree
    {
        public static void MaxPathSumInBinaryTreeMain()
        {
            TreeNode root = TreeNode.GenerateBinaryTreeWithDepth(4);
            int maxSum = GetMaxPathSumInBT(root);
        }

        /// <summary>
        /// Return max Path sum in BT
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int GetMaxPathSumInBT(TreeNode root)
        {
            int maxSum = int.MinValue;
            FindMaxPathSum(root, ref maxSum);
            return maxSum;
        }

        /// <summary>
        /// Find the max sum by computing 4 factors 1. node.val     2. node.val + node.left.val     3. node.val + node.right.val    4. node.val + node.left.val + node.right.val
        /// </summary>
        /// <param name="node"></param>
        /// <param name="maxSum"></param>
        public static int FindMaxPathSum(TreeNode node, ref int maxSum)
        {
            if(node == null)
            {// Base case
                return 0;
            }

            int leftSum = FindMaxPathSum(node.left,ref maxSum);
            int rightSum = FindMaxPathSum(node.right,ref maxSum);

            // Calculate max from left + node.val, right + node.val and node.val
            int chooseSingleMax = Math.Max(Math.Max(leftSum + node.val, rightSum+ node.val), node.val);

            //Choose max between singleMax and node.val + node.left.val+ node.right.val
            maxSum = Math.Max(chooseSingleMax, node.val + leftSum + rightSum);

            return chooseSingleMax;

        }
    }
}
