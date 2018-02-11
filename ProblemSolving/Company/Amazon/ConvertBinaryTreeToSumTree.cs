/*
 Convert a given tree to its Sum Tree
2.6
Given a Binary Tree where each node has positive and negative values. Convert this to a tree where each 
node contains the sum of the left and right sub trees in the original tree. The values of leaf nodes are changed to 0.

For example, the following tree

                  10
               /      \
            -2        6
           /   \      /  \ 
         8     -4    7    5
should be changed to

              20(4-2+12+6)
               /      \
            4(8-4)      12(7+5)
           /   \      /  \ 
         0      0    0    0
 
 */

namespace ProblemSolving
{
    public class ConvertBinaryTreeToSumTree
    {
        public static void ConvertBinaryTreeToSumTreeMain()
        {
            TreeNode root = TreeNode.GenerateBinaryTreeWithDepth(3);
            ConvertBTToSumTree(root);
        }

        /// <summary>
        /// Converts binary tree to Sum tree
        /// </summary>
        /// <param name="node"></param>
        public static int ConvertBTToSumTree(TreeNode node)
        {
            if(node== null)
            {// Base case
                return 0;
            }

            int leftSum = ConvertBTToSumTree(node.left);
            int rightSum = ConvertBTToSumTree(node.right);

            int oldVal = node.val;

            node.val = leftSum + rightSum;

            return node.val + oldVal;

        }
    }
}
