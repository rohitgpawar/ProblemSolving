namespace ProblemSolving
{
    /// <summary>
    /// CTCI Q 4.5 pg-75
    /// Find if the given tree is valid Binary Search Tree
    /// </summary>
    public class CheckBinarySearchTree
    {
        public static void CheckBinarySearchTreeMain()
        {
            TreeNode tree = new TreeNode(20);
            tree.AddLeft(new TreeNode(10));
            tree.left.AddRight(new TreeNode(15));
            tree.AddRight(new TreeNode(30));
            bool isBinarySearchTree = IsBinarySearchTree(tree);
        }

        public static bool IsBinarySearchTree(TreeNode node)
        {
            return CheckForBinarySearchTree(node, null, null);
        }

        public static bool CheckForBinarySearchTree(TreeNode node, int? min, int? max )
        {
            if (node == null)
                return true;
            if ((min != null && node.val <= min) || (max != null && node.val > max))
                return false;
            if (!CheckForBinarySearchTree(node.left, min, node.val) || !CheckForBinarySearchTree(node.right, node.val, max))
                return false;
            return true;
        }
    }
}
