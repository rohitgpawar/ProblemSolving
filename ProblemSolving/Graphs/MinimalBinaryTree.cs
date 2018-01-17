/*
 * CTCI Q-4.2 Pg-75
 Given an sorted array design a Minimal BinaryTree.
 */

namespace ProblemSolving
{
    public class MinimalBinaryTree
    {
        public static void GetMinimalBinaryTree()
        {
            int[] sortedArray = new int[] {1,2,3,4,5,6,7};
            TreeNode node = CreateMinimalbinaryTree(sortedArray, 0, sortedArray.Length - 1);
        }

        public static TreeNode CreateMinimalbinaryTree(int[] sortedArray, int start, int end)
        {
            if (end < start)
            {
                return null;
            }
            int mid = (end + start) / 2;
            TreeNode node = new TreeNode(sortedArray[mid]);
            node.left = CreateMinimalbinaryTree(sortedArray, start, mid-1);
            node.right = CreateMinimalbinaryTree(sortedArray, mid+1, end);
            return node;
        }
    }
}
