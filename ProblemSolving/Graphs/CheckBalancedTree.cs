using System;

namespace ProblemSolving
{
    /// <summary>
    /// CTCI Q 4.4 pg-75
    /// Check if the given binary tree is balanced0
    /// </summary>
    public class CheckBalancedTree
    {
        public static void CheckBalancedTreeMain()
        {
            TreeNode rootNode = TreeNode.GenerateTree();
            bool isBalanced = IsTreeBalanced_DFS(rootNode);
        }

        public static bool IsTreeBalanced_DFS(TreeNode rootNode)
        {
            return (CheckTreeHeight(rootNode) != int.MinValue);
        }

        public static int CheckTreeHeight(TreeNode node)
        {
            if (node == null)
                return -1;
            int leftHeight = CheckTreeHeight(node.left);
            if (leftHeight == int.MinValue)
                return int.MinValue;
            int rightHeight = CheckTreeHeight(node.right);
            if (rightHeight == int.MinValue)
                return int.MinValue;
            if (Math.Abs(leftHeight - rightHeight) > 1)
                return int.MinValue;
            else
            {
                return Math.Max(leftHeight, rightHeight) + 1;
            }
        }
    }
}
